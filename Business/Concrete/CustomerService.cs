using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public List<Customer> GetCustomersByInitial(string initial)
        {
            return _customerDal.GetAll().Where(x => x.FirstName.ToLower().StartsWith(initial.ToLower())).ToList();
        }
    }
}
