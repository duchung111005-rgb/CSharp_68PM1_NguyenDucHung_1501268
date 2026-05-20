using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FrmMain : Form
    {
        UC_QuanLySinhVien ucSinhVien;
        UC_QuanLyLopHoc ucLopHoc;

        MenuStrip menuStrip;

        ToolStripMenuItem menuSinhVien;
        ToolStripMenuItem menuLopHoc;
        ToolStripMenuItem menuDangXuat;

        public FrmMain()
        {
            InitializeComponent();

            this.WindowState =
                FormWindowState.Maximized;

            CreateMenu();

            // Tạo UserControl
            ucSinhVien =
                new UC_QuanLySinhVien();

            ucLopHoc =
                new UC_QuanLyLopHoc();

            // Hiện mặc định
            this.Controls.Add(ucSinhVien);

            ucSinhVien.BringToFront();
        }

        // ================= MENU =================

        private void CreateMenu()
        {
            menuStrip = new MenuStrip();

            menuSinhVien =
                new ToolStripMenuItem(
                    "Quản Lý Sinh Viên"
                );

            menuLopHoc =
                new ToolStripMenuItem(
                    "Quản Lý Lớp Học"
                );

            menuDangXuat =
                new ToolStripMenuItem(
                    "Đăng xuất"
                );

            // Event click
            menuSinhVien.Click += MenuSinhVien_Click;

            menuLopHoc.Click += MenuLopHoc_Click;

            menuDangXuat.Click += MenuDangXuat_Click;

            // Add menu
            menuStrip.Items.Add(menuSinhVien);

            menuStrip.Items.Add(menuLopHoc);

            menuStrip.Items.Add(menuDangXuat);

            // Add form
            this.MainMenuStrip =
                menuStrip;

            this.Controls.Add(menuStrip);
        }

        // ================= SINH VIÊN =================

        private void MenuSinhVien_Click(
            object sender,
            EventArgs e
        )
        {
            if (this.Controls.Contains(ucLopHoc))
            {
                this.Controls.Remove(ucLopHoc);
            }

            this.Controls.Add(ucSinhVien);

            ucSinhVien.BringToFront();
        }

        // ================= LỚP HỌC =================

        private void MenuLopHoc_Click(
            object sender,
            EventArgs e
        )
        {
            if (this.Controls.Contains(ucSinhVien))
            {
                this.Controls.Remove(ucSinhVien);
            }

            this.Controls.Add(ucLopHoc);

            ucLopHoc.BringToFront();
        }

        // ================= ĐĂNG XUẤT =================

        private void MenuDangXuat_Click(
            object sender,
            EventArgs e
        )
        {
            Form1 login = new Form1();

            login.Show();

            this.Hide();
        }

        // ================= LOAD FORM =================

        private void FrmMain_Load(
            object sender,
            EventArgs e
        )
        {

        }
    }
}