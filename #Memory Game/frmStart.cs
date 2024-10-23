using _Memory_Game.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Memory_Game
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        int[] SimiliarNumbers = new int[9];
        int[] pictureBoxes = new int[18];

        PictureBox Pb1 = null, Pb2 = null;

        Random random = new Random();

        int count = 60, CorrectGuess = 0;

        void FillArrayWithZero()
        {
            for(byte i = 0; i<9; i++)
            {
                SimiliarNumbers[i] = 0;
            }
        }

        int GetRandomNumber(int From,  int To)
        {
            return random.Next(From, To);

        }
        
        bool CheckIFNumberTaken(int number)
        {
            if(SimiliarNumbers[number] == 2) 
                return true;
            else
            {
                SimiliarNumbers[number]++;
                return false;
                
            }
        }

        void ShufflingArray(int[] array)
        {
            int temp, randomNumber, n = array.Length;

            for(int i = 0; i < n; i++)
            {
                randomNumber = GetRandomNumber(0, n);
                temp = array[i];
                array[i] = array[randomNumber];
                array[randomNumber] = temp;
            }
        }

        void FillTagsWithRandomNumbers()
        {
            FillArrayWithZero();
            int radNumber;

            for (int i = 0; i<18;i++)
            {
                do
                {
                    radNumber = GetRandomNumber(0, 9);
                } while (CheckIFNumberTaken(radNumber));

                pictureBoxes[i] = radNumber;
            }
            ShufflingArray(pictureBoxes);
        }

        void DisablePictureBoxes()
        {
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    control.Enabled = false;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[pictureBoxes[0]];
            pictureBox1.Tag = pictureBoxes[0];
            GameProcess((PictureBox)sender);
        }

        void FillPictureBoxes(PictureBox pictureBox)
        {
            if(Pb1 == null)
            {
                Pb1 = pictureBox;
            }
            else if (Pb2 == null)
            {
                Pb2 = pictureBox;
            }
        }

        async void CheckCardsSimilarity()
        {
            if (Pb1 == null || Pb2 == null)
            {
                return;
            }

            if((int)Pb1.Tag != (int)Pb2.Tag)
            {
                await Task.Delay(300);
                Pb1.Image = Resources.green_box;
                Pb2.Image = Resources.green_box;
            }
            else
            {
                Pb1.Enabled = false;
                Pb2.Enabled = false;
                CorrectGuess += 2;
            }

            Pb1 = null;
            Pb2 = null;
        }

        void IsTheGameEnded()
        {
            if(CorrectGuess == 18)
            {
                timer1.Stop();

                MessageBox.Show("Congratilations", "You Win:(", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(count == 0)
            {
                DisablePictureBoxes();
                MessageBox.Show("Sorry", "You lose:(", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void GameProcess(PictureBox Pb)
        {
            FillPictureBoxes(Pb);
            CheckCardsSimilarity();
            IsTheGameEnded();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            FillTagsWithRandomNumbers();

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            pictureBox13.Image = imageList1.Images[pictureBoxes[12]];
            pictureBox13.Tag = pictureBoxes[12];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pictureBox14.Image = imageList1.Images[pictureBoxes[13]];
            pictureBox14.Tag = pictureBoxes[13];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            pictureBox15.Image = imageList1.Images[pictureBoxes[14]];
            pictureBox15.Tag = pictureBoxes[14];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            pictureBox16.Image = imageList1.Images[pictureBoxes[15]];
            pictureBox16.Tag = pictureBoxes[15];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            pictureBox17.Image = imageList1.Images[pictureBoxes[16]];
            pictureBox17.Tag = pictureBoxes[16];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            pictureBox18.Image = imageList1.Images[pictureBoxes[17]];
            pictureBox18.Tag = pictureBoxes[17];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = imageList1.Images[pictureBoxes[6]];
                pictureBox7.Tag = pictureBoxes[6];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.Image = imageList1.Images[pictureBoxes[7]];
            pictureBox8.Tag = pictureBoxes[7];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox9.Image = imageList1.Images[pictureBoxes[8]];
            pictureBox9.Tag = pictureBoxes[8];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox10.Image = imageList1.Images[pictureBoxes[9]];
            pictureBox10.Tag = pictureBoxes[9];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = imageList1.Images[pictureBoxes[10]];
            pictureBox11.Tag = pictureBoxes[10];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureBox12.Image = imageList1.Images[pictureBoxes[11]];
            pictureBox12.Tag = pictureBoxes[11];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.Image = imageList1.Images[pictureBoxes[5]];
            pictureBox6.Tag = pictureBoxes[5];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = imageList1.Images[pictureBoxes[4]];
            pictureBox5.Tag = pictureBoxes[4];
            GameProcess((PictureBox)sender);
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = imageList1.Images[pictureBoxes[3]]; 
            pictureBox4.Tag = pictureBoxes[3];
            GameProcess((PictureBox)sender);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = imageList1.Images[pictureBoxes[2]];
            pictureBox3.Tag = pictureBoxes[2];
            GameProcess((PictureBox)sender);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count--;
            lbTimer.Text = count.ToString();

            if (count == 0)
            {
                timer1.Stop();
                CheckCardsSimilarity();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Restart the game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Form frm = new frmStart();
                frm.ShowDialog();
                this.Close();
            }
        }


        private void restartToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btnRestart_Click(sender, e);
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            
            if(MessageBox.Show( "Are you sure?", "Change timer to 30!! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
                count = 30;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Change timer to 100!! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                count = 100;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Change timer to 60!! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                count = 60;
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = imageList1.Images[pictureBoxes[1]];
            pictureBox2.Tag = pictureBoxes[1];
            GameProcess((PictureBox)sender);
        }
    }
}
