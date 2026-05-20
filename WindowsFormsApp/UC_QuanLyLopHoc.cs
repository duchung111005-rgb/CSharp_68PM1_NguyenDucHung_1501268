using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class UC_QuanLyLopHoc : UserControl
    {
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
        }

        private void CreateUI()
        {
            this.Dock = DockStyle.Fill;

            this.BackColor = Color.WhiteSmoke;

            // ================= GROUPBOX =================

            groupThongTin = new GroupBox();

            groupThongTin.Text =
                "Thông tin lớp học";

            groupThongTin.Location =
                new Point(20, 50);

            groupThongTin.Size =
                new Size(470, 700);

            this.Controls.Add(groupThongTin);

            // ================= MÃ ID =================

            lblId = new Label();

            lblId.Text = "Mã ID:";

            lblId.Location =
                new Point(20, 40);

            txtId = new TextBox();

            txtId.Location =
                new Point(20, 70);

            txtId.Size =
                new Size(420, 30);

            // ================= MÃ LỚP =================

            lblMaLop = new Label();

            lblMaLop.Text = "Mã lớp:";

            lblMaLop.Location =
                new Point(20, 130);

            txtMaLop = new TextBox();

            txtMaLop.Location =
                new Point(20, 160);

            txtMaLop.Size =
                new Size(420, 30);

            // ================= TÊN LỚP =================

            lblTenLop = new Label();

            lblTenLop.Text = "Tên lớp:";

            lblTenLop.Location =
                new Point(20, 220);

            txtTenLop = new TextBox();

            txtTenLop.Location =
                new Point(20, 250);

            txtTenLop.Size =
                new Size(420, 30);

            // ================= GHI CHÚ =================

            lblGhiChu = new Label();

            lblGhiChu.Text = "Ghi chú:";

            lblGhiChu.Location =
                new Point(20, 310);

            txtGhiChu = new TextBox();

            txtGhiChu.Location =
                new Point(20, 340);

            txtGhiChu.Size =
                new Size(420, 30);

            // ================= BUTTON =================

            btnThem = new Button();

            btnThem.Text = "Thêm";

            btnThem.Size =
                new Size(200, 55);

            btnThem.Location =
                new Point(20, 450);

            btnThem.BackColor =
                Color.DeepSkyBlue;

            btnThem.ForeColor =
                Color.White;

            btnSua = new Button();

            btnSua.Text = "Sửa";

            btnSua.Size =
                new Size(200, 55);

            btnSua.Location =
                new Point(240, 450);

            btnSua.BackColor =
                Color.LimeGreen;

            btnSua.ForeColor =
                Color.White;

            btnXoa = new Button();

            btnXoa.Text = "Xóa";

            btnXoa.Size =
                new Size(200, 55);

            btnXoa.Location =
                new Point(20, 520);

            btnXoa.BackColor =
                Color.Red;

            btnXoa.ForeColor =
                Color.White;

            btnLamMoi = new Button();

            btnLamMoi.Text = "Làm mới";

            btnLamMoi.Size =
                new Size(200, 55);

            btnLamMoi.Location =
                new Point(240, 520);

            btnLamMoi.BackColor =
                Color.Gray;

            btnLamMoi.ForeColor =
                Color.White;

            btnXemSinhVien = new Button();

            btnXemSinhVien.Text =
                "Xem danh sách sinh viên";

            btnXemSinhVien.Size = new Size(420, 55);

            btnXemSinhVien.Location =  new Point(20, 600);

            btnXemSinhVien.BackColor = Color.FromArgb(52, 152, 219);

            btnXemSinhVien.ForeColor = Color.White;

            // ================= ADD CONTROL =================

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

            // ================= SEARCH =================

            lblTimKiem = new Label();

            lblTimKiem.Text =
                "Tìm kiếm (Mã ID / Mã lớp / Tên lớp):";

            lblTimKiem.Location =
                new Point(520, 60);

            txtTimKiem = new TextBox();

            txtTimKiem.Location =
                new Point(520, 90);

            txtTimKiem.Size =
                new Size(400, 30);

            btnTim = new Button();

            btnTim.Text = "Tìm";

            btnTim.Location =
                new Point(940, 85);

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

            dgvLopHoc = new DataGridView();

            dgvLopHoc.Location = new Point(520, 160);

            dgvLopHoc.Size = new Size(950, 560);

            dgvLopHoc.ColumnCount = 4;

            dgvLopHoc.Columns[0].Name = "Mã ID";
            dgvLopHoc.Columns[1].Name = "Mã lớp";
            dgvLopHoc.Columns[2].Name = "Tên lớp";
            dgvLopHoc.Columns[3].Name = "Ghi chú";

            dgvLopHoc.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvLopHoc.AllowUserToAddRows = false;

            dgvLopHoc.Rows.Add(
                "1",
                "68PM1",
                "Lớp 68PM1",
                "abc"
            );

            dgvLopHoc.Rows.Add(
                "2",
                "68PM2",
                "Lớp 68PM2",
                "xyz"
            );

            this.Controls.Add(dgvLopHoc);

            int centerX = 930;

            btnFirst = new Button();

            btnFirst.Text = "<<";

            btnFirst.Size = new Size(70, 45);

            btnFirst.Location = new Point(centerX - 220, 760);

            btnFirst.BackColor = Color.White;

            this.Controls.Add(btnFirst);

            // ===== PREV =====

            btnPrev = new Button();

            btnPrev.Text = "<";

            btnPrev.Size =
                new Size(70, 45);

            btnPrev.Location = new Point(centerX - 140, 760);

            btnPrev.BackColor = Color.White;

            this.Controls.Add(btnPrev);

            // ===== LABEL =====

            lblTrang = new Label();

            lblTrang.Text = "Trang 1/1 | 2 bản ghi";

            lblTrang.AutoSize = true;

            lblTrang.Font = new Font(
                    "Arial",
                    10,
                    FontStyle.Regular
                );

            lblTrang.Location = new Point(centerX - 5, 775);

            this.Controls.Add(lblTrang);

            // ===== NEXT =====

            btnNext = new Button();

            btnNext.Text = ">";

            btnNext.Size =  new Size(70, 45);

            btnNext.Location = new Point(centerX + 150, 760);

            btnNext.BackColor =  Color.White;

            this.Controls.Add(btnNext);

            // ===== LAST =====

            btnLast = new Button();

            btnLast.Text = ">>";

            btnLast.Size =
                new Size(70, 45);

            btnLast.Location = new Point(centerX + 230, 760);

            btnLast.BackColor =  Color.White;

            this.Controls.Add(btnLast);
        }

        private void UC_QuanLyLopHoc_Load(object sender, EventArgs e)
        {
           
        }
    }
}