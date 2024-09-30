using BTL_WEB2.App_Code;
using System;

namespace BTL_WEB2.Admin.Category
{
    public partial class CategoryControl : System.Web.UI.UserControl
    {
        ClsCategory clsCategory = new ClsCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        void LoadData()
        {
            rptCategory.DataSource = clsCategory.GetList();
            rptCategory.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            mul.ActiveViewIndex = 1;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            mul.ActiveViewIndex = 0;
            lbError.CssClass = "";
            lbError.Text = string.Empty;

            maDanhMuc.Text = string.Empty;
            tenDanhMuc.Text = string.Empty;
            moTaDanhMuc.Text = string.Empty;
            maDanhMuc.Text = string.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string mdm = maDanhMuc.Text.ToString();
            string tdm = tenDanhMuc.Text.ToString();
            string mtdm = moTaDanhMuc.Text.ToString();
            string fileName = anhDanhMuc.FileName;

            //Kiểm tra xem đã nhập vào đầy đủ thông tin chưa
            bool empty = string.IsNullOrEmpty(mdm) || string.IsNullOrEmpty(tdm) || string.IsNullOrEmpty(mtdm) || string.IsNullOrEmpty(fileName);

            if (!empty) //nếu đã đầy đủ thông tin
            {
                string savePath;
                // Tạo đường dẫn tương đối
                savePath = "Images/Category/" + fileName; // Lưu đường dẫn tương đối

                // Lưu ảnh vào thư mục
                string fullSavePath = Server.MapPath(savePath); // Đường dẫn đầy đủ
                anhDanhMuc.SaveAs(fullSavePath);

                // Lưu đường dẫn tương đối vào cơ sở dữ liệu
                clsCategory.Insert(mdm, tdm, mtdm, savePath);

                //Refesh lại trang web
                Response.Redirect(Request.Url.ToString());
            }
            //Nếu chưa nhập đủ thông tin thì sẽ in ra thông báo lỗi
            else
            {
                lbError.Text = "Phải nhập đầy đủ thông tin mới có thể lưu!";
                lbError.CssClass = "blinking-text";
            }
        }
    }
}