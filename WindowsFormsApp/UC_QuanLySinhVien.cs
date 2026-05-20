using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class UC_QuanLySinhVien : UserControl
    {
        GroupBox groupThongTin;

        Label lblMaSV;
        Label lblHoTen;
        Label lblNgaySinh;
        Label lblGioiTinh;
        Label lblLop;

        TextBox txtMaSV;
        TextBox txtHoTen;

        DateTimePicker dtNgaySinh;

        ComboBox cbGioiTinh;
        ComboBox cbLop;

        Button btnThem;
        Button btnSua;
        Button btnXoa;
        Button btnLamMoi;

        Label lblTimKiem;
        TextBox txtTimKiem;
        Button btnTim;

        DataGridView dgvSinhVien;

        Button btnFirst;
        Button btnPrev;
        Button btnNext;
        Button btnLast;

        Label lblTrang;

        public UC_QuanLySinhVien()
        {
            InitializeComponent();

            CreateUI();
        }

        private void CreateUI()
        {
            this.Dock = DockStyle.Fill;

            this.BackColor =
                Color.WhiteSmoke;

            // ================= THÔNG TIN =================

            groupThongTin = new GroupBox();

            groupThongTin.Text =
                "Thông tin sinh viên";

            groupThongTin.Location =
                new Point(20, 50);

            groupThongTin.Size =
                new Size(470, 730);

            this.Controls.Add(groupThongTin);

            // ================= MÃ SV =================

            lblMaSV = new Label();

            lblMaSV.Text =
                "Mã sinh viên:";

            lblMaSV.Location =
                new Point(20, 40);

            txtMaSV = new TextBox();

            txtMaSV.Location =
                new Point(20, 70);

            txtMaSV.Size =
                new Size(420, 30);

            // ================= HỌ TÊN =================

            lblHoTen = new Label();

            lblHoTen.Text =
                "Họ và tên:";

            lblHoTen.Location =
                new Point(20, 130);

            txtHoTen = new TextBox();

            txtHoTen.Location =
                new Point(20, 160);

            txtHoTen.Size =
                new Size(420, 30);

            // ================= NGÀY SINH =================

            lblNgaySinh = new Label();

            lblNgaySinh.Text =
                "Ngày sinh:";

            lblNgaySinh.Location =
                new Point(20, 220);

            dtNgaySinh =
                new DateTimePicker();

            dtNgaySinh.Format =
                DateTimePickerFormat.Short;

            dtNgaySinh.Location =
                new Point(20, 250);

            dtNgaySinh.Size =
                new Size(420, 30);

            // ================= GIỚI TÍNH =================

            lblGioiTinh = new Label();

            lblGioiTinh.Text =
                "Giới tính:";

            lblGioiTinh.Location =
                new Point(20, 310);

            cbGioiTinh =
                new ComboBox();

            cbGioiTinh.Location =
                new Point(20, 340);

            cbGioiTinh.Size =
                new Size(420, 30);

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");

            cbGioiTinh.SelectedIndex = 0;

            // ================= LỚP =================

            lblLop = new Label();

            lblLop.Text =
                "Lớp:";

            lblLop.Location =
                new Point(20, 400);

            cbLop = new ComboBox();

            cbLop.Location =
                new Point(20, 430);

            cbLop.Size =
                new Size(420, 30);

            cbLop.Items.Add("68PM1");
            cbLop.Items.Add("68PM2");

            cbLop.SelectedIndex = 0;

            // ================= BUTTON =================

            btnThem = new Button();

            btnThem.Text = "Thêm";

            btnThem.Size =
                new Size(200, 55);

            btnThem.Location =
                new Point(20, 540);

            btnThem.BackColor =
                Color.DeepSkyBlue;

            btnThem.ForeColor =
                Color.White;

            btnSua = new Button();

            btnSua.Text = "Sửa";

            btnSua.Size =
                new Size(200, 55);

            btnSua.Location =
                new Point(240, 540);

            btnSua.BackColor =
                Color.LimeGreen;

            btnSua.ForeColor =
                Color.White;

            btnXoa = new Button();

            btnXoa.Text = "Xóa";

            btnXoa.Size =
                new Size(200, 55);

            btnXoa.Location =
                new Point(20, 620);

            btnXoa.BackColor =
                Color.Red;

            btnXoa.ForeColor =
                Color.White;

            btnLamMoi = new Button();

            btnLamMoi.Text =
                "Làm mới";

            btnLamMoi.Size =
                new Size(200, 55);

            btnLamMoi.Location =
                new Point(240, 620);

            btnLamMoi.BackColor =
                Color.Gray;

            btnLamMoi.ForeColor =
                Color.White;

            // ================= ADD CONTROL =================

            groupThongTin.Controls.Add(lblMaSV);
            groupThongTin.Controls.Add(txtMaSV);

            groupThongTin.Controls.Add(lblHoTen);
            groupThongTin.Controls.Add(txtHoTen);

            groupThongTin.Controls.Add(lblNgaySinh);
            groupThongTin.Controls.Add(dtNgaySinh);

            groupThongTin.Controls.Add(lblGioiTinh);
            groupThongTin.Controls.Add(cbGioiTinh);

            groupThongTin.Controls.Add(lblLop);
            groupThongTin.Controls.Add(cbLop);

            groupThongTin.Controls.Add(btnThem);
            groupThongTin.Controls.Add(btnSua);
            groupThongTin.Controls.Add(btnXoa);
            groupThongTin.Controls.Add(btnLamMoi);

            // ================= SEARCH =================

            lblTimKiem = new Label();

            lblTimKiem.Text =
                "Tìm kiếm (Tên / Mã):";

            lblTimKiem.Location =
                new Point(540, 60);

            txtTimKiem = new TextBox();

            txtTimKiem.Location =
                new Point(540, 90);

            txtTimKiem.Size =
                new Size(420, 30);

            btnTim = new Button();

            btnTim.Text = "Tìm";

            btnTim.Location =
                new Point(980, 85);

            btnTim.Size =
                new Size(140, 45);

            btnTim.BackColor =
                Color.FromArgb(52, 73, 94);

            btnTim.ForeColor =
                Color.White;

            this.Controls.Add(lblTimKiem);
            this.Controls.Add(txtTimKiem);
            this.Controls.Add(btnTim);

            // ================= DATAGRIDVIEW =================

            dgvSinhVien =
                new DataGridView();

            dgvSinhVien.Location =
                new Point(540, 160);

            dgvSinhVien.Size =
                new Size(1000, 600);

            dgvSinhVien.ColumnCount = 5;

            dgvSinhVien.Columns[0].Name =
                "Mã SV";

            dgvSinhVien.Columns[1].Name =
                "Họ và Tên";

            dgvSinhVien.Columns[2].Name =
                "Giới Tính";

            dgvSinhVien.Columns[3].Name =
                "Ngày Sinh";

            dgvSinhVien.Columns[4].Name =
                "Lớp";

            dgvSinhVien.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvSinhVien.AllowUserToAddRows =
                false;

            dgvSinhVien.Rows.Add(
                "1",
                "Hiếu",
                "Nam",
                "11/03/2026",
                "68PM1"
            );

            dgvSinhVien.Rows.Add(
                "2",
                "Nguyễn Văn B",
                "Nam",
                "11/03/2026",
                "68PM2"
            );

            dgvSinhVien.Rows.Add(
                "3",
                "Trần Văn C",
                "Nam",
                "21/03/2026",
                "68PM2"
            );

            this.Controls.Add(dgvSinhVien);

            // ================= PHÂN TRANG =================

            int centerX = 930;

            btnFirst = new Button();

            btnFirst.Text = "<<";

            btnFirst.Size =
                new Size(70, 45);

            btnFirst.Location =
                new Point(centerX - 220, 790);

            btnFirst.BackColor =
                Color.White;

            this.Controls.Add(btnFirst);

            // ===== PREV =====

            btnPrev = new Button();

            btnPrev.Text = "<";

            btnPrev.Size =
                new Size(70, 45);

            btnPrev.Location =
                new Point(centerX - 140, 790);

            btnPrev.BackColor =
                Color.White;

            this.Controls.Add(btnPrev);

            // ===== LABEL =====

            lblTrang = new Label();

            lblTrang.Text =
                "Trang 1/1 | 3 bản ghi";

            lblTrang.AutoSize = true;

            lblTrang.Font =
                new Font(
                    "Arial",
                    10,
                    FontStyle.Regular
                );

            lblTrang.Location =
                new Point(centerX - 5, 803);

            this.Controls.Add(lblTrang);

            // ===== NEXT =====

            btnNext = new Button();

            btnNext.Text = ">";

            btnNext.Size =
                new Size(70, 45);

            btnNext.Location =
                new Point(centerX + 150, 790);

            btnNext.BackColor =
                Color.White;

            this.Controls.Add(btnNext);

            // ===== LAST =====

            btnLast = new Button();

            btnLast.Text = ">>";

            btnLast.Size =
                new Size(70, 45);

            btnLast.Location =
                new Point(centerX + 230, 790);

            btnLast.BackColor =
                Color.White;

            this.Controls.Add(btnLast);
        }

        private void UC_QuanLySinhVien_Load(
            object sender,
            EventArgs e
        )
        {

        }
    }
}