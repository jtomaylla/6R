using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using pe.com.sil.dal.dao;
using pe.com.rbtec.web;
using AppWeb.Reporte;

namespace AppWeb
{
    public partial class frmEmpSinEval : System.Web.UI.Page
    {
        ListadoEmpSinEvalDAO objListado = new ListadoEmpSinEvalDAO();
        string CodigoUnidad;
        string FechaIni;
        string FechaFin;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //InicializaPagina();
            }
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            CodigoUnidad = Request["CodigoUnidad"];
            FechaIni = Request["FechaIni"];
            FechaFin = Request["FechaFin"]; 
            DataTable dt = objListado.ListarTodos(
                int.Parse(CodigoUnidad),
                AppUtilidad.stringToDateTime(FechaIni, "DD/MM/YYYY"),
                AppUtilidad.stringToDateTime(FechaFin, "DD/MM/YYYY"));

            CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
            myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string strRuta = Server.MapPath("rptEmpSinEval1.rpt");
            myReportDocument.Load(strRuta);
            myReportDocument.SetDataSource(dt);
            myReportDocument.SetParameterValue("FechaIni", AppUtilidad.stringToDateTime(FechaIni, "DD/MM/YYYY"));
            myReportDocument.SetParameterValue("FechaFin", AppUtilidad.stringToDateTime(FechaFin, "DD/MM/YYYY"));

            myReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Listado");
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            CodigoUnidad = Request["CodigoUnidad"];
            FechaIni = Request["FechaIni"];
            FechaFin = Request["FechaFin"]; 
            DataTable dt = objListado.ListarTodos(
                int.Parse(CodigoUnidad),
                AppUtilidad.stringToDateTime(FechaIni, "DD/MM/YYYY"),
                AppUtilidad.stringToDateTime(FechaFin, "DD/MM/YYYY"));

            CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
            myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string strRuta = Server.MapPath("rptEmpSinEval1.rpt");
            myReportDocument.Load(strRuta);
            myReportDocument.SetDataSource(dt);
            myReportDocument.SetParameterValue("FechaIni", AppUtilidad.stringToDateTime(FechaIni, "DD/MM/YYYY"));
            myReportDocument.SetParameterValue("FechaFin", AppUtilidad.stringToDateTime(FechaFin, "DD/MM/YYYY"));

            myReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, "Listado");
        }

    }
}