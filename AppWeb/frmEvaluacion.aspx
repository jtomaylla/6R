<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEvaluacion.aspx.cs" Inherits="AppWeb.frmEvaluacion" %>

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

<div class="cssTituloPagina">Administración de Evaluaciones</div>

<table width="100%">
<tr>

<td valign="top" width="*">

<div class="cssTablaCabeceraRegistro">::Historia de Evaluaciones::</div>
<div class="cssTablaRegistro">

<asp:Panel ID="panLista" runat="server">
    Empleado:<asp:TextBox ID="txtNombreEmpleado" runat="server" Width="400px" 
        ReadOnly="True"></asp:TextBox><br />

    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>    
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
        <asp:BoundField ReadOnly="True" DataField="IdCabecera" HeaderText="ID" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Titulo" HeaderText="Nombre Puesto" ItemStyle-Width="500px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreUsuario" HeaderText="Evaluador" ItemStyle-Width="200px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="100px"></asp:BoundField>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnVerFormato" runat="server" Text="Ver" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdCabecera") %>'
                    CssClass="cssButton" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnEnviarCorreo" runat="server" Text="Email" 
                    CommandName="EnviarCorreo" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdCabecera") %>'
                    CssClass="cssButton" />
            </ItemTemplate>
        </asp:TemplateField>    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>
</asp:Panel>


<asp:Panel ID="panEmail" runat="server">
    <div class="cssTablaCabeceraRegistro">Enviar Email</div>
    <div class="cssTablaEmail">
        <table>
        <tr>
            <td>
                    
                    <div ID="texto" runat="server" ></div>

            </td>
        </tr>
        </table>
        <asp:Button ID="btnEmail" runat="server" Text="Enviar Email" CssClass="cssButton" onclick="btnEmail_Click" />
        <asp:Button ID="btnCancelar" runat="server" CssClass="cssButton" onclick="btnCancelar_Click" Text="Cancelar" />

    </div>

</asp:Panel>    
  
</div>

</td>
</tr>
</table>
    <asp:TextBox ID="txtIdUsuario" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtempEmail" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtempNombre" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtusuEmail" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtusuNombre" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtlinkEval" runat="server" Visible="false"></asp:TextBox>
</asp:Content>

