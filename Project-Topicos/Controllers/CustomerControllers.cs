using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using System.Data;

namespace Controller
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CustomerControllers : ICustomerControllers
    {
        CustomerModel cm = new CustomerModel();

        public DataTable ListCustomers() {
            try
            {
                return cm.ListCustomer();
            }
            catch (Exception ex)
            {          
                throw ex;
            }
        }

        public DataTable ListCustomers_Country(String Country)
        {
            try
            {
                return cm.ListCustomer_Country(Country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListCustomers_Province(String Province)
        {
            try
            {
                return cm.ListCustomer_Province(Province);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListCustomers_City(String City)
        {
            try
            {
                return cm.ListCustomer_City(City);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListCountries()
        {
            try
            {
                return cm.ListCountries();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListProvinces()
        {
            try
            {
                return cm.ListProvinces();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListCities()
        {
            try
            {
                return cm.ListCities();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
