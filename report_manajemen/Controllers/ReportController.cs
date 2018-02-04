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
       
    }
}