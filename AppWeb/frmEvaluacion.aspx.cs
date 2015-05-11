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
        string nombreemp;

        //
        string empEmail; string empNombre; string usuEmail; string usuNombre; string linkEval;

        protected void Page_Load(object sender, EventArgs e)
        {
            codigo = Request["Codigo"];
            nombreemp = Request["Nombre"];
            this.txtNombreEmpleado.Text = nombreemp;
            if (!Page.IsPostBack)
            {
                this.lblMensaje.Text = "";
                this.panEmail.Visible = false;
                this.panLista.Visible = true;
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

            int IdCabecera = int.Parse(e.CommandArgument.ToString());

            Formato6DTO objFormato = objFormato6DAO.BuscarPorClave(IdCabecera);
            //Session["CodigoProyecto"] = 14;
            int IdUsuario = Convert.ToInt32(objFormato.CodigoUsuario); 
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorClave(IdUsuario);

            //string strLink = "http://200.62.226.39/WSData/WFEncuestaEdit6R.aspx?IdCabecera=21509&CodigoProyecto=2&Codigo=R0086&IdFormato=73936eab-db52-4176-9594-fbc710592c53&LoginUsuario=umovil&FechaDeVisita=18/03/2015&IdFormatoNemotecnico=CASI_A1_V1&CodigoGrupoVisita=3&CodigoVisita=12&Visita=VisitaInicial&Ruta=";
            var appSettings = ConfigurationManager.AppSettings;
            string linkPagData = appSettings["LinkPagData"];

            string strLink = linkPagData + "/WFEncuestaEdit6R.aspx";

            //string strLink = "http://200.62.226.39/WSData/WFEncuestaEdit6R.aspx";

            EmpleadoDTO objEmpleado = objEmpleadoDAO.ListarPorCodigo(codigo);
            if (objFormato.IdFormato != "")
            {
                strLink += "?IdCabecera=" + IdCabecera;
                strLink += "&CodigoProyecto=14";
                strLink += "&codigo=" + objEmpleado.CodigoEmpleado;
                strLink += "&IdFormato=" + objFormato.IdFormato;
                strLink += "&LoginUsuario=admin";
                strLink += "&IdFormatoNemotecnico=RR.HH._FORM_41";
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
                        this.panEmail.Visible = true;
                        this.panLista.Visible = false;
                        mostrarEmail(objEmpleado.Email, objEmpleado.Nombre, objUsuario.Email, objUsuario.NombreUsuario, strLink);
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

            #region Notifications

            //string Owner = SessionManager.CurrentUser.Full_Name;
            List<string> mailList = new List<string>();
            mailList.Add(empEmail);
            mailList.Add(usuEmail);
            //foreach (var collaborator in item.RESOURCECollection) mailList.Add(RuleUser.GetOne(collaborator.Id_User).Email);
            if (mailList.Count > 0)
            {
                RuleMail.SendMail(
                    mailList,
                    string.Format(RuleMail.GetHtml(Server.MapPath(string.Format("{0}{1}.htm", AppConfig.PathTemplateHTML, "TmpAssignUserToEvaluation"))),
                        empNombre,
                        usuNombre,
                        linkEval), 
                    "RRHH: Evaluacion del Desempeño");
            }

            #endregion
        }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void mostrarEmail(string empEmail, string empNombre, string usuEmail, string usuNombre, string linkEval)
        {
            this.txtempEmail.Text = empEmail;
            this.txtempNombre.Text = empNombre;
            this.txtusuEmail.Text = usuEmail;
            this.txtusuNombre.Text = usuNombre;
            this.txtlinkEval.Text = linkEval;

            texto.InnerHtml = string.Format(RuleMail.GetHtml(Server.MapPath(string.Format("{0}{1}.htm", AppConfig.PathTemplateHTML, "TmpAssignUserToEvaluation"))),
                        empNombre,
                        usuNombre,
                        linkEval);

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //this.panEmail.Visible = false;
            //this.panLista.Visible = true;

            var appSettings = ConfigurationManager.AppSettings;
            string linkPag = appSettings["LinkPag"];
            string strLink = linkPag + "/frmEmpleado.aspx";

            Response.Redirect(strLink);
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            enviarEmail(this.txtempEmail.Text,
                this.txtempNombre.Text,
                this.txtusuEmail.Text,
                this.txtusuNombre.Text,
                this.txtlinkEval.Text);

            var appSettings = ConfigurationManager.AppSettings;
            string linkPag = appSettings["LinkPag"];
            string strLink = linkPag + "/frmEmpleado.aspx";

            Response.Redirect(strLink);

            //this.panEmail.Visible = true;
            //this.panLista.Visible = false;

        }

    }

}