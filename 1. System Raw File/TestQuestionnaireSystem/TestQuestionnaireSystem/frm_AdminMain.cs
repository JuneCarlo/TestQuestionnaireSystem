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
    public partial class frm_AdminMain : Form
    {
        public frm_AdminMain()
        {
            InitializeComponent();
            TeacherID();
            SectionID();
            lblLname.Text = frm_Login.Lname.First().ToString().ToUpper() + String.Join("", frm_Login.Lname.Skip(1)).ToLower();
            lblLname1.Text = frm_Login.Lname.First().ToString().ToUpper() + String.Join("", frm_Login.Lname.Skip(1)).ToLower();
        }
        string User, TIDCount, ID, TeID, SecIDCount, SecReID;
        static DataClassesTestQuestionnaireDataContext db = null;
        private void frm_AdminMain_Load(object sender, EventArgs e)
        {
            panel.Visible = false;
            pnlTeacher.Visible = false;
            pnlEditInfo.Visible = false;
            pnlTRegister.Visible = false;
            pnlEditTeacher.Visible = false;
            pnlSection.Visible = false;
            pnlUpSection.Visible = false;
            pnlRSection.Visible = false;
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
            pnlTeacher.Visible = false;
            pnlEditInfo.Visible = false;
            pnlTRegister.Visible = false;
            pnlEditTeacher.Visible = false;
            pnlSection.Visible = false;
            pnlUpSection.Visible = false;
            pnlRSection.Visible = false;
        }

        private void txtSearchT_Leave(object sender, EventArgs e)
        {
            if(txtSearchT.Text == "")
            {
                txtSearchT.Text = "Search";
                txtSearchT.ForeColor = System.Drawing.SystemColors.WindowFrame;

                db = new DataClassesTestQuestionnaireDataContext();
                dgvTeacher.DataSource = db.sp_viewTeacher();

                DataGridViewColumn column = dgvTeacher.Columns[0];
                column.Width = 155;

                DataGridViewColumn column1 = dgvTeacher.Columns[1];
                column1.Width = 155;
            }
        }

        private void lblTeacher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel.Visible = false;
            pnlTeacher.Visible = true;
            pnlEditInfo.Visible = false;
            pnlTRegister.Visible = false;
            pnlEditTeacher.Visible = false;
            pnlSection.Visible = false;
            pnlUpSection.Visible = false;
            pnlRSection.Visible = false;

            db = new DataClassesTestQuestionnaireDataContext();
            dgvTeacher.DataSource = db.sp_viewTeacher();

            DataGridViewColumn columnT = dgvTeacher.Columns[0];
            columnT.Width = 155;

            DataGridViewColumn columnT1 = dgvTeacher.Columns[1];
            columnT1.Width = 155;

            txtSearchT.Text = "Search";
            txtSearchT.ForeColor = System.Drawing.SystemColors.ControlDark;
        }

        private void txtSearchT_Click(object sender, EventArgs e)
        {
            if (txtSearchT.Text == "Search")
            {
                txtSearchT.Clear();
                txtSearchT.ForeColor = Color.Black;
            }
        }

        private void txtSearchT_TextChanged(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            dgvTeacher.DataSource = db.sp_searchT(txtSearchT.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            pnlTeacher.Visible = false;
            pnlTRegister.Visible = false;
            pnlEditTeacher.Visible = false;
            pnlSection.Visible = false;
            pnlEditInfo.Visible = true;
            pnlUpSection.Visible = false;
            pnlRSection.Visible = false;

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

        private void pictureBox3_Click(object sender, EventArgs e)
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
                        db.sp_UpdateTeacher(frm_Login.UserID.ToString(), txtEditUname.Text, txtEditPword.Text, txtEditLname.Text, txtEditFname.Text);
                        MessageBox.Show("Succesfully Update", "Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        panel.Visible = false;
                        pnlTeacher.Visible = false;
                        pnlEditInfo.Visible = false;

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();

            if (txtRTFname.Text.Equals("") || txtRTLname.Text.Equals("") || txtRTUname.Text.Equals("") || txtRTPword.Text.Equals(""))
            {
                MessageBox.Show("Fill up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtRTUname.Text.Equals(User))
                {
                    MessageBox.Show("Username is taken", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRTUname.Clear();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to Add Teacher", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        db.sp_addTeacher(TIDCount, txtRTUname.Text, txtRTPword.Text, txtRTLname.Text.ToUpper(), txtRTFname.Text.ToUpper(), "TEACHER");
                        MessageBox.Show("Succesfully Add Teacher", "Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dgvTeacher.DataSource = db.sp_viewTeacher();

                        txtRTUname.Clear();
                        txtRTPword.Clear();
                        txtRTFname.Clear();
                        txtRTLname.Clear();
                        TeacherID();

                        panel.Visible = false;
                        pnlTeacher.Visible = true;
                        pnlEditInfo.Visible = false;
                        pnlTRegister.Visible = false;
                        pnlEditTeacher.Visible = false;
                    }
                }
            }
        }

        private void txtRUname_TextChanged(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            var Query_User = db.sp_retrieveUsernameTeacher(txtRTUname.Text);
            foreach (sp_retrieveUsernameTeacherResult entry in Query_User)
            {
                User = entry.T_Username.ToString();
            }
        }

        string TeacherID()
        {
            int iCount = 0;
            string TID = "";
            db = new DataClassesTestQuestionnaireDataContext();
            var query = db.sp_teacherID();
            foreach (sp_teacherIDResult countT in query)
            {
                iCount = countT.CountT.Value;
            }
            iCount++;
            if (iCount.ToString().Length.Equals(1))
            {
                TID = "T-" + iCount.ToString().PadLeft(4, '0').ToString();
            }
            else if (iCount.ToString().Length.Equals(2))
            {
                TID = "T-" + iCount.ToString().PadLeft(3, '0').ToString();
            }
            else
            {
                TID = "T-" + iCount.ToString().PadLeft(2, '0').ToString();
            }

            return TIDCount = TID;
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

        private void picAddTeacher_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            pnlTeacher.Visible = false;
            pnlEditInfo.Visible = false;
            pnlTRegister.Visible = true;
            pnlEditTeacher.Visible = false;
            pnlSection.Visible = false;
            pnlUpSection.Visible = false;
            pnlRSection.Visible = false;

            txtRTUname.Clear();
            txtRTPword.Clear();
            txtRTFname.Clear();
            txtRTLname.Clear();
            txtRTFname.Focus();
        }

        private void txtUpTUname_TextChanged(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            var Query_User = db.sp_retrieveUsernameTeacher(txtUpTUname.Text);
            foreach (sp_retrieveUsernameTeacherResult entry in Query_User)
            {
                User = entry.T_Username.ToString();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            var query = db.sp_teacherID();
            foreach (sp_teacherIDResult countT in query)
            {
                if (countT.CountT.Value == 1)
                {
                    MessageBox.Show("Add Teacher first!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    panel.Visible = false;
                    pnlTeacher.Visible = false;
                    pnlEditInfo.Visible = false;
                    pnlTRegister.Visible = false;
                    pnlEditTeacher.Visible = true;
                    pnlSection.Visible = false;
                    pnlUpSection.Visible = false;
                    pnlRSection.Visible = false;

                    txtUpTFname.Text = dgvTeacher.CurrentRow.Cells[1].Value.ToString();
                    txtUpTLname.Text = dgvTeacher.CurrentRow.Cells[0].Value.ToString();

                    db = new DataClassesTestQuestionnaireDataContext();
                    var TeaUserPass = db.sp_retrieveName(txtUpTLname.Text, txtUpTFname.Text);
                    foreach (sp_retrieveNameResult entry in TeaUserPass)
                    {
                        txtUpTPword.Text = entry.T_Password.ToString();
                        txtUpTUname.Text = entry.T_Username.ToString();
                        ID = entry.T_ID.ToString();
                    }

                    txtUpTFname.ForeColor = System.Drawing.SystemColors.ControlDark;
                    txtUpTLname.ForeColor = System.Drawing.SystemColors.ControlDark;
                    txtUpTUname.ForeColor = System.Drawing.SystemColors.ControlDark;
                    txtUpTPword.ForeColor = System.Drawing.SystemColors.ControlDark;
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            if (txtUpTFname.Text.Equals("") || txtUpTLname.Text.Equals("") || txtUpTUname.Text.Equals("") || txtUpTPword.Text.Equals(""))
            {
                MessageBox.Show("Fill up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtUpTUname.Text.Equals(User))
                {
                    MessageBox.Show("Username is taken", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUpTUname.Clear();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to Update", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        db.sp_UpdateTeacher(ID, txtUpTUname.Text, txtUpTPword.Text, txtUpTLname.Text.ToUpper(), txtUpTFname.Text.ToUpper());
                        MessageBox.Show("Succesfully Update", "Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dgvTeacher.DataSource = db.sp_viewTeacher();

                        panel.Visible = false;
                        pnlTeacher.Visible = true;
                        pnlEditInfo.Visible = false;
                        pnlTRegister.Visible = false;
                        pnlEditTeacher.Visible = false;
                    }
                }
            }
        }

        private void txtUpTFname_Click(object sender, EventArgs e)
        {
            txtUpTFname.Clear();
            txtUpTFname.ForeColor = Color.Black;
        }

        private void txtUpTLname_Click(object sender, EventArgs e)
        {
            txtUpTLname.Clear();
            txtUpTLname.ForeColor = Color.Black;
        }

        private void txtUpTUname_Click(object sender, EventArgs e)
        {
            txtUpTUname.Clear();
            txtUpTUname.ForeColor = Color.Black;
        }

        private void lblSection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel.Visible = false;
            pnlTeacher.Visible = false;
            pnlEditInfo.Visible = false;
            pnlTRegister.Visible = false;
            pnlEditTeacher.Visible = false;
            pnlSection.Visible = true;
            pnlUpSection.Visible = false;
            pnlRSection.Visible = false;

            db = new DataClassesTestQuestionnaireDataContext();
            dgvSection.DataSource = db.sp_viewSection();
            DataGridViewColumn columnS = dgvSection.Columns[2];
            columnS.Width = 112;

            txtSearchS.Text = "Search";
            txtSearchS.ForeColor = System.Drawing.SystemColors.ControlDark;
        }

        private void txtSearchS_TextChanged(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            dgvSection.DataSource = db.sp_searchS(txtSearchS.Text);

        }

        private void txtSearchS_Click(object sender, EventArgs e)
        {
            if (txtSearchS.Text == "Search")
            {
                txtSearchS.Clear();
                txtSearchS.ForeColor = Color.Black;
            }
        }

        private void txtSearchS_Leave(object sender, EventArgs e)
        {
            if(txtSearchS.Text == "")
            {
                txtSearchS.Text = "Search";
                txtSearchS.ForeColor = System.Drawing.SystemColors.WindowFrame;

                dgvSection.DataSource = db.sp_viewSection();
                DataGridViewColumn columnS = dgvSection.Columns[2];
                columnS.Width = 112;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            var query = db.sp_sectionID();
            foreach (sp_sectionIDResult countT in query)
            {
                if (countT.CountS.Value == 0)
                {
                    MessageBox.Show("Add Section first!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    panel.Visible = false;
                    pnlTeacher.Visible = false;
                    pnlEditInfo.Visible = false;
                    pnlTRegister.Visible = false;
                    pnlEditTeacher.Visible = false;
                    pnlSection.Visible = false;
                    pnlUpSection.Visible = true;

                    cmbUpTeacher.Items.Clear();
                    string Fname, Lname;
                    db = new DataClassesTestQuestionnaireDataContext();
                    var Query_Tname = db.sp_SelectTeacher();
                    foreach (sp_SelectTeacherResult entryST in Query_Tname)
                    {
                        Fname = entryST.T_LastName.ToString();
                        Lname = entryST.T_FirstName.ToString();
                        cmbUpTeacher.Items.Add(Lname + " " + Fname);
                    }

                    txtUpSection.ForeColor = System.Drawing.SystemColors.ControlDark;

                    txtUpSection.Text = dgvSection.CurrentRow.Cells[0].Value.ToString();
                    cmbUpGrade.Text = dgvSection.CurrentRow.Cells[1].Value.ToString();
                    cmbUpTeacher.Text = dgvSection.CurrentRow.Cells[2].Value.ToString();

                    var Query_RertiveSection = db.sp_retrieveSection(dgvSection.CurrentRow.Cells[0].Value.ToString(), dgvSection.CurrentRow.Cells[1].Value.ToString(), dgvSection.CurrentRow.Cells[2].Value.ToString());
                    foreach (sp_retrieveSectionResult entryReSec in Query_RertiveSection)
                    {
                        SecReID = entryReSec.Section_ID.ToString();
                    }
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            pnlTeacher.Visible = false;
            pnlEditInfo.Visible = false;
            pnlTRegister.Visible = false;
            pnlEditTeacher.Visible = false;
            pnlSection.Visible = false;
            pnlUpSection.Visible = false;
            pnlRSection.Visible = true;

            cmbRTeacher.Items.Clear();
            string Fname, Lname;
            db = new DataClassesTestQuestionnaireDataContext();
            var Quert_Tname = db.sp_SelectTeacher();
            foreach (sp_SelectTeacherResult entryST in Quert_Tname)
            {
                Lname = entryST.T_LastName.ToString();
                Fname = entryST.T_FirstName.ToString();
                cmbRTeacher.Items.Add(Fname + " " + Lname);
            }

            txtRSname.Focus();
            txtRSname.Clear();
            cmbRGrade.Items.Clear();
            cmbRGrade.Items.AddRange(new object[] { "Grade 7", "Grade 8", "Grade 9" });
        }

        string SectionID()
        {
            int iCount = 0;
            string SecID = "";
            db = new DataClassesTestQuestionnaireDataContext();
            var query = db.sp_sectionID();
            foreach (sp_sectionIDResult countT in query)
            {
                iCount = countT.CountS.Value;
            }
            iCount++;
            if (iCount.ToString().Length.Equals(1))
            {
                SecID = "Section-" + iCount.ToString().PadLeft(4, '0').ToString();
            }
            else if (iCount.ToString().Length.Equals(2))
            {
                SecID = "Section-" + iCount.ToString().PadLeft(3, '0').ToString();
            }
            else
            {
                SecID = "Section-" + iCount.ToString().PadLeft(2, '0').ToString();
            }

            return SecIDCount = SecID;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            string Fname, Lname;
            db = new DataClassesTestQuestionnaireDataContext();
            if (txtRSname.Text.Equals("") || cmbRGrade.Text.Equals("") || cmbRTeacher.Text.Equals(""))
            {
                MessageBox.Show("Fill up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Add Section", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string Fullname = cmbRTeacher.SelectedItem.ToString();
                    var name = Fullname.Split(' ');
                    Fname = name[0];
                    Lname = name[1];

                    var Tname = db.sp_NameTeacher(Fname, Lname);
                    foreach (sp_NameTeacherResult entryID in Tname)
                    {
                        TeID = entryID.T_ID.ToString();
                    }

                    db.sp_addSection(SecIDCount, txtRSname.Text, cmbRGrade.Text, TeID, cmbRTeacher.Text);
                    MessageBox.Show("Succesfully Add Section", "Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    SectionID();
                    txtRSname.Clear();
                    dgvSection.DataSource = db.sp_viewSection();

                    panel.Visible = false;
                    pnlTeacher.Visible = false;
                    pnlEditInfo.Visible = false;
                    pnlTRegister.Visible = false;
                    pnlEditTeacher.Visible = false;
                    pnlSection.Visible = true;
                    pnlUpSection.Visible = false;
                    pnlRSection.Visible = false;
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string Fname, Lname;
            db = new DataClassesTestQuestionnaireDataContext();
            if (txtUpSection.Text.Equals("") || cmbUpGrade.Text.Equals("") || cmbUpTeacher.Text.Equals(""))
            {
                MessageBox.Show("Fill up Everything", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Update", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string Fullname = cmbUpTeacher.SelectedItem.ToString();
                    var name = Fullname.Split(' ');
                    Fname = name[0];
                    Lname = name[1];

                    var Tname = db.sp_NameTeacher(Fname, Lname);
                    foreach (sp_NameTeacherResult entryID in Tname)
                    {
                        TeID = entryID.T_ID.ToString();
                    }

                    db.sp_updateSection(SecReID, txtUpSection.Text, cmbUpGrade.Text, TeID, cmbUpTeacher.Text);
                    MessageBox.Show("Succesfully Update Section", "Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtRSname.Clear();
                    dgvSection.DataSource = db.sp_viewSection();

                    panel.Visible = false;
                    pnlTeacher.Visible = false;
                    pnlEditInfo.Visible = false;
                    pnlTRegister.Visible = false;
                    pnlEditTeacher.Visible = false;
                    pnlSection.Visible = true;
                    pnlUpSection.Visible = false;
                    pnlRSection.Visible = false;
                }
            }
        }

        private void txtUpTPword_Leave(object sender, EventArgs e)
        {
            txtUpTPword.Clear();
            txtUpTPword.ForeColor = Color.Black;
        }

        private void txtUpSection_Click(object sender, EventArgs e)
        {
            txtUpSection.Clear();
            txtUpSection.ForeColor = Color.Black;
        }    
    }
}
