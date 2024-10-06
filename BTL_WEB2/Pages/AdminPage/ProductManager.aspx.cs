using System;
using System.Data.SqlClient;
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

            }

            LoadProductTable();
        }

        private void LoadProductTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string str = "SELECT * FROM Product";
                SqlCommand cmd = new SqlCommand(str, connection);
                SqlDataReader data = cmd.ExecuteReader();

                int j = 1; // Biến đếm để đánh số thứ tự
                while (data.Read())
                {
                    TableCell stt = new TableCell() { Text = j.ToString() };
                    TableCell ma = new TableCell() { Text = data[0].ToString() };
                    TableCell ten = new TableCell() { Text = data[1].ToString() };
                    TableCell gia = new TableCell() { Text = data[2].ToString() };
                    TableCell mota = new TableCell() { Text = data[3].ToString() };

                    Image image = new Image
                    {
                        ImageUrl = data[4].ToString(),
                        Width = Unit.Pixel(100),
                        Height = Unit.Pixel(50)
                    };


                    TableCell anh = new TableCell();
                    anh.Controls.Add(image);
                    TableCell soluong = new TableCell() { Text = data[5].ToString() };
                    TableCell maDM = new TableCell() { Text = data[6].ToString() };

                    LinkButton editButton = new LinkButton
                    {
                        Text = "Chỉnh sửa",
                        CommandArgument = data[0].ToString(), //Lưu mã của sản phẩm
                    };
                    editButton.Click += EditButton_Click; // Đăng ký sự kiện Click
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
                    row.Cells.Add(nutChinhSua);

                    ProductTable.Controls.Add(row); // Thêm dòng vào bảng
                    j++; // Tăng giá trị chỉ số dòng
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

        }

        //Nút chỉnh sửa sản phẩm
        protected void EditButton_Click(object sender, EventArgs e)
        {
            ProductView.ActiveViewIndex = 2;
        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {

        }

        protected void SaveEditProductButton_Click(object sender, EventArgs e)
        {

        }

        protected void RemoveOldInfor_Click(object sender, EventArgs e)
        {

        }
    }
}