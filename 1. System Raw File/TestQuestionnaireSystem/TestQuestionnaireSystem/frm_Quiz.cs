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
    public partial class frm_Quiz : Form
    {
        public frm_Quiz()
        {
            InitializeComponent();
            pnlStartQuiz.Visible = true;
            pnlEndQuiz.Visible = false;
        }
        int Qnumber = 1, Check = 0;
        private 
        DataClassesTestQuestionnaireDataContext db = null;
        private void frm_Quiz_Load(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            var query = db.sp_ViewQuizNo(Qnumber, frm_StudentMain.SGrade.ToString(), frm_StudentMain.SSection.ToString());
            foreach (sp_ViewQuizNoResult entry in query)
            {
                lblNo.Text = Qnumber.ToString() + ".";
                lblQuestion.Text = entry.Question.ToString();

                String[] Chooses = { entry.Answer.ToString(), entry.Choice1.ToString(), entry.Choice2.ToString(), entry.Choice3.ToString() };
                Random Rnd = new Random();
                int select = Rnd.Next(0, 4);
                radioButton1.Text = Chooses[select];

                if (radioButton1.Text == entry.Answer.ToString())
                {
                    String[] Chooses1 = { entry.Choice1.ToString(), entry.Choice2.ToString(), entry.Choice3.ToString() };
                    int select1 = Rnd.Next(0, 3);
                    radioButton2.Text = Chooses1[select1];

                    if (radioButton2.Text == entry.Choice1.ToString())
                    {
                        String[] Chooses2 = { entry.Choice2.ToString(), entry.Choice3.ToString() };
                        int select2 = Rnd.Next(0, 2);
                        radioButton3.Text = Chooses2[select2];

                        if (radioButton3.Text == entry.Choice2.ToString())
                        {
                            radioButton4.Text = entry.Choice3.ToString();
                        }
                        else
                        {
                            radioButton4.Text = entry.Choice2.ToString();
                        }
                    }
                    else if (radioButton2.Text == entry.Choice2.ToString())
                    {
                        String[] Chooses2 = { entry.Choice1.ToString(), entry.Choice3.ToString() };
                        int select2 = Rnd.Next(0, 2);
                        radioButton3.Text = Chooses2[select2];

                        if (radioButton3.Text == entry.Choice1.ToString())
                        {
                            radioButton4.Text = entry.Choice3.ToString();
                        }
                        else
                        {
                            radioButton4.Text = entry.Choice1.ToString();
                        }
                    }
                    else
                    {
                        String[] Chooses2 = { entry.Choice1.ToString(), entry.Choice2.ToString() };
                        int select2 = Rnd.Next(0, 2);
                        radioButton3.Text = Chooses2[select2];

                        if (radioButton3.Text == entry.Choice1.ToString())
                        {
                            radioButton4.Text = entry.Choice2.ToString();
                        }
                        else
                        {
                            radioButton4.Text = entry.Choice1.ToString();
                        }
                    }
                }
                else if (radioButton1.Text == entry.Choice1.ToString())
                {
                    String[] Chooses1 = { entry.Answer.ToString(), entry.Choice2.ToString(), entry.Choice3.ToString() };
                    int select1 = Rnd.Next(0, 3);
                    radioButton2.Text = Chooses1[select1];

                    if (radioButton2.Text == entry.Answer.ToString())
                    {
                        String[] Chooses2 = { entry.Choice2.ToString(), entry.Choice3.ToString() };
                        int select2 = Rnd.Next(0, 2);
                        radioButton3.Text = Chooses2[select2];

                        if (radioButton3.Text == entry.Choice2.ToString())
                        {
                            radioButton4.Text = entry.Choice3.ToString();
                        }
                        else
                        {
                            radioButton4.Text = entry.Choice2.ToString();
                        }
                    }
                    else if (radioButton2.Text == entry.Choice2.ToString())
                    {
                        String[] Chooses2 = { entry.Answer.ToString(), entry.Choice3.ToString() };
                        int select2 = Rnd.Next(0, 2);
                        radioButton3.Text = Chooses2[select2];

                        if (radioButton3.Text == entry.Answer.ToString())
                        {
                            radioButton4.Text = entry.Choice3.ToString();
                        }
                        else
                        {
                            radioButton4.Text = entry.Answer.ToString();
                        }
                    }
                    else
                    {
                        String[] Chooses2 = { entry.Answer.ToString(), entry.Choice2.ToString() };
                        int select2 = Rnd.Next(0, 2);
                        radioButton3.Text = Chooses2[select2];

                        if (radioButton3.Text == entry.Answer.ToString())
                        {
                            radioButton4.Text = entry.Choice2.ToString();
                        }
                        else
                        {
                            radioButton4.Text = entry.Answer.ToString();
                        }
                    }
                }
                else if (radioButton1.Text == entry.Choice2.ToString())
                {
                    String[] Chooses1 = { entry.Answer.ToString(), entry.Choice1.ToString(), entry.Choice3.ToString() };
                    int select1 = Rnd.Next(0, 3);
                    radioButton2.Text = Chooses1[select1];

                    if (radioButton2.Text == entry.Answer.ToString())
                    {
                        String[] Chooses2 = { entry.Choice1.ToString(), entry.Choice3.ToString() };
                        int select2 = Rnd.Next(0, 2);
                        radioButton3.Text = Chooses2[select2];

                        if (radioButton3.Text == entry.Choice1.ToString())
                        {
                            radioButton4.Text = entry.Choice3.ToString();
                        }
                        else
                        {
                            radioButton4.Text = entry.Choice1.ToString();
                        }
                    }

                    else if (radioButton2.Text == entry.Choice1.ToString())
                    {
                        String[] Chooses2 = { entry.Answer.ToString(), entry.Choice3.ToString() };
                        int select2 = Rnd.Next(0, 2);
                        radioButton3.Text = Chooses2[select2];

                        if (radioButton3.Text == entry.Answer.ToString())
                        {
                            radioButton4.Text = entry.Choice3.ToString();
                        }
                        else
                        {
                            radioButton4.Text = entry.Answer.ToString();
                        }
                    }
                    else
                    {
                        String[] Chooses2 = { entry.Answer.ToString(), entry.Choice1.ToString() };
                        int select2 = Rnd.Next(0, 2);
                        radioButton3.Text = Chooses2[select2];

                        if (radioButton3.Text == entry.Answer.ToString())
                        {
                            radioButton4.Text = entry.Choice1.ToString();
                        }
                        else
                        {
                            radioButton4.Text = entry.Answer.ToString();
                        }
                    }
                }
                else
                {
                    String[] Chooses1 = { entry.Answer.ToString(), entry.Choice1.ToString(), entry.Choice2.ToString() };
                    int select1 = Rnd.Next(0, 3);
                    radioButton2.Text = Chooses1[select1];

                    if (radioButton2.Text == entry.Answer.ToString())
                    {
                        String[] Chooses2 = { entry.Choice1.ToString(), entry.Choice2.ToString() };
                        int select2 = Rnd.Next(0, 2);
                        radioButton3.Text = Chooses2[select2];

                        if (radioButton3.Text == entry.Choice1.ToString())
                        {
                            radioButton4.Text = entry.Choice2.ToString();
                        }
                        else
                        {
                            radioButton4.Text = entry.Choice1.ToString();
                        }
                    }

                    else if (radioButton2.Text == entry.Choice1.ToString())
                    {
                        String[] Chooses2 = { entry.Answer.ToString(), entry.Choice2.ToString() };
                        int select2 = Rnd.Next(0, 2);
                        radioButton3.Text = Chooses2[select2];

                        if (radioButton3.Text == entry.Answer.ToString())
                        {
                            radioButton4.Text = entry.Choice2.ToString();
                        }
                        else
                        {
                            radioButton4.Text = entry.Answer.ToString();
                        }
                    }

                    else
                    {
                        String[] Chooses2 = { entry.Answer.ToString(), entry.Choice1.ToString() };
                        int select2 = Rnd.Next(0, 2);
                        radioButton3.Text = Chooses2[select2];

                        if (radioButton3.Text == entry.Answer.ToString())
                        {
                            radioButton4.Text = entry.Choice1.ToString();
                        }
                        else
                        {
                            radioButton4.Text = entry.Answer.ToString();
                        }
                    }
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            db = new DataClassesTestQuestionnaireDataContext();
            var queryCheck = db.sp_ViewQuizNo(Qnumber, frm_StudentMain.SGrade.ToString(), frm_StudentMain.SSection.ToString());
            foreach (sp_ViewQuizNoResult entry in queryCheck)
            {
                if(radioButton1.Checked == true)
                {
                    if(radioButton1.Text == entry.Answer.ToString())
                    {
                        Check++;
                    }
                }
                else if(radioButton2.Checked == true)
                {
                    if (radioButton2.Text == entry.Answer.ToString())
                    {
                        Check++;
                    }
                }
                else if(radioButton3.Checked == true)
                {
                    if (radioButton3.Text == entry.Answer.ToString())
                    {
                        Check++;
                    }
                }
                else if(radioButton4.Checked == true)
                {
                    if (radioButton4.Text == entry.Answer.ToString())
                    {
                        Check++;
                    }
                }
            }

            var query1 = db.sp_countQuez(frm_StudentMain.SGrade.ToString(), frm_StudentMain.SSection.ToString());
            foreach(sp_countQuezResult entryC in query1)
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
                {
                    MessageBox.Show("You need to answer this question", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Qnumber < entryC.countQ.Value)
                    {
                        Qnumber++;
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;

                        db = new DataClassesTestQuestionnaireDataContext();
                        var query = db.sp_ViewQuizNo(Qnumber, frm_StudentMain.SGrade.ToString(), frm_StudentMain.SSection.ToString());
                        foreach (sp_ViewQuizNoResult entry in query)
                        {
                            lblNo.Text = Qnumber.ToString() + ".";
                            lblQuestion.Text = entry.Question.ToString();

                            String[] Chooses = { entry.Answer.ToString(), entry.Choice1.ToString(), entry.Choice2.ToString(), entry.Choice3.ToString() };
                            Random Rnd = new Random();
                            int select = Rnd.Next(0, 4);
                            radioButton1.Text = Chooses[select];

                            if (radioButton1.Text == entry.Answer.ToString())
                            {
                                String[] Chooses1 = { entry.Choice1.ToString(), entry.Choice2.ToString(), entry.Choice3.ToString() };
                                int select1 = Rnd.Next(0, 3);
                                radioButton2.Text = Chooses1[select1];

                                if (radioButton2.Text == entry.Choice1.ToString())
                                {
                                    String[] Chooses2 = { entry.Choice2.ToString(), entry.Choice3.ToString() };
                                    int select2 = Rnd.Next(0, 2);
                                    radioButton3.Text = Chooses2[select2];

                                    if (radioButton3.Text == entry.Choice2.ToString())
                                    {
                                        radioButton4.Text = entry.Choice3.ToString();
                                    }
                                    else
                                    {
                                        radioButton4.Text = entry.Choice2.ToString();
                                    }
                                }
                                else if (radioButton2.Text == entry.Choice2.ToString())
                                {
                                    String[] Chooses2 = { entry.Choice1.ToString(), entry.Choice3.ToString() };
                                    int select2 = Rnd.Next(0, 2);
                                    radioButton3.Text = Chooses2[select2];

                                    if (radioButton3.Text == entry.Choice1.ToString())
                                    {
                                        radioButton4.Text = entry.Choice3.ToString();
                                    }
                                    else
                                    {
                                        radioButton4.Text = entry.Choice1.ToString();
                                    }
                                }
                                else
                                {
                                    String[] Chooses2 = { entry.Choice1.ToString(), entry.Choice2.ToString() };
                                    int select2 = Rnd.Next(0, 2);
                                    radioButton3.Text = Chooses2[select2];

                                    if (radioButton3.Text == entry.Choice1.ToString())
                                    {
                                        radioButton4.Text = entry.Choice2.ToString();
                                    }
                                    else
                                    {
                                        radioButton4.Text = entry.Choice1.ToString();
                                    }
                                }
                            }
                            else if (radioButton1.Text == entry.Choice1.ToString())
                            {
                                String[] Chooses1 = { entry.Answer.ToString(), entry.Choice2.ToString(), entry.Choice3.ToString() };
                                int select1 = Rnd.Next(0, 3);
                                radioButton2.Text = Chooses1[select1];

                                if (radioButton2.Text == entry.Answer.ToString())
                                {
                                    String[] Chooses2 = { entry.Choice2.ToString(), entry.Choice3.ToString() };
                                    int select2 = Rnd.Next(0, 2);
                                    radioButton3.Text = Chooses2[select2];

                                    if (radioButton3.Text == entry.Choice2.ToString())
                                    {
                                        radioButton4.Text = entry.Choice3.ToString();
                                    }
                                    else
                                    {
                                        radioButton4.Text = entry.Choice2.ToString();
                                    }
                                }
                                else if (radioButton2.Text == entry.Choice2.ToString())
                                {
                                    String[] Chooses2 = { entry.Answer.ToString(), entry.Choice3.ToString() };
                                    int select2 = Rnd.Next(0, 2);
                                    radioButton3.Text = Chooses2[select2];

                                    if (radioButton3.Text == entry.Answer.ToString())
                                    {
                                        radioButton4.Text = entry.Choice3.ToString();
                                    }
                                    else
                                    {
                                        radioButton4.Text = entry.Answer.ToString();
                                    }
                                }
                                else
                                {
                                    String[] Chooses2 = { entry.Answer.ToString(), entry.Choice2.ToString() };
                                    int select2 = Rnd.Next(0, 2);
                                    radioButton3.Text = Chooses2[select2];

                                    if (radioButton3.Text == entry.Answer.ToString())
                                    {
                                        radioButton4.Text = entry.Choice2.ToString();
                                    }
                                    else
                                    {
                                        radioButton4.Text = entry.Answer.ToString();
                                    }
                                }
                            }
                            else if (radioButton1.Text == entry.Choice2.ToString())
                            {
                                String[] Chooses1 = { entry.Answer.ToString(), entry.Choice1.ToString(), entry.Choice3.ToString() };
                                int select1 = Rnd.Next(0, 3);
                                radioButton2.Text = Chooses1[select1];

                                if (radioButton2.Text == entry.Answer.ToString())
                                {
                                    String[] Chooses2 = { entry.Choice1.ToString(), entry.Choice3.ToString() };
                                    int select2 = Rnd.Next(0, 2);
                                    radioButton3.Text = Chooses2[select2];

                                    if (radioButton3.Text == entry.Choice1.ToString())
                                    {
                                        radioButton4.Text = entry.Choice3.ToString();
                                    }
                                    else
                                    {
                                        radioButton4.Text = entry.Choice1.ToString();
                                    }
                                }

                                else if (radioButton2.Text == entry.Choice1.ToString())
                                {
                                    String[] Chooses2 = { entry.Answer.ToString(), entry.Choice3.ToString() };
                                    int select2 = Rnd.Next(0, 2);
                                    radioButton3.Text = Chooses2[select2];

                                    if (radioButton3.Text == entry.Answer.ToString())
                                    {
                                        radioButton4.Text = entry.Choice3.ToString();
                                    }
                                    else
                                    {
                                        radioButton4.Text = entry.Answer.ToString();
                                    }
                                }
                                else
                                {
                                    String[] Chooses2 = { entry.Answer.ToString(), entry.Choice1.ToString() };
                                    int select2 = Rnd.Next(0, 2);
                                    radioButton3.Text = Chooses2[select2];

                                    if (radioButton3.Text == entry.Answer.ToString())
                                    {
                                        radioButton4.Text = entry.Choice1.ToString();
                                    }
                                    else
                                    {
                                        radioButton4.Text = entry.Answer.ToString();
                                    }
                                }
                            }
                            else
                            {
                                String[] Chooses1 = { entry.Answer.ToString(), entry.Choice1.ToString(), entry.Choice2.ToString() };
                                int select1 = Rnd.Next(0, 3);
                                radioButton2.Text = Chooses1[select1];

                                if (radioButton2.Text == entry.Answer.ToString())
                                {
                                    String[] Chooses2 = { entry.Choice1.ToString(), entry.Choice2.ToString() };
                                    int select2 = Rnd.Next(0, 2);
                                    radioButton3.Text = Chooses2[select2];

                                    if (radioButton3.Text == entry.Choice1.ToString())
                                    {
                                        radioButton4.Text = entry.Choice2.ToString();
                                    }
                                    else
                                    {
                                        radioButton4.Text = entry.Choice1.ToString();
                                    }
                                }

                                else if (radioButton2.Text == entry.Choice1.ToString())
                                {
                                    String[] Chooses2 = { entry.Answer.ToString(), entry.Choice2.ToString() };
                                    int select2 = Rnd.Next(0, 2);
                                    radioButton3.Text = Chooses2[select2];

                                    if (radioButton3.Text == entry.Answer.ToString())
                                    {
                                        radioButton4.Text = entry.Choice2.ToString();
                                    }
                                    else
                                    {
                                        radioButton4.Text = entry.Answer.ToString();
                                    }
                                }

                                else
                                {
                                    String[] Chooses2 = { entry.Answer.ToString(), entry.Choice1.ToString() };
                                    int select2 = Rnd.Next(0, 2);
                                    radioButton3.Text = Chooses2[select2];

                                    if (radioButton3.Text == entry.Answer.ToString())
                                    {
                                        radioButton4.Text = entry.Choice1.ToString();
                                    }
                                    else
                                    {
                                        radioButton4.Text = entry.Answer.ToString();
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        pnlStartQuiz.Visible = false;
                        pnlEndQuiz.Visible = true;
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int wrong = 0;
            db = new DataClassesTestQuestionnaireDataContext();
            var query1 = db.sp_countQuez(frm_StudentMain.SGrade.ToString(), frm_StudentMain.SSection.ToString());
            foreach (sp_countQuezResult entryC in query1)
            {
                if (entryC.countQ.Value == Check)
                {
                    db.sp_updateScore(frm_Login.StudentID.ToString(), Check.ToString(), wrong.ToString());
                }
                else
                {
                    wrong = entryC.countQ.Value - Check;
                    db.sp_updateScore(frm_Login.StudentID.ToString(), Check.ToString(), wrong.ToString());
                }

                this.Hide();
                frm_StudentMain SM = new frm_StudentMain();
                SM.Show();
            }
        }
    }
}
