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

        //------------------------- Laporan Aging Hutang -------------------------------

        public DataSet LaporanAgingHutang(string SupplierName)
        {
            try
            {
                BonaDataset ds = new BonaDataset();
                string query = @"SELECT TOP 1000 [Tgl Trans]
                              ,[Partner ID]
                              ,[Tipe Invoice]
                              ,[Supplier]
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
                              FROM [CosmicDB_Cargo].[dbo].[vw_rpt_partner_aging_hutang] where Supplier = '" + SupplierName + "'";
                ds = GetDataSet(query, "aging_hutang");
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //------------------------- Laporan Aging Piutang -------------------------------

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

        //------------------------- Laporan Aging Piutang Rekap -------------------------------

        public DataSet LaporanAgingPiutangRekap(string Periode, string customerName)
        {
            try
            {
                BonaDataset ds = new BonaDataset();
                string query = @"SELECT TOP 1000 [Tgl Trans]
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
                              ,[current_year]
                              ,[begin_date]
                              ,[end_date]
                              ,[Periode]
                              FROM [CosmicDB_Cargo].[dbo].[vw_rpt_partner_aging_piutang_rekap_period] where Periode = '" + Periode + "' and Customer = '" + customerName + "'";
                ds = GetDataSet(query, "aging_piutang_rekap");
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // ------------- Laporan Bukti Kas Keluar ----------------------------------

        public DataSet LaporanBuktiKasKeluar(string txtNoBukti)
        {
            try
            {
                BonaDataset ds = new BonaDataset();
                string query = @"SELECT [Tanggal Bukti]
                                  ,[No Bukti]
                                  ,[Kode Kas]
                                  ,[Nama Kas]
                                  ,[No Akun]
                                  ,[Nama Akun]
                                  ,[Keterangan2]
                                  ,[Doc Reff]
                                  ,[Debet]
                                  ,[Periode]
                                  ,[Keterangan]
                                  ,[project_id]
                                  ,[project_name]
                                  FROM [CosmicDB_Cargo].[dbo].[Bukti BKK] 
                                  where [No Bukti] = '" + txtNoBukti + "'";
                ds = GetDataSet(query, "bukti_kas_keluar");
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }



        // ------------- Laporan Bukti Kas Masuk ----------------------------------

        public DataSet LaporanBuktiKasMasuk(string txtNoBukti)
        {
            try
            {
                BonaDataset ds = new BonaDataset();
                string query = @"SELECT TOP 1000 [Tanggal Bukti]
                                      ,[No Bukti]
                                      ,[Kode Kas]
                                      ,[Nama Kas]
                                      ,[No Akun]
                                      ,[Nama Akun]
                                      ,[Keterangan2]
                                      ,[Doc Reff]
                                      ,[Debet]
                                      ,[Periode]
                                      ,[Keterangan]
                                      ,[project_id]
                                      ,[project_name]
                                  FROM [CosmicDB_Cargo].[dbo].[Bukti BKM]
                                  where [No Bukti] = '" + txtNoBukti + "'";
                ds = GetDataSet(query, "bukti_kas_masuk");
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