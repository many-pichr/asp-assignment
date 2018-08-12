<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Asp_Assignment.User" %>

 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Gridview Basics example.</title>

    <style type="text/css">

        .gv

        {

            font-family: Arial;

            margin-top: 30px;

            font-size: 14px;

        }

        .gv th

        {

            background-color: #5D7B9D;

            font-weight: bold;

            color: #fff;

            padding: 2px 10px;

        }

        .gv td

        {

            padding: 2px 10px;

        }

        input[type="submit"]

        {

            margin: 2px 10px;

            padding: 2px 20px;

            background-color: #5D7B9D;

            border-radius: 10px;

            border: solid 1px #000;

            cursor: pointer;

            color: #fff;

        }

        input[type="submit"]:hover

        {

            background-color: orange;

        }

        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 26px;
        }
        #Select1 {
            width: 256px;
        }

    </style>

</head>

<body>

    <form id="form1" runat="server">

    <div>

        <table align="center" style="position: relative; top: 20px;">

            <tr>

                <td>

                    <table align="center">

                        <tr>

                            <td>

                                User Name :

                            </td>

                            <td>

                                <asp:TextBox ID="username" runat="server" MaxLength="50" Width="250px"></asp:TextBox>

                            </td>

                        </tr>

                        <tr>

                            <td>

                               Email :

                            </td>

                            <td>

                                <asp:TextBox ID="email" runat="server" MaxLength="10" Width="250px"></asp:TextBox>

                            </td>

                        </tr>

                        <tr>

                            <td class="auto-style2">

                                Password :

                            </td>

                            <td class="auto-style2">

                                <asp:TextBox ID="password" runat="server" MaxLength="200" Width="250px" OnTextChanged="password_TextChanged"></asp:TextBox>

                            </td>

                        </tr>
                        <tr>

                            <td class="auto-style1">

                                User Role :

                            </td>

                            <td class="auto-style1">

                                <asp:DropDownList ID="role" runat="server">
                                </asp:DropDownList>

                            </td>

                        </tr>

                        <tr>

                            <td colspan="2" align="center">

                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />

                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"

                                    Visible="false" />

                                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />

                            </td>

                        </tr>

                    </table>

                </td>

            </tr>

            <tr>

                <td align="center">

                    <br />

                    <asp:Label ID="lblMessage" runat="server" EnableViewState="false" ForeColor="Blue"></asp:Label>

                </td>

            </tr>

            <tr>

                <td>

                    <asp:GridView ID="gvDepartments" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"

                        EmptyDataText="No Records Found" GridLines="both" CssClass="gv" EmptyDataRowStyle-ForeColor="Red" OnSelectedIndexChanged="gvDepartments_SelectedIndexChanged">

                        <Columns>

                            <asp:TemplateField HeaderText="User Name">

                                <ItemTemplate>

                                    <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("u_username") %>'></asp:Label>

                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Email">

                                <ItemTemplate>

                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("email") %>'></asp:Label>

                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Password">

                                <ItemTemplate>

                                    <asp:Label ID="lblPassword" runat="server" Text='<%#Eval("password") %>'></asp:Label>

                                </ItemTemplate>

                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="User Role">

                                <ItemTemplate>

                                    <asp:Label ID="lblRole" runat="server" Text='<%#Eval("ur_name") %>'></asp:Label>

                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action">

                                <ItemTemplate>

                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />

                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure? want to delete the department.');"

                                        OnClick="btnDelete_Click" />

                                    <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("u_id") %>' Visible="false"></asp:Label>

                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </td>

            </tr>

        </table>

        <input type="hidden" runat="server" id="hidUserID" />

    </div>

    </form>

</body>

</html>