using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class UC_QuanLySinhVien : UserControl
    {
        QLSVDataContext db = new QLSVDataContext();

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

            LoadSinhVien();
        }

        private void LoadSinhVien()
        {
            dgvSinhVien.DataSource = db.tbl_sinhviens.Select(s => new
            {
                s.id,
                s.hoten,
                s.gioitinh,
                s.ngaysinh,
                s.malop
            }).ToList();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (
                txtMaSV.Text.Trim() == "" ||
                txtHoTen.Text.Trim() == "" ||
                cbGioiTinh.Text.Trim() == "" ||
                cbLop.Text.Trim() == ""
            )
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int maSV = int.Parse(txtMaSV.Text);

            var check = db.tbl_sinhviens.FirstOrDefault(s => s.id == maSV);

            if (check != null)
            {
                MessageBox.Show(
                    "Trùng mã sinh viên",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            tbl_sinhvien sv = new tbl_sinhvien();

            sv.id = maSV;

            sv.hoten = txtHoTen.Text;

            sv.gioitinh = cbGioiTinh.Text;

            sv.ngaysinh = dtNgaySinh.Value;

            sv.malop = cbLop.Text;

            db.tbl_sinhviens.InsertOnSubmit(sv);

            db.SubmitChanges();

            MessageBox.Show(
                "Thêm sinh viên thành công",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            LoadSinhVien();
        }

        private void DgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

            txtMaSV.Text = row.Cells["id"].Value?.ToString();
            txtHoTen.Text = row.Cells["hoten"].Value?.ToString();

            cbGioiTinh.Text = row.Cells["gioitinh"].Value?.ToString();

            cbLop.Text = row.Cells["malop"].Value?.ToString();

            if (row.Cells["ngaysinh"].Value != null)
            {
                dtNgaySinh.Value = Convert.ToDateTime(row.Cells["ngaysinh"].Value);
            }
        }

        private void CreateUI()
        {
            this.Dock = DockStyle.Fill;

            this.BackColor = Color.WhiteSmoke;

            groupThongTin = new GroupBox();

            groupThongTin.Text = "Thông tin sinh viên";

            groupThongTin.Location = new Point(20, 50);

            groupThongTin.Size = new Size(470, 730);

            this.Controls.Add(groupThongTin);

            lblMaSV = new Label();

            lblMaSV.Text = "Mã sinh viên:";

            lblMaSV.Location = new Point(20, 40);

            txtMaSV = new TextBox();

            txtMaSV.Location = new Point(20, 70);

            txtMaSV.Size = new Size(420, 30);

            lblHoTen = new Label();

            lblHoTen.Text = "Họ và tên:";

            lblHoTen.Location = new Point(20, 130);

            txtHoTen = new TextBox();

            txtHoTen.Location = new Point(20, 160);

            txtHoTen.Size = new Size(420, 30);

            lblNgaySinh = new Label();

            lblNgaySinh.Text = "Ngày sinh:";

            lblNgaySinh.Location = new Point(20, 220);

            dtNgaySinh = new DateTimePicker();

            dtNgaySinh.Format = DateTimePickerFormat.Short;

            dtNgaySinh.Location = new Point(20, 250);

            dtNgaySinh.Size = new Size(420, 30);

            lblGioiTinh = new Label();

            lblGioiTinh.Text = "Giới tính:";

            lblGioiTinh.Location = new Point(20, 310);

            cbGioiTinh = new ComboBox();

            cbGioiTinh.Location = new Point(20, 340);

            cbGioiTinh.Size = new Size(420, 30);

            cbGioiTinh.Items.Add("Nam");

            cbGioiTinh.Items.Add("Nữ");

            cbGioiTinh.SelectedIndex = 0;

            lblLop = new Label();

            lblLop.Text = "Lớp:";

            lblLop.Location = new Point(20, 400);

            cbLop = new ComboBox();

            cbLop.Location = new Point(20, 430);

            cbLop.Size = new Size(420, 30);

            cbLop.Items.Add("CNTT03");

            cbLop.Items.Add("MKT01");

            cbLop.Items.Add("NN01");

            cbLop.SelectedIndex = 0;

            btnThem = new Button();

            btnThem.Text = "Thêm";

            btnThem.Size = new Size(200, 55);

            btnThem.Location = new Point(20, 540);

            btnThem.BackColor = Color.DeepSkyBlue;

            btnThem.ForeColor = Color.White;

            btnThem.Click += BtnThem_Click;

            btnSua = new Button();

            btnSua.Text = "Sửa";

            btnSua.Size = new Size(200, 55);

            btnSua.Location = new Point(240, 540);

            btnSua.BackColor = Color.LimeGreen;

            btnSua.ForeColor = Color.White;

            btnXoa = new Button();

            btnXoa.Text = "Xóa";

            btnXoa.Size = new Size(200, 55);

            btnXoa.Location = new Point(20, 620);

            btnXoa.BackColor = Color.Red;

            btnXoa.ForeColor = Color.White;

            btnLamMoi = new Button();

            btnLamMoi.Text = "Làm mới";

            btnLamMoi.Size = new Size(200, 55);

            btnLamMoi.Location = new Point(240, 620);

            btnLamMoi.BackColor = Color.Gray;

            btnLamMoi.ForeColor = Color.White;

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

            lblTimKiem = new Label();

            lblTimKiem.Text = "Tìm kiếm:";

            lblTimKiem.Location = new Point(540, 60);

            txtTimKiem = new TextBox();

            txtTimKiem.Location = new Point(540, 90);

            txtTimKiem.Size = new Size(420, 30);

            btnTim = new Button();

            btnTim.Text = "Tìm";

            btnTim.Location = new Point(980, 85);

            btnTim.Size = new Size(140, 45);

            btnTim.BackColor = Color.FromArgb(52, 73, 94);

            btnTim.ForeColor = Color.White;

            this.Controls.Add(lblTimKiem);
            this.Controls.Add(txtTimKiem);
            this.Controls.Add(btnTim);

            dgvSinhVien = new DataGridView();

            dgvSinhVien.Location = new Point(540, 160);

            dgvSinhVien.Size = new Size(1000, 600);

            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvSinhVien.AllowUserToAddRows = false;

            this.Controls.Add(dgvSinhVien);

            dgvSinhVien.CellClick += DgvSinhVien_CellClick;

            int centerX = 930;

            btnFirst = new Button();

            btnFirst.Text = "<<";

            btnFirst.Size = new Size(70, 45);

            btnFirst.Location = new Point(centerX - 220, 790);

            this.Controls.Add(btnFirst);

            btnPrev = new Button();

            btnPrev.Text = "<";

            btnPrev.Size = new Size(70, 45);

            btnPrev.Location = new Point(centerX - 140, 790);

            this.Controls.Add(btnPrev);

            lblTrang = new Label();

            lblTrang.Text = "Trang 1/1";

            lblTrang.AutoSize = true;

            lblTrang.Location = new Point(centerX - 5, 803);

            this.Controls.Add(lblTrang);

            btnNext = new Button();

            btnNext.Text = ">";

            btnNext.Size = new Size(70, 45);

            btnNext.Location = new Point(centerX + 150, 790);

            this.Controls.Add(btnNext);

            btnLast = new Button();

            btnLast.Text = ">>";

            btnLast.Size = new Size(70, 45);

            btnLast.Location = new Point(centerX + 230, 790);

            this.Controls.Add(btnLast);
        }

        private void UC_QuanLySinhVien_Load(object sender, EventArgs e)
        {

        }
    }
}