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
    public partial class frm_Print : Form
    {
        public frm_Print()
        {
            InitializeComponent();
        }

        private void frm_Print_Load(object sender, EventArgs e)
        {
            var da = new TestQuestionnaireSystem.DataSetScoreTableAdapters.tblScoreTableAdapter();
            var dt = new TestQuestionnaireSystem.DataSetScore.tblScoreDataTable();
            da.FillViewScore(dt, frm_TeacherMain.Section.ToString(), frm_Login.UserID.ToString(), frm_TeacherMain.Grade.ToString());

            var ds = new DataSet();
            ds.Tables.Add(dt);

            var crpt = new CrystalReport();
            crpt.SetDataSource(ds);

            crystalReportViewer1.ReportSource = crpt;
            crystalReportViewer1.RefreshReport();
        }


        private void label1_Click(object sender, EventArgs e)
        {
           
            DialogResult Result = MessageBox.Show("You want to go back to main menu?", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (Result == DialogResult.Yes)
            {
                this.Hide();
                frm_TeacherMain TM = new frm_TeacherMain();
                TM.Show();
            }
        }
    }
}
