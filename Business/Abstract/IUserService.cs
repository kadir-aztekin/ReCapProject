
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetByLastName(string lastname);
        IDataResult<List<User>> GetByFırstName(string fırstname);
        

        List<OperationClaim> GetClaims(User user);

        User GetByMail(string email);


        IResult AddTransactionalTest(User user);

    }
}
