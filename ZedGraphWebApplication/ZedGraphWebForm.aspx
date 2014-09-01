<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZedGraphWebForm.aspx.cs" Inherits="ZedGraphWebApplication.ZedGraphWebForm" %>

<%@ Register assembly="ZedGraph.Web" namespace="ZedGraph.Web" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ZedGraph的WebControl测试</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:ZedGraphWeb ID="ZedGraphWeb1" runat="server">
        </cc1:ZedGraphWeb>
    </div>
    </form>
</body>
</html>
