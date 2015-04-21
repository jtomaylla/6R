<%@ Page Title="6R - Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AppWeb._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


<div class="cssTituloPagina">Evaluación del Desempeño</div>

<table width="100%">
<tr>
<%--<td style="width:350px" valign="top" >

<div class="cssTablaCabeceraRegistro">::Perfil/Función::</div>
<div class="cssTablaRegistro">

    <asp:TreeView ID="TreeView1" runat="server" 
        Width="345px" onselectednodechanged="TreeView1_SelectedNodeChanged" >
    </asp:TreeView>
  
</div>

</td>--%>

<td valign="top" width="*">

<div class="cssTablaCabeceraRegistro">::Evaluaciones::</div>
<div class="cssTablaRegistro">

<asp:Panel ID="panLista" runat="server">
 <%--   Buscar:<asp:TextBox ID="txtBusqueda" runat="server" Width="400px"></asp:TextBox>
    <asp:Button ID="btnBuscar" CssClass="cssButton" runat="server" Text="Buscar" onclick="btnBuscar_Click" />
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="cssButton" onclick="btnNuevo_Click" />
--%>
    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>    
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
<%--        <asp:BoundField ReadOnly="True" DataField="IdEmpleado" HeaderText="ID" ItemStyle-Width="50px"></asp:BoundField>
--%>        <asp:BoundField ReadOnly="True" DataField="CodigoEmpleado" HeaderText="Código" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="500px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Puesto" HeaderText="Puesto" ItemStyle-Width="200px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Grado" HeaderText="Grado" ItemStyle-Width="120px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Unidad" HeaderText="Unidad" ItemStyle-Width="120px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Sede" HeaderText="Sede" ItemStyle-Width="120px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="FechaIngreso" HeaderText="Fecha Ingreso" ItemStyle-Width="100px"></asp:BoundField>
<%--        <asp:CheckBoxField DataField="EstadoBool" HeaderText="Estado"   />--%>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnVerEmpleado" runat="server" Text="Evaluar" 
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


    
  
</div>

</td>
</tr>
</table>
    <asp:TextBox ID="txtIdUsuario" runat="server" Visible="false"></asp:TextBox>
</asp:Content>
