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

namespace AppWeb
{
    public partial class frmEvaluacion : System.Web.UI.Page
    {
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        UsuarioPerfilDAO objUsuarioPerfilDAO = new UsuarioPerfilDAO();
        //AlertaDAO objAlertaDAO = new AlertaDAO();
        string LoginUsuario = HttpContext.Current.User.Identity.Name;
        EmpleadoDAO objEmpleadoDAO = new EmpleadoDAO();
        List<EmpleadoDTO> obj;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //CargarTreeView();
                //test
                //MenuUsuario();
                //test
                this.lblMensaje.Text = "";
                this.Lista();
            }

        }

        protected void Lista()
        {
            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            List<EmpleadoDTO> obj = objEmpleadoDAO.ListarBusquedaPorJefe(objUsuario.IdUsuario);
            this.gvLista.DataSource = obj;
            this.gvLista.DataBind();

        }
        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

                int IdEmpleado = int.Parse(e.CommandArgument.ToString());
                EmpleadoDTO objEmpleado = objEmpleadoDAO.ListarPorClave(IdEmpleado);
                if (objEmpleado.IdFormato != "")
                {

                    //string strLink = "http://70.38.64.52/WSData/WFEncuestaNew.aspx?IdFormato=5a336346-8f8f-4310-bc6a-9a9647c62b90&CodigoProyecto=14&IdFormatoNemotecnico=RR.HH._%20FORM_41&CodigoIdioma=01&CodigoLocal=1&codigo=IdTest&CodigoGrupoVisita=0&CodigoVisita=0&Visita=Test&Test=1&vCodigoUsuario=00000&vOrganizacion=1&&vRol=2";
                    //string strLink = "http://70.38.64.52/WSData/WFEncuestaNew.aspx";
                    //string strLink = "http://200.62.226.39/WSData/WFEncuestaEdit6R.aspx?IdCabecera=21509&CodigoProyecto=2&Codigo=R0086&IdFormato=73936eab-db52-4176-9594-fbc710592c53&LoginUsuario=umovil&FechaDeVisita=18/03/2015&IdFormatoNemotecnico=CASI_A1_V1&CodigoGrupoVisita=3&CodigoVisita=12&Visita=VisitaInicial&Ruta=";


                    string strLink = "http://200.62.226.39/WSData/WFEncuestaEdit6R.aspx";
                    //strLink += "?IdFormato=5a336346-8f8f-4310-bc6a-9a9647c62b90";
                    strLink += "?IdFormato=" + objEmpleado.IdFormato;
                    strLink += "&CodigoProyecto=14";
                    strLink += "&IdFormatoNemotecnico=RR.HH._%20FORM_41";
                    strLink += "&CodigoIdioma=01";
                    strLink += "&CodigoLocal=1";
                    strLink += "&codigo=" + objEmpleado.CodigoEmpleado;
                    strLink += "&CodigoGrupoVisita=0";
                    strLink += "&CodigoVisita=0";
                    strLink += "&Visita=Test";
                    strLink += "&Test=1";
                    strLink += "&vCodigoUsuario=00000";
                    strLink += "&vOrganizacion=1";
                    strLink += "&&vRol=2";
                    strLink += "&vEvaluador=" + objUsuario.NombreUsuario;
                    strLink += "&vEmpleado=" + objEmpleado.Nombre;

                    this.panLista.Visible = false;

                    Response.Redirect(strLink);
                }
                else
                {
                    this.lblMensaje.Text = "Empleado no tiene asignado Formato de Evaluacion";
                }
            }
        }

        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvLista.PageIndex = e.NewPageIndex;
            Lista();
        }
    }

}