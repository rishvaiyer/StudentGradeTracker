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



                if (Convert.ToInt32(txtScore.Text) >= 0 && Convert.ToInt32(txtScore.Text) <= 100)
                {

                    scores.Add(Convert.ToInt32(txtScore.Text));
                }

                else
                {
                    MessageBox.Show("Error, enter a score between 0 and 100");
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid score");
            }
            txtScores.Text = String.Join(", ", scores);
            txtScore.Text = "";
            txtScore.Focus();
        }

   
        private void btnOK_Click(object sender, EventArgs e)
        {
           
            if (txtName.Text != "")
            {
                frmStudentScores.students.Add(txtName.Text, scores);
                this.Close();
            }
           
            else
            {
                MessageBox.Show("Please ener a student name.", "Entry Error");
                txtName.Focus();
            }
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {

            txtScore.Text = "";
            txtScores.Text = "";
            txtScore.Focus();
            scores.Clear();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

