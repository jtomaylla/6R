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

namespace AppWeb
{
    public partial class frmEvaluacion : System.Web.UI.Page
    {
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        UsuarioPerfilDAO objUsuarioPerfilDAO = new UsuarioPerfilDAO();
        //AlertaDAO objAlertaDAO = new AlertaDAO();
        string LoginUsuario = HttpContext.Current.User.Identity.Name;
        EmpleadoDAO objEmpleadoDAO = new EmpleadoDAO();
        Formato6DAO objFormato6DAO = new Formato6DAO();
        //List<Formato6DTO> obj;
        string codigo;

        protected void Page_Load(object sender, EventArgs e)
        {
            codigo = Request["Codigo"];
            if (!Page.IsPostBack)
            {
                this.lblMensaje.Text = "";

                this.Lista(codigo);
            }

        }

        protected void Lista(string Codigo)
        {
            //string LoginUsuario = HttpContext.Current.User.Identity.Name;
            //UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            List<Formato6DTO> obj = objFormato6DAO.ListarPorCodigo(Codigo);
            
            this.gvLista.DataSource = obj;
            this.gvLista.DataBind();

        }
        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //string strLink = "http://200.62.226.39/WSData/WFEncuestaEdit6R.aspx?IdCabecera=21509&CodigoProyecto=2&Codigo=R0086&IdFormato=73936eab-db52-4176-9594-fbc710592c53&LoginUsuario=umovil&FechaDeVisita=18/03/2015&IdFormatoNemotecnico=CASI_A1_V1&CodigoGrupoVisita=3&CodigoVisita=12&Visita=VisitaInicial&Ruta=";
            var appSettings = ConfigurationManager.AppSettings;
            string linkPagData = appSettings["LinkPagData"];

            string strLink = linkPagData + "/WFEncuestaEdit6R.aspx";

            //string strLink = "http://200.62.226.39/WSData/WFEncuestaEdit6R.aspx";
            Session["CodigoProyecto"] = 14;
            int IdUsuario = 4;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorClave(IdUsuario);

            int IdCabecera = int.Parse(e.CommandArgument.ToString());

            Formato6DTO objFormato = objFormato6DAO.BuscarPorClave(IdCabecera);

            EmpleadoDTO objEmpleado = objEmpleadoDAO.ListarPorCodigo(codigo);
            if (objFormato.IdFormato != "")
            {
                strLink += "?IdCabecera=" + IdCabecera;
                strLink += "&CodigoProyecto=14";
                strLink += "&codigo=" + objEmpleado.CodigoEmpleado;
                strLink += "&IdFormato=" + objFormato.IdFormato;
                strLink += "&LoginUsuario=admin";
                strLink += "&IdFormatoNemotecnico=RR.HH._%20FORM_41";
                strLink += "&FechaDeVisita=" + objFormato.FechaRegistro;
                strLink += "&CodigoGrupoVisita=0";
                strLink += "&CodigoVisita=0";
                strLink += "&Visita=Test";
                strLink += "&Ruta=1";
                strLink += "&vCodigoUsuario=00000";
                strLink += "&vOrganizacion=1";
                strLink += "&vRol=2";
                strLink += "&vEvaluador=" + objUsuario.NombreUsuario;
                strLink += "&vEmpleado=" + objEmpleado.Nombre;

                if (e.CommandName == "Seleccionar")
                {
                    this.panLista.Visible = false;
                    Response.Redirect(strLink);
                }
                if (e.CommandName == "EnviarCorreo")
                {
                    if (objEmpleado.Email != "")
                    {
                        enviarEmail(objEmpleado.Email, objEmpleado.Nombre, objUsuario.Email, objUsuario.NombreUsuario, strLink);
                    }
                    else 
                    {
                        this.lblMensaje.Text = "Empleado no tiene asignado un Email";
                    }
                }
            }
            else
            {
                this.lblMensaje.Text = "Empleado no tiene asignado Formato de Evaluacion";
            }
        }

        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvLista.PageIndex = e.NewPageIndex;
            Lista(codigo);
        }

        protected void enviarEmail(string empEmail, string empNombre, string usuEmail, string usuNombre, string linkEval)
        {

        }
    }

}