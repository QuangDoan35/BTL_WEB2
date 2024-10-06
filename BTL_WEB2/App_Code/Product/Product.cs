namespace BTL_WEB2.App_Code.Product
{
    public class Product
    {
        private string maSanPham;
        private string tenSanPham;
        private double giaSanPham;
        private string moTaSanPham;
        private string anhSanPham;
        private int soLuongTonKho;
        private string maDanhMuc;
        private int giamGia;

        public Product() { }

        public Product(string maSanPham, string tenSanPham, double giaSanPham, string moTaSanPham, string anhSanPham, int soLuongTonKho, string maDanhMuc, int giamGia)
        {
            this.maSanPham = maSanPham;
            this.tenSanPham = tenSanPham;
            this.giaSanPham = giaSanPham;
            this.moTaSanPham = moTaSanPham;
            this.anhSanPham = anhSanPham;
            this.soLuongTonKho = soLuongTonKho;
            this.maDanhMuc = maDanhMuc;
            this.giamGia = giamGia;
        }

        public string getMaSanPham() { return maSanPham; }
        public string getTenSanPham() { return tenSanPham; }
        public double getGiaSanPham() { return giaSanPham; }
        public string getMoTaSanPham() { return moTaSanPham; }
        public string getAnhSanPham() { return anhSanPham; }
        public int getSoLuongTonKho() { return soLuongTonKho; }
        public string getMaDanhMuc() { return maDanhMuc; }
        public int getGiamGia() { return giamGia; }
    }
}