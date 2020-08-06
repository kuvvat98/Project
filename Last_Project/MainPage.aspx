<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Last_Project.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div style="height: 534px">
            <asp:FileUpload  ID="btn_upload" runat="server" Width="235px" />
            <asp:Button ID="OpenButton" runat="server" Text="Открыть" Width="138px" height="25px" OnClick="OpenButton_Click" />
            <asp:RadioButton ID="DecryptBut" runat="server" Text ="Расшифровать" GroupName="Crypt"/>
            <asp:RadioButton ID="EncryptBut" runat="server" Text ="Зашифровать" GroupName="Crypt"/>
            <br />
            До преобразования:<br />
            <asp:TextBox ID="TextBox1" runat="server" Height="190px" Width="611px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="CountBut" runat="server" Text="Рассчитать" Width="160px" OnClick="CountBut_Click" />
            <asp:Button ID="SaveBut" runat="server" Text="Сохранить" Width="160px" OnClick="SaveBut_Click" />
            <asp:RadioButton ID="TxtBut" runat="server" Text =".txt" GroupName="extension"/>
            <asp:RadioButton ID="DocxBut" runat="server" Text =".docx" GroupName="extension"/>
            &nbsp;&nbsp; Ключ:<asp:TextBox ID="TextBox3" runat="server" Width="123px" Text="скорпион"></asp:TextBox>
            <br />
            После преобразования:<br />
            <asp:TextBox ID="TextBox2" runat="server" Height="190px" Width="611px" TextMode="MultiLine"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Исключения: " ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
