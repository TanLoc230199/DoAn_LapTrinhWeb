<%@ Page Title="" Language="C#" MasterPageFile="~/TrangChu.Master" AutoEventWireup="true" CodeBehind="PhiGiaoHang.aspx.cs" Inherits="WEB_BanSach.PhiGiaoHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 194px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Con1" runat="server">
<div class="daukhungmain">
    <asp:Label ID="lblTieuDe" runat="server" Font-Bold="False" Font-Names="Arial" 
        Font-Size="Large" ForeColor="#333333" Text="Phí giao hàng"></asp:Label>
    </div>
    <div style="margin-left:10px;">
    <asp:Image ID="Image2" runat="server" ImageAlign="Baseline" 
        ImageUrl="~/Anh/shipping.jpg" />
    </div>
    <div style="margin:10px">
    Để kĐể khách hàng có lựa chọn phù hợp, chúng tôi xin đưa ra bảng giá như sau:
    </div>
    <div style="text-align:center; color: #FF6600; font-size:large"><b>Tại Q. Gò Vấp</b></div>
    <div style="margin:10px">
    Đối với địa chỉ giao hàng tại Q. Gò Vấp, chúng tôi miễn phí cước vận chuyển hàng cho khách hàng.
    Nhưng khách hàng lưu ý, khi thanh toán các bạn phải lựa chọn hình thức vận chuyển là <i style="color:Red">Giao hàng trực tiếp.
 .
    Nếu các khách hàng không phải ở Q. Gò Vấp mà chọn giao hàng trực tiếp, thì đơn hàng của các bạn không hợp lệ,
    chúng tôi sẽ không chuyển hàng cho bạn.
    </div>
    <div style="text-align:center; color: #FF6600; font-size:large"><b>Tại các địa chỉ khác</div>
    <div style="margin:10px">
    
        <table class="style1">
            <tr>
                <td class="style2">
    
    <asp:Image ID="Image1" runat="server" ImageUrl="Anh/chuyenphatnhanh.jpg" Height="133px" 
                        Width="142px" />
                </td>
                <td>
                    &nbsp;<b>1.Chuyển phát nhanh</b><br />
    Chúng tôi sẽ tính phí chuyển phát nhanh theo trọng lượng. Cụ thể là 100đ/g.<br />
    Công thức tính: tổng trọng lượng gói hàng(tính bằng gam)*100<br />
    Đố với hình thức chuyển phát nhanh này, các bạn sẽ rất nhanh chóng nhận được hàng: khoảng từ 12 đến 24h</td>
            </tr>
            <tr>
                <td class="style2">
    
                    <asp:Image ID="Image5" runat="server" Height="164px" 
                        ImageUrl="~/Anh/chuyenbuupham.jpg" Width="168px" />
                </td>
                <td>
                    &nbsp;<b>1.Chuyển bưu phẩm qua bưu điện</b><br />
    Chúng tôi sẽ tính phí gửi bưu phẩm qua bưu điện theo trọng lượng. Cụ thể là 40đ/g.<br />
    Công thức tính: tổng trọng lượng gói hàng(tính bằng gam)*40<br />
    Đối với hình thức vận chuyển này chi phí thấp nhưng thời gian vận chuyển khá lâu, 
    nhất là đối với các tỉnh thành xa.</td>
            </tr>
            <tr>
                <td class="style2">
    
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Anh/chuyenbangoto.jpg" />
                </td>
                <td>
                    &nbsp;<b>1.Chuyển bằng ô tô</b><br />
                    Chúng tôi sẽ tính phí vận chuyển trung bình là 25.000đ/1 gói hàng<br />
                    Phí này áp dụng với tất cả các địa chỉ giao hàng trong cả nước. 
                    Thời gian nhận được hàng trong vòng 2 ngày, tùy vào khoảng cách địa lý</td>
            </tr>
        </table>
    Trên đây là bảng phí vận chuyển. Khách hàng, tùy vào hoàn cảnh, điều kiện của mình chọn loại hình vận chuyển phù hợp nhất!
    <br />Chúc các bạn sẽ sở hữu được sản phẩm ưng ý!
    
    </div>
</asp:Content>
