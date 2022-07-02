<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateFlights.aspx.cs" Inherits="UpdateFlights" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="background-color:lightblue" align="center">
                <tr>
                    <th colspan="3">Update Flight</th>
                </tr>
                <tr>
                    <td>Flight Number :</td>
                    <td>
                        <asp:TextBox ID="txtflightNo" runat="server" Width="80" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtflightNo" Text="*" runat="server" ErrorMessage="Flight Number is mandatory field"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Flight Name :</td>
                    <td>
                        <asp:TextBox ID="txtflightName" runat="server" Width="80" />

                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtflightName" Text="*" runat="server" ErrorMessage="Flight Name is mandatory field"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Origin City :</td>
                    <td>
                        <asp:TextBox ID="txtoriginCity" runat="server" Width="80" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtoriginCity" Text="*" runat="server" ErrorMessage="Origin City is mandatory field"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Destination City :</td>
                    <td>
                        <asp:TextBox ID="txtdestCity" runat="server" Width="80" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtdestCity" Text="*" runat="server" ErrorMessage="Destination City is mandatory field"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Seats Available :</td>
                    <td>
                        <asp:TextBox ID="txtseatsAvailable" runat="server" Width="80" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtseatsAvailable" Text="*" runat="server" ErrorMessage="Seats Available is mandatory field"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtseatsAvailable" Text="*" Operator="DataTypeCheck" Type="Integer" runat="server" ErrorMessage="Value must be integer"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
