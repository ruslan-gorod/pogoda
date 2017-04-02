using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PogodaForm.ServRef;


namespace PogodaForm
{
    public partial class Form1 : Form
    {
        string[] ar_str = null;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            label3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServClient client = new ServClient();

            
            string str = dateTimePicker1.Value.Year.ToString() + "-" +
                            dateTimePicker1.Value.Month.ToString() + "-" +
                            dateTimePicker1.Value.Day.ToString();
            try
            {
                string rez = client.GetData(str);

                ar_str = rez.Split(' ');
                label3.Text = ar_str[comboBox1.SelectedIndex] + " C";

                client.Close();

            }
            catch (Exception except)
            {
                MessageBox.Show("Не можливо показати погоду на дату\n" + dateTimePicker1.Value.Date.ToShortDateString());
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ar_str != null) 
            {
                label3.Text = ar_str[comboBox1.SelectedIndex] + " C";
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > DateTime.Now) 
            {
                MessageBox.Show("Це ж архів :-)");
                dateTimePicker1.Value = DateTime.Now;
            }
        }
    }
}
