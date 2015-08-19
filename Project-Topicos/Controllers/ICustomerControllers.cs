using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Controller
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICustomerControllers
    {
        [OperationContract]
        DataTable ListCustomers();

        [OperationContract]
        DataTable ListCustomers_Country(String Country);

        [OperationContract]
        DataTable ListCustomers_Province(String Province);

        [OperationContract]
        DataTable ListCustomers_City(String City);

        [OperationContract]
        DataTable ListCountries();

        [OperationContract]
        DataTable ListProvinces();

        [OperationContract]
        DataTable ListCities();
    }

}
