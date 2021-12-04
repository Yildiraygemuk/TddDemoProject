using DataAccess;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
    [TestClass]
    public class CustomerManagerTests
    {
        Mock<ICustomerDal> _mockCustomerDal;
        List<Customer> _dbCustomers;
        [TestInitialize]
        public void Start()
        {
            _mockCustomerDal = new Mock<ICustomerDal>();
            //ilerideki testlerde data silme testleri olma ihtimaline karşı her seferinde yeniden oluşturuyoruz.
            _dbCustomers = new List<Customer>
            {
                new Customer{Id=1,FirstName = "Ali"},
                new Customer{Id=2,FirstName = "Ayşe"},
                new Customer{Id=3,FirstName = "Ahmet"},
                new Customer{Id=4,FirstName = "Aydın"},
                new Customer{Id=5,FirstName = "Beril"}
            };
            _mockCustomerDal.Setup(x => x.GetAll()).Returns(_dbCustomers);
        }
        [TestMethod]
        public void All_Customers_List()
        {
            //Arrange
            ICustomerService customerService = new CustomerService(_mockCustomerDal.Object);
            //Act
            List<Customer> customers= customerService.GetAll();
            //Assert
            Assert.AreEqual(5, customers.Count);
        }
        [TestMethod]
        public void Starting_With_A()
        {
            //Arrange
            ICustomerService customerService = new CustomerService(_mockCustomerDal.Object);
            //Act
            List<Customer> customers = customerService.GetCustomersByInitial("b");
            //Assert
            Assert.AreEqual(1, customers.Count);
        }
    }
}

//Müşteriler listelenebilmelidir
//Müşteriler baş harflerine göre sayfalanabilmelidir

//Test Case
//5 elemanlı bir listem olsun