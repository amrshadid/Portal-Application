<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Portal_Application.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <p>
               <strong style="font-size: xx-large">Welcome asp portal </strong>
            </p>

        </div>

        <p>
            <asp:Label ID="Wellcom" runat="server">Wellcome </asp:Label>
        </p>
        <p>
            <asp:Button ID="Logout" runat="server" Height="47px" OnClick="Logout_btn"
                Text="Logout" Width="92px" />
        </p>
    </form>
</body>
</html>
