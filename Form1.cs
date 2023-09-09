using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;

namespace Pizza_Ordering_System
{
    public partial class pizza : Form
    {
        string listboxItems = "{0, -5}";
        Thread OrderList;

        public pizza()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Order adding in listbox
            string ordererName, ordererPhoneNum, ordererAdress, pizzaType, pizzaSize, pizzaCornerType, drink, extra;

            try
            {
                ordererName = textBox1.Text; ordererPhoneNum = textBox2.Text; ordererAdress = textBox3.Text;

                pizzaType = comboBox2.Text; pizzaSize = comboBox1.Text;pizzaCornerType = comboBox3.Text ; drink = comboBox4.Text; extra = comboBox5.Text;

                //listbox
                listBox1.Items.Add(string.Format(listboxItems, ordererName));
                listBox2.Items.Add(string.Format(listboxItems, ordererPhoneNum));
                listBox3.Items.Add(string.Format(listboxItems, ordererAdress));
                listBox4.Items.Add(string.Format(listboxItems, pizzaType));
                listBox5.Items.Add(string.Format(listboxItems, pizzaSize));
                listBox6.Items.Add(string.Format(listboxItems, pizzaCornerType));
                listBox7.Items.Add(string.Format(listboxItems, drink));
                listBox8.Items.Add(string.Format(listboxItems, extra));

            }
            catch(FormatException exceptionError)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

                MessageBox.Show(exceptionError.Message);
                
                listBox4.Items.RemoveAt(listBox4.Items.Count - 1);
                listBox5.Items.RemoveAt(listBox5.Items.Count - 1);
                listBox6.Items.RemoveAt(listBox6.Items.Count - 1);
                listBox7.Items.RemoveAt(listBox7.Items.Count - 1);
                listBox8.Items.RemoveAt(listBox8.Items.Count - 1);
            }
            finally
            {
                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";

                comboBox1.Text = "Default"; comboBox2.Text = "Please Select"; comboBox3.Text = "Default"; comboBox4.Text = "None"; comboBox5.Text = "None";

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pizza_Load(object sender, EventArgs e)
        {

            //comboBox item Adds
            
            //Sizes
            comboBox1.Items.Add("Default");
            comboBox1.Items.Add("One Slice");
            comboBox1.Items.Add("Small");
            comboBox1.Items.Add("Large");
            comboBox1.Items.Add("Extra Large");
            
            comboBox1.Text = "Default";

            //Pizza Types
            comboBox2.Items.Add("Please Select");
            comboBox2.Items.Add("Primavera");
            comboBox2.Items.Add("Al Taglio");
            comboBox2.Items.Add("Ai Funghi");
            comboBox2.Items.Add("Quattro Formaggi");
            comboBox2.Items.Add("Capricciosa");
            comboBox2.Items.Add("Marinara");
            comboBox2.Items.Add("Caprese");
            comboBox2.Items.Add("Calzone");
            comboBox2.Items.Add("Napoletana");
            comboBox2.Items.Add("Margherita");

            comboBox2.Text = "Please Select";
            
            //Corner Types
            comboBox3.Items.Add("Default");
            comboBox3.Items.Add("Crispy");
            comboBox3.Items.Add("Soft");
            comboBox3.Items.Add("Hot Dog");
            comboBox3.Items.Add("Garlic");

            comboBox3.Text = "Default";


            //Drinks
            comboBox4.Items.Add("None");
            comboBox4.Items.Add("Coca Cola");
            comboBox4.Items.Add("Coca Cola Zero");
            comboBox4.Items.Add("Pepsi");
            comboBox4.Items.Add("Pepsi Max");
            comboBox4.Items.Add("Fanta(orange)");
            comboBox4.Items.Add("Fanta(tangerine)");
            comboBox4.Items.Add("Peach Juice");
            comboBox4.Items.Add("Apple Juice");

            comboBox4.Text = "None";


            //Extras
            comboBox5.Items.Add("None");
            comboBox5.Items.Add("Mushroom");
            comboBox5.Items.Add("Sausage");
            comboBox5.Items.Add("Salami");
            comboBox5.Items.Add("Pepper");
            comboBox5.Items.Add("Sweetcorn");
            comboBox5.Items.Add("8 Piece Nugget");
            comboBox5.Items.Add("16 Piece Nugget");
            comboBox5.Items.Add("Fried Potatoes(Small)");
            comboBox5.Items.Add("Fried Potatoes(Medium)");
            comboBox5.Items.Add("Fried Potatoes(Large)");

            comboBox5.Text = "None";

            //TextBoxs Text Add

            textBox1.Text = "Jenniffer";
            textBox2.Text = "+1 999 99 99";
            textBox3.Text = "first street/second neighbourhood/star apartment/ LA";

            //ListBox
            listBox1.Items.Add(string.Format(listboxItems, "Customer Name"));
            listBox2.Items.Add(string.Format(listboxItems, "Customer Phone Number"));
            listBox3.Items.Add(string.Format(listboxItems, "Customer Adress"));
            listBox4.Items.Add(string.Format(listboxItems, "Pizza Type"));
            listBox5.Items.Add(string.Format(listboxItems, "Pizza Size"));
            listBox6.Items.Add(string.Format(listboxItems, "Pizza Corner Type"));
            listBox7.Items.Add(string.Format(listboxItems, "Drink"));
            listBox8.Items.Add(string.Format(listboxItems, "Extra"));
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //listbox last item delete

            if(listBox1.Items.Count == 1)
            {
                MessageBox.Show("No new order found");
            }
            else
            {
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                listBox2.Items.RemoveAt(listBox2.Items.Count - 1);
                listBox3.Items.RemoveAt(listBox3.Items.Count - 1);
                listBox4.Items.RemoveAt(listBox4.Items.Count - 1);
                listBox5.Items.RemoveAt(listBox5.Items.Count - 1);
                listBox6.Items.RemoveAt(listBox6.Items.Count - 1);
                listBox7.Items.RemoveAt(listBox7.Items.Count - 1);
                listBox8.Items.RemoveAt(listBox8.Items.Count - 1);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("Exit","exit",MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

            if (exit == DialogResult.OK) 
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
