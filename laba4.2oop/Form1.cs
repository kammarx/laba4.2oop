using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4._2oop
{
    public partial class Form1 : Form
    {
        Model model;
       
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.observers += new System.EventHandler(this.UpdateFromModel);
        }

       private void Form1_Load(object sender, EventArgs e)
        {
        textBox1.Text = Properties.Settings.Default.A.ToString();
            numericUpDown1.Value = Properties.Settings.Default.A;
            trackBar1.Value = Properties.Settings.Default.A;

            textBox2.Text = Properties.Settings.Default.B.ToString();
            numericUpDown2.Value = Properties.Settings.Default.B;
            trackBar2.Value = Properties.Settings.Default.B;

            textBox3.Text = Properties.Settings.Default.C.ToString();
            numericUpDown3.Value = Properties.Settings.Default.C;
            trackBar3.Value = Properties.Settings.Default.C;

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.A = model.GetValue(0);
            Properties.Settings.Default.B = model.GetValue(1);
            Properties.Settings.Default.C = model.GetValue(2);
            Properties.Settings.Default.Save();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.SetValue(Decimal.ToInt32(numericUpDown1.Value),0);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.SetValue(Decimal.ToInt32(numericUpDown2.Value), 1);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            model.SetValue(Decimal.ToInt32(numericUpDown3.Value), 2);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                model.SetValue(Int32.Parse(textBox1.Text), 0);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                model.SetValue(Int32.Parse(textBox2.Text), 1);
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                model.SetValue(Int32.Parse(textBox3.Text), 2);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            model.SetValue(Int32.Parse(trackBar1.Value.ToString()),0);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            model.SetValue(Int32.Parse(trackBar2.Value.ToString()), 1);
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            model.SetValue(Int32.Parse(trackBar3.Value.ToString()), 2);
        }
        private void UpdateFromModel(object sender,EventArgs e)
        {
            textBox1.Text = model.GetValue(0).ToString();
            textBox2.Text = model.GetValue(1).ToString();
            textBox3.Text = model.GetValue(2).ToString();
            trackBar1.Value = model.GetValue(0);
            trackBar2.Value = model.GetValue(1);
            trackBar3.Value = model.GetValue(2);
            numericUpDown1.Value = Decimal.Parse(model.GetValue(0).ToString());
            numericUpDown2.Value = Decimal.Parse(model.GetValue(1).ToString());
            numericUpDown3.Value = Decimal.Parse(model.GetValue(2).ToString());
        }




       public class Model
        {
            public int A, B, C;
            public int[] value = { 0, 0, 0 };
        
           
            public System.EventHandler observers;
          
            public void SetValue(int value, int index)
            {
                if (index == 0)
                {
                    if (value < 0)
                    {
                        this.value[0] = 0;
                    }
                    else if (value > 100)
                    {
                        this.value[0] = 100;
                        this.value[1] = 100;
                        this.value[2] = 100;
                    }

                    else if (value <= this.value[2])
                    {
                        this.value[0] = value;
                        if (value > this.value[1])
                        {
                            this.value[1] = value;
                        }
                    }

                    else if (value==this.value[2])
                    {
                        this.value[0] = value;
                        this.value[1] = value;
                    }
                    else if (value>this.value[2])
                    {
                        this.value[0] = value;
                        this.value[1] = value;
                        this.value[2] = value;


                    }

                }
                else if (index == 1)
                {
                   if(value<=this.value[2] && value>=this.value[0])
                    {
                        this.value[1] = value;
                    }
                }
                else
                {
                    if (value < 0)
                    {
                        this.value[0] = 0;
                        this.value[1] = 0;
                        this.value[2] = 0;
                    }
                    else if (value > 100) 
                    {
                        this.value[2] = value;
                    }

                    else if (value<=this.value[0])
                    {
                        this.value[0] = value;
                        this.value[1] = value;
                        this.value[2] = value;

                    }
                    else if (value >= this.value[0])
                    {
                        this.value[2] = value;
                        if (value <= this.value[1])
                        {
                            this.value[1] = value;
                        }
                    }
                }
                A = this.value[0];
                B = this.value[1];
                C = this.value[2];
                observers.Invoke(this, null);
            }
            public int GetValue(int index)
            {
                return value[index];
            }
        }

    }
}
