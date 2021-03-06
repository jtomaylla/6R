﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using pe.com.rbtec.web;
using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;

using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;

namespace AppWeb
{
    public partial class frmReportes : System.Web.UI.Page
    {
        UnidadDAO objUnidadDAO = new UnidadDAO();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblTitulo.Text = "";
            this.btnImprimir.Attributes.Add("onclick", "return js_validar();");
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }
        protected void InicializaPagina()
        {
            this.txtIdReporte.Text = "";
            this.panRepEval.Visible = false;
            this.panMenu.Visible = true;
            
            //UNIDAD
            List<UnidadDTO> objUnidadLista = objUnidadDAO.Listar();
            this.ddlUnidad.DataSource = objUnidadLista;
            this.ddlUnidad.DataTextField = "Nombre";
            this.ddlUnidad.DataValueField = "CodigoUnidad";
            this.ddlUnidad.DataBind();
            this.ddlUnidad.Items.Insert(0, new ListItem("- Seleccione -", "0"));
        }
        protected void lnkPrint1_Click(object sender, EventArgs e)
        {
            this.txtIdReporte.Text = "1";
            this.panMenu.Visible=false;
            this.panRepEval.Visible=true;
            this.lblTitulo.Text = "Colaboradores con Evaluaciones";
            this.txtFechaInicio.Text = "01/01/2000";
            //this.txtFechaFin.Text = DateTime.Today.ToShortDateString();
        }

        protected void lnkPrint2_Click(object sender, EventArgs e)
        {
            this.txtIdReporte.Text = "2";
            this.panMenu.Visible=false;
            this.panRepEval.Visible=true;
            this.lblTitulo.Text = "Colaboradores sin Evaluaciones";
            this.txtFechaInicio.Text = "01/01/2000";
            //this.txtFechaFin.Text = DateTime.Today.ToShortDateString();
        }

        protected void Imprimir(string frmNombre, int codigounidad, string fechaini, string fechafin)
        {
            String CodigoUnidad = codigounidad.ToString();
            //String FechaIni = fechaini.ToShortDateString();
            //String FechaFin = fechafin.ToShortDateString();

            var appSettings = ConfigurationManager.AppSettings;
            string linkPag = appSettings["LinkPag"];

            string strLink = linkPag + "/" + frmNombre;
            strLink += "?CodigoUnidad=" + CodigoUnidad + "&FechaIni=" + fechaini + "&FechaFin=" + fechafin;

            Response.Redirect(strLink);
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.txtIdReporte.Text == "1") 
            {
                Imprimir("frmEmpConEval.aspx",
                    int.Parse(ddlUnidad.SelectedValue.ToString()),
                    this.txtFechaInicio.Text,
                    this.txtFechaFin.Text);
            }
            if (this.txtIdReporte.Text == "2")
            {
                Imprimir("frmEmpSinEval.aspx",
                    int.Parse(ddlUnidad.SelectedValue.ToString()),
                    this.txtFechaInicio.Text,
                    this.txtFechaFin.Text);
            }
        }
    }
}