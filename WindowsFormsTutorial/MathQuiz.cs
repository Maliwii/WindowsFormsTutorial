using System;
using System.Drawing;
using System.Windows.Forms;

namespace PatternDoodle
{
    public partial class MathQuiz : Form
    {
        int timeLeft;

        Random randomizer = new Random();

        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;

        public MathQuiz()
        {
            InitializeComponent();
        }

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;
            sum.BackColor = Color.White;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;
            difference.BackColor = Color.White;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;
            product.BackColor = Color.White;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;
            quotient.BackColor = Color.White;

            timeLeft = 60;
            timeLabel.Text = $"{timeLeft} seconds";
            timeLabel.BackColor = Color.White;
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                if(timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
                timeLeft--;
                timeLabel.Text = $"{timeLeft} seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private bool CheckTheAnswer()
        {
            int numCorrect = 0;

            if (addend1 + addend2 == sum.Value)
            {
                numCorrect++;
                sum.BackColor = Color.Green;
            }
            if (minuend - subtrahend == difference.Value) 
            {
                numCorrect++;
                difference.BackColor = Color.Green;
            }
            if (multiplicand * multiplier == product.Value) 
            {
                numCorrect++;
                product.BackColor = Color.Green;
            }
            if (dividend / divisor == quotient.Value)
            {
                numCorrect++;
                quotient.BackColor = Color.Green;
            }
            if (numCorrect == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
