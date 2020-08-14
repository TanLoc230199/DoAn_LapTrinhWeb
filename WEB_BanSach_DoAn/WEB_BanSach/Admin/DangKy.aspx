<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="WEB_BanSach.Admin.DangKy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="2" style="text-align: center; color: blue;" >
                ĐĂNG KÝ NHÂN VIÊN</td>
        </tr>
        <tr>
            <td>Tên đầy đủ:</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Ngày sinh:</td>
            <td>
                <asp:Calendar ID="txtNgay" runat="server" Enabled="true"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>Giới tính:</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="94px">
                    <asp:ListItem>Nam</asp:ListItem>
                    <asp:ListItem>Nữ</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Địa chỉ:</td>
            <td>
                <asp:TextBox ID="txtDiachi" runat="server" Height="22px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Height="22px" Width="250px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email không đúng định dạng" style="font-size: small" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Số điện thoại:</td>
            <td>
                <asp:TextBox ID="txtSDT" runat="server" Height="22px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnDangki" runat="server" OnClick="btnDangki_Click" Text="Đăng kí" />
            </td>
        </tr>
    </table>
</asp:Content>
