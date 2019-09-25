using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AllPatientsWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetQuery();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class GetQuery
    {

        [DataMember]
        public bool BoolValue
        {get; set;}
        }
    }

