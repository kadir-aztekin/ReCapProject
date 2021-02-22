using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            ValidationTool.Validate(new CustomerValidator(), customer);
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(int customerId )
        {
           var result=  _customerDal.Get(c => c.Id == customerId);
            if (result==null)
            {
                return new ErrorResult(Messages.NotDeleted);
            }

            _customerDal.Delete(result);
            return new SuccessResult(Messages.CustomerDeleted);

            
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return  new SuccessDataResult<List<Customer>>(_customerDal.GetAll() ,Messages.CustomersListed);
        }

        public IDataResult<List<Customer>> GetByCompanyName(string companyname)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.CompanyName == companyname));
        }

        public IDataResult<Customer> GetUserId(int userıd)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == userıd));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
