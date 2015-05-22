﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEmpConEval.aspx.cs" Inherits="AppWeb.frmEmpConEval" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
            <div style="margin:auto; width:100%;height:50px;"><span><asp:Button ID="btnpdf" 
                runat="server"  Text="PDF" CssClass="cssButton" onclick="btnpdf_Click" /></span><span>
            <asp:Button ID="btnexcel" runat="server" Text="EXCEL" CssClass="cssButton" 
                onclick="btnexcel_Click" /></span></div>
   
    <div style="margin:auto; width:100%;height:50px;">
            <CR:CrystalReportViewer ID="crvReporte" runat="server" 
            AutoDataBind="true" HasCrystalLogo="False" />
    </div>
    </form>
</body>
</html>
