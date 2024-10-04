namespace BTL_WEB2.App_Code.Category
{
    public class Category
    {
        private string MaDanhMuc;
        private string TenDanhMuc;
        private string MoTaDanhMuc;
        private string AnhDanhMuc;
        private string TrangThai;

        public Category() { }

        public Category(string maDanhMuc, string tenDanhMuc, string moTaDanhMuc, string anhDanhMuc, string trangThai)
        {
            MaDanhMuc = maDanhMuc;
            TenDanhMuc = tenDanhMuc;
            MoTaDanhMuc = moTaDanhMuc;
            AnhDanhMuc = anhDanhMuc;
            TrangThai = trangThai;
        }

        public string getMaDanhMuc() { return MaDanhMuc; }
        public string getTenDanhMuc() { return TenDanhMuc; }
        public string getMoTaDanhMuc() { return MoTaDanhMuc; }
        public string getAnhDanhMuc() { return AnhDanhMuc; }
        public string getTrangThai() { return TrangThai; }
    }
}