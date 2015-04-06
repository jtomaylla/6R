<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEmpleado.aspx.cs" Inherits="AppWeb.frmEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language=javascript src="Scripts/popcalendar.js"></script>

    <script type="text/javascript">
        function js_validar() {
            var frm = document.getElementById("formmain");
            var codigo = document.getElementById("<%= txtCodigoEmpleado.ClientID%>");
            var nombre = document.getElementById("<%= txtNombre.ClientID%>");
            var documento = document.getElementById("<%= txtDocumentoIdentidad.ClientID%>");

            if (!JS_hasValue(codigo, "TEXT")) {
                if (!JS_onError(frm, codigo, "TEXT", "Ingrese Código de Empleado"))
                    return false;
            }
            if (!JS_hasValue(nombre, "TEXT")) {
                if (!JS_onError(frm, nombre, "TEXT", "Ingrese Nombre"))
                    return false;
            }
            if (!JS_hasValue(documento, "TEXT")) {
                if (!JS_onError(frm, documento, "TEXT", "Ingrese Documneto"))
                    return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="cssTituloPagina">Mantenimiento de Empleado</div>
<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

<asp:Panel ID="panLista" runat="server">
    Buscar:<asp:TextBox ID="txtBusqueda" runat="server" Width="400px"></asp:TextBox>
    <asp:Button ID="btnBuscar" CssClass="cssButton" runat="server" Text="Buscar" onclick="btnBuscar_Click" />
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="cssButton" onclick="btnNuevo_Click" />
    
    <asp:gridview id="gvLista" runat="server" 
        autogeneratecolumns="False"
        OnRowCommand="gvLista_RowCommand"  
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        PageSize="20" 
        AllowPaging="true" 
        OnPageIndexChanging="gvLista_PageIndexChanging"
    >
    <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdEmpleado" HeaderText="ID" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoEmpleado" HeaderText="Código" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="500px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Puesto" HeaderText="Puesto" ItemStyle-Width="200px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Grado" HeaderText="Grado" ItemStyle-Width="120px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Unidad" HeaderText="Unidad" ItemStyle-Width="120px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Sede" HeaderText="Sede" ItemStyle-Width="120px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="FechaIngreso" HeaderText="Fecha Ingreso" ItemStyle-Width="100px"></asp:BoundField>
        <asp:CheckBoxField DataField="EstadoBool" HeaderText="Estado"   />
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnVerEmpleado" runat="server" Text="Editar" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdEmpleado") %>'
                    CssClass="cssButton" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>
</asp:Panel>
<asp:Panel ID="panRegistro" runat="server">
    <div class="cssTablaCabeceraRegistro">Registro</div>
    <div class="cssTablaRegistro">
        <table>
        <tr>
            <td>ID</td>
            <td>:</td>
            <td><asp:TextBox ID="txtIdEmpleado" runat="server" Width="60px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Codigo</td>
            <td>:</td>
            <td><asp:TextBox ID="txtCodigoEmpleado" runat="server" Width="200px" ></asp:TextBox></td>
        </tr>
        <tr>
            <td>Documento Identidad</td>
            <td>:</td>
            <td><asp:TextBox ID="txtDocumentoIdentidad" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Nombre</td>
            <td>:</td>
            <td><asp:TextBox ID="txtNombre" runat="server" Width="600px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Cargo</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlCargo" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Fiscalizado</td>
            <td>:</td>
            <td><asp:CheckBox ID="chkFiscalizado" runat="server" /> Si</td>
        </tr>
        <tr>
            <td>Puesto</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlPuesto" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Grado</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlGrado" runat="server"></asp:DropDownList></td>
        </tr>        
        <tr>
            <td>Area</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlArea" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Unidad</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlUnidad" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Fecha Ingreso</td>
            <td>:</td>
            <td><asp:TextBox ID="txtFechaIngreso" runat="server" Width="200px"></asp:TextBox>
                <script language="javascript">
		        <!--
                    if (!document.layers) {
                        document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaIngreso, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
                    }
		        //-->
		        </script>
            </td>
        </tr>        
        <tr>
            <td>Jefe</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlJefe" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Sede</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlSede" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Estado</td>
            <td>:</td>
            <td><asp:CheckBox ID="chkEstado" runat="server" /> Activo</td>
        </tr>

        </table>

        <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="cssButton" onclick="btnGrabar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="cssButton" onclick="btnActualizar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  CssClass="cssButton" onclick="btnEliminar_Click" />
        <asp:Button ID="btnCancelar" runat="server" CssClass="cssButton" onclick="btnCancelar_Click" Text="Cancelar" />
    </div>
    <asp:TextBox ID="txtIdUsuario" runat="server" Visible="false"></asp:TextBox>
</asp:Panel>
</asp:Content>
