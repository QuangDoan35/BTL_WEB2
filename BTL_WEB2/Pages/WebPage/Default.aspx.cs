using BTL_WEB2.App_Code.Category;
using BTL_WEB2.App_Code.Product;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;

namespace BTL_WEB2.Pages.WebPage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ProductDAO productDAO;
        List<Product> productListBySale = new List<Product>(); //list chứa danh sách sản phẩm sắp xếp theo giảm giá
        List<Product> productListByBanChay = new List<Product>(); //list chứa danh sách sản phẩm săp xếp theo bán chạy
        List<Product> productListByCayAnQua = new List<Product>(); //list chứa danh sách sản phẩm cây ăn quả
        protected void Page_Load(object sender, EventArgs e)
        {
            productDAO = new ProductDAO();

            productListBySale = productDAO.getListProduct("sale"); //Lấy sản phẩm sắp xếp theo sale
            productListByBanChay = productDAO.getListProduct("banChay"); //Lấy sản phẩm sắp xếp theo số lượng đã bán
            productListByCayAnQua = productDAO.getListProduct("cayAnQua"); //Lấy sản phẩm cây ăn quả

            displayCategoryRow();

            DisplayProducts(saleRow, "sale");
            DisplayProducts(banChayRow, "banChay");
            DisplayProducts(cayAnQuaRow, "cayAnQua");
        }

        //Tạo danh sách sản phẩm
        private void DisplayProducts(PlaceHolder div, string category)
        {

            List<Product> listProduct = new List<Product>();

            switch (category)
            {
                case "sale":
                    listProduct = GetProductsListByCategory("sale");
                    break;
                case "banChay":
                    listProduct = GetProductsListByCategory("banChay");
                    break;
                case "cayAnQua":
                    listProduct = GetProductsListByCategory("cayAnQua");
                    break;
            }

            foreach (Product product in listProduct)
            {

                // Tạo một div chứa các điều khiển
                Panel productPanel = new Panel
                {
                    CssClass = "product-panel",
                    Width = Unit.Percentage(18),
                };

                Panel inforProductPanel = new Panel
                {
                    CssClass = "container-infor-product"
                };

                // Tạo điều khiển Image
                Image productImage = new Image
                {
                    CssClass = "product-img",
                    ImageUrl = product.getAnhSanPham(),
                    Width = Unit.Percentage(100), // Chiều rộng ảnh
                    Style = { ["object-fit"] = "cover" } // Kiểu cho ảnh
                };

                // Tạo điều khiển Label cho tên sản phẩm
                Label productName = new Label
                {
                    Text = $"<p>{product.getTenSanPham()}</p>",
                    CssClass = "product-name"
                };
                Panel productNamePanel = new Panel
                {
                    CssClass = "product-name-panel"
                };
                productNamePanel.Controls.Add(productName);


                // Tạo điều khiển Label cho giá sản phẩm
                Label productPrice = new Label
                {
                    Text = product.getGiaSanPham().ToString("N0", new CultureInfo("vi-VN")) + " VND",
                    CssClass = "product-price"
                };

                //Tạo label cho số lượng mua
                Label productQuantitySold = new Label
                {
                    Text = $"<div>{product.getSoLuongDaBan().ToString()} Đã bán</div>",
                };

                // Tạo điều khiển Label cho giảm giá, nếu không phải là sản phẩm đang giảm giá thì sẽ ẩn label này
                Label productDiscount = new Label();
                if (category.Equals("sale") && product.getGiamGia() > 0)
                {
                    productDiscount = new Label
                    {
                        Text = $"<p>-{product.getGiamGia()}%</p>",
                        CssClass = "product-discount"
                    };
                }

                // Tạo nút LinkButton để xem chi tiết sản phẩm
                LinkButton productLink = new LinkButton
                {
                    Text = "Xem chi tiết", // Văn bản của nút
                    CssClass = "product-link",
                    Width = Unit.Percentage(100),
                    CommandArgument = product.getMaSanPham().ToString(),
                };
                // Gắn sự kiện Click cho nút
                productLink.Click += ProductLink_Click;


                // Thêm các điều khiển vào panel
                inforProductPanel.Controls.Add(productNamePanel);
                inforProductPanel.Controls.Add(productPrice);
                inforProductPanel.Controls.Add(productQuantitySold);
                inforProductPanel.Controls.Add(productLink);

                productPanel.Controls.Add(productImage);
                productPanel.Controls.Add(inforProductPanel);
                productPanel.Controls.Add(productDiscount);


                // Thêm panel vào PlaceHolder
                div.Controls.Add(productPanel);
            }
        }

        //Lấy 5 sản phẩm theo danh mục
        private List<Product> GetProductsListByCategory(string category)
        {
            List<Product> listProducts = new List<Product>();
            int bienDem = 0; // Biến đếm để đếm số lượng sản phẩm lấy ra

            // Lấy sản phẩm đang giảm giá
            if (category.Equals("sale"))
            {

                foreach (Product product in productListBySale)
                {
                    if (product.getGiamGia() > 0) //Nếu mà sản phẩm không được giảm giá
                    {
                        listProducts.Add(product);
                        bienDem++;
                    }

                    // Kiểm tra nếu đã đủ 5 sản phẩm
                    if (bienDem == 5)
                        break; // Kết thúc vòng lặp nếu đủ sản phẩm
                }
            }
            // Lấy sản phẩm bán chạy
            else if (category.Equals("banChay"))
            {

                foreach (Product product in productListByBanChay)
                {
                    listProducts.Add(product);
                    bienDem++;

                    // Kiểm tra nếu đã đủ 5 sản phẩm
                    if (bienDem == 5)
                        break; // Kết thúc vòng lặp nếu đủ sản phẩm
                }
            }
            //Lấy sản phẩm danh mục cây ăn quả
            else if (category.Equals("cayAnQua"))
            {

                foreach (Product product in productListByCayAnQua)
                {
                    listProducts.Add(product);
                    bienDem++;

                    // Kiểm tra nếu đã đủ 5 sản phẩm
                    if (bienDem == 5)
                        break; // Kết thúc vòng lặp nếu đủ sản phẩm
                }
            }

            return listProducts;
        }


        // Chuyển sang trang xem chi tiết sản phẩm
        protected void ProductLink_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ nút được nhấn
            LinkButton clickedButton = (LinkButton)sender;
            string productId = clickedButton.CommandArgument; // Lấy ID sản phẩm từ CommandArgument

            // Lưu ID sản phẩm vào session nếu cần sử dụng sau
            Session["SelectedProductId"] = productId;

            // Chuyển hướng đến trang chi tiết sản phẩm
            Response.Redirect("ChiTietSanPham.aspx");
        }

        //Lấy danh sách danh mục để hiển thị lên đầu trang
        private void displayCategoryRow()
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            categoryDAO.GetList();
            //Lấy danh sách danh mục trong cơ sở dữ liệu
            List<Category> listCategory = new List<Category>();
            listCategory = categoryDAO.listCategory;

            foreach (Category category in listCategory)
            {
                //tạo các khung chứa danh sách danh mục và hiển thị trên Placehoder CategoryRow
                Panel categoryPanel = new Panel
                {
                    CssClass = "category-panel",
                };

                // Tạo điều khiển Image
                Image categoryImage = new Image
                {
                    CssClass = "category-img",
                    ImageUrl = category.getAnhDanhMuc(),
                    Width = Unit.Percentage(100), // Chiều rộng ảnh
                };

                Label categoryName = new Label
                {
                    CssClass = "category-name",
                    Text = category.getTenDanhMuc(),
                };

                //Thêm ảnh và tên danh mục vào vùng chứa
                categoryPanel.Controls.Add(categoryImage);
                categoryPanel.Controls.Add(categoryName);

                categoryRow.Controls.Add(categoryPanel);
            }
        }
    }
}