using BTL_WEB2.App_Code.Product;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;

namespace BTL_WEB2.Pages.WebPage
{
    public partial class ChiTietSanPham : System.Web.UI.Page
    {
        ProductDAO productDAO = new ProductDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            productDAO.getListProduct("");

            showProduct();

            showsuggetsProductList();
        }

        //Hiển thị thông tin lên giao diện
        private void showProduct()
        {
            Product product = new Product();
            product = getInforProductSelected();

            imageProduct.ImageUrl = product.getAnhSanPham();
            lblTenSanPham.Text = product.getTenSanPham();
            lblMoTaSanPham.Text = product.getMoTaSanPham();
            // Định dạng giá sản phẩm
            lblGiaSanPham.Text = product.getGiaSanPham().ToString("N0", new CultureInfo("vi-VN")) + " VND";

            int giamgia = product.getGiamGia();
            double giaSanPham = product.getGiaSanPham();

            if (giamgia > 0)
            {
                //Tạo khối trang trí màu đỏ phía bên dưới tên sản phẩm biểu thị là sản phẩm này được giảm giá
                Panel salePanelDecor = new Panel
                {
                    CssClass = "sale-panel-decor",
                    Width = Unit.Percentage(100),
                };
                Image plashSale = new Image
                {
                    ImageUrl = "../../Images/plashSale.svg"
                };

                Label lblGiamGia = new Label
                {
                    Text = giamgia.ToString() + "% GIẢM",
                    CssClass = "label-giamgia",
                };

                salePanelDecor.Controls.Add(plashSale);
                salePanelDecor.Controls.Add(lblGiamGia);
                Decor.Controls.Add(salePanelDecor);

                //css cho giá cũ và giá sau khi sale
                lblGiaSanPham.Attributes["style"] = "color: #929292; font-size: 1rem; margin-right: 10px; text-decoration: line-through;";
                lblGiaSanPhamSauKhiSale.Attributes["style"] = "color: rgba(255,0,74,1); font-size: 1.875rem;";

                //Hiển thị số tiền của sản phẩm sau khi giảm giá
                double giaSauKhiSale = product.getGiaSanPham() - (giamgia * (giaSanPham / 100));
                lblGiaSanPhamSauKhiSale.Text = giaSauKhiSale.ToString("N0", new CultureInfo("vi-VN")) + " VND";

                //Lấy số lượng đã bán của sản phẩm
                lblSoluongDaBan.Text = "Đã bán: " + product.getSoLuongDaBan().ToString();
            }
            else
            {
                lblGiaSanPhamSauKhiSale.Text = string.Empty; //Nếu sản phẩm không giảm giá thì ẩn label tiền sau giảm giá
            }
        }

        //Lấy thông tin của sản phẩm
        private Product getInforProductSelected()
        {
            string maSanPham = Request.QueryString["maSP"];

            Product product;

            foreach (Product p in productDAO.listProduct)
            {
                string ma = p.getMaSanPham();
                if (ma.Equals(maSanPham))
                {
                    // Lấy thông tin sản phẩm khi tìm thấy
                    string tenSanPham = p.getTenSanPham();
                    double giaSanPham = p.getGiaSanPham();
                    string moTaSanPham = p.getMoTaSanPham();
                    string anhSanPham = p.getAnhSanPham();
                    int soLuongTonKho = p.getSoLuongTonKho();
                    string maDanhMuc = p.getMaDanhMuc();
                    int giamGia = p.getGiamGia();
                    int soLuongDaBan = p.getSoLuongDaBan();

                    product = new Product(maSanPham, tenSanPham, giaSanPham, moTaSanPham, anhSanPham, soLuongTonKho, maDanhMuc, giamGia, soLuongDaBan);

                    // Kết thúc vòng lặp khi đã tìm thấy sản phẩm
                    return product;
                }
            }
            return null;
        }

        //Hiện sản phẩm gợi ý
        private void showsuggetsProductList()
        {
            List<Product> productList = new List<Product>();
            productList = getsuggetsProductList();

            int i = 0;

            foreach (Product product in productList)
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

                // Tạo nút LinkButton để xem chi tiết sản phẩm
                HyperLink productLink = new HyperLink
                {
                    Text = "Xem chi tiết",
                    CssClass = "product-link",
                    Width = Unit.Percentage(100),
                    NavigateUrl = "ChiTietSanPham.aspx?maSP=" + product.getMaSanPham() + "&" + product.getTenSanPham(),
                };


                // Thêm các điều khiển vào panel
                inforProductPanel.Controls.Add(productNamePanel);
                inforProductPanel.Controls.Add(productPrice);
                inforProductPanel.Controls.Add(productQuantitySold);
                inforProductPanel.Controls.Add(productLink);

                productPanel.Controls.Add(productImage);
                productPanel.Controls.Add(inforProductPanel);

                // Thêm panel vào PlaceHolder
                if (i < 5)
                {
                    productSuggetsRow1.Controls.Add(productPanel);
                }
                else
                {
                    productSuggetsRow2.Controls.Add(productPanel);
                }

                i++;
            }
        }

        //Tạo danh sách sản phẩm gợi ý tương tự, in ra 5 sản phẩm trên một dòng
        private List<Product> getsuggetsProductList()
        {
            List<Product> listSuggetsProduct = new List<Product>();
            Product product = new Product();
            product = getInforProductSelected();
            int i = 0;

            foreach (Product p in productDAO.listProduct)
            {
                if (i < 10) //Kiểm tra xem đã lấy đủ 10 sản phẩm chưa
                {
                    if (product.getMaDanhMuc().Equals(p.getMaDanhMuc())) //Nếu như trùng danh mục với sản phẩm được chọn thì lấy
                    {
                        listSuggetsProduct.Add(p);
                        i++;
                    }
                }
                else
                {
                    break;
                }
            }

            return listSuggetsProduct;
        }

        //Nút bấm mua sản phẩm
        protected void BtnBuy_Click(object sender, EventArgs e)
        {
            //Kiem tra xem nguoi dung da dang nhap chua
            if (Request.Cookies["loginCookie"] != null)
            {
                containerAlert.Attributes["style"] = "display: flex;";
            }
            //Neu chua dang nhap thi chuyen sang trang dang nhap
            else
            {
                Response.Redirect("WebLogin.aspx");
            }
        }

        protected void CloseAlert_Click(object sender, EventArgs e)
        {
            containerAlert.Attributes["style"] = "display: none;";
        }
    }
}