<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPageTheme.Master" AutoEventWireup="true" CodeBehind="ProductManager.aspx.cs" Inherits="BTL_WEB2.Pages.AdminPage.ProductManager" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Sản phẩm</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper-content">
        <div class="main-content">
            <div class="title-btnAdd">
                <asp:Label ID="title" runat="server" Text="Quản lý sản phẩm"></asp:Label>
                <asp:Button CssClass="btnStyle" ID="btnAdd" runat="server" Text="Tạo sản phẩm mới" OnClick="AddButton_Onclick" />
            </div>
            <asp:MultiView runat="server" ID="ProductView" ActiveViewIndex="0">
                <asp:View runat="server" ID="ViewProductList">
                    <asp:Table ID="ProductTable" runat="server" CellPadding="10" HorizontalAlign="Center">
                        <asp:TableRow>
                            <asp:TableCell CssClass="table-header">STT</asp:TableCell>
                            <asp:TableCell CssClass="table-header">Mã sản phẩm</asp:TableCell>
                            <asp:TableCell CssClass="table-header">Tên sản phẩm</asp:TableCell>
                            <asp:TableCell CssClass="table-header">Giá sản phẩm</asp:TableCell>
                            <asp:TableCell CssClass="table-header">Mô tả sản phẩm</asp:TableCell>
                            <asp:TableCell CssClass="table-header">Ảnh sản phẩm</asp:TableCell>
                            <asp:TableCell CssClass="table-header">Số lượng</asp:TableCell>
                            <asp:TableCell CssClass="table-header">Mã danh mục</asp:TableCell>
                            <asp:TableCell CssClass="table-header">Chỉnh sửa</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Label ID="lblEmptyTable" runat="server" CssClass="lblNoti" Height="50px"></asp:Label>
                </asp:View>

                <asp:View runat="server" ID="addProductView">
                    <div class="container">
                        <asp:Label ID="lblError" runat="server" Text="" CssClass="error"></asp:Label>
                        <div class="row">
                            <div class="col">Mã sản phẩm</div>
                            <div class="col">
                                <asp:TextBox ID="txbMaSanPham" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Tên Sản phẩm</div>
                            <div class="col">
                                <asp:TextBox ID="txbTenSanPham" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Giá Sản phẩm</div>
                            <div class="col">
                                <asp:TextBox ID="txbGiaSanPham" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Mô tả sản phẩm</div>
                            <div class="col">
                                <asp:TextBox ID="txbMoTaSanPham" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Số lượng tồn kho</div>
                            <div class="col">
                                <asp:TextBox ID="txbSLTK" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Mã danh mục</div>
                            <div class="col">
                                <asp:DropDownList ID="ddl_danhmuc" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:FileUpload ID="fileAnhSanPham" runat="server" />
                            </div>
                            <div>
                                <asp:Button runat="server" Text="Xem ảnh" BackColor="#FFD166" BorderStyle="None" ForeColor="White" OnClick="ReviewImageButton_Click" />
                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:Image ID="Image1" CssClass="review-image" runat="server" ImageAlign="Middle" />
                    </div>
                    <asp:Button runat="server" Text="Thêm mới sản phẩm" Width="100%" BackColor="#06D6A0" BorderColor="White" BorderStyle="None" ForeColor="White" Height="40px" OnClick="SaveAddProductButton_Click" />
                </asp:View>

                <asp:View runat="server" ID="editProduct">
                    <div class="container">
                        <asp:Label ID="Label1" runat="server" Text="" CssClass="error"></asp:Label>
                        <div class="row">
                            <div class="col">Mã sản phẩm</div>
                            <div class="col">
                                <asp:TextBox ID="txtEditMaSanPham" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Tên sản phẩm</div>
                            <div class="col">
                                <asp:TextBox ID="txtEditTenSanPham" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Giá sản phẩm</div>
                            <div class="col">
                                <asp:TextBox ID="txtEditGiaSanPham" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Mô tả sản phẩm</div>
                            <div class="col">
                                <asp:TextBox ID="txtEditMoTaSanPham" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Số lượng tồn kho</div>
                            <div class="col">
                                <asp:TextBox ID="txtEditSLTK" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Danh mục</div>
                            <div class="col">
                                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:FileUpload ID="fileEditAnhSanPham" runat="server" />
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
                        <asp:Button runat="server" ID="btnDeleteProduct" Text="Xóa sản phẩm" Width="100%" BackColor="#EF476F" BorderColor="White" BorderStyle="None" ForeColor="White" Height="40px" OnClick="btnDeleteProduct_Click" />
                        <asp:Button runat="server" Text="Hoàn tất chỉnh sửa" Width="100%" BackColor="#06D6A0" BorderColor="White" BorderStyle="None" ForeColor="White" Height="40px" OnClick="SaveEditProductButton_Click" />
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
