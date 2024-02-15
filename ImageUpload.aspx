<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageUpload.aspx.cs" Inherits="ImagesUpload.ImageUpload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="UserControls/DatumExtender.ascx" TagName="DatumExtender" TagPrefix="uc2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 40%;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            font-size: x-large;
            color: #0066CC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width: 100%">
            <tr>
                <td align="center" colspan="2" width="40%">
                    <hr size="1" />
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="left" colspan="2" class="auto-style4"><strong>Upload Image :</strong></td>
            </tr>
            <tr>
                <td align="left" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">Title :</td>
                <td align="left">
                    <strong>
                    <asp:TextBox ID="txtTitle" runat="server" Width="350px"></asp:TextBox>
                    </strong></td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">Description :</td>
                <td align="left">
                    <strong>
                    <asp:TextBox ID="txtDescription" runat="server" Height="150px" TabIndex="16" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    </strong></td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">Date_Start :</td>
                <td align="left">
                    <uc2:DatumExtender ID="DatStart" runat="server" DefaultDatum="Danas" DozvoliPrazno="True" Enabled="True" />
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">Date_End :</td>
                <td align="left">
                    <uc2:DatumExtender ID="DatEnd" runat="server" DefaultDatum="Danas" DozvoliPrazno="True" Enabled="True" />
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">Link :</td>
                <td align="left">
                    <strong>
                    <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
                    </strong></td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">&nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">Image :</td>
                <td align="left">
                    <strong>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    </strong></td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">&nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">Reference :</td>
                <td align="left"><strong>
                    <asp:TextBox ID="txtReference" runat="server" Height="49px" TabIndex="16" TextMode="MultiLine" Width="164px"></asp:TextBox>
                    </strong></td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2"><strong>
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td align="right" colspan="2"><strong>
                    <asp:ImageButton ID="imbNew" runat="server" AlternateText="Add new row" ImageUrl="images/add2_48.png" OnClick="imbNew_Click" ValidationGroup="Stavke" />
                    </strong></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <hr size="1" />
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" class="auto-style4"><strong>Added items:</strong></td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="auto-style3" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="ObjectDataSource1" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound1">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imbObrada" runat="server" AlternateText="Obrada stavke" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Id") %>' CommandName="Obrada" ImageUrl="~/images/edit_48.png" Width="25px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Images" SortExpression="Images">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl='<%# "~/Images1/" + Eval("Images")  %>' style="width: 80px; height: 100px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
                            <asp:BoundField DataField="DetailId" HeaderText="DetailId" SortExpression="DetailId" Visible="False" />
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                            <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" SortExpression="Date" />
                            <asp:BoundField DataField="Date1" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date1" SortExpression="Date1" />
                            <asp:BoundField DataField="Link" HeaderText="Link" SortExpression="Link" />
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                            <asp:BoundField DataField="Reference" HeaderText="Reference" SortExpression="Reference" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imbBrisanje" runat="server" AlternateText="Brisanje stavke" CausesValidation="False" CommandArgument='<%# Bind("Id") %>' CommandName="Brisanje" ImageUrl="images/delete_024.png" Width="24px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="ImagesUpload.Data.ImageUploadTableAdapters.advertisementTableAdapter">
                        <InsertParameters>
                            <asp:Parameter Name="DetailId" Type="Int32" />
                            <asp:Parameter Name="Images" Type="String" />
                            <asp:Parameter Name="Title" Type="String" />
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="Date" Type="DateTime" />
                            <asp:Parameter Name="Date1" Type="DateTime" />
                            <asp:Parameter Name="Link" Type="String" />
                            <asp:Parameter Name="Status" Type="String" />
                            <asp:Parameter Name="Reference" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <hr size="1" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/createdBy.bmp" />
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td align="left" colspan="2">&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
