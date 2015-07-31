<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFormato.aspx.cs" Inherits="AppWeb.frmFormato" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src='<%# ResolveUrl("~/Scripts/jquery-latest.min.js") %>'></script>
    <script type="text/javascript" src='<%# ResolveUrl("~/Scripts/jquery-ui-1.8.9.custom.js") %>'></script>

    <script type="text/javascript">
        function ShowPopup(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "jQuery Dialog Popup",
                    buttons: {
                        Close: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true
                });
            });
        };
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<div class="cssTituloPagina">Formatos</div>

<table width="100%">
<tr>

<td valign="top" width="*">

<div class="cssTablaCabeceraRegistro">::Lista de Formatos::</div>
<div class="cssTablaRegistro">

<asp:Panel ID="panLista" runat="server">
<%--    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>--%>
    Buscar:<asp:TextBox ID="txtBusqueda" runat="server" Width="400px"></asp:TextBox>
    <asp:Button ID="btnBuscar" CssClass="cssButton" runat="server" Text="Buscar" onclick="btnBuscar_Click" />    
    <asp:gridview id="gvLista" runat="server" 
        autogeneratecolumns="False"
        OnRowCommand="gvLista_RowCommand"  
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        PageSize="20" 
        AllowPaging="true" 
        OnPageIndexChanging="gvLista_PageIndexChanging" onselectedindexchanged="gvLista_SelectedIndexChanged"
    >
    <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    <Columns>
        <asp:BoundField Visible="false" ReadOnly="True" DataField="IdFormato" HeaderText="ID" ItemStyle-Width="300px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Titulo" HeaderText="Nombre Puesto" ItemStyle-Width="500px"></asp:BoundField>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnVerFormato" runat="server" Text="Ver" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdFormato") %>'
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
</asp:Content>

