using BTL_WEB2.App_Code.Product;
using System;
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
            string maSanPham = Session["SelectedProductId"].ToString();

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
    }
}