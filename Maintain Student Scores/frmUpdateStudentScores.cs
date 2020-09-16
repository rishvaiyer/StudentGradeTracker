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
        //create a temporarily doctionary that contain strings and lists that stores scores with integer value
        public static Dictionary<string, List<int>> studentScore;
        //default property value
        BindingSource bs = new BindingSource();
        public static int selected;

        public frmUpdateStudentScores()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //declare add score form
            Form addScore = new frmAddScore();
            //display add score form
            addScore.ShowDialog();
            //false shows that only the value of one or more scores have chenaged. 
            bs.ResetBindings(false);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //update a score from the score list box by selecting the index
            selected = lbxScores.SelectedIndex;
            //create update score form
            Form updateScore = new frmUpdateScore();
            //display upadate score form
            updateScore.ShowDialog();
            //false shows that only the value of one or more scores have chenaged. 
            bs.ResetBindings(false);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //delete the student's score and store the new value to list box
            studentScore.Values.ElementAt(frmStudentScores.selected).RemoveAt(lbxScores.SelectedIndex);
            bs.ResetBindings(false);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //delete all the values 
            studentScore.Values.ElementAt(frmStudentScores.selected).RemoveRange(0, studentScore.Values.ElementAt(frmStudentScores.selected).Count);
            bs.ResetBindings(false);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //passes the value of studentsocre list to student list box
            frmStudentScores.students = studentScore;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateStudentScores_Load(object sender, EventArgs e)
        {
            //pass the values from student list box to student score list box
            studentScore = frmStudentScores.students.ToDictionary(p => p.Key, p => p.Value.ToList());
            txtName.Text= studentScore.Keys.ElementAt(frmStudentScores.selected);
            bs.DataSource = studentScore.Values.ElementAt(frmStudentScores.selected);
            lbxScores.DataSource = bs;
        }
    }
}
