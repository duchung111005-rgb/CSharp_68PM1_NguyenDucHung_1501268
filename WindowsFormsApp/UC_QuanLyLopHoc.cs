using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class UC_QuanLyLopHoc : UserControl
    {
        QLSVDataContext db = new QLSVDataContext();

        GroupBox groupThongTin;

        Label lblId;
        Label lblMaLop;
        Label lblTenLop;
        Label lblGhiChu;

        TextBox txtId;
        TextBox txtMaLop;
        TextBox txtTenLop;
        TextBox txtGhiChu;

        Button btnThem;
        Button btnSua;
        Button btnXoa;
        Button btnLamMoi;
        Button btnXemSinhVien;

        Label lblTimKiem;
        TextBox txtTimKiem;
        Button btnTim;

        DataGridView dgvLopHoc;

        Button btnFirst;
        Button btnPrev;
        Button btnNext;
        Button btnLast;

        Label lblTrang;

        public UC_QuanLyLopHoc()
        {
            InitializeComponent();

            CreateUI();

            LoadLopHoc();
        }

        private void LoadLopHoc()
        {
            dgvLopHoc.DataSource = db.tbl_lophocs.Select(l => new
            {
                l.id,
                l.malop,
                l.tenlop,
                l.ghichu
            }).ToList();

            lblTrang.Text = "Tổng: " + db.tbl_lophocs.Count() + " lớp";
        }

        private void CreateUI()
        {
            this.Dock = DockStyle.Fill;

            this.BackColor = Color.WhiteSmoke;

            groupThongTin = new GroupBox();

            groupThongTin.Text = "Thông tin lớp học";

            groupThongTin.Location = new Point(20, 50);

            groupThongTin.Size = new Size(470, 700);

            this.Controls.Add(groupThongTin);

            lblId = new Label();

            lblId.Text = "Mã ID:";

            lblId.Location = new Point(20, 40);

            txtId = new TextBox();

            txtId.Location = new Point(20, 70);

            txtId.Size = new Size(420, 30);

            lblMaLop = new Label();

            lblMaLop.Text = "Mã lớp:";

            lblMaLop.Location = new Point(20, 130);

            txtMaLop = new TextBox();

            txtMaLop.Location = new Point(20, 160);

            txtMaLop.Size = new Size(420, 30);

            lblTenLop = new Label();

            lblTenLop.Text = "Tên lớp:";

            lblTenLop.Location = new Point(20, 220);

            txtTenLop = new TextBox();

            txtTenLop.Location = new Point(20, 250);

            txtTenLop.Size = new Size(420, 30);

            lblGhiChu = new Label();

            lblGhiChu.Text = "Ghi chú:";

            lblGhiChu.Location = new Point(20, 310);

            txtGhiChu = new TextBox();

            txtGhiChu.Location = new Point(20, 340);

            txtGhiChu.Size = new Size(420, 30);

            btnThem = new Button();

            btnThem.Text = "Thêm";

            btnThem.Size = new Size(200, 55);

            btnThem.Location = new Point(20, 450);

            btnThem.BackColor = Color.DeepSkyBlue;

            btnThem.ForeColor = Color.White;

            btnSua = new Button();

            btnSua.Text = "Sửa";

            btnSua.Size = new Size(200, 55);

            btnSua.Location = new Point(240, 450);

            btnSua.BackColor = Color.LimeGreen;

            btnSua.ForeColor = Color.White;

            btnXoa = new Button();

            btnXoa.Text = "Xóa";

            btnXoa.Size = new Size(200, 55);

            btnXoa.Location = new Point(20, 520);

            btnXoa.BackColor = Color.Red;

            btnXoa.ForeColor = Color.White;

            btnLamMoi = new Button();

            btnLamMoi.Text = "Làm mới";

            btnLamMoi.Size = new Size(200, 55);

            btnLamMoi.Location = new Point(240, 520);

            btnLamMoi.BackColor = Color.Gray;

            btnLamMoi.ForeColor = Color.White;

            btnXemSinhVien = new Button();

            btnXemSinhVien.Text = "Xem danh sách sinh viên";

            btnXemSinhVien.Size = new Size(420, 55);

            btnXemSinhVien.Location = new Point(20, 600);

            btnXemSinhVien.BackColor = Color.FromArgb(52, 152, 219);

            btnXemSinhVien.ForeColor = Color.White;

            groupThongTin.Controls.Add(lblId);
            groupThongTin.Controls.Add(txtId);

            groupThongTin.Controls.Add(lblMaLop);
            groupThongTin.Controls.Add(txtMaLop);

            groupThongTin.Controls.Add(lblTenLop);
            groupThongTin.Controls.Add(txtTenLop);

            groupThongTin.Controls.Add(lblGhiChu);
            groupThongTin.Controls.Add(txtGhiChu);

            groupThongTin.Controls.Add(btnThem);
            groupThongTin.Controls.Add(btnSua);
            groupThongTin.Controls.Add(btnXoa);
            groupThongTin.Controls.Add(btnLamMoi);

            groupThongTin.Controls.Add(btnXemSinhVien);

            lblTimKiem = new Label();

            lblTimKiem.Text = "Tìm kiếm (Mã ID / Mã lớp / Tên lớp):";

            lblTimKiem.Location = new Point(520, 60);

            txtTimKiem = new TextBox();

            txtTimKiem.Location = new Point(520, 90);

            txtTimKiem.Size = new Size(400, 30);

            btnTim = new Button();

            btnTim.Text = "Tìm";

            btnTim.Location = new Point(940, 85);

            btnTim.Size = new Size(140, 45);

            btnTim.BackColor = Color.FromArgb(52, 73, 94);

            btnTim.ForeColor = Color.White;

            this.Controls.Add(lblTimKiem);
            this.Controls.Add(txtTimKiem);
            this.Controls.Add(btnTim);

            dgvLopHoc = new DataGridView();

            dgvLopHoc.Location = new Point(520, 160);

            dgvLopHoc.Size = new Size(950, 560);

            dgvLopHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvLopHoc.AllowUserToAddRows = false;

            this.Controls.Add(dgvLopHoc);

            int centerX = 930;

            btnFirst = new Button();

            btnFirst.Text = "<<";

            btnFirst.Size = new Size(70, 45);

            btnFirst.Location = new Point(centerX - 220, 760);

            this.Controls.Add(btnFirst);

            btnPrev = new Button();

            btnPrev.Text = "<";

            btnPrev.Size = new Size(70, 45);

            btnPrev.Location = new Point(centerX - 140, 760);

            this.Controls.Add(btnPrev);

            lblTrang = new Label();

            lblTrang.Text = "Trang 1/1";

            lblTrang.AutoSize = true;

            lblTrang.Font = new Font("Arial", 10, FontStyle.Regular);

            lblTrang.Location = new Point(centerX - 5, 775);

            this.Controls.Add(lblTrang);

            btnNext = new Button();

            btnNext.Text = ">";

            btnNext.Size = new Size(70, 45);

            btnNext.Location = new Point(centerX + 150, 760);

            this.Controls.Add(btnNext);

            btnLast = new Button();

            btnLast.Text = ">>";

            btnLast.Size = new Size(70, 45);

            btnLast.Location = new Point(centerX + 230, 760);

            this.Controls.Add(btnLast);
        }

        private void UC_QuanLyLopHoc_Load(object sender, EventArgs e)
        {

        }
    }
}