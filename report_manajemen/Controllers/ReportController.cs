using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using report_manajemen.DAL;

namespace report_manajemen.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult test()
        {
            return View();
        }

        public ActionResult IndexLaporanPerkiraan()
        {
            return View();
        }

        [HttpPost]
        public void ShowLaporanPerkiraan(string txtFromDate, string txtToDate)
        {
            Global_Acess global = new Global_Acess();
            // Setting session for generating report
            this.HttpContext.Session["ReportName"] = "LaporanPerkiraan.rpt";
            //this.HttpContext.Session["rptFromDate"] = txtFromDate;
            //this.HttpContext.Session["rptToDate"] = txtToDate;
            this.HttpContext.Session["rptSource"] = global.LaporanPerkiraan();
            // Redirecting generic report viewer page from action
            Response.Redirect("~/WebForm/frmLaporanPerkiraan.aspx");

        }

        //------------------------- Laporan Aging Hutang -------------------------------

        public ActionResult IndexLaporanAgingHutang()
        {
            return View();
        }

        [HttpPost]
        public void ShowLaporanAgingHutang(string txtSupplierName)
        {
            Global_Acess global = new Global_Acess();
            // Setting session for generating report
            this.HttpContext.Session["ReportName"] = "AgingHutang.rpt";
            this.HttpContext.Session["rptSupplierName"] = txtSupplierName;
            //this.HttpContext.Session["rptToDate"] = txtToDate;
            this.HttpContext.Session["rptSource"] = global.LaporanAgingHutang(txtSupplierName);
            // Redirecting generic report viewer page from action
            Response.Redirect("~/WebForm/frmLaporanAgingHutang.aspx");

        }

        //------------------------- Laporan Aging Piutang -------------------------------

        public ActionResult IndexLaporanAgingPiutang()
        {
            return View();
        }

        [HttpPost]
        public void ShowLaporanAgingPiutang(string txtCustomerName)
        {
            Global_Acess global = new Global_Acess();
            // Setting session for generating report
            this.HttpContext.Session["ReportName"] = "AgingPiutang.rpt";
            this.HttpContext.Session["rptCustomerName"] = txtCustomerName;
            //this.HttpContext.Session["rptToDate"] = txtToDate;
            this.HttpContext.Session["rptSource"] = global.LaporanAgingPiutang(txtCustomerName);
            // Redirecting generic report viewer page from action
            Response.Redirect("~/WebForm/frmLaporanAgingPiutang.aspx");

        }

        //------------------------- Laporan Aging Piutang Rekap -------------------------------

        public ActionResult IndexLaporanAgingPiutangRekap()
        {
            return View();
        }

        [HttpPost]
        public void ShowLaporanAgingPiutangRekap(string txtPeriode, string txtCustomerName)
        {
            Global_Acess global = new Global_Acess();
            // Setting session for generating report
            this.HttpContext.Session["ReportName"] = "AgingPiutangRekap.rpt";
            this.HttpContext.Session["rptPeriode"] = txtPeriode;
            this.HttpContext.Session["rptCustomerName"] = txtCustomerName;
            //this.HttpContext.Session["rptToDate"] = txtToDate;
            this.HttpContext.Session["rptSource"] = global.LaporanAgingPiutangRekap(txtPeriode,txtCustomerName);
            // Redirecting generic report viewer page from action
            Response.Redirect("~/WebForm/frmLaporanAgingPiutangRekap.aspx");

        }


        //------------------------- Bukti Kas Keluar -------------------------------

        public ActionResult IndexLaporanBuktiKasKeluar()
        {
            return View();
        }


        [HttpPost]
        public void ShowLaporanBuktiKasKeluar(string txtNoBukti)
        {
            Global_Acess global = new Global_Acess();
            // Setting session for generating report
            this.HttpContext.Session["ReportName"] = "BuktiKasKeluar.rpt";
            this.HttpContext.Session["rptNoBukti"] = txtNoBukti;
            //this.HttpContext.Session["rptToDate"] = txtToDate;
            this.HttpContext.Session["rptSource"] = global.LaporanBuktiKasKeluar(txtNoBukti);
            // Redirecting generic report viewer page from action
            Response.Redirect("~/WebForm/frmLaporanBuktiKasKeluar.aspx");

        }


        //------------------------- Bukti Kas Masuk -------------------------------

        public ActionResult IndexLaporanBuktiKasMasuk()
        {
            return View();
        }


        [HttpPost]
        public void ShowLaporanBuktiKasMasuk(string txtNoBukti)
        {
            Global_Acess global = new Global_Acess();
            // Setting session for generating report
            this.HttpContext.Session["ReportName"] = "BuktiKasMasuk.rpt";
            this.HttpContext.Session["rptNoBukti"] = txtNoBukti;
            //this.HttpContext.Session["rptToDate"] = txtToDate;
            this.HttpContext.Session["rptSource"] = global.LaporanBuktiKasMasuk(txtNoBukti);
            // Redirecting generic report viewer page from action
            Response.Redirect("~/WebForm/frmLaporanBuktiKasMasuk.aspx");

        }


    }
}