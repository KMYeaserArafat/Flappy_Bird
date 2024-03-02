using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Game_Project
{
    public partial class FormGame : Form
    {
        public FormGame()
        {
            InitializeComponent();
        }

        int pipespeed = 8;
        int gravity = 5;
        int score = 0;
        // CM : 
        private void endGame()
        {
            gameTimer.Stop();
            lblScore.Text = $"Game is over !!! Your Current Score : {score}";
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeTop.Left -= pipespeed;
            pipeBottom.Left -= pipespeed;
            lblScore.Text = "Score : " + score;

            if (pipeBottom.Left < -100)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds)||
                flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }

            if(score > 5)
            {
                pipespeed = 15;
            }
        }

        private void gamekeyisDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity -= 15;
            }
        }

        private void gameKeyisUp(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.Space)
            {
                gravity += 15;
            }
        }
    }
}
