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
    public partial class frm_TeacherMain : Form
    {
        public frm_TeacherMain()
        {
            InitializeComponent();
            lblLname.Text = frm_Login.Lname.First().ToString().ToUpper() + String.Join("", frm_Login.Lname.Skip(1)).ToLower();
            lblLname1.Text = frm_Login.Lname.First().ToString().ToUpper() + String.Join("", frm_Login.Lname.Skip(1)).ToLower();
        }

        public static string Section, Grade;
        string User, SidCount, StuID;
        int No = 0;
        DataClassesTestQuestionnaireDataContext db = null;
        private void frm_TeacherMain_Load(object sender, EventArgs e)
        {
            panel.Visible = false;
            pnlEditInfo.Visible = false;
            pnlStudent.Visible = false;
            pnlSRegister.Visible = false;
            pnlUpStudent.Visible = false;
            pnlMQuiz.Visible = false;
            pnlVQuiz.Visible = false;
            pnlAQuestion.Visible = false;
            pnlUpQuiz.Visible = false;
            pnlReport.Visible = false;
            pnlPrint.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            if (txtEditFname.Text.Equals("") || txtEditLname.Text.Equals("") || txtEditUname.Text.Equals("") || txtEditPword.Text.Equals(""))
            {
                MessageBox.Show("Fill up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtEditUname.Text.Equals(User) && txtEditPword.Text != frm_Login.Password.ToString())
                {
                    MessageBox.Show("Username is taken", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEditUname.Clear();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to Update", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        db.sp_UpdateTeacher(frm_Login.UserID.ToString(), txtEditUname.Text, txtEditPword.Text, txtEditLname.Text.ToUpper(), txtEditFname.Text.ToUpper());
                        MessageBox.Show("Succesfully Update", "Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        panel.Visible = false;
                        pnlEditInfo.Visible = false;
                        pnlAQuestion.Visible = false;
                        pnlMQuiz.Visible = false;
                        pnlSRegister.Visible = false;
                        pnlStudent.Visible = false;
                        pnlUpQuiz.Visible = false;
                        pnlUpStudent.Visible = false;
                        pnlVQuiz.Visible = false;

                        db = new DataClassesTestQuestionnaireDataContext();
                        var View_Info = db.sp_retrieveID(frm_Login.UserID.ToString());
                        foreach (sp_retrieveIDResult count in View_Info)
                        {
                            lblLname.Text = count.T_LastName.First().ToString().ToUpper() + String.Join("", count.T_LastName.Skip(1)).ToLower();
                            lblLname1.Text = count.T_LastName.First().ToString().ToUpper() + String.Join("", count.T_LastName.Skip(1)).ToLower();
                        }
                    }
                }
            }
        }

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

        private void label2_Click(object sender, EventArgs e)
        {
            pnlEditInfo.Visible = true;
            panel.Visible = false;
            pnlStudent.Visible = false;
            pnlSRegister.Visible = false;
            pnlUpStudent.Visible = false;
            pnlMQuiz.Visible = false;
            pnlVQuiz.Visible = false;
            pnlAQuestion.Visible = false;
            pnlUpQuiz.Visible = false;
            pnlReport.Visible = false;
            pnlPrint.Visible = false;

            db = new DataClassesTestQuestionnaireDataContext();
            var View_Info = db.sp_retrieveID(frm_Login.UserID.ToString());
            foreach (sp_retrieveIDResult count in View_Info)
            {
                txtEditFname.Text = count.T_FirstName.ToString();
                txtEditLname.Text = count.T_LastName.ToString();
                txtEditUname.Text = count.T_Username.ToString();
                txtEditPword.Text = count.T_Password.ToString();
            }

            txtEditFname.ForeColor = System.Drawing.SystemColors.ControlDark;
            txtEditLname.ForeColor = System.Drawing.SystemColors.ControlDark;
            txtEditUname.ForeColor = System.Drawing.SystemColors.ControlDark;
            txtEditPword.ForeColor = System.Drawing.SystemColors.ControlDark;
        }

        private void txtEditUname_TextChanged(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            var Query_User = db.sp_retrieveUsernameTeacher(txtEditUname.Text);
            foreach (sp_retrieveUsernameTeacherResult entry in Query_User)
            {
                User = entry.T_Username.ToString();
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

        private void lblHome_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            pnlEditInfo.Visible = false;
            pnlStudent.Visible = false;
            pnlSRegister.Visible = false;
            pnlUpStudent.Visible = false;
            pnlMQuiz.Visible = false;
            pnlAQuestion.Visible = false;
            pnlUpQuiz.Visible = false;
            pnlReport.Visible = false;
            pnlPrint.Visible = false;
        }

        private void txtEditFname_Click(object sender, EventArgs e)
        {
            txtEditFname.Clear();
            txtEditFname.ForeColor = Color.Black;
        }

        private void txtEditLname_Click(object sender, EventArgs e)
        {
            txtEditLname.Clear();
            txtEditLname.ForeColor = Color.Black;
        }

        private void txtEditUname_Click(object sender, EventArgs e)
        {
            txtEditUname.Clear();
            txtEditUname.ForeColor = Color.Black;
        }

        private void txtEditPword_Click(object sender, EventArgs e)
        {
            txtEditPword.Clear();
            txtEditPword.ForeColor = Color.Black;
        }

        private void lblStudent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            dgvStudent.DataSource = db.sp_viewStudent(frm_Login.UserID.ToString());

            pnlStudent.Visible = true;
            panel.Visible = false;
            pnlEditInfo.Visible = false;
            pnlSRegister.Visible = false;
            pnlUpStudent.Visible = false;
            pnlMQuiz.Visible = false;
            pnlVQuiz.Visible = false;
            pnlAQuestion.Visible = false;
            pnlUpQuiz.Visible = false;
            pnlReport.Visible = false;
            pnlPrint.Visible = false;

            txtSearchS.Text = "Search";
            txtSearchS.ForeColor = System.Drawing.SystemColors.ControlDark;
        }

        private void txtSearchS_Click(object sender, EventArgs e)
        {
           if(txtSearchS.Text == "Search")
           {
               txtSearchS.Clear();
               txtSearchS.ForeColor = Color.Black;
           }
        }

        private void txtSearchS_Leave(object sender, EventArgs e)
        {
            if(txtSearchS.Text == "")
            {
                txtSearchS.ForeColor = System.Drawing.SystemColors.WindowFrame;
                txtSearchS.Text = "Search";

                db = new DataClassesTestQuestionnaireDataContext();
                dgvStudent.DataSource = db.sp_viewStudent(frm_Login.UserID.ToString());
            }
        }

        private void txtSearchS_TextChanged(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            dgvStudent.DataSource = db.sp_searchStudent(txtSearchS.Text);
        }

        private void cmbRSGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            int Counter = 0;
            cmbRSSection.Items.Clear();
            var Query_Grade = db.sp_selectSectioninGrade(cmbRSGrade.Text, frm_Login.UserID.ToString());
            foreach (sp_selectSectioninGradeResult entry in Query_Grade)
            {
                cmbRSSection.Items.Add(entry.Section_Name.ToString());
                Counter++;
            }
            if (Counter.Equals(0))
            {
                cmbRSSection.Items.Clear();
            }
        }

        private void txtRSLname_Leave(object sender, EventArgs e)
        {
            if(txtRSFname.Text.Equals("") || txtRSLname.Text.Equals(""))
            {
                txtRSUname.Text = "";
            }
            else
            {
                txtRSUname.Text = txtRSLname.Text.ToString().ToLower() + txtRSFname.Text.ToString().ToLower();
            }
        }

        private void txtRSFname_Leave(object sender, EventArgs e)
        {
            if (txtRSFname.Text.Equals("") || txtRSLname.Text.Equals(""))
            {
                txtRSUname.Text = "";
            }
            else
            {
                txtRSUname.Text = txtRSLname.Text.ToString().ToLower() + txtRSFname.Text.ToString().ToLower();
            }
        }

        string StudentID()
        {
            int iCount = 0;
            string SID = "";
            db = new DataClassesTestQuestionnaireDataContext();
            var query = db.sp_StudentID();
            foreach (sp_StudentIDResult countS in query)
            {
                iCount = countS.CountS.Value;
            }
            iCount++;
            if (iCount.ToString().Length.Equals(1))
            {
                SID = "S-" + iCount.ToString().PadLeft(4, '0').ToString();
            }
            else if (iCount.ToString().Length.Equals(2))
            {
                SID = "S-" + iCount.ToString().PadLeft(3, '0').ToString();
            }
            else
            {
                SID = "S-" + iCount.ToString().PadLeft(2, '0').ToString();
            }

            return SidCount = SID;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            if (txtRSFname.Text.Equals("") || txtRSLname.Text.Equals("") || txtRSUname.Text.Equals("") || txtRSPword.Text.Equals("") || cmbRSGrade.Text.Equals("") || cmbRSSection.Text.Equals(""))
            {
                MessageBox.Show("Fill up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                 DialogResult result = MessageBox.Show("Are you sure you want to Add", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (result == DialogResult.Yes)
                 {
                     db.sp_addStudent(SidCount, txtRSUname.Text, txtRSPword.Text, txtRSLname.Text.ToString().ToUpper(), txtRSFname.Text.ToString().ToUpper(), cmbRSGrade.Text, cmbRSSection.Text, frm_Login.UserID.ToString(), frm_Login.NameofUser.ToString());
                     db.sp_addScore(SidCount, frm_Login.UserID.ToString(), txtRSLname.Text.ToString().ToUpper(), txtRSFname.Text.ToString().ToUpper(), cmbRSGrade.Text, cmbRSSection.Text, "", "");
                     dgvStudent.DataSource = db.sp_viewStudent(frm_Login.UserID.ToString());
                     StudentID();
                     pnlStudent.Visible = true;
                     pnlSRegister.Visible = false;
                     pnlEditInfo.Visible = false;
                     panel.Visible = false;
                     pnlAQuestion.Visible = false;
                     pnlMQuiz.Visible = false;
                     pnlUpQuiz.Visible = false;
                     pnlUpStudent.Visible = false;
                     pnlVQuiz.Visible = false;

                     txtRSUname.Clear();
                     txtRSLname.Clear();
                     txtRSFname.Clear();
                     cmbRSGrade.Items.Clear();
                     cmbRSGrade.Items.AddRange(new object[] { "Grade 7", "Grade 8", "Grade 9" });
                     cmbRSSection.Items.Clear();
                 }
                 else
                 {
                     txtRSUname.Clear();
                     txtRSLname.Clear();
                     txtRSFname.Clear();
                     cmbRSGrade.Items.Clear();
                     cmbRSGrade.Items.AddRange(new object[] { "Grade 7", "Grade 8", "Grade 9" });
                     cmbRSSection.Items.Clear();
                 }
            }
        }

        private void picAddTeacher_Click(object sender, EventArgs e)
        {
            StudentID();

            pnlSRegister.Visible = true;
            panel.Visible = false;
            pnlEditInfo.Visible = false;
            pnlStudent.Visible = false;
            pnlUpStudent.Visible = false;
            pnlAQuestion.Visible = false;
            pnlMQuiz.Visible = false;
            pnlUpQuiz.Visible = false;
            pnlVQuiz.Visible = false;

            txtRSFname.Focus();
            txtRSUname.Clear();
            txtRSLname.Clear();
            txtRSFname.Clear();
            cmbRSGrade.Items.Clear();
            cmbRSGrade.Items.AddRange(new object[] { "Grade 7", "Grade 8", "Grade 9" });
            cmbRSSection.Items.Clear();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            var query = db.sp_StudentID();
            foreach (sp_StudentIDResult countS in query)
            {
                if(countS.CountS.Value == 0)
                {
                    MessageBox.Show("Add Student First!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtUpSLname.Text = dgvStudent.CurrentRow.Cells[0].Value.ToString();
                    txtUpSFname.Text = dgvStudent.CurrentRow.Cells[1].Value.ToString();
                    cmbUpSGrade.Text = dgvStudent.CurrentRow.Cells[3].Value.ToString();
                    cmbUpSSection.Text = dgvStudent.CurrentRow.Cells[2].Value.ToString();

                    txtUpSLname.ForeColor = System.Drawing.SystemColors.ControlDark;
                    txtUpSFname.ForeColor = System.Drawing.SystemColors.ControlDark;

                    pnlUpStudent.Visible = true;
                    panel.Visible = false;
                    pnlEditInfo.Visible = false;
                    pnlStudent.Visible = false;
                    pnlSRegister.Visible = false;
                    pnlAQuestion.Visible = false;
                    pnlMQuiz.Visible = false;
                    pnlUpQuiz.Visible = false;
                    pnlVQuiz.Visible = false;

                    db = new DataClassesTestQuestionnaireDataContext();
                    var Query_StudentID = db.sp_retrieveInfoStudent(dgvStudent.CurrentRow.Cells[0].Value.ToString(), dgvStudent.CurrentRow.Cells[1].Value.ToString(), cmbUpSGrade.Text = dgvStudent.CurrentRow.Cells[3].Value.ToString(), dgvStudent.CurrentRow.Cells[2].Value.ToString());
                    foreach (sp_retrieveInfoStudentResult entry in Query_StudentID)
                    {
                        txtUpSUname.Text = entry.S_Username.ToString();
                        txtUpSPword.Text = entry.S_Password.ToString();
                        StuID = entry.S_ID.ToString();
                    }
                }
            }
        }

        private void cmbUpSGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            int Counter = 0;
            cmbUpSSection.Items.Clear();
            var Query_Grade = db.sp_selectSectioninGrade(cmbUpSGrade.Text, frm_Login.UserID.ToString());
            foreach (sp_selectSectioninGradeResult entry in Query_Grade)
            {
                cmbUpSSection.Items.Add(entry.Section_Name.ToString());
                Counter++;
            }
            if (Counter.Equals(0))
            {
                cmbUpSSection.Items.Clear();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Reset the Username and Password?", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtUpSUname.Text = txtUpSLname.Text.ToString().ToLower() + txtUpSFname.Text.ToString().ToLower();
                txtUpSPword.Text = "1234";
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            if (txtUpSFname.Text.Equals("") || txtUpSLname.Text.Equals("") || txtUpSUname.Text.Equals("") || txtUpSPword.Text.Equals("") || cmbUpSGrade.Text.Equals("") || cmbUpSSection.Text.Equals(""))
            {
                MessageBox.Show("Fill up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtEditUname.Text.Equals(User))
                {
                    MessageBox.Show("Username is taken", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEditUname.Clear();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to Update?", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        db.sp_updateStudent(StuID, txtUpSUname.Text, txtUpSPword.Text, txtUpSLname.Text.ToUpper(), txtUpSFname.Text.ToUpper(), cmbUpSGrade.Text, cmbUpSSection.Text);
                        dgvStudent.DataSource = db.sp_viewStudent(frm_Login.UserID.ToString());
                        pnlStudent.Visible = true;
                        pnlSRegister.Visible = false;
                        pnlEditInfo.Visible = false;
                        pnlUpStudent.Visible = false;
                        panel.Visible = false;
                        pnlUpQuiz.Visible = false;
                        pnlMQuiz.Visible = false;
                        pnlAQuestion.Visible = false;
                    }
                }
            }
        }

        private void lblQuiz_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlMQuiz.Visible = true;
            panel.Visible = false;
            pnlEditInfo.Visible = false;
            pnlStudent.Visible = false;
            pnlSRegister.Visible = false;
            pnlUpStudent.Visible = false;
            pnlVQuiz.Visible = false;
            pnlAQuestion.Visible = false;
            pnlUpQuiz.Visible = false;
            pnlReport.Visible = false;
            pnlPrint.Visible = false;

            cmbMQGrade.Items.Clear();
            cmbMQGrade.Items.AddRange(new object[] { "Grade 7", "Grade 8", "Grade 9" });
            cmbMQSection.Items.Clear();
        }

        private void cmbMQGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            int Counter = 0;
            cmbMQSection.Items.Clear();
            var Query_Grade = db.sp_selectSectioninGrade(cmbMQGrade.Text, frm_Login.UserID.ToString());
            foreach (sp_selectSectioninGradeResult entry in Query_Grade)
            {
                cmbMQSection.Items.Add(entry.Section_Name.ToString());
                Counter++;
            }
            if (Counter.Equals(0))
            {
                cmbMQSection.Items.Clear();
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (cmbMQGrade.Text.Equals("") || cmbMQSection.Text.Equals(""))
            {
                MessageBox.Show("Fill up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvQuestion.DataSource = db.sp_viewQuestion(cmbMQGrade.Text, cmbMQSection.Text, frm_Login.UserID.ToString());

                DataGridViewColumn column = dgvQuestion.Columns[0];
                column.Width = 30;

                DataGridViewColumn column1 = dgvQuestion.Columns[1];
                column1.Width = 540;

                pnlVQuiz.Visible = true;
                panel.Visible = false;
                pnlEditInfo.Visible = false;
                pnlStudent.Visible = false;
                pnlSRegister.Visible = false;
                pnlUpStudent.Visible = false;
                pnlMQuiz.Visible = false;
                pnlAQuestion.Visible = false;

                txtSearchQ.Text = "Search";
                txtSearchQ.ForeColor = System.Drawing.SystemColors.ControlDark;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            if (txtQuestion.Text.Equals("") || txtcorrect.Text.Equals("") || txtwrong.Text.Equals("") || txtwrong1.Text.Equals("") || txtwrong2.Text.Equals(""))
            {
                MessageBox.Show("Fill up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                db.sp_addQuestion(No, cmbMQGrade.Text, cmbMQSection.Text, txtQuestion.Text, txtcorrect.Text, txtwrong.Text, txtwrong1.Text, txtwrong2.Text, frm_Login.UserID.ToString());
                MessageBox.Show("Succesfully Add Question", "Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                QuizNo();

                DialogResult result = MessageBox.Show("Are you want to go back in View Question form?", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dgvQuestion.DataSource = db.sp_viewQuestion(cmbMQGrade.Text, cmbMQSection.Text, frm_Login.UserID.ToString());

                    DataGridViewColumn column = dgvQuestion.Columns[0];
                    column.Width = 30;
                    DataGridViewColumn column1 = dgvQuestion.Columns[1];
                    column1.Width = 540;

                    txtQuestion.Clear();
                    txtcorrect.Clear();
                    txtwrong.Clear();
                    txtwrong1.Clear();
                    txtwrong2.Clear();

                    pnlVQuiz.Visible = true;
                    panel.Visible = false;
                    pnlEditInfo.Visible = false;
                    pnlStudent.Visible = false;
                    pnlSRegister.Visible = false;
                    pnlUpStudent.Visible = false;
                    pnlMQuiz.Visible = false;
                    pnlAQuestion.Visible = false;
                    pnlUpQuiz.Visible = false;
                }
                else
                {
                    txtQuestion.Clear();
                    txtcorrect.Clear();
                    txtwrong.Clear();
                    txtwrong1.Clear();
                    txtwrong2.Clear();
                    txtQuestion.Focus();
                }
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            QuizNo();

            pnlAQuestion.Visible = true;
            panel.Visible = false;
            pnlEditInfo.Visible = false;
            pnlStudent.Visible = false;
            pnlSRegister.Visible = false;
            pnlUpStudent.Visible = false;
            pnlMQuiz.Visible = false;
            pnlVQuiz.Visible = false;
            pnlUpQuiz.Visible = false;

            txtQuestion.Clear();
            txtcorrect.Clear();
            txtwrong.Clear();
            txtwrong1.Clear();
            txtwrong2.Clear();
            txtQuestion.Focus();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            var query = db.sp_countQuez(cmbMQGrade.Text, cmbMQSection.Text);
            foreach (sp_countQuezResult countQNO in query)
            {
                if(countQNO.countQ.Value == 0)
                {
                    MessageBox.Show("Add Question First!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    pnlUpQuiz.Visible = true;
                    pnlAQuestion.Visible = false;
                    panel.Visible = false;
                    pnlEditInfo.Visible = false;
                    pnlStudent.Visible = false;
                    pnlSRegister.Visible = false;
                    pnlUpStudent.Visible = false;
                    pnlMQuiz.Visible = false;
                    pnlVQuiz.Visible = false;

                    db = new DataClassesTestQuestionnaireDataContext();
                    var Query_RQuiz = db.sp_RetrieveQuiz(int.Parse(dgvQuestion.CurrentRow.Cells[0].Value.ToString()), cmbMQGrade.Text, cmbMQSection.Text, frm_Login.UserID.ToString());
                    foreach (sp_RetrieveQuizResult entry in Query_RQuiz)
                    {
                        txtUpQuestion.Text = entry.Question.ToString();
                        txtUpCorrect.Text = entry.Answer.ToString();
                        txtUpWrong.Text = entry.Choice1.ToString();
                        txtUpWrong1.Text = entry.Choice2.ToString();
                        txtUpWrong2.Text = entry.Choice3.ToString();
                    }

                    txtUpQuestion.ForeColor = System.Drawing.SystemColors.ControlDark;
                    txtUpCorrect.ForeColor = System.Drawing.SystemColors.ControlDark;
                    txtUpWrong.ForeColor = System.Drawing.SystemColors.ControlDark;
                    txtUpWrong1.ForeColor = System.Drawing.SystemColors.ControlDark;
                    txtUpWrong2.ForeColor = System.Drawing.SystemColors.ControlDark;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlReport.Visible = true;
            panel.Visible = false;
            pnlEditInfo.Visible = false;
            pnlStudent.Visible = false;
            pnlSRegister.Visible = false;
            pnlUpStudent.Visible = false;
            pnlMQuiz.Visible = false;
            pnlVQuiz.Visible = false;
            pnlAQuestion.Visible = false;
            pnlUpQuiz.Visible = false;
            pnlPrint.Visible = false;

            cmbRGrade.Items.Clear();
            cmbRGrade.Items.AddRange(new object[] { "Grade 7", "Grade 8", "Grade 9" });
            cmbRSection.Items.Clear();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            if (txtUpQuestion.Text.Equals("") || txtUpCorrect.Text.Equals("") || txtUpWrong.Text.Equals("") || txtUpWrong1.Text.Equals("") || txtUpWrong2.Text.Equals(""))
            {
                MessageBox.Show("Fill up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you want to update this Question?", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    db.sp_updateQuiz(int.Parse(dgvQuestion.CurrentRow.Cells[0].Value.ToString()),txtUpQuestion.Text,txtUpCorrect.Text,txtUpWrong.Text,txtUpWrong1.Text,txtUpWrong2.Text,cmbMQGrade.Text,cmbMQSection.Text,frm_Login.UserID.ToString());
                    MessageBox.Show("Succesfully Update Question", "Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dgvQuestion.DataSource = db.sp_viewQuestion(cmbMQGrade.Text, cmbMQSection.Text, frm_Login.UserID.ToString());

                    pnlVQuiz.Visible = true;
                    panel.Visible = false;
                    pnlEditInfo.Visible = false;
                    pnlStudent.Visible = false;
                    pnlSRegister.Visible = false;
                    pnlUpStudent.Visible = false;
                    pnlMQuiz.Visible = false;
                    pnlAQuestion.Visible = false;
                    pnlUpQuiz.Visible = false;
                }

            }
        }

        int QuizNo()
        {
            db = new DataClassesTestQuestionnaireDataContext();
            var query = db.sp_countQuez(cmbMQGrade.Text, cmbMQSection.Text);
            foreach (sp_countQuezResult countQNO in query)
            {
                No = countQNO.countQ.Value;
            }
            No++;

            return No;
        }

        private void txtSearchQ_Click(object sender, EventArgs e)
        {
            if (txtSearchQ.Text == "Search")
            {
                txtSearchQ.Clear();
                txtSearchQ.ForeColor = Color.Black;
            }
        }

        private void txtSearchQ_TextChanged(object sender, EventArgs e)
        {
            dgvQuestion.DataSource = db.sp_searchQuestion(txtSearchQ.Text,cmbMQGrade.Text, cmbMQSection.Text, frm_Login.UserID.ToString());
        }

        private void txtSearchQ_Leave(object sender, EventArgs e)
        {
            if(txtSearchQ.Text == "")
            {
                txtSearchQ.Text = "Search";
                txtSearchQ.ForeColor = System.Drawing.SystemColors.ControlDark;

                dgvQuestion.DataSource = db.sp_viewQuestion(cmbMQGrade.Text, cmbMQSection.Text, frm_Login.UserID.ToString());

                DataGridViewColumn column = dgvQuestion.Columns[0];
                column.Width = 30;
                DataGridViewColumn column1 = dgvQuestion.Columns[1];
                column1.Width = 540;
            }
        }

        private void txtUpQuestion_Click(object sender, EventArgs e)
        {
            txtUpQuestion.Clear();
            txtUpQuestion.ForeColor = Color.Black;
        }

        private void txtUpCorrect_Click(object sender, EventArgs e)
        {
            txtUpCorrect.Clear();
            txtUpCorrect.ForeColor = Color.Black;
        }

        private void txtUpWrong1_Click(object sender, EventArgs e)
        {
            txtUpWrong1.Clear();
            txtUpWrong1.ForeColor = Color.Black;
        }

        private void txtUpWrong_Click(object sender, EventArgs e)
        {
            txtUpWrong.Clear();
            txtUpWrong.ForeColor = Color.Black;
        }

        private void txtUpWrong2_Click(object sender, EventArgs e)
        {
            txtUpWrong2.Clear();
            txtUpWrong2.ForeColor = Color.Black;
        }

        private void cmbRGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            int Counter = 0;
            cmbRSection.Items.Clear();
            var Query_Grade = db.sp_selectSectioninGrade(cmbRGrade.Text, frm_Login.UserID.ToString());
            foreach (sp_selectSectioninGradeResult entry in Query_Grade)
            {
                cmbRSection.Items.Add(entry.Section_Name.ToString());
                Counter++;
            }
            if (Counter.Equals(0))
            {
                cmbRSection.Items.Clear();
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if(cmbRGrade.Text.Equals("") || cmbRSection.Text.Equals(""))
            {
                MessageBox.Show("Fill up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pnlPrint.Visible = true;
                panel.Visible = false;
                pnlEditInfo.Visible = false;
                pnlStudent.Visible = false;
                pnlSRegister.Visible = false;
                pnlUpStudent.Visible = false;
                pnlMQuiz.Visible = false;
                pnlAQuestion.Visible = false;
                pnlUpQuiz.Visible = false;
                pnlReport.Visible = false;

                db = new DataClassesTestQuestionnaireDataContext();
                dgvScore.DataSource = db.sp_viewScore(frm_Login.UserID.ToString(), cmbRSection.Text, cmbRGrade.Text);

                DataGridViewColumn column = dgvScore.Columns[0];
                column.Width = 135;
                DataGridViewColumn column1 = dgvScore.Columns[1];
                column1.Width = 135;
                DataGridViewColumn column2 = dgvScore.Columns[2];
                column2.Width = 134;
                DataGridViewColumn column3 = dgvScore.Columns[3];
                column3.Width = 134;
            }
        }

        private void txtUpSFname_Click(object sender, EventArgs e)
        {
            txtUpSFname.Clear();
            txtUpSFname.ForeColor = Color.Black;
        }

        private void txtUpSLname_Click(object sender, EventArgs e)
        {
            txtUpSLname.Clear();
            txtUpSLname.ForeColor = Color.Black;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Section = cmbRSection.Text;
            Grade = cmbRGrade.Text;

            this.Hide();
            frm_Print P = new frm_Print();
            P.Show();
        }
    }
}
