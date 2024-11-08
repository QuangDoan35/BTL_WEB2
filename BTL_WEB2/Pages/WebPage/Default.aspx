﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WebPageTheme.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BTL_WEB2.Pages.WebPage.WebForm1" %>

<asp:Content ContentPlaceHolderID="plHead" runat="server">
    <title>Trang chủ - Cây Xanh</title>
    <link rel="stylesheet" href="../../Content/Styles/WebPage/DefaultPage.css" type="text/css" />
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
                <asp:Image runat="server" ImageUrl="~/Images/Carousel/carousel-6.jpg" CssClass="image-carousel" />
            </div>
            <div class="carousel-item">
                <asp:Image runat="server" ImageUrl="~/Images/Carousel/carousel-1.jpg" CssClass="image-carousel" />
            </div>
            <div class="carousel-item">
                <asp:Image runat="server" ImageUrl="~/Images/Carousel/carousel-2.jpg" CssClass="image-carousel" />
            </div>
            <div class="carousel-item">
                <asp:Image runat="server" ImageUrl="~/Images/Carousel/carousel-5.jpg" CssClass="image-carousel" />
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

    <!--Hiển thị tất cả các danh mục có trong cơ sở dữ liệu-->
    <div style="padding: 50px 0;">
        <div style="text-align: center;  margin-bottom: 20px; font-size: 20px; font-weight: 600">Danh Mục</div>
        <div class="category-row">
            <asp:PlaceHolder ID="categoryRow" runat="server"></asp:PlaceHolder>
        </div>
    </div>

    <!--Hiển thị sản phẩm đang sale-->
    <div class="product-row prodcut-row-decor">
        <div class="title-link">
            <div class="title-category flex">
                SẢN PHẨM
                <p style="color: red; margin-left: 7px;">ĐANG SALE</p>
            </div>
            <asp:HyperLink ID="saleLink" runat="server" CssClass="link-xemthem">
                <div class="flex">
                    Xem thêm sản phẩm
                    <i class="bi bi-arrow-right-short"></i>
                </div>
            </asp:HyperLink>
        </div>
        <div style="display: flex; justify-content: space-between; align-items: center; width: 90%;">
            <asp:PlaceHolder ID="saleRow" runat="server"></asp:PlaceHolder>
        </div>
    </div>

    <!--Hiển thị sản phẩm bán chạy-->
    <div class="product-row">
        <div class="title-link">
            <div class="title-category flex">
                SẢN PHẨM
            <p style="color: red; margin-left: 7px;">BÁN CHẠY</p>
            </div>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="link-xemthem">
            <div class="flex">
                Xem thêm sản phẩm
                <i class="bi bi-arrow-right-short"></i>
            </div>
            </asp:HyperLink>
        </div>
        <div style="display: flex; justify-content: space-between; align-items: center; width: 90%;">
            <asp:PlaceHolder ID="banChayRow" runat="server"></asp:PlaceHolder>
        </div>
    </div>

    <!--Hiển thị sản phẩm cây ăn quả-->
    <div class="product-row prodcut-row-decor">
        <div class="title-link">
            <div class="title-category flex">
                CÂY
            <p style="color: mediumspringgreen; margin-left: 7px;">ĂN QUẢ</p>
            </div>
            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="link-xemthem">
            <div class="flex">
                Xem thêm sản phẩm
                <i class="bi bi-arrow-right-short"></i>
            </div>
            </asp:HyperLink>
        </div>
        <div style="display: flex; justify-content: space-between; align-items: center; width: 90%;">
            <asp:PlaceHolder ID="cayAnQuaRow" runat="server"></asp:PlaceHolder>
        </div>
    </div>

    <!--Hiển thị sản phẩm cây cảnh-->
    <asp:PlaceHolder ID="cayCanhRow" runat="server"></asp:PlaceHolder>

    <!--Hiển thị sản phẩm sen đá-->
    <asp:PlaceHolder ID="senDaRow" runat="server"></asp:PlaceHolder>

    <!--Hiển thị sản phẩm hạt giống-->
    <asp:PlaceHolder ID="hatGiongRow" runat="server"></asp:PlaceHolder>


    <style>
        .prodcut-row-decor {
            background-color: #fafafa;
        }

        .product-row {
            padding: 50px 0;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
        }

        .product-panel {
            box-shadow: rgba(50, 50, 93, 0.25) 0px 2px 5px -1px, rgba(0, 0, 0, 0.3) 0px 1px 3px -1px;
            border-radius: 5px;
            position: relative;
            padding: 0;
            margin: 0;
            border: 1px solid transparent;
            background-color: white;
        }

        .product-panel:hover { 
            border: 1px solid #00a896;
        }

        .title-link {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 50px 0;
            width: 90%;
            color: black;
        }

        .product-img {
            border-radius: 5px 5px 0px 0px;
            height: 200px;
        }

        .title-category {
            font-size: 26px;
            font-weight: 700;
        }

        .link-xemthem {
            color: #00a896;
            border: 1px solid #00a896;
            padding: 5px 10px;
            border-radius: 10px 0 10px 0;
        }

            .link-xemthem:hover {
                background-color: #00a896;
                color: white;
                transition: all 300ms;
            }

        .container-infor-product {
            padding: 10px;
        }

        .product-discount {
            background-color: red;
            position: absolute;
            right: 0;
            top: 0;
            padding: 10px;
            border-radius: 0 3px 0 20px;
            color: white;
        }

        .product-link {
            color: black;
            background-color: #00a896;
            padding: 10px;
            border-radius: 10px;
            color: white;
            margin-top: 20px;
            text-align: center;
        }

        .product-price {
            color: #09bc8a;
            font-size: 22px;
        }

        .product-name {
            text-transform: uppercase;
            font-size: 16px;
            font-weight: 500;
        }

        .product-name-panel {
            width: 100%;
            height: 51px;
            overflow: hidden; /* Ẩn văn bản vượt ra ngoài */
            display: -webkit-box; /* Hiển thị như một hộp */
            -webkit-box-orient: vertical; /* Định hướng theo chiều dọc */
            -webkit-line-clamp: 2; /* Giới hạn số dòng hiển thị */
            white-space: normal; /* Cho phép xuống dòng */
        }

        .category-row {
            display: flex;
            justify-content: center;
        }

        .category-panel {
            width: 100px;
            text-align: center;
            margin: 15px;
            padding: 5px;
            background-color: #00a89650;
            border-radius: 5px;
        }

        .category-panel:hover {
            background-color: #00a896;
            color: white;
            transition: all 300ms;
            box-shadow: rgba(255, 255, 255, 0.1) 0px 1px 1px 0px inset, rgba(50, 50, 93, 0.25) 0px 50px 100px -20px, rgba(0, 0, 0, 0.3) 0px 30px 60px -30px;
        }

        .category-img {
            width: 80px;
            height: 80px;
            object-fit: cover;
            border-radius: 5px;
            margin-bottom: 10px;
        }

        .category-name {
        }
    </style>
</asp:Content>
