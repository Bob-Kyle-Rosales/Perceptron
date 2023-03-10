using System.Data.Common;
using System.Security.Cryptography.Xml;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        int w1;
        int w2;
        int bias;
        int learnRate=1;
        public Form1()
        {
            InitializeComponent();
            label5.Text += learnRate;
        }

        /// <summary>
        /// initialize the weights and bias
        /// </summary>
        public void intialize()
        {
            w1 = 0;
            w2 = 0;
            bias = 0;
            learnRate= 1;
        }

        /// <summary>
        /// implement hard limiting function where if
        /// x is greater than 0, then it is 1
        /// </summary>
        /// <param name="x">y'</param>
        /// <returns></returns>
        public int hardLimitingFunc(int x)
        {
            return x > 0 ? 1 : -1;
        }

        /// <summary>
        /// updates all the weights and bias
        /// </summary>
        /// <param name="desired"> the desired output </param>
        /// <param name="x1">input 1</param>
        /// <param name="x2">input 2</param>
        public void updateWeightsBias(int desired, int x1, int x2)
        {
            w1 = w1 + learnRate * desired * x1;
            w2 = w2 + learnRate * desired * x2;
            bias = bias + learnRate * desired;
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            int inp1 = Convert.ToInt32(textBox1.Text);
            int inp2 = Convert.ToInt32(textBox2.Text);
            int res = hardLimitingFunc((inp1 * w1) + (inp2 * w2) + bias);

            textBox3.Text = "" + res;
        }

        private void buttonAND_Click(object sender, EventArgs e)
        {
            intialize();
            int[,] data = { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };
            int[] desiredOutput = { 1, -1, -1, -1 };
            int i = 0;
            int reLearn = 0;
            int res = 0;
            
            //unstable variable checks if there is no mistakes from the expected output and y'
            int unstable = 0;

            while(reLearn < 50)
            {
                res = (data[i,0] * w1) + (data[i,1] * w2) + bias;
                res = hardLimitingFunc(res);
                if(res != desiredOutput[i])
                {
                    updateWeightsBias(desiredOutput[i], data[i, 0], data[i, 1]);
                    unstable++;
                }
                
                if(i != 3)
                {
                    i++;
                }
                else if ( i == 3 && unstable == 0) //if there is no mistakes, then it will stop
                {
                    break;
                }
                else
                {
                    i = 0;
                    unstable = 0;
                }
                reLearn++;
            }
            
            button1.BackColor= Color.LightBlue;
            button2.BackColor= Color.White;
            button3.BackColor= Color.White;
            button4.BackColor= Color.White;
        }

        private void buttonNAND_Click(object sender, EventArgs e)
        {
            intialize();
            int[,] data = { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };
            int[] desiredOutput = { -1, 1, 1, 1 };
            int i = 0;
            int reLearn = 0;
            int res = 0;

            //unstable variable checks if there is no mistakes from the expected output and y'
            int unstable = 0;

            while (reLearn < 50)
            {
                res = (data[i, 0] * w1) + (data[i, 1] * w2) + bias;
                res = hardLimitingFunc(res);
                if (res != desiredOutput[i])
                {
                    updateWeightsBias(desiredOutput[i], data[i, 0], data[i, 1]);
                    unstable++;
                }

                if (i != 3)
                {
                    i++;
                }
                else if (i == 3 && unstable == 0) //if there is no mistakes, then it will stop
                {
                    break;
                }
                else
                {
                    i = 0;
                    unstable = 0;
                }
                reLearn++;
            }

            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.LightBlue;
            button4.BackColor = Color.White;
        }

        private void buttonOR_Click(object sender, EventArgs e)
        {
            intialize();
            int[,] data = { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };
            int[] desiredOutput = { 1, 1, 1, -1 };
            int i = 0;
            int reLearn = 0;
            int res = 0;

            //unstable variable checks if there is no mistakes from the expected output and y'
            int unstable = 0;

            while (reLearn < 50)
            {
                res = (data[i, 0] * w1) + (data[i, 1] * w2) + bias;
                res = hardLimitingFunc(res);
                if (res != desiredOutput[i])
                {
                    updateWeightsBias(desiredOutput[i], data[i, 0], data[i, 1]);
                    unstable++;
                }

                if (i != 3)
                {
                    i++;
                }
                else if (i == 3 && unstable == 0) //if there is no mistakes, then it will stop
                {
                    break;
                }
                else
                {
                    i = 0;
                    unstable = 0;
                }
                reLearn++;
            }
            button1.BackColor = Color.White;
            button2.BackColor = Color.LightBlue;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
        }

        private void buttonNOR_Click(object sender, EventArgs e)
        {
            intialize();
            int[,] data = { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };
            int[] desiredOutput = { -1, -1, -1, 1 };
            int i = 0;
            int reLearn = 0;
            int res = 0;

            //unstable variable checks if there is no mistakes from the expected output and y'
            int unstable = 0;

            while (reLearn < 50)
            {
                res = (data[i, 0] * w1) + (data[i, 1] * w2) + bias;
                res = hardLimitingFunc(res);
                if (res != desiredOutput[i])
                {
                    updateWeightsBias(desiredOutput[i], data[i, 0], data[i, 1]);
                    unstable++;
                }

                if (i != 3)
                {
                    i++;
                }
                else if (i == 3 && unstable == 0) //if there is no mistakes, then it will stop
                {
                    break;
                }
                else
                {
                    i = 0;
                    unstable = 0;
                }
                reLearn++;
            }
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.LightBlue;
        }    
    }
}