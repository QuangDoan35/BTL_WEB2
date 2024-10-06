<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WebPageTheme.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BTL_WEB2.Pages.WebPage.WebForm1" %>

<asp:Content ContentPlaceHolderID="plHead" runat="server">
    <title>Cây Xanh - Trang chủ</title>
    <link rel="stylesheet" href="../../Content/Styles/WebPage/DefaultPage.css" type="text/css" />
</asp:Content>


<asp:Content ContentPlaceHolderID="ContentWebPage" runat="server">
    <style>
        .product-row {
            margin: 100px 0;
            display: flex;
            flex-direction: column;
            width: 100%;
            justify-content: center;
            align-items: center;
        }

        .product-panel {
            border: 2px solid #02c39a;
            border-radius: 10px;
            
        }

        .product-panel:hover {
            box-shadow: #02c39a50 0px 5px 15px;
            transition: all 300ms;
        }

        .title-link {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 50px 0;
            width: 80%;
            color: black;
        }

        .product-img {
            border-radius: 10px 10px 0px 0px;
        }

        .title-category {
        }

        .link-xemthem {
            color: #00a896;
        }

        .link-xemthem:hover {
            color: greenyellow;
        }

        .container-infor-product {
            padding: 10px;
        }
    </style>

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
    <div class="product-row">
        <div class="title-link">
            <div class="title-category">SẢN PHẨM BÁN CHẠY</div>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="link-xemthem">Xem thêm sản phẩm</asp:HyperLink>
        </div>
        <div style="display: flex; justify-content: space-between; align-items: center; width: 80%;">
            <asp:PlaceHolder ID="saleRow" runat="server"></asp:PlaceHolder>
        </div>
    </div>

    <!--Hiển thị sản phẩm bán chạy-->
    <asp:PlaceHolder ID="banChayRow" runat="server"></asp:PlaceHolder>

    <!--Hiển thị sản phẩm cây ăn quả-->
    <asp:PlaceHolder ID="cayAnQuaRow" runat="server"></asp:PlaceHolder>

    <!--Hiển thị sản phẩm cây cảnh-->
    <asp:PlaceHolder ID="cayCanhRow" runat="server"></asp:PlaceHolder>

    <!--Hiển thị sản phẩm sen đá-->
    <asp:PlaceHolder ID="senDaRow" runat="server"></asp:PlaceHolder>

    <!--Hiển thị sản phẩm hạt giống-->
    <asp:PlaceHolder ID="hatGiongRow" runat="server"></asp:PlaceHolder>
</asp:Content>
