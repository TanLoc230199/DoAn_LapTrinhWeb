<%@ Page Title="" Language="C#" MasterPageFile="~/TrangChu.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="WEB_BanSach.DangKy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 100%;
            height: 114px;
        }
        .style3
        {
            font-size: small;
            font-family: Arial, Helvetica, sans-serif;
            text-align: left;
            width: 22%;
        }
    .style4
    {
        color: #FF0000;
    }
        .style5
        {
            font-size: small;
            font-family: Arial, Helvetica, sans-serif;
            text-align: left;
            width: 22%;
            height: 26px;
        }
        .style6
        {
            height: 26px;
        }
        .style7
        {
            font-size: small;
            font-family: Arial, Helvetica, sans-serif;
            text-align: left;
            width: 22%;
            height: 28px;
        }
        .style8
        {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Con1" runat="server">
    <div class="daukhungmain">
<asp:Label ID="Label2" runat="server" Text="ĐĂNG KÍ TÀI KHOẢN" Font-Names="Arial" 
        Font-Size="Large" ForeColor="Black"></asp:Label>
</div>
<div class="khungthanhtoan">
            <table cellpadding="0" cellspacing="0" class="style2">
                <tr>
                    <td class="style5">
                        <asp:Label ID="Label4" runat="server" Text="Thông tin cá nhân" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style6">
                        </td>
                </tr>
                <tr>
                    <td class="style7">
                        Tên đầy đủ:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtTendaydu" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td class="style7">
                        Địa chỉ:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtDiachi" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Quận/Huyện:</td>
                    <td class="style8">
                        <asp:TextBox ID="txtQuanHuyen" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Tỉnh/Thành phố:</td>
                    <td class="style8">
                        <asp:TextBox ID="txtTinhThanh" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Quốc gia:</td>
                    <td class="style8">
                        <asp:TextBox ID="txtQuocGia" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Số điện thoại:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtSDT" runat="server" Width="220px"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ErrorMessage="Số điện thoại phải là số" ControlToValidate="txtSDT" 
                             MaximumValue="99999999999" MinimumValue="1"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        Email:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtEmail" runat="server" Width="220px" 
                            ontextchanged="TextBox4_TextChanged"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtEmail" ErrorMessage="Email không đúng định dạng" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </div>
        <div class="khungthanhtoan">
        <table cellpadding="0" cellspacing="0" class="style2">
                <tr>
                    <td class="style7">
                        <asp:Label ID="Label3" runat="server" Text="Thông tin tài khoản" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style8">
                        </td>
                </tr>
                <tr>
                    <td class="style7">
                        <span class="style4">*</span>
                        Tên đăng nhập:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtUser" runat="server" Width="220px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Chưa điền tên tài khoản" ControlToValidate="txtUser" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        <span class="style4">* </span>Mật khẩu:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtPass" runat="server" Width="220px" TextMode="Password"></asp:TextBox>
                        
                    </td>
                </tr>
               <tr>
                    <td class="style7">
                        <span class="style4">* </span>Xác nhận mật khẩu:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="RePass" runat="server" Width="220px" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator
                            ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu không giống nhau" ControlToValidate="RePass" 
                            ControlToCompare="txtPass">
                            </asp:CompareValidator>
                    </td>
                </tr>
            </table>
        </div>
        
        <center>
            <asp:Label ID="Label1" runat="server" Text="" style="color: #FF0000"></asp:Label><br />
            <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" 
                ImageUrl="~/Anh/taotaikhoan.jpg" onclick="ImageButton1_Click" Width="138px" />
            <br />
        </center>
        
    
</asp:Content>
