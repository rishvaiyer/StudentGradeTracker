using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maintain_Student_Scores
{
    public partial class frmUpdateStudentScores : Form
    {
        public static Dictionary<string, List<int>> studentScore;
        
        BindingSource bs = new BindingSource();
        public static int selected;

        public frmUpdateStudentScores()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            Form addScore = new frmAddScore();
            addScore.ShowDialog();
            bs.ResetBindings(false);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            selected = lbxScores.SelectedIndex;
            Form updateScore = new frmUpdateScore();
            updateScore.ShowDialog();
            
            bs.ResetBindings(false);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
         
            studentScore.Values.ElementAt(frmStudentScores.selected).RemoveAt(lbxScores.SelectedIndex);
            bs.ResetBindings(false);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            studentScore.Values.ElementAt(frmStudentScores.selected).RemoveRange(0, studentScore.Values.ElementAt(frmStudentScores.selected).Count);
            bs.ResetBindings(false);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
            frmStudentScores.students = studentScore;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateStudentScores_Load(object sender, EventArgs e)
        {
          
            studentScore = frmStudentScores.students.ToDictionary(p => p.Key, p => p.Value.ToList());
            txtName.Text= studentScore.Keys.ElementAt(frmStudentScores.selected);
            bs.DataSource = studentScore.Values.ElementAt(frmStudentScores.selected);
            lbxScores.DataSource = bs;
        }
    }
}
