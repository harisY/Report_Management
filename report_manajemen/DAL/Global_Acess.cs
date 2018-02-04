using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using report_manajemen.Dataset;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace report_manajemen.DAL
{
    public class Global_Acess
    {
        private SqlConnection con;
        public static TransactionHelper gh_Trans;
        private static string Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            return constr;
            //con = new SqlConnection(constr);

        }
        public static BonaDataset GetDataSet(string pQuery, int pTimeOut = 30)
        {
            SqlDataAdapter da = null;
            BonaDataset dsa = new BonaDataset();
            try
            {
                if (gh_Trans != null && gh_Trans.Command != null)
                {
                    gh_Trans.Command.CommandType = CommandType.Text;
                    gh_Trans.Command.CommandText = pQuery;
                    gh_Trans.Command.CommandTimeout = pTimeOut;
                    da = new SqlDataAdapter(gh_Trans.Command);
                    da.Fill(dsa);
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = Connection();
                        conn.Open();
                        da = new SqlDataAdapter(pQuery, conn);
                        da.Fill(dsa);
                    }
                }
                da = null;
                return dsa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public class TransactionHelper
    {
        SqlCommand _Cmd = new SqlCommand();
        public SqlCommand Command
        {
            get { return _Cmd; }
            set { _Cmd = value; }
        }
    }
}