<%@ Page Title="" Language="C#" MasterPageFile="~/TrangChu.Master" AutoEventWireup="true" CodeBehind="LuuYKhiMuaHang.aspx.cs" Inherits="WEB_BanSach.LuuYKhiMuaHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Con1" runat="server">
<div class="daukhungmain">
    <asp:Label ID="lblTieuDe" runat="server" Font-Bold="False" Font-Names="Arial" 
        Font-Size="Large" ForeColor="#333333" Text="Lưu ý khi mua hàng"></asp:Label>
    </div>
    <div style="margin:10px;">
    1. Đọc kĩ <a href="Huongdanmuahang.aspx" style="color: #FF0000">Hướng dẫn mua hàng</a> trước khi mua hàng<br /><br />

    3. Nhân viên của chúng tôi sẵn sàng giao hàng đến tận nơi cho bạn.<br />

    Bạn vui lòng chắc chắn lấy các sản phẩm mà chúng tôi mang đến.<br /><br />

    4. Hàng đã giao đến tận nơi xin quý khách không trả lại.<br />
        Các sản phẩm mua rồi miễn trả lại vì thế các bạn cân nhắc trước khi mua.<br /><br />
    
    5. Giá ship và điều kiện giao hàng miễn phí xem tại mục <a href="PhiGiaoHang.aspx" 
            style="color: #FF0000">Phí giao hàng</a>.
    </div>
</asp:Content>
