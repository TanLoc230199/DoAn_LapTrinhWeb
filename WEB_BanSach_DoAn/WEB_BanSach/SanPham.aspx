<%@ Page Title="" Language="C#" MasterPageFile="~/TrangChu.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="WEB_BanSach.SanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Con1" runat="server">
    <link href="CSS/Giaodien.css" rel="stylesheet" type="text/css" />
<div class="daukhungmain">
    <asp:Label ID="lblTieuDe" runat="server" Font-Bold="False" Font-Names="Arial" 
        Font-Size="Large" ForeColor="#333333"></asp:Label>
    </div>
    <div style="margin-left:10px">
    <asp:DataList ID="sanpham" runat="server" HorizontalAlign="Center" 
        RepeatColumns="3" Width="100%" DataKeyField="Product_ID" 
        RepeatDirection="Horizontal">
        <ItemTemplate>
        <div class="khungsanpham">
        <div class="khunganh">
        <a href='<%# "ChiTiet.aspx?Product_ID="+Eval("Product_ID") %>'>
        <img id="anh" runat="server" src='<%# "~/AnhSanPham/"+Eval("Image") %>' />
       </a>
       </div>
            <div class="dong">
                <asp:HyperLink ID="HyperLink3" runat="server" Font-Size="10pt" 
                    ForeColor="#333333" Text='<%# Eval("Product_Name") %>' 
                    NavigateUrl='<%# "ChiTiet.aspx?Product_ID="+Eval("Product_ID") %>' Font-Underline="False"
                   ></asp:HyperLink>
                  
             </div>
             <div class="dong">
                &nbsp;<asp:Label ID="Label1" runat="server" ForeColor="#CC0000" 
                    Text='<%# Eval("Price_Export") %>' Font-Size="11pt"></asp:Label>
                <asp:Label ID="Label3" runat="server" ForeColor="#CC0000" Text="VNĐ" 
                     Font-Size="11pt"></asp:Label>
                 
            </div>
            
                </div>
        
        </ItemTemplate>
    </asp:DataList>
    </div>
    <div style=" float:right; width:150px;">
        <asp:LinkButton ID="LbtBack" runat="server" onclick="LbtBack_Click" >&lt;&lt;Back</asp:LinkButton>
        <asp:Label ID="LblPage" runat="server" Text="Page"></asp:Label>
        <asp:LinkButton ID="LbtNext" runat="server" onclick="LbtNext_Click">Next&gt;&gt;</asp:LinkButton>
    </div>
</asp:Content>