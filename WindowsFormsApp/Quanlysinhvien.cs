using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Quanlysinhvien : Form
    {
        // ===== MENU =====
        MenuStrip menuStrip;
        ToolStripMenuItem menuQLSV;
        ToolStripMenuItem menuQLLop;
        ToolStripMenuItem menuDangXuat;

        // ===== LEFT PANEL =====
        GroupBox groupThongTin;

        Label lblMaSV;
        Label lblHoTen;
        Label lblNgaySinh;
        Label lblGioiTinh;
        Label lblLop;

        TextBox txtMaSV;
        TextBox txtHoTen;

        DateTimePicker dtpNgaySinh;

        ComboBox cboGioiTinh;
        ComboBox cboLop;

        Button btnThem;
        Button btnSua;
        Button btnXoa;
        Button btnLamMoi;

        // ===== RIGHT PANEL =====
        Label lblTimKiem;
        TextBox txtTimKiem;
        Button btnTim;

        DataGridView dgvSinhVien;

        Button btnFirst;
        Button btnPrev;
        Button btnNext;
        Button btnLast;

        Label lblTrang;

        public Quanlysinhvien()
        {
            InitializeComponent();
            CreateUI();
        }

        private void CreateUI()
        {
            // ================= FORM =================
            this.Text = "Quản Lý Sinh Viên";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.WhiteSmoke;

            // ================= MENU =================
            menuStrip = new MenuStrip();

            menuQLSV = new ToolStripMenuItem("Quản Lý Sinh Viên");
            menuQLLop = new ToolStripMenuItem("Quản Lý Lớp Học");
            menuDangXuat = new ToolStripMenuItem("Đăng xuất");

            menuStrip.Items.Add(menuQLSV);
            menuStrip.Items.Add(menuQLLop);
            menuStrip.Items.Add(menuDangXuat);

            this.Controls.Add(menuStrip);

            // ================= GROUPBOX =================
            groupThongTin = new GroupBox();
            groupThongTin.Text = "Thông tin sinh viên";
            groupThongTin.Location = new Point(20, 60);
            groupThongTin.Size = new Size(470, 720);

            this.Controls.Add(groupThongTin);

            // ================= LABEL + TEXTBOX =================

            // Mã SV
            lblMaSV = new Label();
            lblMaSV.Text = "Mã sinh viên:";
            lblMaSV.Location = new Point(20, 40);

            txtMaSV = new TextBox();
            txtMaSV.Location = new Point(20, 70);
            txtMaSV.Size = new Size(420, 30);

            // Họ tên
            lblHoTen = new Label();
            lblHoTen.Text = "Họ và tên:";
            lblHoTen.Location = new Point(20, 130);

            txtHoTen = new TextBox();
            txtHoTen.Location = new Point(20, 160);
            txtHoTen.Size = new Size(420, 30);

            // Ngày sinh
            lblNgaySinh = new Label();
            lblNgaySinh.Text = "Ngày sinh:";
            lblNgaySinh.Location = new Point(20, 220);

            dtpNgaySinh = new DateTimePicker();
            dtpNgaySinh.Location = new Point(20, 250);
            dtpNgaySinh.Size = new Size(420, 30);
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";

            // Giới tính
            lblGioiTinh = new Label();
            lblGioiTinh.Text = "Giới tính:";
            lblGioiTinh.Location = new Point(20, 310);

            cboGioiTinh = new ComboBox();
            cboGioiTinh.Location = new Point(20, 340);
            cboGioiTinh.Size = new Size(420, 30);

            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");

            // Lớp
            lblLop = new Label();
            lblLop.Text = "Lớp:";
            lblLop.Location = new Point(20, 400);

            cboLop = new ComboBox();
            cboLop.Location = new Point(20, 430);
            cboLop.Size = new Size(420, 30);

            cboLop.Items.Add("68PM1");
            cboLop.Items.Add("68PM2");
            cboLop.Items.Add("68PM3");

            // ================= BUTTON =================

            btnThem = new Button();
            btnThem.Text = "Thêm";
            btnThem.Size = new Size(200, 55);
            btnThem.Location = new Point(20, 520);
            btnThem.BackColor = Color.DeepSkyBlue;
            btnThem.ForeColor = Color.White;

            btnSua = new Button();
            btnSua.Text = "Sửa";
            btnSua.Size = new Size(200, 55);
            btnSua.Location = new Point(240, 520);
            btnSua.BackColor = Color.LimeGreen;
            btnSua.ForeColor = Color.White;

            btnXoa = new Button();
            btnXoa.Text = "Xóa";
            btnXoa.Size = new Size(200, 55);
            btnXoa.Location = new Point(20, 590);
            btnXoa.BackColor = Color.Red;
            btnXoa.ForeColor = Color.White;

            btnLamMoi = new Button();
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Size = new Size(200, 55);
            btnLamMoi.Location = new Point(240, 590);
            btnLamMoi.BackColor = Color.Gray;
            btnLamMoi.ForeColor = Color.White;
            // ================= ADD CONTROL TO GROUPBOX =================

            groupThongTin.Controls.Add(lblMaSV);
            groupThongTin.Controls.Add(txtMaSV);

            groupThongTin.Controls.Add(lblHoTen);
            groupThongTin.Controls.Add(txtHoTen);

            groupThongTin.Controls.Add(lblNgaySinh);
            groupThongTin.Controls.Add(dtpNgaySinh);

            groupThongTin.Controls.Add(lblGioiTinh);
            groupThongTin.Controls.Add(cboGioiTinh);

            groupThongTin.Controls.Add(lblLop);
            groupThongTin.Controls.Add(cboLop);

            groupThongTin.Controls.Add(btnThem);
            groupThongTin.Controls.Add(btnSua);
            groupThongTin.Controls.Add(btnXoa);
            groupThongTin.Controls.Add(btnLamMoi);

            // ================= SEARCH =================

            lblTimKiem = new Label();
            lblTimKiem.Text = "Tìm kiếm (Tên / Mã SV / Lớp):";
            lblTimKiem.Location = new Point(520, 70);

            txtTimKiem = new TextBox();
            txtTimKiem.Location = new Point(520, 100);
            txtTimKiem.Size = new Size(400, 30);

            btnTim = new Button();
            btnTim.Text = "Tìm";
            btnTim.Location = new Point(940, 95);
            btnTim.Size = new Size(140, 45);
            btnTim.BackColor = Color.FromArgb(52, 73, 94);
            btnTim.ForeColor = Color.White;

            this.Controls.Add(lblTimKiem);
            this.Controls.Add(txtTimKiem);
            this.Controls.Add(btnTim);

            dgvSinhVien = new DataGridView();
            dgvSinhVien.Location = new Point(520, 160);
            dgvSinhVien.Size = new Size(900, 650);

            dgvSinhVien.ColumnCount = 5;

            dgvSinhVien.Columns[0].Name = "Mã SV";
            dgvSinhVien.Columns[1].Name = "Họ và Tên";
            dgvSinhVien.Columns[2].Name = "Giới Tính";
            dgvSinhVien.Columns[3].Name = "Ngày Sinh";
            dgvSinhVien.Columns[4].Name = "Lớp";

            dgvSinhVien.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvSinhVien.AllowUserToAddRows = false;


            dgvSinhVien.Rows.Add(
                "1",
                "Hieu",
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

            // ================= PAGINATION =================

            btnFirst = new Button();
            btnFirst.Text = "<<";
            btnFirst.Location = new Point(520, 830);
            btnFirst.Size = new Size(70, 50);

            btnPrev = new Button();
            btnPrev.Text = "<";
            btnPrev.Location = new Point(600, 830);
            btnPrev.Size = new Size(70, 50);

            lblTrang = new Label();
            lblTrang.Text = "Trang 1/1 | 3 bản ghi";
            lblTrang.Location = new Point(800, 845);
            lblTrang.AutoSize = true;

            btnNext = new Button();
            btnNext.Text = ">";
            btnNext.Location = new Point(1060, 830);
            btnNext.Size = new Size(70, 50);

            btnLast = new Button();
            btnLast.Text = ">>";
            btnLast.Location = new Point(1140, 830);
            btnLast.Size = new Size(70, 50);

            this.Controls.Add(btnFirst);
            this.Controls.Add(btnPrev);
            this.Controls.Add(lblTrang);
            this.Controls.Add(btnNext);
            this.Controls.Add(btnLast);
        }

        private void Quanlysinhvien_Load(object sender, EventArgs e)
        {

        }
    }
}