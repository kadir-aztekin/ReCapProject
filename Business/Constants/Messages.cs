using Core.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string CarAdded = "Araba Eklendi";
        public static string CarNotAdded = "Araba Eklenemedi";
        public static string CarDeleted = "Araba Silindi";
        public static string MainintenanceTime = "Sistem Bakımda";
        public static string ProductsListed= "Ürünler Listelendi";
        public  static string CarUpdate = "Araba Güncellendi";
        public static string BrandUptaded = "Marka Güncellendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandNotAdded = "Marka Kaydedilmedi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated="Renk Güncellendi";
        public static string ColorAdded= "Renk Eklendi";
        public static string CustomerDeleted = "Musteri Silindi";
        public static string CustomerUpdated = "Musteri Guncellendi";
        public static string CustomersListed = "Musteriler Listelendi";
        public static object CustomersCompanyListed = "Musteri Şirket Listelendi";
        public static string CustomerAdded = "Musteri Eklendi";
        public static string ResultAdded = "Sonuclar Eklendi";
        public static string ResultUptaded = "Sonuclar Guncellendi";
        public static string ResultDeleted = "Sonuclar Slindi";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string RentalAddedError = "Eklenmedi";
        public static string RentalAdded = "Eklendi";
        public static string CustomerNotAdded = "Kullanıcı Eklenemedi";
        public static string NotDeleted = "Silinemedi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Yanlıs ";
        public static string SucessFulLogin = "Sisteme Giriş Başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegisterd = "Kullanıcı Başarıyla Kaydedildi";
        public static string AccessTokenCreate = "Access Token Başarıyla Olusturuldu ";
        public static string AuthorizationDenied = "Yetkiniz Yok";
    }
}
