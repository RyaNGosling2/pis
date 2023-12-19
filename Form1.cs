using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace pmm3
{
    public partial class Form1 : Form
    {
        
        
        double xd(double c,double t,double h)
        {
            return (c * c * t * t) / (h * h);
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double[,] arry = new double[101, 2001];
            double x, h = 0.01;
            double tau = 0.002;
            double t = 0, c = 1;
            
            for (int i = 0; i < 101; i++)
            {
                arry[i, 0] = 0;
                arry[i, 1] = 0;
            }
            for (int i = 2; i < 2001; i++)
            {
                arry[0, i] = 0;
                arry[100, i] = t * Math.Exp(-t);
                t += tau;
            }


            for (int j = 3; j < 2001; j++)
            {
                for (int i = 1; i < 100; i++)
                {
                    //arry[i,j]=2*(1-xd(c,tau,h))*arry[i,j-1] - arry[i,j-2] + xd(c, tau, h)* (arry[i + 1, j - 1] + arry[i - 1, j - 1]);
                    arry[i, j] = (arry[i + 1, j - 1] - 2 * arry[i, j - 1] + arry[i - 1, j - 1])*xd(c,tau,h) + 2 * arry[i, j - 1] - arry[i, j - 2];
                }
                //arry[100, j] = (2*arry[99, j - 1] - 2 * arry[100, j - 1]) * xd(c, tau, h) + 2 * arry[100, j - 1] - arry[100, j - 2];
            }
            x = 0.00;
            int jg = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < 101; i++)
            {
                chart1.Series["Series0"].Points.AddXY(x, arry[i, jg]);
                x += h;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series["Series0"].Points.Clear();
        }
    }
}
