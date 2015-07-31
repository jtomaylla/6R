using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;
using pe.com.sil.dal.dao;
using pe.com.sil.dal.dto;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using AppWeb.Seguridad;
using pe.com.rbtec.web;

namespace AppWeb
{
    public partial class frmFormato : System.Web.UI.Page
    {
        //UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        //UsuarioPerfilDAO objUsuarioPerfilDAO = new UsuarioPerfilDAO();
        //string LoginUsuario = HttpContext.Current.User.Identity.Name;
        //EmpleadoDAO objEmpleadoDAO = new EmpleadoDAO();
        FormatoDAO objFormatoDAO = new FormatoDAO();
        //List<Formato6DTO> obj;
        string codigo;
        string nombreemp;

        //
        protected void Page_Load(object sender, EventArgs e)
        {
            codigo = Request["Codigo"];
            nombreemp = Request["Nombre"];
            if (!Page.IsPostBack)
            {
                //this.lblMensaje.Text = "";
                this.panLista.Visible = true;
                this.Lista();
            }

        }

        protected void Lista()
        {

            List<FormatoDTO> obj = objFormatoDAO.ListarTodos();
            
            this.gvLista.DataSource = obj;
            this.gvLista.DataBind();

        }
        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            String IdFormato = e.CommandArgument.ToString();

            //string strLink = "http://200.62.226.39/WSData/WFEncuestaEdit6R.aspx?IdCabecera=21509&CodigoProyecto=2&Codigo=R0086&IdFormato=73936eab-db52-4176-9594-fbc710592c53&LoginUsuario=umovil&FechaDeVisita=18/03/2015&IdFormatoNemotecnico=CASI_A1_V1&CodigoGrupoVisita=3&CodigoVisita=12&Visita=VisitaInicial&Ruta=";
            var appSettings = ConfigurationManager.AppSettings;
            string linkPagData = appSettings["LinkPagData"];

            string strLink = linkPagData + "/WFEncuestaEdit6R.aspx";

            //string strLink = "http://200.62.226.39/WSData/WFEncuestaEdit6R.aspx";

                strLink += "?IdCabecera=" + "99999";
                strLink += "&CodigoProyecto=14";
                strLink += "&codigo=" + "999";
                strLink += "&IdFormato=" + IdFormato;
                strLink += "&LoginUsuario=admin";
                strLink += "&IdFormatoNemotecnico=RR.HH._FORM_99";
                strLink += "&FechaDeVisita=" + "01/01/2050";
                strLink += "&CodigoGrupoVisita=0";
                strLink += "&CodigoVisita=0";
                strLink += "&Visita=Test";
                strLink += "&Ruta=1";
                strLink += "&vCodigoUsuario=00000";
                strLink += "&vOrganizacion=1";
                strLink += "&vRol=2";
                strLink += "&vEvaluador=" + "EVAL";
                strLink += "&vEmpleado=" + "EMPL";

                if (e.CommandName == "Seleccionar")
                {
                    this.panLista.Visible = false;
                    Response.Redirect(strLink);
                }
        }
        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvLista.PageIndex = e.NewPageIndex;
            Lista();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<FormatoDTO> obj;
            try
            {
                string strBusqueda = txtBusqueda.Text;
                obj = objFormatoDAO.ListarPorNombre(strBusqueda);
                this.gvLista.DataSource = obj;
                this.gvLista.DataBind();
            }
            catch (Exception err)
            {
                throw (err);
            }
        }
    }
 
}