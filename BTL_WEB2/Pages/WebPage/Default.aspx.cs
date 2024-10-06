using BTL_WEB2.App_Code.Product;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BTL_WEB2.Pages.WebPage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ProductDAO productDAO;
        protected void Page_Load(object sender, EventArgs e)
        {
            productDAO = new ProductDAO();

            if (!IsPostBack)
            {
                productDAO.getListProduct();
                LoadProducts();
            }
        }

        //Hiển thị danh sách sản phẩm
        private void LoadProducts()
        {
            DisplayProducts(saleRow, "sale");
        }

        private void DisplayProducts(PlaceHolder div, string category)
        {
            List<Product> listProduct = GetProductsListByCategory(category);

            for (int i = 0; i < listProduct.Count; i++)
            {
                Product product = listProduct[i];

                // Tạo một div chứa các điều khiển
                Panel productPanel = new Panel
                {
                    CssClass = "product-panel",
                    Width = Unit.Percentage(20),

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
                    Text = $"<h3>{product.getTenSanPham()}</h3>",
                    CssClass = "product-name" // Thêm class CSS nếu cần
                };

                // Tạo điều khiển Label cho giá sản phẩm
                Label productPrice = new Label
                {
                    Text = $"<p>Giá: {product.getGiaSanPham()} VND</p>",
                    CssClass = "product-price"
                };

                // Tạo điều khiển Label cho giảm giá
                Label productDiscount = new Label
                {
                    Text = $"<p>Giảm giá: {product.getGiamGia()}%</p>",
                    CssClass = "product-discount"
                };

                // Tạo điều khiển LinkButton
                LinkButton productLink = new LinkButton
                {
                    Text = "Xem chi tiết", // Văn bản của nút
                    CssClass = "product-link" // Thêm class CSS nếu cần
                };

                // Thêm các điều khiển vào panel
                inforProductPanel.Controls.Add(productName);
                inforProductPanel.Controls.Add(productPrice);
                inforProductPanel.Controls.Add(productDiscount);
                inforProductPanel.Controls.Add(productLink);

                productPanel.Controls.Add(productImage);
                productPanel.Controls.Add(inforProductPanel);

                // Thêm panel vào PlaceHolder
                div.Controls.Add(productPanel);
            }
        }



        private List<Product> GetProductsListByCategory(string category)
        {
            List<Product> listProduct = new List<Product>();
            int bienDem = 0; //Biến đếm để đếm số lượng sản phẩm lấy ra

            //Lấy sản phẩm đang giảm giá
            if (category.Equals("sale"))
            {
                foreach (Product product in productDAO.listProduct)
                {
                    if (product.getGiamGia() > 0 && bienDem < 4)
                    {
                        listProduct.Add(product);
                        bienDem++;
                    }
                    else
                    {
                        return listProduct;
                    }
                }
            }
            //Lấy sản phẩm bán chạy
            else if (category.Equals("banChay"))
            {

            }

            return listProduct;
        }
    }
}