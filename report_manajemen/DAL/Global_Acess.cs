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
        public static BonaDataset GetDataSet(string pQuery,string dt, int pTimeOut = 30)
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
                        da.Fill(dsa,dt);
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
        public DataSet LaporanPerkiraan()
        {
            try
            {
                BonaDataset ds = new BonaDataset();
                string query = @"SELECT NoAccount AS [Kode Akun], AccountName AS [Nama Akun], Type AS [Tipe Akun], [Group] AS [Grup Akun], GroupAccount
                                    FROM    dbo.GLAccount";
                ds= GetDataSet(query, "Laporan_Perkiraan");
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet LaporanAgingPiutang(string customerName)
        {
            try
            {
                BonaDataset ds = new BonaDataset();
                string query = @"SELECT [Tgl Trans]
                                          ,[Partner ID]
                                          ,[Tipe Invoice]
                                          ,[Customer]
                                          ,[No Bukti]
                                          ,[No Ref]
                                          ,[Tipe Partner]
                                          ,[Harga]
                                          ,[Tgl Jatuh Tempo]
                                          ,[TypeTrans]
                                          ,[term_days]
                                          ,[reminder_days]
                                          ,[Batas Bayar]
                                          ,[Reminder Bayar]
                                          ,[DateTrans]
                                          ,[no_invoice]
                                          ,[no_kwitansi]
                                          FROM [CosmicDB_Cargo].[dbo].[vw_rpt_partner_aging_piutang] where Customer = '" + customerName + "'";
                ds = GetDataSet(query, "aging_piutang");
                return ds;
            }
            catch (Exception)
            {

                throw;
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