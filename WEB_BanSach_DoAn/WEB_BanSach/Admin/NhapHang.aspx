<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="NhapHang.aspx.cs" Inherits="WEB_BanSach.Admin.NhapHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .khungNH
        {
            width: 797px;
            margin-left: 0px;
            height: 607px;
        }
        .daukhungNH
        {
            color: Black;
            font-weight: bold;
            text-align: center;
            margin-top: auto;
            height: 25px;
        }
        .style8
        {
            width: 49%;
            text-align: right;
            color: #FFFFFF;
            font-family: Arial;
            font-size: small;
        }
        .style9
        {
            color: Black;
            text-align: center;
            margin-top: auto;
            height: 25px;
            font-family: Arial;
            font-size: large;
            width: 777px;
        }
        .style11
        {
            width: 238px;
            text-align: left;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="khungNH">
        <div style="width: 801px">
            <div class="style9">
                NHẬP HÀNG</div>
            <div>
                <hr style="width: 40%" />
            </div>
            <div style="width: 796px; margin-left: 0px">
                <table style="height: 69px; margin-top: 0px; width: 347px;" align="center">
                 <tr>
                        <td class="style8" style="color: #000000">
                            Mã hoá đơn:</td>
                        <td class="style11">
                            <asp:TextBox ID="txtMa" runat="server" Width="107px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="color: #000000">
                            Nhân viên nhập:
                        </td>
                        <td class="style11">
                            <asp:DropDownList ID="drNhanvien" runat="server" Height="23px" Width="150px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="color: #000000">
                            Ngày nhập:
                        </td>
                        <td class="style11">
                            <asp:TextBox ID="txtNgay" runat="server" Width="150px"></asp:TextBox>
                            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                            <asp:Label ID="Label2" runat="server" style="color: #FF0000; font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="color: #000000">
                            Nhà cung cấp:
                        </td>
                        <td class="style11">
                            <asp:DropDownList ID="DropDownList1" runat="server" 
                                DataSourceID="SqlDataSource1" DataTextField="Supplier_Name" 
                                DataValueField="Supplier_ID">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                SelectCommand="SELECT [Supplier_ID], [Supplier_Name] FROM [tbl_Supplier]">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
                <br />
                <div style="height: 42px; width: 798px;">
                    <center>
                        <asp:Button ID="btnNhap" runat="server" Text="Nhập" OnClick="btnNhap_Click" Width="60px" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnSua" runat="server" onclick="btnSua_Click1" Text="Sửa" 
                            Width="60px" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnXoa" runat="server" onclick="btnXoa_Click1" Text="Xoá" 
                            Width="60px" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Style="color: #0066FF"></asp:Label>
                        <br />
                    </center>
                </div>
                <br />
                <div style="height: 336px;">
                    <center>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="3" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
                            Style="text-align: center" onrowediting="GridView1_RowEditing" 
                            onrowupdating="GridView1_RowUpdating" Height="271px" PageSize="20" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <RowStyle ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="Mã hoá đơn" SortExpression="Import_ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lbMa" runat="server" Text='<%# Bind("Import_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nhân viên nhập" SortExpression="EmployeeID">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("EmployeeID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngày nhập" SortExpression="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nhà cung cấp" SortExpression="Supplier_ID">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Supplier_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField EditText="Chọn" HeaderText="Chọn" ShowCancelButton="False" 
                                    ShowEditButton="True" UpdateText="Huỷ" />
                                <asp:HyperLinkField DataNavigateUrlFields="Import_ID" 
                                    DataNavigateUrlFormatString="ChiTietNhap.aspx?Import_ID={0}" 
                                    HeaderText="Chi tiết" Text="Chi tiết&gt;&gt;" />
                            </Columns>
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#FF3399" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </center>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
