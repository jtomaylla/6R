using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using pe.com.rbtec.web;
using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;

using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;

namespace AppWeb
{
    public partial class frmEmpleado : System.Web.UI.Page
    {

        EmpleadoDAO objEmpleadoDAO = new EmpleadoDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        TablaDAO objTablaDAO = new TablaDAO();
        CargoDAO objCargoDAO = new CargoDAO();
        PuestoDAO objPuestoDAO = new PuestoDAO();
        GradoDAO objGradoDAO = new GradoDAO();
        AreaDAO objAreaDAO = new AreaDAO();
        UnidadDAO objUnidadDAO = new UnidadDAO();
        JefeDAO objJefeDAO = new JefeDAO();
        SedeDAO objSedeDAO = new SedeDAO();

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
            this.txtIdEmpleado.Enabled = false;
            this.txtIdEmpleado.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);
            this.panRegistro.Visible = false;
            this.panLista.Visible = true;

            CargaCombos();
        }

        protected void Listar()
        {
            List<EmpleadoDTO> obj;
            try
            {
                obj = objEmpleadoDAO.Listar();
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
            this.txtIdEmpleado.Text = "";
            this.txtCodigoEmpleado.Text = "";
            this.txtDocumentoIdentidad.Text = "";
            this.txtNombre.Text = "";
            this.chkFiscalizado.Checked = false;
            this.txtFechaIngreso.Text = "";
            this.chkEstado.Checked = true;
        }

        protected void CargaCombos()
        {
            //CARGO
            List<CargoDTO> objCargoLista = objCargoDAO.Listar();
            this.ddlCargo.DataSource = objCargoLista;
            this.ddlCargo.DataTextField = "Nombre";
            this.ddlCargo.DataValueField = "CodigoCargo";
            this.ddlCargo.DataBind();
            this.ddlCargo.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            
            //PUESTO
            List<PuestoDTO> objPuestoLista = objPuestoDAO.Listar();
            this.ddlPuesto.DataSource = objPuestoLista;
            this.ddlPuesto.DataTextField = "Nombre";
            this.ddlPuesto.DataValueField = "CodigoPuesto";
            this.ddlPuesto.DataBind();
            this.ddlPuesto.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            //GRADO
            List<GradoDTO> objGradoLista = objGradoDAO.Listar();
            this.ddlGrado.DataSource = objGradoLista;
            this.ddlGrado.DataTextField = "Nombre";
            this.ddlGrado.DataValueField = "CodigoGrado";
            this.ddlGrado.DataBind();
            this.ddlGrado.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            //AREA
            List<AreaDTO> objAreaLista = objAreaDAO.Listar();
            this.ddlArea.DataSource = objAreaLista;
            this.ddlArea.DataTextField = "Nombre";
            this.ddlArea.DataValueField = "CodigoArea";
            this.ddlArea.DataBind();
            this.ddlArea.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            //UNIDAD
            List<UnidadDTO> objUnidadLista = objUnidadDAO.Listar();
            this.ddlUnidad.DataSource = objUnidadLista;
            this.ddlUnidad.DataTextField = "Nombre";
            this.ddlUnidad.DataValueField = "CodigoUnidad";
            this.ddlUnidad.DataBind();
            this.ddlUnidad.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            //JEFE
            List<JefeDTO> objJefeLista = objJefeDAO.Listar();
            this.ddlJefe.DataSource = objJefeLista;
            this.ddlJefe.DataTextField = "Nombre";
            this.ddlJefe.DataValueField = "CodigoJefe";
            this.ddlJefe.DataBind();
            this.ddlJefe.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            //SEDE
            List<SedeDTO> objSedeLista = objSedeDAO.Listar();
            this.ddlSede.DataSource = objSedeLista;
            this.ddlSede.DataTextField = "Nombre";
            this.ddlSede.DataValueField = "CodigoSede";
            this.ddlSede.DataBind();
            this.ddlSede.Items.Insert(0, new ListItem("- Seleccione -", "0"));
    }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            CargaCombos();

            this.panRegistro.Visible = true;
            this.panLista.Visible = false;

            this.btnGrabar.Visible = true;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = true;

        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                EmpleadoDTO obj;
                try
                {
                    int IdEmpleado = int.Parse(e.CommandArgument.ToString());

                    this.txtIdEmpleado.Text = IdEmpleado.ToString();
                    obj = objEmpleadoDAO.ListarPorClave(Convert.ToInt32(this.txtIdEmpleado.Text));

                    this.txtCodigoEmpleado.Text = obj.CodigoEmpleado;
                    this.txtDocumentoIdentidad.Text = obj.DocumentoIdentidad;
                    this.txtNombre.Text = obj.Nombre;

                    if (obj.FechaIngreso.Year == 1)
                        this.txtFechaIngreso.Text = "";
                    else
                        this.txtFechaIngreso.Text = obj.FechaIngreso.ToString("dd/MM/yyyy");

                    if (obj.Fiscalizado == "1")
                        this.chkFiscalizado.Checked = true;
                    else
                        this.chkFiscalizado.Checked = false;

                    if (obj.Estado == "1")
                        this.chkEstado.Checked = true;
                    else
                        this.chkEstado.Checked = false;

                    CargaCombos();

                    ddlCargo.SelectedValue = obj.CodigoCargo.ToString();
                    ddlPuesto.SelectedValue = obj.CodigoPuesto.ToString();
                    ddlGrado.SelectedValue = obj.GradoPuesto.ToString();
                    ddlArea.SelectedValue = obj.CodigoArea.ToString();
                    ddlUnidad.SelectedValue = obj.CodigoUnidad.ToString();
                    ddlJefe.SelectedValue = obj.CodigoJefe.ToString();
                    ddlSede.SelectedValue = obj.CodigoSede.ToString();

                    this.panRegistro.Visible = true;
                    this.panLista.Visible = false;

                    this.btnGrabar.Visible = false;
                    this.btnActualizar.Visible = true;
                    this.btnEliminar.Visible = true;
                    this.btnCancelar.Visible = true;

                }
                catch (Exception err)
                {
                    this.lblMensaje.Text = err.Message.ToString();
                }
            }
            if (e.CommandName == "Historial")
            {
                try
                {
                 
                    var appSettings = ConfigurationManager.AppSettings;
                    string linkPag = appSettings["LinkPag"];

                    string CodigoEmpleado = e.CommandArgument.ToString();
                    string strLink = linkPag + "/frmEvaluacion.aspx";
                    strLink += "?Codigo=" + CodigoEmpleado;
                    this.panLista.Visible = false;

                    Response.Redirect(strLink);
                }
                catch (Exception err)
                {
                    this.lblMensaje.Text = err.Message.ToString();
                }
            }

        }

        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvLista.PageIndex = e.NewPageIndex;
            Listar();
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
            EmpleadoDTO obj = new EmpleadoDTO();

            obj.CodigoEmpleado = txtCodigoEmpleado.Text;
            obj.CodigoEmpleado = txtCodigoEmpleado.Text;
            obj.DocumentoIdentidad = txtDocumentoIdentidad.Text; 
            obj.Nombre = txtNombre.Text;
            if (this.chkFiscalizado.Checked)
                obj.Fiscalizado = "1";
            else
                obj.Fiscalizado = "0";
        
            if (this.txtFechaIngreso.Text != "")
                obj.FechaIngreso = AppUtilidad.stringToDateTime(this.txtFechaIngreso.Text, "DD/MM/YYYY");

            obj.CodigoCargo = int.Parse(ddlCargo.SelectedValue.ToString());
            obj.CodigoPuesto = int.Parse(ddlPuesto.SelectedValue.ToString());
            obj.GradoPuesto = int.Parse(ddlGrado.SelectedValue.ToString());
            obj.CodigoArea = int.Parse(ddlArea.SelectedValue.ToString());
            obj.CodigoUnidad = int.Parse(ddlUnidad.SelectedValue.ToString());
            obj.CodigoJefe = int.Parse(ddlJefe.SelectedValue.ToString());
            obj.CodigoSede = int.Parse(ddlSede.SelectedValue.ToString()); 


            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            obj.Usuario_creacion = objUsuarioDTO.IdUsuario;

            int id =  objEmpleadoDAO.Agregar(obj);

            this.txtIdEmpleado.Text = id.ToString();

            this.btnNuevo.Visible = false;
            this.btnActualizar.Visible = true;
            this.btnEliminar.Visible = true;
            this.panRegistro.Visible = true;
            this.panLista.Visible = false;
            this.lblMensaje.Text = "Datos creados!!";
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
            EmpleadoDTO obj = new EmpleadoDTO();
            try
            {
                obj = objEmpleadoDAO.ListarPorClave(Convert.ToInt32(this.txtIdEmpleado.Text));

                obj.CodigoEmpleado = txtCodigoEmpleado.Text;
                obj.CodigoEmpleado = txtCodigoEmpleado.Text;
                obj.DocumentoIdentidad = txtDocumentoIdentidad.Text;
                obj.Nombre = txtNombre.Text;
                if (this.chkFiscalizado.Checked)
                    obj.Fiscalizado = "1";
                else
                    obj.Fiscalizado = "0";

                if (this.txtFechaIngreso.Text != "")
                    obj.FechaIngreso = AppUtilidad.stringToDateTime(this.txtFechaIngreso.Text, "DD/MM/YYYY");

                obj.CodigoCargo = int.Parse(ddlCargo.SelectedValue.ToString());
                obj.CodigoPuesto = int.Parse(ddlPuesto.SelectedValue.ToString());
                obj.GradoPuesto = int.Parse(ddlGrado.SelectedValue.ToString());
                obj.CodigoArea = int.Parse(ddlArea.SelectedValue.ToString());
                obj.CodigoUnidad = int.Parse(ddlUnidad.SelectedValue.ToString());
                obj.CodigoJefe = int.Parse(ddlJefe.SelectedValue.ToString());
                obj.CodigoSede = int.Parse(ddlSede.SelectedValue.ToString());
                obj.Email = txtEmail.Text;

                if (this.chkEstado.Checked)
                    obj.Estado = "1";
                else
                    obj.Estado = "0";

                obj.Usuario_modificacion = objUsuarioDTO.IdUsuario;

                objEmpleadoDAO.Actualizar(obj);
                this.lblMensaje.Text = "Datos actualizados!!";
            }
            catch (Exception err)
            {
                this.lblMensaje.Text = err.Message.ToString();
            }
            

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EmpleadoDTO obj = new EmpleadoDTO();

            if (this.txtIdEmpleado.Text != "")
            {
                objEmpleadoDAO.Eliminar(Convert.ToInt32(this.txtIdEmpleado.Text));
                this.lblMensaje.Text = "Datos anulados!!";
                Limpiar();
            }

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;
            Listar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.btnNuevo.Visible = true;
            this.txtIdEmpleado.Text = "";
            this.chkEstado.Checked = true;

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;

            Listar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<EmpleadoDTO> obj;
            try
            {
                string strBusqueda = txtBusqueda.Text;
                obj = objEmpleadoDAO.ListarBusqueda(strBusqueda);
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