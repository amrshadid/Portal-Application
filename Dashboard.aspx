<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Portal_Application.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashborad</title>

    <link href="src/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="src/css/custom.css" rel="stylesheet" type="text/css" />
</head>
<body>

    <form id="form1" runat="server">
        <div>

            <div class="container">

                <div class="row">

                    <div class="col-md-6">
                        <h1 class="display-4 d-inline-flex p-2">ASP Portal&nbsp;</h1>
                    </div>
                    <div class="col-md-6">
                        <div class="d-flex justify-content-end p-4">

                            <asp:Button ID="Logout" runat="server" Height="47px" OnClick="Logout_btn"
                                Text="Logout" CssClass="btn btn-outline-danger" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="container-fluid">
            <div class="p-2 d-flex justify-content-between">

                <h3 class="d-inline-flex">
                    <asp:Label ID="Wellcom" runat="server">Wellcome </asp:Label></h3>

            </div>
            <div class="d-flex justify-content-between">

                <asp:Button ID="modal" runat="server" Height="47px" OnClick="modal_btn"
                    Text="My schedule" CssClass="btn btn-dark btn-block" />

                <h3 id="ConfirmedHours" runat="server" class="d-inline-flex">you are register:18&nbsp;hours</h3>

            </div>
            <div id="scheduleTable" runat="server" class="table-responsive schedule">
                <table class="table table-striped table-hover table-dark">
                    <thead>
                        <tr>
                            <th>Course Code<br />
                            </th>
                            <th>
                                <br />
                                Course Name<br />
                            </th>
                            <th>
                                <br />
                                <strong>Activity</strong><br />
                            </th>
                            <th>
                                <br />
                                <strong>Confirmed Hours</strong><br />
                            </th>
                            <th>
                                <br />
                                <strong>Section</strong><br />
                            </th>
                            <th>
                                <br />
                                <br />
                                <strong>Instructor</strong><br />
                            </th>
                            <th>
                                <br />
                                <br />
                                Faculty<br />
                            </th>
                            <th>
                                <br />
                                <br />
                                Add</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>100210</td>
                            <td>Web programming</td>
                            <td>Lecture<br />
                            </td>
                            <td>3</td>
                            <td>1</td>
                            <td>Amr Shadid</td>
                            <td>EIT</td>
                            <td>
                                <button class="btn btn-outline-danger" type="button"><i class="icon ion-android-delete"></i></button>
                            </td>
                        </tr>
                        <tr>
                            <td>100210</td>
                            <td>Web programming</td>
                            <td>Lecture<br />
                            </td>
                            <td>3</td>
                            <td>1</td>
                            <td>Amr Shadid</td>
                            <td>EIT</td>
                            <td>
                                <button class="btn btn-outline-danger" type="button"><i class="icon ion-android-delete"></i></button>
                            </td>
                        </tr>
                        <tr>
                            <td>100210</td>
                            <td>Web programming</td>
                            <td>Lecture<br />
                            </td>
                            <td>3</td>
                            <td>1</td>
                            <td>Amr Shadid</td>
                            <td>EIT</td>
                            <td>
                                <button class="btn btn-outline-danger" type="button"><i class="icon ion-android-delete"></i></button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <hr />
        <div class="p-3 d-flex align-items-center">
                <asp:DropDownList CssClass="dropdown" ID="DropDownList1" runat="server">
                    <asp:ListItem Value="">Please Select</asp:ListItem>
                    <asp:ListItem>New Delhi </asp:ListItem>
                    <asp:ListItem>Greater Noida</asp:ListItem>
                    <asp:ListItem>NewYork</asp:ListItem>
                    <asp:ListItem>Paris</asp:ListItem>
                    <asp:ListItem>London</asp:ListItem>
                </asp:DropDownList>
            <div class="p-3">
            <asp:Button ID="select" runat="server" OnClick="select_Click" Text="Submit" />
            </div>
            <br />
            <asp:Label ID="Label1" runat="server" EnableViewState="False"></asp:Label>
        </div>
        <div class="container-fluid">
            <div class="table-responsive schedule" id="schedule">
                <table class="table table-striped table-hover table-dark">
                    <thead>
                        <tr>
                            <th>Course Code<br />
                            </th>
                            <th>
                                <br />
                                Course Name<br />
                            </th>
                            <th>
                                <br />
                                <strong>Activity</strong><br />
                            </th>
                            <th>
                                <br />
                                <strong>Confirmed Hours</strong><br />
                            </th>
                            <th>
                                <br />
                                <strong>Section</strong><br />
                            </th>
                            <th>
                                <br />
                                <br />
                                <strong>Instructor</strong><br />
                            </th>
                            <th>
                                <br />
                                <br />
                                Faculty<br />
                            </th>
                            <th>
                                <br />
                                <br />
                                Add
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>100210</td>
                            <td>Web programming</td>
                            <td>Lecture<br />
                            </td>
                            <td>3</td>
                            <td>1</td>
                            <td>Amr Shadid</td>
                            <td>EIT</td>
                            <td>
                                <button class="btn btn-outline-primary" type="button"><i class="icon ion-plus"></i></button>
                            </td>
                        </tr>
                        <tr>
                            <td>100210</td>
                            <td>Web programming</td>
                            <td>Lecture<br />
                            </td>
                            <td>3</td>
                            <td>1</td>
                            <td>Amr Shadid</td>
                            <td>EIT</td>
                            <td>
                                <button class="btn btn-outline-primary" type="button"><i class="icon ion-plus"></i></button>
                            </td>
                        </tr>
                        <tr>
                            <td>100210</td>
                            <td>Web programming</td>
                            <td>Lecture<br />
                            </td>
                            <td>3</td>
                            <td>1</td>
                            <td>Amr Shadid</td>
                            <td>EIT</td>
                            <td>
                                <button class="btn btn-outline-primary" type="button"><i class="icon ion-plus"></i></button>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

        </div>
    </form>



</body>
</html>
