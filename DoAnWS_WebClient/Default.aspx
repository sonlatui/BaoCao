<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
    
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <div align="right">
    <h1 align="left"> THÔNG TIN TÁC GIẢ TÁC PHẨM</h1>
    <asp:Panel ID="Panel1" runat="server">
    
    ID<asp:TextBox ID="Txb_username" runat="server"></asp:TextBox>
    Password<asp:TextBox ID="Txb_password" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="Btt_Login" runat="server" Text="Login" 
            onclick="Btt_Login_Click" />
            
    
    </asp:Panel>
    <asp:Button ID="Btt_Logout" runat="server" Text="Logout" 
            onclick="Btt_Logout_Click" Visible="False" />
    </div>
    <div>
        <asp:TextBox ID="Txb_tim" runat="server"></asp:TextBox>Tìm<asp:DropDownList
        ID="Ddl_theotg" runat="server">
        <asp:ListItem Value="1">Tiểu Sử Theo Tên Tác Giả</asp:ListItem>
        <asp:ListItem Value="2">Tên Tác Giả Theo Tiểu Sử</asp:ListItem>
            <asp:ListItem Value="3">Tên Tác Phẩm Theo Tên Tác Giả </asp:ListItem>
            <asp:ListItem Value="4">Nội Dung TP Theo Tên Tác Phẩm</asp:ListItem>
            <asp:ListItem Value="5">Tên Tác Phẩm Theo Thể Loại</asp:ListItem>
            <asp:ListItem Value="6">Tên Tác Phẩm Theo Nội Dung</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Btt_Tim" runat="server" onclick="Btt_Tim_Click" Text="Tìm" />
    </div>
    <div>
    </div>
    
   
    <asp:Literal ID="Lit_ketqua" runat="server"></asp:Literal>

    <div>
        <asp:Table ID="Table1" runat="server" BorderStyle="Solid">
        </asp:Table>
    </div>
   
    </asp:PlaceHolder>
    
    <asp:PlaceHolder ID="ph_admin" runat="server" Visible="False">
        <asp:Button ID="btt_adminthemtg" runat="server" Text="Thêm Tác Giả" 
        onclick="btt_adminthemtg_Click" />
    <asp:Button ID="btt_adminthemtp" runat="server" Text="Thêm Tác Phẩm" 
        onclick="btt_adminthemtp_Click" />
        <asp:PlaceHolder ID="ph_themtacgia" runat="server">
    <div>
    <table align="left">
    <tr><td>Tên tác giả:</td><td><asp:TextBox ID="txb_themtg" runat="server" Width="500px"></asp:TextBox></td> </tr>
     <tr><td>Tiểu sử:</td><td> <asp:TextBox ID="txb_themts" runat="server" Width="500px" Height="200px"></asp:TextBox> </td> </tr>
      <tr><td></td><td><asp:Button ID="btt_them" runat="server" Text="Thêm" 
              onclick="btt_them_Click1" /></td></tr>
      <tr><td></td><td><asp:Label ID="lbl_them" runat="server" Text=""></asp:Label></td></tr>
        </table>
        </div>
        </asp:PlaceHolder>
        <br />
        <asp:PlaceHolder ID="ph_themtacpham" runat="server">
        <div>
        <table align="left">
    <tr><td>Tên tác phẩm:</td><td><asp:TextBox ID="txt_themtentp" runat="server" Width="500px"></asp:TextBox></td> </tr>
     <tr><td>Thể loại:</td><td> <asp:TextBox ID="txt_themtheloai" runat="server" Width="500px"></asp:TextBox> </td> </tr>
     <tr><td>Nội dung:</td><td> <asp:TextBox ID="txt_themnoidung" runat="server" Width="500px" Height="200px"></asp:TextBox> </td> </tr>
     <tr><td>Tên tác giả:</td><td><asp:TextBox ID="txt_themtentg" runat="server" Width="500px"></asp:TextBox></td> </tr>
      <tr><td></td><td><asp:Button ID="btt_themtp" runat="server" Text="Thêm" 
              onclick="btt_themtp_Click" /></td></tr>
      <tr><td></td><td><asp:Label ID="lbl_themtp" runat="server" Text=""></asp:Label></td></tr>
        </table>
    </div>
    </asp:PlaceHolder>
    </asp:PlaceHolder>
    </asp:Content>
