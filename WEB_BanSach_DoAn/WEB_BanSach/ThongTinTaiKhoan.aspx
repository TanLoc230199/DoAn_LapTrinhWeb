<%@ Page Title="" Language="C#" MasterPageFile="~/TrangChu.Master" AutoEventWireup="true" CodeBehind="ThongTinTaiKhoan.aspx.cs" Inherits="WEB_BanSach.ThongTinTaiKhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 617px;
        }
        .style5
        {
            width: 355px;
        }
        .style6
        {
            width: 154px;
        }
        
        .style7
        {
            height: 33px;
        }
        
        .style8
        {
            height: 30px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Con1" runat="server">
    <div class="daukhungmain">
<asp:Label ID="tieude" runat="server" Text="Thông tin tài khoản" Font-Names="Arial" 
        Font-Size="Large" ForeColor="Black"></asp:Label> 
</div>
    <asp:Panel ID="Panel1" runat="server">
    <div class="khungthanhtoan">
    <table class="style1">
        <tr>
            <td class="style6">
                <b>Thông tin tài khoản</b></td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Tên đăng nhập:</td>
            <td class="style5">
                <asp:Label ID="lblTenDN" runat="server" Text="(Chưa có thông tin)" 
                    Font-Bold="True"></asp:Label>
                                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Mật khẩu:</td>
            <td class="style5">
                <asp:Label ID="lblMatKhau" runat="server" Text="(Chưa có thông tin)"></asp:Label>
                                </td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Cập nhật</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <b>Thông tin cá nhân</b></td>
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Cập nhật</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Tên đầy đủ:</td>
            <td class="style5">
                <asp:Label ID="lblTen" runat="server" 
                    Text="(Chưa có thông tin)"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Địa chỉ:</td>
            <td class="style5">
                <asp:Label ID="lblDiaChi" runat="server" 
                    Text="(Chưa có thông tin)"></asp:Label>
                                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Số điện thoại:</td>
            <td class="style5">
                <asp:Label ID="lblSDT" runat="server" 
                    Text="(Chưa có thông tin)"></asp:Label>
                                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Email:</td>
            <td class="style5">
                <asp:Label ID="lblEmail" runat="server" 
                    Text="(Chưa có thông tin)"></asp:Label>
                                </td>
            <td>
                &nbsp;</td>
        </tr>
    </table></div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
    <div class="khungthanhtoan">
    <table cellpadding="0" cellspacing="0" class="style2">
                <tr>
                    <td class="style7" >
                        <asp:Label ID="Label4" runat="server" Text="Thông tin cá nhân" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style7" >
                        </td>
                </tr>
                <tr>
                    <td class="style8" >
                        Tên đầy đủ:
                    </td>
                    <td class="style8" >
                        <asp:TextBox ID="txtTendaydu" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td class="style8" >
                        Địa chỉ:
                    </td>
                    <td class="style8" >
                        <asp:TextBox ID="txtDiachi" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style8" >
                        Quận/Huyện:</td>
                    <td class="style8" >
                        <asp:TextBox ID="txtQuanHuyen" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style8" >
                        Tỉnh/Thành phố:</td>
                    <td class="style8" >
                        <asp:TextBox ID="txtTinhThanh" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style8" >
                        Quốc gia:</td>
                    <td class="style8" >
                        <asp:TextBox ID="txtQuocGia" runat="server" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style8" >
                        Số điện thoại:
                    </td>
                    <td class="style8" >
                        <asp:TextBox ID="txtSDT" runat="server" Width="220px"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ErrorMessage="Số điện thoại phải là số" ControlToValidate="txtSDT" 
                             MaximumValue="99999999999" MinimumValue="1"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        Email:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtEmail" runat="server" Width="220px" 
                            ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtEmail" ErrorMessage="Email không đúng định dạng" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            </div>
         <div class="khungthanhtoan" style="text-align:right; margin-top:1px; margin-bottom:1px;">
        <asp:ImageButton ID="btnQuayLai1" runat="server" ImageUrl="Anh/quaylai.jpg" 
            Width="81.5" Height="25" ImageAlign="Left"
                  PostBackUrl="~/Thongtintaikhoan.aspx" />
        <asp:ImageButton ID="btnCapNhat" runat="server" Height="25px" 
             ImageUrl="~/Anh/capnhat.jpg" Width="81px" ImageAlign="Middle" 
            onclick="btnTiepTuc1_Click" /></div>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server">
    <div class="khungthanhtoan">
    <table cellpadding="0" cellspacing="0" class="style2">
                <tr>
                    <td class="style8">
                        Mật khẩu hiện tại:
                    </td>
                    <td class="style8" >
                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="220px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Chưa điền mật khẩu" ControlToValidate="txtPass" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                       Mật khẩu mới:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtNewPass" runat="server" Width="220px" TextMode="Password"></asp:TextBox>
                        
                    </td>
                </tr>
               <tr>
                    <td class="style8">
                        Xác nhận mật khẩu:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="RePass" runat="server" Width="220px" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator
                            ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu không giống nhau" ControlToValidate="RePass" 
                            ControlToCompare="txtNewPass">
                            </asp:CompareValidator>
                    </td>
                </tr>
            </table>
        <div style="text-align:center"><asp:Label ID="Label1" runat="server" Text="Label" 
                ForeColor="Red"></asp:Label>  </div>   
           </div>
            <div class="khungthanhtoan" style="text-align:right; margin-top:1px; margin-bottom:1px;">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Anh/quaylai.jpg" 
            Width="81.5" Height="25" ImageAlign="Left" onclick="ImageButton1_Click"
                />
        <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" 
             ImageUrl="~/Anh/capnhat.jpg" Width="81px" ImageAlign="Middle" onclick="ImageButton2_Click" 
             /></div>
    </asp:Panel>
</asp:Content>

