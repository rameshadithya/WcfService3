using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WcfService3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public DataSet GetAllData()
        {
            SqlConnection con = new SqlConnection("server=LAPTOP-LDB7QIVH;database=test;Integrated Security=true");
            SqlDataAdapter ada = new SqlDataAdapter("select * from PLAYER", con);
            DataSet ds = new DataSet();
            ada.Fill(ds, "PLAYER");
            return ds;
        }

        

        
        public string InsertDetails(PlayerDetails p)
        {
            string Message;
            SqlConnection con = new SqlConnection("server=LAPTOP-LDB7QIVH;database=test;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into PLAYER(PLRNO,PLRNAME,GAME,COUNTRY) values(@pno,@Pname,@game,@country)", con);
            cmd.Parameters.AddWithValue("@pno", p.pno);
            cmd.Parameters.AddWithValue("@Pname", p.PName);
            cmd.Parameters.AddWithValue("@game", p.Game);
            cmd.Parameters.AddWithValue("@country", p.Country);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = p.PName + " Details inserted successfully";
            }
            else
            {
                Message = p.PName + " Details not inserted successfully";
            }
            con.Close();
            return Message;
        }

        
    }
}
