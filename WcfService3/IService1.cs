using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace WcfService3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        DataSet GetAllData();

        [OperationContract]
        string InsertDetails(PlayerDetails p);

        /*[OperationContract]
        DataSet SearchPlayerDetails(PlayerDetails PlayerInfo);*/

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class PlayerDetails
    {
        int Pno;
        string plrname;
        string game;
        string country;

        [DataMember]
        public int pno
        {
            get { return Pno; }
            set { Pno = value; }
        }
        [DataMember]
        public string PName
        {
            get { return plrname; }
            set { plrname = value; }
        }
        [DataMember]
        public string Game
        {
            get { return game; }
            set { game = value; }
        }
        [DataMember]
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

    }
}
