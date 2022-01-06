using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace en_dictionary_pro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //-------------------
                this.progress_panel1.Visible = true;
                this.progress_panel1.Refresh();
                //-------------------
                this.en_word_listTableAdapter.Fill(this.en_dic_ds.en_word_list);
                //-------------------
                this.progress_panel1.Visible = false;
                //-------------------
            }
            catch (Exception ex)
            {
                //--------------------
                this.progress_panel1.Visible = false;
                //--------------------
                MessageBox.Show("Error: " + ex.Message);
            }

            this.search_typecomboBox1.SelectedIndex = 0;

        }

        private void search_Button1_Click(object sender, EventArgs e)
        {
            //-------------------
            string w;
            w = this.Search_TextBox1.Text;
            w = w.TrimEnd();
            //--------------------
            if (w=="") 
            {
                MessageBox.Show("Please enter your word to search!");
                return;
            }
            //-------------------
            this.progress_panel1.Visible = true;
            this.progress_panel1.Refresh();
            //-------------------
            try
            {
                // 
                //---------------------------------------------------
                if (this.search_typecomboBox1.SelectedIndex==1)//// Equals
                {
                    this.en_word_listTableAdapter.FillBy_word(this.en_dic_ds.en_word_list, this.Search_TextBox1.Text);
                }
                //---------------------------------------------------
                if (this.search_typecomboBox1.SelectedIndex == 2)//Starts With
                {
                    this.en_word_listTableAdapter.FillBy_like_word(this.en_dic_ds.en_word_list,
                                                                   this.Search_TextBox1.Text + "%");
                }
                //---------------------------------------------------
                if (this.search_typecomboBox1.SelectedIndex == 3)//Ends With
                {
                    this.en_word_listTableAdapter.FillBy_like_word(this.en_dic_ds.en_word_list,
                                                                   "%" + this.Search_TextBox1.Text  );
                }
                //---------------------------------------------------
                if (this.search_typecomboBox1.SelectedIndex == 4)//Every Where
                {
                    this.en_word_listTableAdapter.FillBy_like_word(this.en_dic_ds.en_word_list,
                                                                  "%" + this.Search_TextBox1.Text + "%");
                }
                //---------------------------------------------------
            }
            catch (Exception ex)
            {
                //--------------------
                this.progress_panel1.Visible = false;
                //--------------------
                MessageBox.Show("Error: " + ex.Message);
            }
            //--------------------
            this.progress_panel1.Visible = false;
            //--------------------
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
            try
            {
                //-------------------
                this.progress_panel1.Visible = true;
                this.progress_panel1.Refresh();
                //-------------------
                this.en_word_listTableAdapter.Fill(this.en_dic_ds.en_word_list);
                //-------------------
                this.progress_panel1.Visible = false;
                //-------------------
                this.search_typecomboBox1.SelectedIndex = 0;
                this.Search_TextBox1.Clear();
            }
            catch (Exception ex)
            {
                //--------------------
                this.progress_panel1.Visible = false;
                //--------------------
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void search_typecomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.search_typecomboBox1.SelectedIndex == 0)
            {
                this.search_Button1.Enabled = false;
            }
            else
            {
                this.search_Button1.Enabled = true;
            }
        }
    }
}
