<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchFlights.aspx.cs" Inherits="SearchFlights" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" align="center">
                <tr>
                    <th colspan="3">Search Flights</th>
                </tr>
                <tr>
                    <td>Enter Origin City</td>
                    <td>
                        <asp:TextBox ID="txtOrigin" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtOrigin" Text="*" runat="server" ErrorMessage="Please enter Origin City"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Enter Destination City</td>
                    <td>
                        <asp:TextBox ID="txtDestination" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDestination" Text="*" runat="server" ErrorMessage="Please enter Destination City"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </td>
                    
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="gridView1" runat="server" DataKeyNames="Id" OnRowDeleting="gridView1_RowDeleting" OnRowCommand="gridView1_RowCommand">
                            <Columns>

                                <asp:ButtonField Text="Edit" CommandName="Edit">
												<ItemStyle Width="40%"></ItemStyle>
							    </asp:ButtonField>
                                <asp:ButtonField Text="Delete" CommandName="Delete" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
