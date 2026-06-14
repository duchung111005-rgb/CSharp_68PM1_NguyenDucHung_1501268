using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class UC_QuanLyLopHoc : UserControl
    {
        QLSVDataContext db = new QLSVDataContext();

        private int currentPage = 1;
        private int pageSize = 5;
        private int totalPages = 1;

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

            txtTimKiem.KeyDown += TxtTimKiem_KeyDown;
        }

        private void TxtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnTim_Click(null, null);
            }
        }

        private void LoadLopHoc()
        {
            var danhSach = db.tbl_lophocs.ToList();

            int totalRecords = danhSach.Count;

            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (totalPages == 0)
                totalPages = 1;

            dgvLopHoc.DataSource = danhSach
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new
                {
                    x.id,
                    x.malop,
                    x.tenlop,
                    x.ghichu
                })
                .ToList();

            lblTrang.Text = "Trang " + currentPage + "/" + totalPages +
                            " | " + totalRecords + " bản ghi";
        }

        private void DgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLopHoc.Rows[e.RowIndex];

            txtId.Text = row.Cells[0].Value?.ToString();
            txtMaLop.Text = row.Cells[1].Value?.ToString();
            txtTenLop.Text = row.Cells[2].Value?.ToString();
            txtGhiChu.Text = row.Cells[3].Value?.ToString();

            txtId.Enabled = false;
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtId.Enabled = true;

            txtId.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtGhiChu.Clear();

            dgvLopHoc.ClearSelection();

            txtId.Focus();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa!");
                return;
            }

            int id = Convert.ToInt32(txtId.Text);

            var lop = db.tbl_lophocs.SingleOrDefault(x => x.id == id);

            if (lop == null)
            {
                MessageBox.Show("Không tìm thấy lớp!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaLop.Text) ||
                string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            lop.malop = txtMaLop.Text.Trim();
            lop.tenlop = txtTenLop.Text.Trim();
            lop.ghichu = txtGhiChu.Text.Trim();

            db.SubmitChanges();

            MessageBox.Show("Cập nhật lớp học thành công!");

            LoadLopHoc();
        }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa lớp này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
                return;

            int id = Convert.ToInt32(txtId.Text);

            var lop = db.tbl_lophocs.SingleOrDefault(x => x.id == id);

            if (lop == null)
            {
                MessageBox.Show("Không tìm thấy lớp");
                return;
            }

            db.tbl_lophocs.DeleteOnSubmit(lop);

            db.SubmitChanges();

            MessageBox.Show("Xóa thành công");

            LoadLopHoc();

            BtnLamMoi_Click(null, null);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (
                txtId.Text.Trim() == "" ||
                txtMaLop.Text.Trim() == "" ||
                txtTenLop.Text.Trim() == ""
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

            int id = Convert.ToInt32(txtId.Text);

            var checkId = db.tbl_lophocs.FirstOrDefault(x => x.id == id);

            if (checkId != null)
            {
                MessageBox.Show(
                    "Trùng ID lớp",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            var checkMaLop = db.tbl_lophocs.FirstOrDefault(
                x => x.malop == txtMaLop.Text.Trim()
            );

            if (checkMaLop != null)
            {
                MessageBox.Show(
                    "Trùng mã lớp",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            tbl_lophoc lop = new tbl_lophoc();

            lop.id = id;

            lop.malop = txtMaLop.Text.Trim();

            lop.tenlop = txtTenLop.Text.Trim();

            lop.ghichu = txtGhiChu.Text.Trim();

            db.tbl_lophocs.InsertOnSubmit(lop);

            db.SubmitChanges();

            MessageBox.Show(
                "Thêm lớp học thành công",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            LoadLopHoc();

            BtnLamMoi_Click(null, null);
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            if (keyword == "")
            {
                currentPage = 1;
                LoadLopHoc();
                return;
            }

            dgvLopHoc.DataSource = db.tbl_lophocs
                .Where(l =>
                    l.id.ToString().Contains(keyword) ||
                    l.malop.ToLower().Contains(keyword) ||
                    l.tenlop.ToLower().Contains(keyword))
                .Select(l => new
                {
                    l.id,
                    l.malop,
                    l.tenlop,
                    l.ghichu
                })
                .ToList();

            lblTrang.Text = "Tìm thấy " + dgvLopHoc.Rows.Count + " kết quả";
        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadLopHoc();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadLopHoc();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadLopHoc();
            }
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadLopHoc();
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

            btnThem.Click += BtnThem_Click;

            btnSua = new Button();

            btnSua.Text = "Sửa";

            btnSua.Size = new Size(200, 55);

            btnSua.Location = new Point(240, 450);

            btnSua.BackColor = Color.LimeGreen;

            btnSua.ForeColor = Color.White;

            btnSua.Click += BtnSua_Click;

            btnXoa = new Button();

            btnXoa.Text = "Xóa";

            btnXoa.Size = new Size(200, 55);

            btnXoa.Location = new Point(20, 520);

            btnXoa.BackColor = Color.Red;

            btnXoa.ForeColor = Color.White;

            btnXoa.Click += BtnXoa_Click;

            btnLamMoi = new Button();

            btnLamMoi.Text = "Làm mới";

            btnLamMoi.Size = new Size(200, 55);

            btnLamMoi.Location = new Point(240, 520);

            btnLamMoi.BackColor = Color.Gray;

            btnLamMoi.ForeColor = Color.White;

            btnLamMoi.Click += BtnLamMoi_Click;

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

            btnTim.Click += BtnTim_Click;

            this.Controls.Add(lblTimKiem);
            this.Controls.Add(txtTimKiem);
            this.Controls.Add(btnTim);

            dgvLopHoc = new DataGridView();

            dgvLopHoc.Location = new Point(520, 160);

            dgvLopHoc.Size = new Size(950, 560);

            dgvLopHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvLopHoc.AllowUserToAddRows = false;

            dgvLopHoc.CellClick += DgvLopHoc_CellClick;

            this.Controls.Add(dgvLopHoc);

            int centerX = 930;

            btnFirst = new Button();

            btnFirst.Text = "<<";

            btnFirst.Size = new Size(70, 45);

            btnFirst.Location = new Point(centerX - 220, 760);

            this.Controls.Add(btnFirst);

            btnFirst.Click += BtnFirst_Click;

            btnPrev = new Button();

            btnPrev.Text = "<";

            btnPrev.Size = new Size(70, 45);

            btnPrev.Location = new Point(centerX - 140, 760);

            this.Controls.Add(btnPrev);

            btnPrev.Click += BtnPrev_Click;

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

            btnNext.Click += BtnNext_Click;

            btnLast = new Button();

            btnLast.Text = ">>";

            btnLast.Size = new Size(70, 45);

            btnLast.Location = new Point(centerX + 230, 760);

            this.Controls.Add(btnLast);

            btnLast.Click += BtnLast_Click;
        }

        private void UC_QuanLyLopHoc_Load(object sender, EventArgs e)
        {

        }
    }
}