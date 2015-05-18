using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using pe.com.rbtec.web;
using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;

using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;

namespace AppWeb
{
    public partial class frmMantPuesto : System.Web.UI.Page
    {
        PuestoDAO objPuestoDAO = new PuestoDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        TablaDAO objTablaDAO = new TablaDAO();
        FormatoDAO objFormatoDAO = new FormatoDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnEliminar.Attributes.Add("onclick", "return confirm('" + AppConstantes.MSG_ELIMINAR_REGISTRO + "')");
            this.btnGrabar.Attributes.Add("onclick", "return js_validar();");
            this.btnActualizar.Attributes.Add("onclick", "return js_validar();");
            this.lblMensaje.Text = "";
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {

            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            this.txtIdUsuario.Text = objUsuario.IdUsuario.ToString();

            Listar();
            this.txtId.Enabled = false;
            this.txtId.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);
            this.panRegistro.Visible = false;
            this.panLista.Visible = true;

            List<FormatoDTO> objFormatoLista = objFormatoDAO.ListarPorProyecto(14);
            this.ddlFormato.DataSource = objFormatoLista;
            this.ddlFormato.DataTextField = "Titulo";
            this.ddlFormato.DataValueField = "IdFormato";
            this.ddlFormato.DataBind();
            this.ddlFormato.Items.Insert(0, new ListItem("- Seleccione -", "0"));
        }

        protected void Listar()
        {
            List<PuestoDTO> obj;
            try
            {
                obj = objPuestoDAO.Listar();
                this.gvLista.DataSource = obj;
                this.gvLista.DataBind();
            }
            catch (Exception err)
            {
                throw (err);
            }
        }

        protected void Limpiar()
        {
            this.txtId.Text = "";
            this.txtDescripcion.Text = "";
            this.chkEstado.Checked = true;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

            this.panRegistro.Visible = true;
            this.panLista.Visible = false;

            this.btnGrabar.Visible = true;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = true;
        }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {

            PuestoDTO obj;
            try
            {
                this.txtId.Text = gvLista.SelectedRow.Cells[0].Text;
                obj = objPuestoDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

                this.txtDescripcion.Text = obj.Nombre;
                if (obj.Estado == "1")
                    this.chkEstado.Checked = true;
                else
                    this.chkEstado.Checked = false;

                List<FormatoDTO> objFormatoLista = objFormatoDAO.ListarPorProyecto(14);
                this.ddlFormato.DataSource = objFormatoLista;
                this.ddlFormato.DataTextField = "Titulo";
                this.ddlFormato.DataValueField = "IdFormato";
                this.ddlFormato.DataBind();
                this.ddlFormato.Items.Insert(0, new ListItem("- Seleccione -", ""));
                ddlFormato.SelectedValue = obj.IdFormato;

                this.panRegistro.Visible = true;
                this.panLista.Visible = false;

                this.btnGrabar.Visible = false;
                this.btnActualizar.Visible = true;
                this.btnEliminar.Visible = false;
                this.btnCancelar.Visible = true;

            }
            catch (Exception err)
            {
                this.lblMensaje.Text = err.Message.ToString();
            }
        }


        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            PuestoDTO obj = new PuestoDTO();

            obj.Nombre = txtDescripcion.Text;

            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            obj.IdFormato = ddlFormato.SelectedValue;

            int id = objPuestoDAO.Agregar(obj);

            this.txtId.Text = id.ToString();

            this.btnNuevo.Visible = false;
            this.btnActualizar.Visible = true;
            this.btnEliminar.Visible = false;
            this.panRegistro.Visible = true;
            this.panLista.Visible = false;
            this.lblMensaje.Text = "Datos creados!!";
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            PuestoDTO obj = new PuestoDTO();

            obj = objPuestoDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

            obj.Nombre = txtDescripcion.Text;
            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            obj.IdFormato = ddlFormato.SelectedValue;

            objPuestoDAO.Actualizar(obj);

            this.lblMensaje.Text = "Datos guardados!!";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            PuestoDTO obj = new PuestoDTO();

            if (this.txtId.Text != "")
            {
                
                objPuestoDAO.Eliminar(this.txtId.Text);

                Limpiar();
            }

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;
            Listar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.btnNuevo.Visible = true;
            this.txtId.Text = "";
            this.chkEstado.Checked = true;

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;

            Listar();
        }


    }
}