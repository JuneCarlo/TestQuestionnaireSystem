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
    public partial class frm_StudentMain : Form
    {
        public frm_StudentMain()
        {
            InitializeComponent();
            lblLname.Text = frm_Login.Lname.First().ToString().ToUpper() + String.Join("", frm_Login.Lname.Skip(1)).ToLower();
            lblLname1.Text = frm_Login.Lname.First().ToString().ToUpper() + String.Join("", frm_Login.Lname.Skip(1)).ToLower();
        }
        string Uname;
        public static string SGrade, SSection, STeacher;
        DataClassesTestQuestionnaireDataContext db = null;
        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("You want to Lagout?", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (Result == DialogResult.Yes)
            {
                this.Hide();
                frm_Login L = new frm_Login();
                L.Show();
            }
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            pnlEditStudent.Visible = false;
            pnlQuiz.Visible = false;
            pnlQScore.Visible = false;
        }

        private void frm_StudentMain_Load(object sender, EventArgs e)
        {
            pnlEditStudent.Visible = false;
            panel.Visible = false;
            pnlQuiz.Visible = false;
            pnlQScore.Visible = false;

            db = new DataClassesTestQuestionnaireDataContext();
            var Quary = db.sp_retrieveIDStudent(frm_Login.StudentID.ToString());
            foreach (sp_retrieveIDStudentResult entry in Quary)
            {
                SGrade = entry.Section_Grade.ToString();
                SSection = entry.Section_name.ToString();
            }
        }

        private void lblLname_Click(object sender, EventArgs e)
        {
            panel.Visible = true;
        }

        private void lblLname1_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pnlEditStudent.Visible = true;
            panel.Visible = false;
            pnlQuiz.Visible = false;
            pnlQScore.Visible = false;

            db = new DataClassesTestQuestionnaireDataContext();
            var Quary = db.sp_retrieveIDStudent(frm_Login.StudentID.ToString());
            foreach(sp_retrieveIDStudentResult entry in Quary)
            {
                txtUpSUname.Text = entry.S_Username.ToString();
                txtUpSPword.Text = entry.S_Password.ToString();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            if (txtUpSUname.Text.Equals("") || txtUpSPword.Text.Equals(""))
            {
                MessageBox.Show("Fill up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtUpSUname.Text.Equals(Uname))
                {
                    MessageBox.Show("Username is taken", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUpSUname.Clear();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to Update?", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        db.sp_updateStudent1(frm_Login.StudentID.ToString(), txtUpSUname.Text, txtUpSPword.Text);
                        MessageBox.Show("Successfully Update?", "NOTE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        panel.Visible = false;
                        pnlEditStudent.Visible = false;
                    }
                }
            }
        }

        private void lblTeacher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlQuiz.Visible = true;
            panel.Visible = false;
            pnlEditStudent.Visible = false;
            pnlQScore.Visible = false;
        }

        private void lblSection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlQScore.Visible = true;
            pnlQuiz.Visible = false;
            panel.Visible = false;
            pnlEditStudent.Visible = false;

            db = new DataClassesTestQuestionnaireDataContext();
            var Quary = db.sp_retrieveScore(frm_Login.StudentID.ToString());
            foreach (sp_retrieveScoreResult entry in Quary)
            {
                if(entry.Correct.Equals("") || entry.Wrong.Equals(""))
                {
                    panel2.Visible = true;
                    pnlScore.Visible = false;
                }
                else
                {
                    panel2.Visible = false;
                    pnlScore.Visible = true;

                    lblcheck.Text = entry.Correct.ToString();
                    lblwrong.Text = entry.Wrong.ToString();
                }
            }
        }

        private void txtUpSUname_TextChanged(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            var Quary = db.sp_retrieveIDStudent(frm_Login.StudentID.ToString());
            foreach (sp_retrieveIDStudentResult entry in Quary)
            {
                Uname = entry.S_Username.ToString();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            var Quary = db.sp_retrieveScore(frm_Login.StudentID.ToString());
            foreach (sp_retrieveScoreResult entry in Quary)
            {
                if (entry.Correct.Equals("") || entry.Wrong.Equals(""))
                {
                this.Hide();
                frm_Quiz FQ = new frm_Quiz();
                FQ.Show();
                }
                else
                {
                    MessageBox.Show("You already take the quiz", "NOTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
