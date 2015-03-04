﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;

namespace Saveyour
{
    public partial class Form1 : Form
    {
        static Boolean userClick = true;
        static Boolean passClick = true;
        
        public static String username;

        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(login_Click);
            textBox1.Click += new EventHandler(user_Click);
            textBox1.KeyDown += new KeyEventHandler(user_Enter);
            textBox2.Click += new EventHandler(pass_Click);
            textBox2.KeyDown += new KeyEventHandler(pass_Enter);
            
        }

        /* Adding Listener for Log In Button */
        private void login_Click(object sender, System.EventArgs e)
        {
            username = textBox1.Text;
            String password = textBox2.Text;

            //Create a network connection and connect
            NetworkControl network = new NetworkControl();
            String response = network.Connect(network.getIP(), username + "," + password);
            Debug.WriteLine(response);


            if (response.Contains("Logged in as"))
            { 
                this.Hide();

                Form2 newForm = new Form2(this);
                newForm.ShowDialog();
            }
        }

        /* Adding Listener for Username Click */

        private void user_Click(object sender, System.EventArgs e)
        {   
            if (userClick)
            {
                textBox1.Text = String.Empty;
                userClick = false;
            }
        }
        
        /* Pressing enter or on username form will jump to password form */
        private void user_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                //Debug.WriteLine("Enter pressed");
            }
        }

        /* Adding Listener for Password Click */

        private void pass_Click(object sender, System.EventArgs e)
        {
            if (passClick)
            {
                textBox2.Text = String.Empty;
                passClick = false;
            }
        }

        private void pass_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                e.Handled = true;
                login_Click(sender, null); //Tries to log in using null for System.EventArgs. Hopefully this won't break anything
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
