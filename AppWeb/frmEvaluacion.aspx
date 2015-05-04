<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEvaluacion.aspx.cs" Inherits="AppWeb.frmEvaluacion" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


<div class="cssTituloPagina">Administración de Evaluaciones</div>

<table width="100%">
<tr>

<td valign="top" width="*">

<div class="cssTablaCabeceraRegistro">::Historia de Evaluaciones::</div>
<div class="cssTablaRegistro">

<asp:Panel ID="panLista" runat="server">
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
        <asp:BoundField ReadOnly="True" DataField="IdCabecera" HeaderText="ID" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="IdFormato" HeaderText="Código" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Titulo" HeaderText="Titulo" ItemStyle-Width="500px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoUsuario" HeaderText="CodigoUsuario" ItemStyle-Width="200px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="FechaRegistro" HeaderText="Fecha Registro" ItemStyle-Width="100px"></asp:BoundField>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnVerFormato" runat="server" Text="Ver" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdCabecera") %>'
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

