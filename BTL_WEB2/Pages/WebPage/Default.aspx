<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WebPageTheme.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BTL_WEB2.Pages.WebPage.WebForm1" %>
<asp:Content ContentPlaceHolderID="plHead" runat="server">
    <title>Cây Xanh - Trang chủ</title>
    <link rel="stylesheet" href="../../Content/Styles/WebPage/DefaultPage.css"/>
</asp:Content>


<asp:Content ContentPlaceHolderID="ContentWebPage" runat="server">
    <!--Hiển thị slider-->
    <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel" data-bs-interval="3000">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="3" aria-label="Slide 4"></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <asp:Image runat="server" ImageUrl="~/Images/Category/header-decor.png" CssClass="image-carousel" />
            </div>
            <div class="carousel-item">
                <asp:Image runat="server" ImageUrl="~/Images/Carousel/carousel-1.jpg" CssClass="image-carousel" />
            </div>
            <div class="carousel-item">
                <asp:Image runat="server" ImageUrl="~/Images/Carousel/carousel-2.jpg" CssClass="image-carousel" />
            </div>
            <div class="carousel-item">
                <asp:Image runat="server" ImageUrl="~/Images/Carousel/carousel-3.jpg" CssClass="image-carousel" />
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>

    <!--Hiển thị sản phẩm đang sale-->
    <div class="sale-Row product-row">

    </div>

    <!--Hiển thị sản phẩm bán chạy-->
    <div class="ban-chay-Row product-row">

    </div>

    <!--Hiển thị sản phẩm cây ăn quả-->
    <div class="cay-an-qua-Row product-row">

    </div>

    <!--Hiển thị sản phẩm cây cảnh-->
    <div class="cay-canh-Row product-row">

    </div>

    <!--Hiển thị sản phẩm sen đá-->
    <div class="sen-da-Row product-row">

    </div>

    <!--Hiển thị sản phẩm hạt giống-->
    <div class="hat-giong-Row product-row">

    </div>

</asp:Content>
