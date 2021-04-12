<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmStandardControl.aspx.cs" Inherits="FirstWebApp.FrmStandardControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>표준컨트롤</title>
</head>
<body>
    <form id="form1" runat="server">
        <div> <%--문서서식(줄맞춰주는 단축키): ctr--%>
            <h1>표준컨트롤</h1>

            <asp:TextBox ID="TxtUserID" runat="server" TextMode="SingleLine" /><br />
            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" /><br />
            <asp:TextBox ID="TxtDesc" runat="server" TextMode="MultiLine" /><br />


            <asp:Label ID="LblDateTime" runat="server" Text="sample" /><br />
            <input type="button" value="버튼1" id="BtnInput"  /><br />
            <input type="button" value="버튼2" id="BtnHtml" runat="server" /><br /> <%--runat을 써줌으로서 C#과 연동시켜줌, HTML과 연동이 아닌--%>
            <asp:Button Text="로그인" runat="server" ID="Btnservar" Onclick="Btnservar_Click" /> 
            <%--asp=> Onclick, 다른 버튼 => onclick(대문자 소문자차이)--%>
            <%--runat을 쓰게 되면 ctrl F7을 눌러 코드를 만들어 참조시킬 수 있는 반면에 없는 경우에는 그냥 HTML의 버튼이기때문에 사용할 수 없다--%>
            <%--이 세개의 버튼은 웹페이지 상에 들어가 코드를 확인하면(F12를 눌러 확인가능) 3개 다 input으로 나온다.--%>
        </div>
    </form>
</body>
</html>
