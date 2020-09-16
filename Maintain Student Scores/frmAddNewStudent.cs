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
    public partial class frmAddNewStudent : Form
    {
        //declare a dictionary that contain strings and lists that will store scores of the students.
        Dictionary<string, List<int>> newStudent = new Dictionary<string, List<int>>();
        List<int> scores = new List<int>();

        public frmAddNewStudent()
        {
            InitializeComponent();
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            try
            {
                //if-else statement that checks for whether the score range is between 0 and 100.
                if (Convert.ToInt32(txtScore.Text) >= 0 && Convert.ToInt32(txtScore.Text) <= 100)
                {
                    //if the score is between 0 and 100 then it is added to scores list box
                    scores.Add(Convert.ToInt32(txtScore.Text));
                }
                //if not, shows an error message.
                else
                {
                    MessageBox.Show("Invalid input, please enter a score between 0 and 100", "Entry Error");
                }
            }
            //catch block throws formatexcpetion
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid score", "Entry Error");
            }
            txtScores.Text = String.Join(", ", scores);
            txtScore.Text = "";
            txtScore.Focus();
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            //clear the text boxes
            txtScore.Text = "";
            txtScores.Text = "";
            txtScore.Focus();
            scores.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if name text box is not empty, then add student's anme and scores to the student list box
            if (txtName.Text != "")
            {
                frmStudentScores.students.Add(txtName.Text, scores);
                this.Close();
            }
            //if not, then show error message
            else
            {
                MessageBox.Show("Please ener a student name.", "Entry Error");
                txtName.Focus();
            }
        }
    }
}

