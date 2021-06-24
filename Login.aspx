<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Portal_Application.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login || portal </title>
    <link href="src/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="src/css/custom.css" rel="stylesheet" type="text/css" />
</head>
<body>


    <div class="login">

        <form class="login-form" id="Form1" runat="server">
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Email address</label>
                <asp:TextBox ID="username" CssClass="form-control" runat="server"></asp:TextBox>
                <div>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="username" ErrorMessage="*Please Enter Your username "
                    ForeColor="black" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Password</label>
                <asp:TextBox ID="password" CssClass="form-control" runat="server"> </asp:TextBox>
                <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="password" ErrorMessage="*Please Enter Your password"
                    ForeColor="black" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div>
                <asp:Label ID="Massage" runat="server"></asp:Label>
            </div>

            <div>
            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Log In" OnClick="Login_btn" />
            </div>
        </form>
    </div>


    <script src="src/js/bootstrap.min.js"></script>
</body>

</html>
