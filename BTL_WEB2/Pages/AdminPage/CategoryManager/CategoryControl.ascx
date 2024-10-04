<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryControl.ascx.cs" Inherits="BTL_WEB2.Pages.AdminPage.CategoryManager.CategoryControl" %>
<style type="text/css">
</style>
<div class="wrapper-content">
    <div class="main-content">
        <div class="title-btnAdd">
            <asp:Label ID="title" runat="server" Text="Quản lý danh mục"></asp:Label>
            <asp:Button CssClass="btnStyle" ID="btnAdd" runat="server" Text="Tạo danh mục mới" OnClick="AddButton_Onclick" />
        </div>
        <asp:MultiView ID="categoryView" runat="server" EnableViewState="true">
            <asp:View ID="ShowListView" runat="server">
                <asp:Table ID="CategoryTable" runat="server" CellPadding="10" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell CssClass="table-header">STT</asp:TableCell>
                        <asp:TableCell CssClass="table-header">Mã danh mục</asp:TableCell>
                        <asp:TableCell CssClass="table-header">Tên danh mục</asp:TableCell>
                        <asp:TableCell CssClass="table-header">Mô tả danh mục</asp:TableCell>
                        <asp:TableCell CssClass="table-header">Ảnh danh mục</asp:TableCell>
                        <asp:TableCell CssClass="table-header">Chỉnh sửa danh mục</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Label ID="lblEmptyTable" runat="server" CssClass="lblNoti" Height="50px" ></asp:Label>
            </asp:View>

            <asp:View ID="AddView" runat="server">
                <div class="container">
                    <asp:Label ID="lblError" runat="server" Text="" CssClass="error"></asp:Label>
                    <div class="row">
                        <div class="col">Mã danh mục</div>
                        <div class="col">
                            <asp:TextBox ID="txbMaDanhMuc" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">Tên danh mục</div>
                        <div class="col">
                            <asp:TextBox ID="txbTenDanhMuc" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">Mô tả danh mục</div>
                        <div class="col">
                            <asp:TextBox ID="txbMoTaDanhMuc" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:FileUpload ID="fileAnhDanhMuc" runat="server" />
                        </div>
                        <div>
                            <asp:Button runat="server" Text="Xem ảnh" BackColor="#FFD166" BorderStyle="None" ForeColor="White" OnClick="ReviewImageButton_Click" />
                        </div>
                    </div>
                </div>
                <div>
                    <asp:Image ID="Image1" CssClass="review-image" runat="server" ImageAlign="Middle" />
                </div>
                <asp:Button runat="server" Text="Thêm mới danh mục" Width="100%" BackColor="#06D6A0" BorderColor="White" BorderStyle="None" ForeColor="White" Height="40px" OnClick="SaveAddButton_Click" />
            </asp:View>

            <asp:View ID="EditView" runat="server">
                <div class="container">
                    <asp:Label ID="Label1" runat="server" Text="" CssClass="error"></asp:Label>
                    <div class="row">
                        <div class="col">Mã danh mục</div>
                        <div class="col">
                            <asp:TextBox ID="txtEditMaDanhMuc" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">Tên danh mục</div>
                        <div class="col">
                            <asp:TextBox ID="txtEditTenDanhMuc" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">Mô tả danh mục</div>
                        <div class="col">
                            <asp:TextBox ID="txtEditMoTaDanhMuc" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:FileUpload ID="fileEditAnhDanhMuc" runat="server" />
                        </div>
                        <div>
                            <asp:Button runat="server" Text="Xóa thông tin cũ" BackColor="#FFD166" BorderStyle="None" ForeColor="White" OnClick="RemoveOldInfor_Click" />
                        </div>
                    </div>
                </div>
                <div>
                    <asp:Image ID="Image2" CssClass="review-image" runat="server" ImageAlign="Middle" />
                </div>
                <div style="display: flex;">
                    <asp:Button runat="server" ID="btnChangeStatus" Text="Vô hiệu hóa danh mục" Width="100%" BackColor="#EF476F" BorderColor="White" BorderStyle="None" ForeColor="White" Height="40px" OnClick="ChangeStatusCategory_Click" />
                    <asp:Button runat="server" Text="Hoàn tất chỉnh sửa" Width="100%" BackColor="#06D6A0" BorderColor="White" BorderStyle="None" ForeColor="White" Height="40px" OnClick="SaveEditButton_Click" />
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</div>

