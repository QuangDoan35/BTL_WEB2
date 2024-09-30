<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryControl.ascx.cs" Inherits="BTL_WEB2.Admin.Category.CategoryControl" %>

<style type="text/css">
    .auto-style1 {
        margin-left: 42px;
    }
    .auto-style2 {
        width: 430px;
    }
    </style>

<div style="display: flex; justify-content: space-around; align-items: flex-start; margin: 80px 0;">
    <div>
        <asp:MultiView ID="mul" runat="server" ActiveViewIndex="0">
            <!--Hiển thị danh mục-->
            <asp:View ID="categoryView" runat="server">
                <div style="display: flex; justify-content: space-between; margin-bottom: 20px;">
                    <h2>Danh mục sản phẩm</h2>
                    <asp:Button CssClass="style-button" ID="Button1" runat="server" Text="Thêm danh mục sản phẩm" OnClick="Button1_Click" BorderColor="White" BorderStyle="None" />
                </div>

                <asp:Repeater ID="rptCategory" runat="server">
                    <HeaderTemplate>
                        <table class="category-table">
                            <tr>
                                <td class="header-category-table">STT</td>
                                <td class="header-category-table">Mã danh mục</td>
                                <td class="header-category-table">Tên danh mục</td>
                                <td class="header-category-table">Mô tả danh mục</td>
                                <td class="header-category-table">Ảnh danh mục</td>
                                <td style="background-color: #09BC8A; color: white;">
                                    Chỉnh sửa danh mục
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#: Eval("STT") %></td>
                            <td><%#: Eval("MaDanhMuc") %></td>
                            <td><%#: Eval("TenDanhMuc") %></td>
                            <td><%#: Eval("MoTaDanhMuc") %></td>
                            <td><img src='<%#: Eval("AnhDanhMuc") %>' alt='Ảnh danh mục' style="width: 100%; height: 50px; border-radius: 5px; object-fit: cover;"/></td>
                            <td style="background-color: #09BC8A; text-align: center;">
                                <asp:LinkButton ID="updateButton" runat="server" CommandName="Update" CommandArgument='<%# Eval("MaDanhMuc") %>'>
                                    Chỉnh sửa
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>

                </asp:Repeater>
            </asp:View>
            <!--Thêm danh mục-->
            <asp:View ID="addCategoryView" runat="server">
                <div style="display: flex; justify-content: space-between; margin-bottom: 40px;" class="auto-style2">
                    <h2>Thêm danh mục</h2>
                    <asp:Button CssClass="style-button" ID="Button2" runat="server" Text="Quay lại" OnClick="Button2_Click" BorderStyle="None" />
                </div>
                <table class="addnew-category-table">
                    <tr >
                        <td>Mã danh mục</td>
                        <td><asp:TextBox ID="maDanhMuc" runat="server" CssClass="auto-style1" Width="249px"></asp:TextBox></td>
                    </tr>
                    <tr >
                        <td>Tên danh mục</td>
                        <td><asp:TextBox ID="tenDanhMuc" runat="server" CssClass="auto-style1" Width="249px"></asp:TextBox></td>
                    </tr>
                    <tr >
                        <td style="text-align: right">Mô tả danh mục</td>
                        <td><asp:TextBox ID="moTaDanhMuc" runat="server" CssClass="auto-style1" Width="249px"></asp:TextBox></td>
                    </tr>
                    <tr >
                        <td>Ảnh danh mục</td>
                        <td>
                            <asp:FileUpload name="file"  ID="anhDanhMuc" runat="server" CssClass="auto-style1" Width="249px"></asp:FileUpload>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin: 10px 0;"><asp:Label ID="lbError" runat="server" ForeColor="#FF3300"></asp:Label></div>
                <div style="width: 100%; display: flex; justify-content: right; margin-top: 20px;">
                    <asp:Button id="btnSave" runat="server" Text="Lưu danh mục" CssClass="btn-save" OnClick="btnSave_Click"/>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</div>

