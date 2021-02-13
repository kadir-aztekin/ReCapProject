using Core.Utilities.Results;
using Entities.Concrete;
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
        IDataResult<List<User>> GetByEmail(string email);


    }
}
