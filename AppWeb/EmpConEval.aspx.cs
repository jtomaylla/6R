using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using pe.com.sil.dal.dto;
using Microsoft.Practices.EnterpriseLibrary.Data;
using pe.com.rbtec.web;
using AppWeb.Reporte;

namespace pe.com.sil.dal.dao
{
    public partial class EmpConEval1 : System.Web.UI.Page
    {
        ListadoEmpConEvalDAO objListado = new ListadoEmpConEvalDAO();
        string CodigoUnidad;
        string FechaInicio;
        string FechaFin;
        protected void Page_Load(object sender, EventArgs e)
        {
            CodigoUnidad = Request["Codigo"];
            FechaInicio = Request["FechaInicio"];
            FechaFin = Request["FechaFin"];
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {

            //myReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, "Listado");
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {

            dsRepEvaluacion dsEmpConEval = new dsRepEvaluacion();
            CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
            myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string strRuta = Server.MapPath("rptEmpConEval.rpt");
            myReportDocument.Load(strRuta);

            DataTable dt = objListado.ListarTodos(
                int.Parse(CodigoUnidad),
                AppUtilidad.stringToDateTime(FechaInicio, "DD/MM/YYYY"),
                AppUtilidad.stringToDateTime(FechaFin, "DD/MM/YYYY"));

            myReportDocument.SetDataSource(dt);

            myReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Listado");
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
            myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string strRuta = Server.MapPath("rptEmpConEval.rpt");
            myReportDocument.Load(strRuta);

            DataTable dt = objListado.ListarTodos(
                int.Parse(CodigoUnidad),
                AppUtilidad.stringToDateTime(FechaInicio, "DD/MM/YYYY"),
                AppUtilidad.stringToDateTime(FechaFin, "DD/MM/YYYY"));

            myReportDocument.SetDataSource(dt);

            myReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, "Listado");
        }

    }
}