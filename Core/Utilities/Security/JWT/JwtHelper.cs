using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }  //APİ DEKİ TOKENOPTİONDAKİ DEĞERLERI OKUMAYA  YARAR  
        private TokenOptions _tokenOptions; //APİDE DEKI BILGILER VE BİZ BU METHODU TANIMLADIK CLASS OLARAK 
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration) //APİDEKİ TOKENOPTİONSU OKU ESLESTİR DEMEK 
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //benim değerlerım confıguration dakı alanı al ve Tokenoptions classına eşitle veya at 
            //CONFIGURATİON DEDIGMIZDE AKLIMIZA DIREK TOKENOPTİONS GELSIN 
            // GET SECTİON DEDIGIMIZDE AKLIMIZA DIREK APPSETTİNG İÇİNDEKİLER GELMELİ 
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims) //TOKEN OLUSTURMA 
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); //APİDEKİ TOKENN OPTİONDAKİ BİLGİYİ OKU EŞLEŞTİR DEMEK 
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //TOKENN OPTİONSAKİ BİLGİYİ OKU VE BENIM SECURİTYKEY CLASSIMA  EŞLEŞTİR DEMEK
             var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);  //HANGİ ALGORİTMAYI OKUYACAK BIZ ONU ZATEN ENCRYPTİON DA TANIMLADIK 
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims); //(APİDEKİ BİLGİLER , CLAİMLERİNİ VER) aşağıda methodda tanımlamısım 
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,                           //APİDEKİ TOKENOPTİONSLARI KULLANARAK BIZ BURDA JWT OLUSTURUYORUZ 
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now, //eğer tokun experition bilgisi suandan onceyse yani şart
                claims: SetClaims(user, operationClaims),  //user sınıfının ıcersınde ad soyad mail ... onları burda tanımlamak yerıne kısaca alt tarafta tanımladım 
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims) //YETKİLER VE BİLGİLER  //EXTENSİONS DA BIZ TANIMLADIK METHODLARI KISACA BURDA EKLEYEBİLİYORUZ 
        {
            var claims = new List<Claim>();  
            
            claims.AddNameIdentifier(user.Id.ToString());   //KULLANICI ID
            claims.AddEmail(user.Email); //KULLANICI MAİL
            claims.AddName($"{user.FirstName} {user.LastName}"); //DOLAR KULLANIMI 2 STRİNG YANYANA KULLANMAK ICIN KULLANILIR 
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());  //VERİTABANINDA CEKTIGMIZ CLAIMLERINI (ROLLER) NAMELERINI AREYE ATAYIP ROLLERINI CEKIYORUZ 

            return claims;
        }
    }
}
