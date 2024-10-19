using BTL_WEB2.App_Code.Category;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace BTL_WEB2.Pages.AdminPage
{
    public partial class CategoryManager : System.Web.UI.Page
    {
        CategoryDAO categoryDAO = new CategoryDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryView.ActiveViewIndex = 0;
                ViewState["countClick"] = 0;
                ViewState["imageFileName"] = string.Empty;// Đặt giá trị ban đầu cho countClick để tái sử dụng nút add button
                ViewState["isSave"] = false; //Đánh dấu người dùng bấm nút lưu
                ViewState["imageFilePath"] = string.Empty;
                ViewState["btnChangeStatus"] = null;
            }
            LoadCategoryTable();
        }

        //Hiển thị danh sách danh mục
        protected void LoadCategoryTable()
        {
            List<Category> listCategory = categoryDAO.GetList(); // Lấy danh sách danh mục từ cơ sở dữ liệu

            if (listCategory != null && listCategory.Count > 0)
            {
                int stt = 1; // Giá trị tăng dần cho cột STT

                foreach (Category category in listCategory)
                {
                    string trangthai = category.getTrangThai();

                    TableRow tableRow = new TableRow();

                    TableCell cellSTT = new TableCell { Text = stt.ToString() };
                    TableCell cellMaDanhMuc = new TableCell { Text = category.getMaDanhMuc() };
                    TableCell cellTenDanhMuc = new TableCell { Text = category.getTenDanhMuc() };
                    TableCell cellMoTaDanhMuc = new TableCell { Text = category.getMoTaDanhMuc() };

                    // Tạo đối tượng Image và thiết lập các thuộc tính
                    Image img = new Image
                    {
                        ImageUrl = category.getAnhDanhMuc(), // Đường dẫn đến hình ảnh
                        Width = Unit.Pixel(100), // Chiều rộng ảnh
                        Height = Unit.Pixel(50)  // Chiều cao ảnh
                    };

                    // Thêm thuộc tính style cho ảnh
                    img.Attributes.Add("style", "object-fit: cover;");

                    TableCell cellAnhDanhMuc = new TableCell();
                    cellAnhDanhMuc.Controls.Add(img);
                    cellAnhDanhMuc.Attributes.Add("style", "text-align: center; vertical-align: middle;");

                    // Tạo nút chỉnh sửa
                    LinkButton editButton = new LinkButton
                    {
                        Text = "Chỉnh sửa",
                        CommandArgument = category.getMaDanhMuc(), //Lưu mã của danh mục
                    };
                    editButton.Click += EditButton_Click; // Đăng ký sự kiện Click
                    TableCell cellNutChinhSua = new TableCell();
                    cellNutChinhSua.Controls.Add(editButton);
                    cellNutChinhSua.Attributes.Add("style", "text-align: center; vertical-align: middle;");

                    // Thêm các ô vào hàng
                    tableRow.Cells.Add(cellSTT);
                    tableRow.Cells.Add(cellMaDanhMuc);
                    tableRow.Cells.Add(cellTenDanhMuc);
                    tableRow.Cells.Add(cellMoTaDanhMuc);
                    tableRow.Cells.Add(cellAnhDanhMuc);
                    tableRow.Cells.Add(cellNutChinhSua);

                    //Style cho row và ảnh tùy theo trạng thái của danh mục
                    if (!trangthai.Equals("ACTIVATED"))
                    {
                        img.Attributes.Add("style", "filter: grayscale(100%);"); //Màu chữ và hiệu ứng ảnh đen trắng của hàng khi trạng thái danh mục là không active
                        tableRow.Attributes.Add("style", "color: #B7B7B7;");
                    }

                    // Thêm hàng vào bảng
                    CategoryTable.Rows.Add(tableRow);

                    stt++;
                }

                lblEmptyTable.Text = string.Empty;
            }
            else
            {
                lblEmptyTable.Text = "Không có danh mục nào để hiển thị, thêm danh mục mới ngay!";
            }
        }

        //Thêm danh mục
        protected void AddButton_Onclick(object sender, EventArgs e)
        {
            int countClick = (int)ViewState["countClick"];

            //Thêm danh mục
            if (countClick == 0)
            {
                categoryView.ActiveViewIndex = 1; //Chuyển sang view thêm danh mục
                ViewState["countClick"] = 1; //Tăng biến đếm lên để tí quay lại view ban đầu
                title.Text = "Thêm mới danh mục";
                btnAdd.Text = "Quay lại";
                Image1.ImageUrl = "~/Images/Category/DefaultCategoryImg.png";
                lblError.Text = "";
                ViewState["isSave"] = false;
                ViewState["imageFileName"] = string.Empty;


                //Xóa đi thông tin cũ
                txbMaDanhMuc.Text = string.Empty;
                txbTenDanhMuc.Text = string.Empty;
                txbMoTaDanhMuc.Text = string.Empty;
            }
            //Quay trờ lại
            else if (countClick == 1)
            {
                categoryView.ActiveViewIndex = 0; //Quay trở lại view ban đầu
                title.Text = "Quản lý danh mục";
                btnAdd.Text = "Thêm mới danh mục";
                ViewState["countClick"] = 0;
                lblError.Text = "";
                //Kiểm tra xem người dùng đã bấm nút lưu ở lần thêm trước chưa, hoặc là ở lần thêm trước có tải ảnh lên không
                //nếu mà chưa lưu lại mà đã thoát thì xóa ảnh cũ ra khỏi thư mục Image
                if (ViewState["imageFileName"] != null && (bool)ViewState["isSave"] == false)
                {
                    //Xóa tệp
                    string oldFileName = ViewState["imageFileName"].ToString();
                    string oldFilePath = Server.MapPath("~/Images/Category/") + oldFileName;

                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }
            }
        }

        //Nút xem ảnh trong quá trình thêm mới và danh mục
        protected void ReviewImageButton_Click(object sender, EventArgs e)
        {
            if (fileAnhDanhMuc.HasFile)
            {
                // Lấy tên tệp ảnh từ điều khiển FileUpload
                string fileName = Path.GetFileName(fileAnhDanhMuc.FileName);
                string filePath = Server.MapPath("~/Images/Category/") + fileName;

                // Kiểm tra nếu có ảnh cũ, xóa ảnh cũ
                if (ViewState["imageFileName"] != null)
                {
                    string oldFileName = ViewState["imageFileName"].ToString();
                    string oldFilePath = Server.MapPath("~/Images/Category/") + oldFileName;

                    // Xóa tệp cũ nếu nó tồn tại
                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }

                ViewState["isSave"] = false; //Đánh dấu lại là chưa lưu
                                             // Lưu tên file ảnh vào trong view state
                ViewState["imageFileName"] = fileName;

                fileAnhDanhMuc.SaveAs(filePath); // Lưu tạm thời vào trong thư mục image để hiển thị

                // Gán đường dẫn của ảnh vào Image control
                Image1.ImageUrl = "~/Images/Category/" + fileName;
            }
            else
            {
                lblError.Text = "Bạn chưa chọn ảnh cho danh mục!";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Lưu thông tin thêm danh mục người dùng nhập vào
        protected void SaveAddButton_Click(object sender, EventArgs e)
        {
            string ma = txbMaDanhMuc.Text.Trim();
            string ten = txbTenDanhMuc.Text.Trim();
            string mota = txbMoTaDanhMuc.Text.Trim();

            // Lấy tên ảnh từ ViewState
            string fileName = ViewState["imageFileName"]?.ToString() ?? string.Empty;

            //Kiểm tra mã danh mục nhập vào đã tồn tại hay là chưa
            Category category = categoryDAO.GetCategoryById(ma);
            if (category != null)
            {
                lblError.Text = "Mã danh mục đã tồn tại trong cơ sở dữ liệu, hãy điền mã danh mục khác!";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Kiểm tra thông tin
            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(mota))
            {
                lblError.Text = "Vui lòng nhập đủ thông tin của Danh mục!";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Kiểm tra nếu chưa có ảnh nào được chọn
            if (string.IsNullOrEmpty(fileName) && !fileAnhDanhMuc.HasFile)
            {
                lblError.Text = "Vui lòng chọn ảnh trước khi lưu!";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Nếu có ảnh được chọn, xử lý việc lưu
            if (fileAnhDanhMuc.HasFile)
            {
                fileName = Path.GetFileName(fileAnhDanhMuc.FileName); // Lấy tên ảnh mới
                ViewState["imageFileName"] = fileName; // Lưu tên ảnh vào ViewState

                string filePath = Server.MapPath("~/Images/Category/") + fileName;

                // Lưu ảnh vào thư mục
                fileAnhDanhMuc.SaveAs(filePath); // Thực hiện lưu ảnh
            }

            // Gán đường dẫn ảnh cho đối tượng
            string anh = "~/Images/Category/" + fileName;

            // Thêm danh mục vào cơ sở dữ liệu
            categoryDAO.Insert(ma, ten, mota, anh);

            // Đánh dấu trạng thái đã lưu
            ViewState["isSave"] = true;

            //Xóa text sau khi lưu thành công
            txbMaDanhMuc.Text = string.Empty;
            txbTenDanhMuc.Text = string.Empty;
            txbMoTaDanhMuc.Text = string.Empty;
            Image1.ImageUrl = "~/Images/Category/DefaultCategoryImg.png";

            lblError.Text = "Lưu danh mục thành công";
            lblError.ForeColor = System.Drawing.ColorTranslator.FromHtml("#118AB2");
        }

        // Chỉnh sửa danh mục
        protected void EditButton_Click(object sender, EventArgs e)
        {
            Label1.Text = string.Empty;

            int countClick = (int)ViewState["countClick"];
            LinkButton editButton = (LinkButton)sender;
            string maDanhMuc = editButton.CommandArgument; // Lấy mã danh mục từ nút "Chỉnh sửa"

            // Truy vấn danh mục từ cơ sở dữ liệu dựa trên mã danh mục
            Category category = categoryDAO.GetCategoryById(maDanhMuc);

            if (category != null)
            {
                // Hiển thị thông tin danh mục vào các TextBox
                txtEditMaDanhMuc.Text = category.getMaDanhMuc();
                txtEditTenDanhMuc.Text = category.getTenDanhMuc();
                txtEditMoTaDanhMuc.Text = category.getMoTaDanhMuc();

                Image2.ImageUrl = category.getAnhDanhMuc();
                ViewState["imageFilePath"] = category.getAnhDanhMuc(); //Lấy ảnh của danh mục, dùng khi người dùng không cập nhật ảnh

                //Lấy Trạng thái của danh mục được chọn và gán text tương ứng cho button btn-change-status
                if (category.getTrangThai().Equals("ACTIVATED"))
                {
                    btnChangeStatus.Text = "Vô hiệu hóa danh mục";
                    ViewState["btnChangeStatus"] = 0; // 0 là trạng thái vô hiệu hóa
                }
                else if (category.getTrangThai().Equals("UNACTIVATED"))
                {
                    btnChangeStatus.Text = "Kích hoạt danh mục";
                    ViewState["btnChangeStatus"] = 1; // 1 là trạng thái kích hoạt
                }

                ViewState["currentCategoryId"] = maDanhMuc; // Lưu lại mã danh mục để sử dụng khi cập nhật
                                                            // Chuyển sang view chỉnh sửa
                categoryView.ActiveViewIndex = 2;
                title.Text = "Chỉnh sửa danh mục";
                btnAdd.Text = "Quay lại";
                ViewState["countClick"] = 1;
            }
        }

        // nút xóa thông tin cũ trên các ô text box để không phải xóa thủ công
        protected void RemoveOldInfor_Click(object sender, EventArgs e)
        {
            txtEditTenDanhMuc.Text = string.Empty;
            txtEditMoTaDanhMuc.Text = string.Empty;
        }

        //lưu thông tin sửa danh mục
        protected void SaveEditButton_Click(object sender, EventArgs e)
        {
            string ma = txtEditMaDanhMuc.Text;
            string ten = txtEditTenDanhMuc.Text;
            string mota = txtEditMoTaDanhMuc.Text;
            string anh = (string)ViewState["imageFilePath"]; //Lấy ảnh hiện tại từ ViewState;

            if (fileEditAnhDanhMuc.HasFile)
            {
                string fileName = Path.GetFileName(fileEditAnhDanhMuc.FileName);
                string filePath = Server.MapPath("~/Images/Category/") + fileName;
                fileEditAnhDanhMuc.SaveAs(filePath);
                Image2.ImageUrl = "~/Images/Category/" + fileName;
                anh = "~/Images/Category/" + fileName;
                ViewState["imageFilePath"] = anh;
            }

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(mota))
            {
                Label1.Text = "Vui lòng nhập thông tin đầy đủ!";
                Image2.ImageUrl = (string)ViewState["imageFilePath"];
                return;
            }

            categoryDAO.Update(ma, ten, mota, anh); // Cập nhật danh mục

            Label1.Text = "Cập nhật thành công";
            Label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#118AB2");
        }


        //Thay đổi trạng thái của danh mục
        protected void ChangeStatusCategory_Click(object sender, EventArgs e)
        {
            string maDanhMuc = txtEditMaDanhMuc.Text;

            int check = (int)ViewState["btnChangeStatus"]; //Lấy giá trị đã được gán vào ở trong hàm EditButton_Click
            categoryDAO.SetCategoryStatus(maDanhMuc, check);

            LoadCategoryTable();

            categoryView.ActiveViewIndex = 0;
            Response.Redirect(Request.RawUrl); //Refesh lại trang
        }
    }
}