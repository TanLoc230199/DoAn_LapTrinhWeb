<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ThongKeDoanhThu.aspx.cs" Inherits="WEB_BanSach.Admin.ThongKeDoanhThu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <center>
            <span class="style2">THỐNG KÊ DOANH THU</span>
        </center>
        <hr width="60%" />
    </div>
    <br />
    <div>
        <table cellpadding="0" cellspacing="0" class="style3" align="center">
            <tr>
                <td class="style4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                Height="84px" Width="161px">
                                <asp:ListItem>Theo ngày</asp:ListItem>
                                <asp:ListItem>Theo khoảng thời gian</asp:ListItem>
                                <asp:ListItem>Theo năm</asp:ListItem>
                            </asp:RadioButtonList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Label ID="lbl1" runat="server" Text="Nhập ngày: "></asp:Label>
                    <asp:TextBox ID="txtNgay" runat="server"></asp:TextBox>
                    <asp:Calendar ID="txtNgay_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtNgay" OnSelectionChanged="txtNgay_CalendarExtender_SelectionChanged">
                    </asp:Calendar>
                    <br />
                    <asp:Label ID="lblNgay0" runat="server" Text="Từ ngày: "></asp:Label>
                    <asp:TextBox ID="txtTungay" runat="server"></asp:TextBox>
                    <asp:Calendar ID="txtTungay_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTungay" OnSelectionChanged="txtTungay_CalendarExtender_SelectionChanged">
                    </asp:Calendar>
                    &nbsp;<asp:Label ID="lblNgay" runat="server" Text="Đến ngày: "></asp:Label>
                    <asp:TextBox ID="txtDenngay" runat="server"></asp:TextBox>
                    <asp:Calendar ID="txtDenngay_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtDenngay" OnSelectionChanged="txtDenngay_CalendarExtender_SelectionChanged">
                    </asp:Calendar>
                    <br />
                    Nhập năm:
                    <asp:TextBox ID="txtNam" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
    <center>
    <asp:Button ID="btnThongke" runat="server" Text="Thống kê" 
            onclick="btnThongke_Click" />
        <br />
                    <asp:Label ID="lblThongBao" runat="server"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            style="text-align: center" Width="90%">
            <RowStyle ForeColor="#000066" />
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Doanh thu:"></asp:Label>
&nbsp;
        <asp:Label ID="Label1" runat="server" style="font-weight: 700"></asp:Label>
    </center>
    </div>
    
</asp:Content>

