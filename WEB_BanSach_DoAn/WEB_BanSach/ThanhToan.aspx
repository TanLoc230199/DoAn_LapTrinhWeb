<%@ Page Title="" Language="C#" MasterPageFile="~/TrangChu.Master" AutoEventWireup="true" CodeBehind="ThanhToan.aspx.cs" Inherits="WEB_BanSach.ThanhToan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 96%;
        }
        .style2
        {
            font-size: small;
            font-family: Arial, Helvetica, sans-serif;
            text-align: left;
            width: 22%;
            height: 28px;
        }
        .style3
        {
            width: 98%;
        }
        .style4
        {
            width: 158px;
        }
        .style5
        {
            width: 348px;
        }
        .style6
        {
            width: 96%;
        }
        .style7
        {
            width: 210px;
        }
        .style8
        {
        	color: #FF0000;
        }
        
        #TextArea1
        {
            width: 365px;
            height: 65px;
        }
        #txtMS
        {
            width: 362px;
            height: 73px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Con1" runat="server">
    <div class="daukhungmain">
<asp:Label ID="Label1" runat="server" Text="THANH TOÁN" Font-Names="Arial" 
        Font-Size="Large" ForeColor="Black"></asp:Label>
</div>
    <asp:Panel ID="Panel1" runat="server">
    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Địa chỉ thanh toán" Font-Bold="True"></asp:Label><br />
    &nbsp;&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" 
        Text="Địa chỉ thanh toán giống thông tin tài khoản" AutoPostBack="True" 
            oncheckedchanged="CheckBox1_CheckedChanged" /><br />
    <div class="khungthanhtoan">
        <table class="style1">
            <tr>
                <td class="style2">
                <span class="style8">*</span>
                    Họ tên:
                </td>
                <td>
                    <asp:TextBox ID="txtHoTen1" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Chưa điền họ tên" ControlToValidate="txtHoTen1" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span class="style8">*</span>
                    Địa chỉ:
                </td>
                <td>
                    <asp:TextBox ID="txtDiaChi1" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Chưa điền địa chỉ" ControlToValidate="txtDiaChi1" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span class="style8">*</span>
                    Quận/Huyện:
                </td>
                <td>
                    <asp:TextBox ID="txtQuanHuyen1" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Chưa điền quận/huyện" ControlToValidate="txtQuanHuyen1" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span class="style8">*</span>
                    Tỉnh/Thành Phố:
                </td>
                <td>
                    <asp:TextBox ID="txtTinh1" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="Chưa điền tỉnh/thành phố" ControlToValidate="txtTinh1" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span class="style8">*</span>
                    Quốc gia:
                </td>
                <td>
                    <asp:TextBox ID="txtQuocGia1" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="Chưa điền quốc gia" ControlToValidate="txtQuocGia1" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Số điện thoại:
                </td>
                <td>
                    <asp:TextBox ID="txtSDT1" runat="server" Width="140px"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ErrorMessage="Số điện thoại phải là số" ControlToValidate="txtSDT1" 
                             MaximumValue="99999999999" MinimumValue="1"></asp:RangeValidator>
                </td>
            </tr>
        </table>
    </div>
    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Địa chỉ giao hàng" Font-Bold="True"></asp:Label><br />
    &nbsp;&nbsp;<asp:CheckBox ID="CheckBox2" runat="server" 
        Text="Địa chỉ giao hàng giống địa chỉ thanh toán" AutoPostBack="True" 
            oncheckedchanged="CheckBox2_CheckedChanged" /><br />
    <div class="khungthanhtoan">
     <table class="style1">
            <tr>
                <td class="style2">
                    <span class="style8">*</span>
                    Họ tên:
                </td>
                <td>
                    <asp:TextBox ID="txtHoTen2" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="Chưa điền họ tên" ControlToValidate="txtHoTen2" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span class="style8">*</span>
                    Địa chỉ:
                </td>
                <td>
                    <asp:TextBox ID="txtDiaChi2" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ErrorMessage="Chưa điền địa chỉ" ControlToValidate="txtDiaChi2" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span class="style8">*</span>
                    Quận/Huyện:
                </td>
                <td>
                    <asp:TextBox ID="txtQuanHuyen2" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ErrorMessage="Chưa điền quận/huyện" ControlToValidate="txtQuanHuyen2" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span class="style8">*</span>
                    Tỉnh/Thành Phố:
                </td>
                <td>
                    <asp:TextBox ID="txtTinh2" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ErrorMessage="Chưa điền tỉnh/thành phố" ControlToValidate="txtTinh2" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span class="style8">*</span>
                    Quốc gia:
                </td>
                <td>
                    <asp:TextBox ID="txtQuocGia2" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ErrorMessage="Chưa điền quốc gia" ControlToValidate="txtQuocGia2" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Số điện thoại:
                </td>
                <td>
                    <asp:TextBox ID="txtSDT2" runat="server" Width="140px"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" 
                        ErrorMessage="Số điện thoại phải là số" ControlToValidate="txtSDT2" 
                             MaximumValue="99999999999" MinimumValue="1"></asp:RangeValidator>
                </td>
            </tr>
        </table>
    </div>
    <div class="khungthanhtoan" style="text-align:right; margin-top:1px; margin-bottom:1px;">
        <asp:ImageButton ID="btnQuayLai1" runat="server" ImageUrl="Anh/quaylai.jpg" 
            Width="81.5" Height="25" ImageAlign="Left" PostBackUrl="~/GioHang.aspx" />
        <asp:ImageButton ID="btnTiepTuc1" runat="server" Height="25px" 
             ImageUrl="~/Anh/tieptuc.jpg" Width="81px" ImageAlign="Middle" 
            onclick="btnTiepTuc1_Click" /></div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Hình thức vận chuyển" Font-Bold="True"></asp:Label>
    <div class="khungthanhtoan">
        <table class="style6">
            <tr>
                <td class="style7">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="Transport_Name" 
                        DataValueField="Transport_Name" ValidationGroup="Check" 
                        AutoPostBack="True">
                    </asp:RadioButtonList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT [Transport_Name] FROM [tbl_Transport]">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <asp:CheckBox ID="CheckGoiQua" runat="server" Text="Gói quà" />
                    <br />
                    <asp:TextBox ID="txtGoiQua" runat="server" Height="24px" Width="364px"></asp:TextBox>
                    <br />
                </td>
            </tr>
        </table>
        
    </div>
    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="Hình thức thanh toán" Font-Bold="True"></asp:Label>
    <div class="khungthanhtoan">
        <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
            DataSourceID="SqlDataSource2" DataTextField="Pay_Name" 
            DataValueField="Pay_Name">
        </asp:RadioButtonList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [Pay_Name] FROM [tbl_Payment]"></asp:SqlDataSource>
    </div>
    <div class="khungthanhtoan" style="text-align:right; margin-top:1px; margin-bottom:1px;">
        <asp:ImageButton ID="btnQuayLai2" runat="server" ImageUrl="Anh/quaylai.jpg" 
            Width="81.5" Height="25" ImageAlign="Left" onclick="btnQuayLai2_Click" />
        <asp:ImageButton ID="btnTiepTuc2" runat="server" Height="25px" 
             ImageUrl="~/Anh/tieptuc.jpg" Width="81px" ImageAlign="Middle" 
            onclick="btnTiepTuc2_Click" /></div>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server">
    <div class="khungthanhtoan">
        <table class="style3">
            <tr>
                <td class="style4">
                    <asp:Label ID="Label18" runat="server" Font-Bold="True" 
                        Text="Địa chỉ thanh toán"></asp:Label>
                </td>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    <asp:LinkButton ID="LinkThayDoiDCTT" runat="server" 
                        onclick="LinkThayDoiDCTT_Click">Thay đổi</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Họ tên:</td>
                <td class="style5">
                    <asp:Label ID="lblHoTen" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Địa chỉ&nbsp;:</td>
                <td class="style5">
                    <asp:Label ID="lblDiaChi" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Số điện thoại:</td>
                <td class="style5">
                    <asp:Label ID="lblSDT" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label19" runat="server" Font-Bold="True" 
                        Text="Địa chỉ giao hàng"></asp:Label>
                </td>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    <asp:LinkButton ID="LinkThayDoiDCGH" runat="server" 
                        onclick="LinkThayDoiDCGH_Click">Thay đổi</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Họ tên:</td>
                <td class="style5">
                    <asp:Label ID="lblHoTen0" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Địa chỉ:</td>
                <td class="style5">
                    <asp:Label ID="lblDiaChi0" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Số điện thoại:</td>
                <td class="style5">
                    <asp:Label ID="lblSDT0" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label20" runat="server" Font-Bold="True" 
                        Text="Hình thức vận chuyển"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblHTVC" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="LinkThayDoiHTVC" runat="server" 
                        onclick="LinkThayDoiHTVC_Click">Thay đổi</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Gói quà:</td>
                <td class="style5">
                    <asp:Label ID="lblgoiqua" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Lới nhắn:</td>
                <td class="style5">
                    <asp:Label ID="lblLoiNhan" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" 
                        Text="Hình thức thanh toán"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="lblHTTT" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="LinkThayDoiHTTT" runat="server" 
                        onclick="LinkThayDoiHTTT_Click">Thay đổi</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div class="khungthanhtoan">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" Font-Size="Medium"  
         Width="100%">
         <RowStyle BackColor="White" ForeColor="#003399" />
        <Columns>
            <asp:TemplateField HeaderText="Tên sản phẩm">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="False" 
                        ForeColor="Red" 
                        NavigateUrl='<%# "Chitiet.aspx?Product_ID="+Eval("Product_ID") %>' 
                        Text='<%# Bind("Product_Name") %>'></asp:HyperLink>
                </ItemTemplate>
                <HeaderStyle BackColor="Silver" ForeColor="Black" />
                <ItemStyle ForeColor="Red" />
            </asp:TemplateField>
            <asp:BoundField DataField="Amount" HeaderText="SL">
                <HeaderStyle BackColor="Silver" ForeColor="Black" />
            </asp:BoundField>
            <asp:BoundField DataField="Price_Export" HeaderText="Giá">
                <HeaderStyle BackColor="Silver" ForeColor="Black" />
            </asp:BoundField>
            <asp:BoundField DataField="Size" HeaderText="Size">
                <HeaderStyle BackColor="Silver" ForeColor="Black" />
            </asp:BoundField>
            <asp:BoundField DataField="Color" HeaderText="Màu">
                <HeaderStyle BackColor="Silver" ForeColor="Black" />
            </asp:BoundField>
            <asp:BoundField DataField="Material" HeaderText="Chất liệu">
                <HeaderStyle BackColor="Silver" ForeColor="Black" />
            </asp:BoundField>
            <asp:BoundField DataField="Weight" HeaderText="Trọng lượng">
                <HeaderStyle BackColor="Silver" ForeColor="Black" />
            </asp:BoundField>
            <asp:BoundField DataField="Product_ID" HeaderText="Mã SP">
                <HeaderStyle BackColor="Silver" ForeColor="Black" />
            </asp:BoundField>
            <asp:BoundField DataField="Money" HeaderText="Tiền">
                <HeaderStyle BackColor="Silver" ForeColor="Black" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <EmptyDataTemplate>
            <asp:TextBox ID="TextBox1" runat="server" Height="25px" 
                Text='<%# Bind("SL") %>' Width="41px"></asp:TextBox>
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
    </asp:GridView>
    <div style="text-align:right">
            Tiền mua hàng:  <asp:Label ID="lbltienmuahang" runat="server" ></asp:Label><br />
            Tổng trọng lượng: <asp:Label ID="lbltongtrongluong" runat="server"></asp:Label><br />
            Phí vận chuyển:  <asp:Label ID="lblPhiVanChuyen" runat="server" ></asp:Label><br />
            Phí gói hàng:  <asp:Label ID="lblPhiGoiHang" runat="server"></asp:Label><br />
            Tổng tiền:  <asp:Label ID="lblTongTien" runat="server" ></asp:Label>
    </div>
    </div>
    <div class="khungthanhtoan" style="text-align:right; margin-top:1px; margin-bottom:1px;">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Anh/quaylai.jpg" 
            Width="81.5" Height="25" ImageAlign="Left" onclick="ImageButton1_Click" />
        <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" 
             ImageUrl="~/Anh/xacnhanthanhtoan.jpg" Width="207px" ImageAlign="Middle" 
            onclick="ImageButton2_Click" /></div>
</asp:Panel>
<asp:Panel ID="Panel4" runat="server">
<div class="khungthanhtoan">
<p>Đơn hàng của bạn đã được chấp nhận!<br />
Để hiểu rõ hơn về cách mua hàng và thanh toán, mời bạn xem mục <a href="Huongdanmuahang.aspx">hướng dẫn mua hàng</a><br />
    Cảm ơn bạn quý khách đã mua hàng tại Sách Online Of Lộc!</p>
</div>
</asp:Panel>
</asp:Content>

