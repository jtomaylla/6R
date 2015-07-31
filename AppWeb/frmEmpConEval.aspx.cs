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
    public partial class frmEmpConEval : System.Web.UI.Page
    {
        ListadoEmpConEvalDAO objListado = new ListadoEmpConEvalDAO();
        string CodigoUnidad;
        string FechaIni;
        string FechaFin;
        protected void Page_Load(object sender, EventArgs e)
        {
            CodigoUnidad = Request["CodigoUnidad"];
            FechaIni = Request["FechaIni"];
            FechaFin = Request["FechaFin"];
            if (!Page.IsPostBack)
            {
                //InicializaPagina();
            }
        }
        protected void InicializaPagina()
        {

            CodigoUnidad = Request["CodigoUnidad"];
            FechaIni = Request["FechaIni"];
            FechaFin = Request["FechaFin"];

            DataTable dt = objListado.ListarTodos(
                int.Parse(CodigoUnidad),
                AppUtilidad.stringToDateTime(FechaIni, "DD/MM/YYYY"),
                AppUtilidad.stringToDateTime(FechaFin, "DD/MM/YYYY"));

            //dsRepEvaluacion dsEmpConEval = new dsRepEvaluacion();
            CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
            myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string strRuta = Server.MapPath("rptEmpConEval1.rpt");
            myReportDocument.Load(strRuta);
            myReportDocument.SetDataSource(dt);
            //myReportDocument.SetParameterValue("FechaIni", AppUtilidad.stringToDateTime(FechaIni, "DD/MM/YYYY"));
            //myReportDocument.SetParameterValue("FechaFin", AppUtilidad.stringToDateTime(FechaFin, "DD/MM/YYYY"));
            myReportDocument.SetParameterValue("FechaIni", FechaIni);
            myReportDocument.SetParameterValue("FechaFin", FechaFin);

            Session.Add("ReporteCrystal", myReportDocument);
            Session.Add("FormatoReporte", "PDF");

            MemoryStream stream = new MemoryStream();
            stream = (MemoryStream)myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            Response.ContentType = "application/pdf";

            myReportDocument.Close();
            myReportDocument.Dispose();

            Response.Clear();
            Response.Buffer = true;

            Response.BinaryWrite(stream.ToArray());
            Response.End();

            stream.Flush();
            stream.Close();
            stream.Dispose();
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
            string strRuta = Server.MapPath("rptEmpConEval1.rpt");
            myReportDocument.Load(strRuta);
            myReportDocument.SetDataSource(dt);
            //myReportDocument.SetParameterValue("FechaIni", AppUtilidad.stringToDateTime(FechaIni, "DD/MM/YYYY"));
            //myReportDocument.SetParameterValue("FechaFin", AppUtilidad.stringToDateTime(FechaFin, "DD/MM/YYYY"));
            myReportDocument.SetParameterValue("FechaIni", FechaIni);
            myReportDocument.SetParameterValue("FechaFin", FechaFin);
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
            string strRuta = Server.MapPath("rptEmpConEval1.rpt");
            myReportDocument.Load(strRuta);
            myReportDocument.SetDataSource(dt);
            //myReportDocument.SetParameterValue("FechaIni", AppUtilidad.stringToDateTime(FechaIni, "DD/MM/YYYY"));
            //myReportDocument.SetParameterValue("FechaFin", AppUtilidad.stringToDateTime(FechaFin, "DD/MM/YYYY"));
            myReportDocument.SetParameterValue("FechaIni", FechaIni);
            myReportDocument.SetParameterValue("FechaFin", FechaFin);
            myReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, "Listado");
        }

    }
}