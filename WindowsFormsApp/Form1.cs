using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Ẩn mật khẩu
            txtPassword.PasswordChar = '*';
        }

        // Nút đăng nhập
        private void button1_Click(object sender, EventArgs e)
        {
            string studentEmail = "hung1501268@st.edu.vn";
            string studentId = "1501268";

            // Kiểm tra đăng nhập
            if (txtEmail.Text == studentEmail &&
                txtPassword.Text == studentId)
            {
                MessageBox.Show(
                    "Đăng nhập thành công",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Mở form chính
                FrmMain frm = new FrmMain();

                frm.Show();

                // Ẩn form login
                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "Sai email hoặc mật khẩu",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Event txtEmail
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        // Event label Email
        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        // Event password
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        // Event form load
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}