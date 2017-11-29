<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlPageTest.aspx.cs" Inherits="SmartSocial.Web.testing.ControlPageTest" %>

<%@ Register src="ucChartBaseTesting.ascx" tagname="ucChartBaseTesting" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:ucChartBaseTesting ID="ucChartBaseTesting1" runat="server" />
    
    </div>
        <uc1:ucChartBaseTesting ID="ucChartBaseTesting2" runat="server" />
    </form>
</body>
</html>
