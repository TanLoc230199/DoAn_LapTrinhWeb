<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ChiTietHD.aspx.cs" Inherits="WEB_BanSach.Admin.ChiTietHD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="style2">
        CHI TIẾT HOÁ ĐƠN<hr width="60%" />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="False" 
            style="font-size: small" Text="Mã hoá đơn:"></asp:Label>
&nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Button ID="btnXuly" runat="server" onclick="btnXuly_Click" Text="Xử lý" 
            Width="60px" />
        <br />
        <br />
        <div>
            <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                Font-Bold="False" 
                style="font-family: 'Times New Roman', Times, serif; text-align: center; margin-top: 0px;" 
                AutoGenerateColumns="False" 
                Width="728px" AllowPaging="True" PageSize="25">
                <RowStyle ForeColor="#000066" />
                <Columns>
                    <asp:TemplateField HeaderText="Mã sách" SortExpression="Product_ID">
                        <ItemTemplate>
                            <asp:Label ID="lbMaSP" runat="server" Text='<%# Bind("Product_ID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Product_ID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Price_Export" HeaderText="Giá bán" 
                        SortExpression="Price_Export" />
                    <asp:BoundField DataField="Amount" HeaderText="Số lượng" 
                        SortExpression="Amount" />
                    <asp:BoundField DataField="Money" HeaderText="Thành tiền " 
                        SortExpression="Money" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#FF3399" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>
        <br />
    </div>
</asp:Content>
