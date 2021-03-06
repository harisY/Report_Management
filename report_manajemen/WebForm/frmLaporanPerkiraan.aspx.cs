﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using report_manajemen.DAL;
using report_manajemen.Report;

namespace report_manajemen.WebForm
{
    public partial class frmLaporanPerkiraan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
            //LaporanPerkiraan crystalReport = new LaporanPerkiraan();
            //DataSet ds = new DataSet();
            //Global_Acess repo = new Global_Acess();
            //ds = repo.LaporanPerkiraan();
            //crystalReport.SetDataSource(ds);
            //CrystalReportViewer1.ReportSource = crystalReport;
            //CrystalReportViewer1.RefreshReport();
            try
            {
                bool isValid = true;

                // Setting ReportName
                string strReportName = System.Web.HttpContext.Current.Session["ReportName"].ToString();
                // Setting Report Data Source     
                var rptSource = System.Web.HttpContext.Current.Session["rptSource"];

                if (string.IsNullOrEmpty(strReportName)) // Checking is Report name provided or not
                {
                    isValid = false;
                }


                if (isValid) // If Report Name provided then do other operation
                {
                    ReportDocument rd = new ReportDocument();
                    string strRptPath = Server.MapPath("~/") + "Report//" + strReportName;
                    //Loading Report
                    rd.Load(strRptPath);

                    // Setting report data source
                    if (rptSource != null && rptSource.GetType().ToString() != "System.String")
                        rd.SetDataSource(rptSource);

                    //if (!string.IsNullOrEmpty(strFromDate))
                    //    rd.SetParameterValue("fromDate", strFromDate);
                    //if (!string.IsNullOrEmpty(strToDate))
                    //    rd.SetParameterValue("toDate", strFromDate);
                    CrystalReportViewer1.ReportSource = rd;


                    Session["ReportName"] = "";
                    Session["rptFromDate"] = "";
                    Session["rptToDate"] = "";
                    Session["rptSource"] = "";
                }
                else
                {
                    Response.Write("<H2>Nothing Found; No Report name found</H2>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}