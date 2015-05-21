<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReportes.aspx.cs" Inherits="AppWeb.frmReportes" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language=javascript src="Scripts/popcalendar.js"></script>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="cssTituloPagina">Reportes de Evaluacion</div>

<asp:Panel ID="panMenu" runat="server">
    <table>
        <tr>
            <td style="width: 500px">
                <table >
		            <tr>
			            <td class="SubHead" style="width: 491px; height: 24px">
                            <asp:Label ID="Label1" runat="server" BorderStyle="None" CssClass="SESLabel"
                                >Empleados con Evaluaciones</asp:Label></td>
			            <td class="SubHead" style="height: 24px; width: 83px;">
                            <asp:LinkButton ID="lnkPrint1" runat="server" BorderStyle="None" CssClass="SESCommandButton"
                                 onclick="lnkPrint1_Click">Imprimir</asp:LinkButton></td>
		            </tr>
		            <tr>
			            <td class="SubHead" style="width: 491px; height: 24px">
                            <asp:Label ID="Label2" runat="server" BorderStyle="None" CssClass="SESLabel"
                                >Empleados sin Evaluaciones</asp:Label></td>
			            <td class="SubHead" style="height: 24px; width: 83px;">
                            <asp:LinkButton ID="lnkPrint2" runat="server"
                                BorderStyle="None" CssClass="SESCommandButton" 
                                 onclick="lnkPrint2_Click">Imprimir</asp:LinkButton></td>
		            </tr>
                    <tr>
			            <td class="SubHead" style="width: 491px; height: 24px">
                            </td>
			            <td class="SubHead" style="height: 24px; width: 83px;">
                            &nbsp;</td>
		            </tr>
	            </table>
            </td>
        </tr>
        <tr>
            <td style="width: 500px">
			   <asp:LinkButton id="cmdReturn" runat="server" BorderStyle="None" CssClass="SESCommandButton">Cancelar</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="panRepEval" runat="server">
    <div class="cssTablaRepEval"><asp:Label ID="lblTitulo" runat="server" Text="" CssClass="cssMensaje"></asp:Label></div>
    <div class="cssTablaRepEval">
        <table>
            <tr>
                <td>Seleccione la Unidad:</td>
                <td>:</td>
                <td><asp:DropDownList ID="ddlUnidad" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Desde:</td>
                <td>:</td>
                <td><asp:TextBox ID="txtFechaInicio" runat="server" Width="200px"></asp:TextBox>
                    <script language="javascript">
		            <!--
                        if (!document.layers) {
                            document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaInicio, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
                        }
		            //-->
		            </script>
                </td>
            </tr>  
            <tr>
                <td>Hasta:</td>
                <td>:</td>
                <td><asp:TextBox ID="txtFechaFin" runat="server" Width="200px"></asp:TextBox>
                    <script language="javascript">
		            <!--
                        if (!document.layers) {
                            document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaFin, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
                        }
		            //-->
		            </script>
                </td>
            </tr>  
        </table>
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="cssButton" onclick="btnGrabar_Click" />
     </div>
     <asp:TextBox ID="txtIdReporte" runat="server" Visible="false"></asp:TextBox>
     
</asp:Panel>

</asp:Content>