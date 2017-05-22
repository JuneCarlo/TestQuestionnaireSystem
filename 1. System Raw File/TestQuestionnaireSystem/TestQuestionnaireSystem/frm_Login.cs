using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestQuestionnaireSystem
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }
        public static string UserID; // ID
        public static string Username = "Admin"; //Default Username 
        public static string Password = "Admin"; //Default Password
        public static string NameofUser = "Admin";
        public static string UserType; // Teacher, Admin or student 
        public static string StudentID; // Student ID
        public static string Lname;

        static DataClassesTestQuestionnaireDataContext db = null;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            if (txtusername.Text.Equals("Username") || txtpassword.Text.Equals("Passwrod") || txtusername.Text.Equals("") || txtpassword.Text.Equals(""))
            {
                MessageBox.Show("Fill Up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rdoStudent.Checked)
                {
                    int counter = 0;
                    var Query_Student = db.sp_retrieveStudent(txtusername.Text, txtpassword.Text);
                    foreach (sp_retrieveStudentResult entry in Query_Student)
                    {
                        StudentID = entry.S_ID.ToString();
                        UserID = entry.T_ID.ToString();
                        Lname = entry.S_LastName.ToString();
                        Password = entry.S_Password.ToString();

                        this.Hide();
                        frm_StudentMain SM = new frm_StudentMain();
                        SM.Show();

                        counter++;
                    }
                    if (counter.Equals(0))
                    {
                        int counter1 = 0;
                        var Query_UserStu = db.sp_retrieveUsernameStudent(txtusername.Text);
                        foreach (sp_retrieveUsernameStudentResult entry in Query_UserStu)
                        {
                            MessageBox.Show("Incorrect Password", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            counter1++;
                        }
                        if (counter1.Equals(0))
                        {
                            MessageBox.Show("You are not Register! Please ask your Teacher", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (rdoAdmin.Checked || rdoTeacher.Checked)
                {
                    int counter = 0;
                    var Query_Teacher = db.sp_retrieveTeacher(txtusername.Text, txtpassword.Text);
                    foreach (sp_retrieveTeacherResult entry in Query_Teacher)
                    {
                        UserID = entry.T_ID.ToString();
                        NameofUser = entry.T_FirstName.ToString() + " " + entry.T_LastName.ToString();
                        Lname = entry.T_LastName.ToString();
                        Username = entry.T_Username.ToString();
                        Password = entry.T_Password.ToString();

                        if (rdoAdmin.Checked && entry.T_UserType.Equals("ADMIN"))
                        {
                            this.Hide();
                            frm_AdminMain AM = new frm_AdminMain();
                            AM.Show();
                        }
                        else if (rdoTeacher.Checked && entry.T_UserType.Equals("TEACHER"))
                        {
                            this.Hide();
                            frm_TeacherMain TM = new frm_TeacherMain();
                            TM.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Account", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        counter++;
                    }
                    if (counter.Equals(0))
                    {
                        int counter1 = 0;
                        var Query_UserTeacher = db.sp_retrieveUsernameTeacher(txtusername.Text);
                        foreach (sp_retrieveUsernameTeacherResult entry in Query_UserTeacher)
                        {
                            MessageBox.Show("Incorrect Password", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            counter1++;
                        }
                        if (counter1.Equals(0))
                        {
                            MessageBox.Show("Invalid Account", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Fill Up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtusername_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Text = "";
                txtusername.ForeColor = Color.White;
            }
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            if (txtusername.Text == "")
            {
                txtusername.Text = "Username";
                txtusername.ForeColor = Color.Gray;
            }
        }

        private void txtusername_TabIndexChanged(object sender, EventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Text = "";
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            if (txtusername.TabIndex == 0)
            {
                txtusername.ForeColor = Color.White;
            }
        }

        private void txtpassword_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.Text = "";
                txtpassword.ForeColor = Color.White;
                txtpassword.PasswordChar = '*'; 
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                txtpassword.Text = "Password";
                txtpassword.ForeColor = Color.Gray;
                txtpassword.PasswordChar = '\0';
            }
        }

        private void txtpassword_TabIndexChanged(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.Text = "";
            }
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            if (txtpassword.TabIndex == 1)
            {
                txtpassword.ForeColor = Color.White;
                txtpassword.PasswordChar = '*'; 
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Exit?", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
