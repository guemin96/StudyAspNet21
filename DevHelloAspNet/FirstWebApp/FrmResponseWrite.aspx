﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmResponseWrite.aspx.cs" Inherits="FirstWebApp.FrmResponseWrite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BtnMessage" runat="server" 
                Text="클릭" OnClick="BtnMessage_Click" />
            <br />
            <%="또 만나요 <br />" %>
            <asp:Button ID="BtnJs" runat="server"
                Text="JS Greeting" OnClick="BtnJs_Click" />
            <br />
            <asp:LinkButton ID="BtnLink" runat="server"
                text="네이버" OnClick="BtnLink_Click"> 네이버 </asp:LinkButton>
        </div>
    </form>
</body>
</html>
