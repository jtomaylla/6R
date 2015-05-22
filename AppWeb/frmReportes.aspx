<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReportes.aspx.cs" Inherits="AppWeb.frmReportes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language=javascript src="Scripts/popcalendar.js"></script>

    <style type="text/css">
        .style1
        {
            height: 24px;
            width: 253px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="cssTituloPagina">Reportes de Evaluacion</div>

<asp:Panel ID="panMenu" runat="server">
    <div class="cssTablaRegistro">
        <table>
            <tr>
                <td style="width: 500px">
                    <table >
		                <tr>
			                <td class="style1">
                                <asp:Label ID="Label1" runat="server" BorderStyle="None" CssClass="bold" 
                                    >Colaboradores con Evaluaciones</asp:Label></td>
			                <td class="SubHead" style="height: 24px; width: 83px;">
                                <asp:LinkButton ID="lnkPrint1" runat="server" BorderStyle="None" 
                                     onclick="lnkPrint1_Click">Imprimir</asp:LinkButton></td>
		                </tr>
		                <tr>
			                <td class="style1">
                                <asp:Label ID="Label2" runat="server" BorderStyle="None" CssClass="bold" 
                                    >Colaboradores sin Evaluaciones</asp:Label></td>
			                <td class="SubHead" style="height: 24px; width: 83px;">
                                <asp:LinkButton ID="lnkPrint2" runat="server"
                                    BorderStyle="None"  
                                     onclick="lnkPrint2_Click">Imprimir</asp:LinkButton></td>
		                </tr>
                        <tr>
			                <td class="style1">
                                </td>
			                <td class="SubHead" style="height: 24px; width: 83px;">
                                &nbsp;</td>
		                </tr>
	                </table>
                </td>
            </tr>
            <tr>
                <td style="width: 500px">
			       <asp:LinkButton id="cmdReturn" runat="server" BorderStyle="None">Cancelar</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>

<asp:Panel ID="panRepEval" runat="server">
    <div class="cssTituloPagina"><asp:Label ID="lblTitulo" runat="server" 
            CssClass="cssTituloPagina"></asp:Label></div>
    <div class="cssTablaRegistro">
        <table>
            <tr>
                <td>Seleccione la Unidad:</td>
                <td>:</td>
                <td><asp:DropDownList ID="ddlUnidad" runat="server" Height="25px" Width="261px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Desde:</td>
                <td>:</td>
                <td><asp:TextBox ID="txtFechaInicio" runat="server" Width="70px"></asp:TextBox>
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
                <td><asp:TextBox ID="txtFechaFin" runat="server" Width="70px"></asp:TextBox>
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
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="cssButton" onclick="btnImprimir_Click" />
     </div>
     <asp:TextBox ID="txtIdReporte" runat="server" Visible="false"></asp:TextBox>
     
</asp:Panel>

</asp:Content>