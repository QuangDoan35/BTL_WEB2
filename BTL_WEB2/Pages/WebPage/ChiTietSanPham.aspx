﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WebPageTheme.Master" AutoEventWireup="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="BTL_WEB2.Pages.WebPage.ChiTietSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="plHead" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Content/Styles/WebPage/ChiTietSanPham.css" />
    <title>Chi tiết sản phẩm</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentWebPage" runat="server">
    <div class="wrapper">
        <!--Hộp thoại xuất hiện thông báo mua hàng thành công khi người dùng bấm vào nút mua-->
        <div class="container-alert" runat="server" id="containerAlert">
            <div class="alert">
                <h5>Mua hàng thành công</h5>
                <p>Cảm ơn bạn vì đã đặt hàng</p>
                <asp:LinkButton CssClass="btn-alert" ID="LinkButton2" runat="server" OnClick="CloseAlert_Click">Đóng</asp:LinkButton>
            </div>
        </div>

        <!--Giới thiệu sản phẩm-->
        <div class="product-briefing">
            <!--Ảnh sản phẩm và chia sẻ sản phẩm-->
            <div class="left-col">
                <!--Ảnh sản phẩm-->
                <asp:Image ID="imageProduct" runat="server" CssClass="image-product" />
                <!--Nút chia sẻ lên mạng xã hội và hiển thị số lượt thích-->
                <div class-="share-heart" style="display: flex; justify-content: space-between; align-items: center; margin-top: 20px;">
                    <div class="share">
                        <p style="font-weight: 600;">Chia sẻ: </p>
                        <i class="bi bi-messenger"></i>
                        <i class="bi bi-facebook"></i>
                        <i class="bi bi-pinterest"></i>
                        <i class="bi bi-twitter"></i>
                    </div>
                    <div class="heart">
                        <i class="bi bi-heart" style="font-size: 20px; color: red; margin-right: 10px;"></i>
                        <p>Đã thích (69K)</p>
                    </div>
                </div>
            </div>
            <!--Chi tiết sản phẩm và mua-->
            <div class="right-col">
                <!--Hiện thông tin sản phẩm-->
                <div class="product-detail">
                    <div style="font-size: 28px; font-weight: 500; text-transform: uppercase;">
                        <asp:Label ID="lblTenSanPham" runat="server" Text=""></asp:Label>
                    </div>
                    <!--Box màu đỏ biểu thị là sản phẩm được sale-->
                    <asp:PlaceHolder ID="Decor" runat="server"></asp:PlaceHolder>
                    <div style="background-color: #fafafa; padding: 10px 20px;">
                        <asp:Label ID="lblGiaSanPham" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblGiaSanPhamSauKhiSale" runat="server" Text=""></asp:Label>
                    </div>
                    <asp:Label ID="lblSoluongDaBan" runat="server" Text="Label" CssClass="label-soluongdaban"></asp:Label>
                    <asp:Label ID="lblMoTaSanPham" runat="server" Text="" CssClass="lblMoTaSanPham"></asp:Label>
                </div>
                <!--Nút mua và nút thêm vào giỏ hàng-->
                <div class="buy-cart" style="display: flex;">
                    <div style="position: relative">
                        <i class="bi bi-cart2"></i>
                        <asp:Button ID="btnAddCart" runat="server" Text="Thêm Vào Giỏ Hàng" CssClass="btn-addtocart" />
                    </div>
                    <asp:Button ID="btnBuy" runat="server" Text="Mua Ngay" CssClass="btn-buy" OnClick="BtnBuy_Click"/>
                </div>
            </div>
        </div>

        <!--Gợi ý sản phẩm-->
        <div style="width: 90%; margin-top: 100px;">
            <p style="font-size: 20px; font-weight: 500;">CÓ THỂ BẠN SẼ THÍCH</p>
            <div class="product-suggets product-row">
                <asp:PlaceHolder ID="productSuggetsRow1" runat="server"></asp:PlaceHolder>
            </div>
            <div class="product-suggets product-row">
                <asp:PlaceHolder ID="productSuggetsRow2" runat="server"></asp:PlaceHolder>
            </div>
        </div>
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn-xemthemsanpham">
             Xem thêm sản phẩm
             <i class="bi bi-arrow-repeat"></i>
        </asp:LinkButton>
    </div>
</asp:Content>
