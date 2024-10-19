using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace BTL_WEB2.Pages.AdminPage
{
    public partial class ProductManager : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDanhMuc();
            }

            LoadProductTable();
        }
        // Phương thức nạp danh sách danh mục từ cơ sở dữ liệu
        private void LoadDanhMuc()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT MaDanhMuc, TenDanhMuc FROM Category", conn))
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Nạp dữ liệu vào DropDownList
                        ddl_danhmuc.DataSource = reader;
                        ddl_danhmuc.DataTextField = "TenDanhMuc";  // Hiển thị tên danh mục
                        ddl_danhmuc.DataValueField = "MaDanhMuc";  // Giá trị là mã danh mục
                        ddl_danhmuc.DataBind();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi
                lblError.Text = ex.Message; // Hoặc ghi vào log
            }
        }

        private void LoadProductTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string str = "SELECT * FROM Product";
                SqlCommand cmd = new SqlCommand(str, connection);
                SqlDataReader data = cmd.ExecuteReader();

                int j = 1;
                while (data.Read())
                {
                    TableCell stt = new TableCell() { Text = j.ToString() };
                    TableCell ma = new TableCell() { Text = data[0].ToString() };
                    TableCell ten = new TableCell() { Text = data[1].ToString() };
                    TableCell gia = new TableCell() { Text = data[2].ToString() };
                    TableCell mota = new TableCell() { Text = data[3].ToString() };

                    Image image = new Image
                    {
                        ImageUrl = data[4].ToString(), // Sử dụng tên cột
                        Width = Unit.Pixel(100),
                        Height = Unit.Pixel(50)
                    };
                    TableCell anh = new TableCell();
                    anh.Controls.Add(image);
                    TableCell soluong = new TableCell() { Text = data[5].ToString() };
                    TableCell maDM = new TableCell() { Text = data[6].ToString() };
                    TableCell giamGia = new TableCell() { Text = data[7].ToString() }; // Sử dụng tên cột
                    TableCell soluongdaban = new TableCell() { Text = data[8].ToString() }; // Sử dụng tên cột
                    LinkButton editButton = new LinkButton
                    {
                        Text = "Chỉnh sửa",
                        CommandArgument = data["MaSanPham"].ToString(),
                    };
                    editButton.Click += EditButton_Click;
                    TableCell nutChinhSua = new TableCell();
                    nutChinhSua.Controls.Add(editButton);
                    nutChinhSua.Attributes.Add("style", "text-align: center; vertical-align: middle;");

                    TableRow row = new TableRow();
                    row.Cells.Add(stt);
                    row.Cells.Add(ma);
                    row.Cells.Add(ten);
                    row.Cells.Add(gia);
                    row.Cells.Add(mota);
                    row.Cells.Add(anh);
                    row.Cells.Add(soluong);
                    row.Cells.Add(maDM);
                    row.Cells.Add(giamGia);
                    row.Cells.Add(soluongdaban);
                    row.Cells.Add(nutChinhSua);

                    ProductTable.Controls.Add(row);
                    j++;
                }
            }
        }

        //Them san pham moi
        protected void AddButton_Onclick(object sender, EventArgs e)
        {
            if (ProductView.ActiveViewIndex == 0)
            {
                title.Text = "Thêm mới sản phẩm";
                btnAdd.Text = "Quay lại";
                ProductView.ActiveViewIndex = 1;
            }
            else
            {
                title.Text = "Quản lý sản phẩm";
                btnAdd.Text = "Thêm mới sản phẩm";
                ProductView.ActiveViewIndex = 0;
            }
        }

        //Nut xem truoc san pham
        protected void ReviewImageButton_Click(object sender, EventArgs e)
        {
        }

        //Nut them moi san pham
        protected void SaveAddProductButton_Click(object sender, EventArgs e)
        {
            string filePath = null;

            // Kiểm tra các trường đầu vào có rỗng không
            if (string.IsNullOrEmpty(txbMaSanPham.Text) ||
                string.IsNullOrEmpty(txbTenSanPham.Text) ||
                string.IsNullOrEmpty(txbMoTaSanPham.Text) ||
                string.IsNullOrEmpty(txbSLTK.Text) ||
                string.IsNullOrEmpty(txbGiamGiaSanPham.Text) ||
                string.IsNullOrEmpty(txbSoLuongDaBan.Text))
            {
                lblError.Text = "Không được để trống một trong các ô";
                return; // Thoát khỏi hàm nếu có trường rỗng
            }

            string filename = "";
            if (fileAnhSanPham.HasFile)
            {
                filename = fileAnhSanPham.FileName;
                filePath = Path.Combine(Server.MapPath("~/Images/Product/"), filename);

                // Kiểm tra xem thư mục đã tồn tại chưa
                string directoryPath = Server.MapPath("~/Images/Product/");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath); // Tạo thư mục nếu chưa tồn tại
                }

                fileAnhSanPham.SaveAs(filePath);
            }

            // Kết nối tới cơ sở dữ liệu và thực hiện lưu thông tin sản phẩm
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spud_addProduct", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@maSanPham", txbMaSanPham.Text);
                    cmd.Parameters.AddWithValue("@tenSanPham", txbTenSanPham.Text);
                    cmd.Parameters.AddWithValue("@giaSanPham", txbGiaSanPham.Text);
                    cmd.Parameters.AddWithValue("@moTaSanPham", txbMoTaSanPham.Text);
                    cmd.Parameters.AddWithValue("@soLuongTonKho", txbSLTK.Text);
                    cmd.Parameters.AddWithValue("@anhSanPham", "~/Images/Product/" + filename);
                    cmd.Parameters.AddWithValue("@maDanhMuc", ddl_danhmuc.SelectedValue);
                    cmd.Parameters.AddWithValue("@giamGia", txbGiamGiaSanPham.Text);
                    cmd.Parameters.AddWithValue("@SoLuongDaBan", txbSoLuongDaBan.Text);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery(); // Thực hiện lệnh
                        lblError.Text = "Thêm sản phẩm thành công."; // Hiển thị thông báo thành công
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 50000) 
                        {
                            lblError.Text = ex.Message; 
                            lblError.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            lblError.Text = "Đã xảy ra lỗi khi thêm sản phẩm. Vui lòng thử lại.";
                        }
                    }
                }
            }
        }




        protected void EditButton_Click(object sender, EventArgs e)
        {
            ProductView.ActiveViewIndex = 2;

            if (ProductView.ActiveViewIndex == 0)
            {
                title.Text = "Thêm mới sản phẩm";
                btnAdd.Text = "Quay lại";
            }
            else
            {
                title.Text = "Chỉnh sửa";
                btnAdd.Text = "Quay lại";
            }

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                LinkButton editButton = (LinkButton)sender;
                string masanpham = editButton.CommandArgument;

                string sql = "SELECT * FROM Product WHERE MaSanPham = @masanpham";
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.Parameters.AddWithValue("@masanpham", masanpham);

                using (SqlDataReader data = cmd.ExecuteReader())
                {
                    if (data.Read())
                    {
                        // Nạp dữ liệu vào các trường chỉnh sửa
                        txtEditMaSanPham.Text = data["MaSanPham"].ToString();
                        txtEditTenSanPham.Text = data["TenSanPham"].ToString();
                        txtEditGiaSanPham.Text = data["GiaSanPham"].ToString();
                        txtEditMoTaSanPham.Text = data["MoTaSanPham"].ToString();
                        txtEditSLTK.Text = data["SoLuongTonKho"].ToString();
                        txtEditGiamGiaSanPham.Text = data["GiamGia"].ToString();
                        txtEditSoLuongDaBan.Text = data["SoLuongDaBan"].ToString();

                        // Hiển thị ảnh từ cơ sở dữ liệu
                        ImageEdit.ImageUrl = data["AnhSanPham"].ToString();
                    }
                    else
                    {
                        lb_errorEdit.Text = "Sản phẩm không tồn tại.";
                    }
                }
            }
        }






        protected void SaveEditProductButton_Click(object sender, EventArgs e)
        {
            string filePath = null;

            // Kiểm tra xem có tệp nào được tải lên không
            if (fileEditAnhSanPham.HasFile)
            {
                string fileName = Path.GetFileName(fileEditAnhSanPham.FileName);
                filePath = "~/Images/Product/" + fileName; // Đường dẫn lưu ảnh
                fileEditAnhSanPham.SaveAs(Server.MapPath(filePath)); // Lưu ảnh vào server
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spud_updateProduct", conn))
                {
                    conn.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Truyền các tham số vào stored procedure
                    cmd.Parameters.AddWithValue("@maSanPham", txtEditMaSanPham.Text);
                    cmd.Parameters.AddWithValue("@tenSanPham", txtEditTenSanPham.Text);
                    cmd.Parameters.AddWithValue("@giaSanPham", Convert.ToDecimal(txtEditGiaSanPham.Text));
                    cmd.Parameters.AddWithValue("@moTaSanPham", txtEditMoTaSanPham.Text);
                    cmd.Parameters.AddWithValue("@soLuongTonKho", Convert.ToInt32(txtEditSLTK.Text)); // Chuyển đổi về INT
                    cmd.Parameters.AddWithValue("@anhSanPham", "~/Images/Product/"+filePath ?? string.Empty); // Nếu không có tệp mới thì dùng string.Empty
                    cmd.Parameters.AddWithValue("@giamGia", txtEditGiamGiaSanPham.Text);
                    cmd.Parameters.AddWithValue("@SoLuongDaBan", txtEditSoLuongDaBan.Text);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        lblError.Text = "Cập nhật thành công!";

                        // Cập nhật ảnh sau khi lưu
                        ImageEdit.ImageUrl = filePath ?? ImageEdit.ImageUrl; // Hiển thị ảnh mới nếu có, ngược lại giữ ảnh cũ

                        // Tải lại dữ liệu
                        LoadProductTable(); // Gọi lại phương thức này để refresh bảng
                    }
                    catch (SqlException ex)
                    {
                        lblError.Text = "Có lỗi xảy ra: " + ex.Message;
                    }
                }
            }
        }


        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            string connectString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectString);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("spud_deleteProduct", sqlConnection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("maSanPham", Request.QueryString["masanpham"]);
            cmd.ExecuteNonQuery();
        }

        protected void RemoveOldInfor_Click(object sender, EventArgs e)
        {

        }
    }
}