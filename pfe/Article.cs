using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace pfe
{
    public partial class Article : Form
    {
        connection ado = new connection();
        public Article()
        {
            InitializeComponent();
        }

        FilterInfoCollection FilterInfoCollection;
        VideoCaptureDevice captureDevice;
        private void button2_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(FilterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();

        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }
            else
            {
                return;
            }
        }

        private void Article_Load(object sender, EventArgs e)
        {
            ado.Connect();
            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in FilterInfoCollection)
            {
                comboBox1.Items.Add(filterInfo.Name);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);

                if (result != null)
                {

                    label2.Text = result.ToString();
                    ado.cmd.CommandText = "select * from article where ref_art =" + int.Parse(label2.Text);
                    ado.cmd.Connection = ado.cn;
                    ado.dr = ado.cmd.ExecuteReader();
                    while (ado.dr.Read())
                    {
                        ref_art.Text = (ado.dr.GetValue(0)).ToString();
                        rayon.Text = (ado.dr.GetValue(1)).ToString();
                        design_art.Text = (ado.dr.GetValue(2)).ToString();
                        qte_stock.Text = (ado.dr.GetValue(3)).ToString();
                        prix_ht_stock.Text = (ado.dr.GetValue(4)).ToString();
                    }// takes the qr results and matches them with database, then prints results in labels
                    ado.dr.Close();//closes the reader
                    timer1.Stop();

                    if (captureDevice.IsRunning)
                    {
                        captureDevice.Stop();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                MessageBox.Show("search box is empty");
                return;
            }
            ado.cmd.CommandText = "select * from article where ref_art =" + int.Parse(searchBox.Text);
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                ref_art.Text = (ado.dr.GetValue(0)).ToString();
                rayon.Text = (ado.dr.GetValue(1)).ToString();
                design_art.Text = (ado.dr.GetValue(2)).ToString();
                qte_stock.Text = (ado.dr.GetValue(3)).ToString();
                prix_ht_stock.Text = (ado.dr.GetValue(4)).ToString();
            } //take whats in searchbox and match with database, then print the result in labels
            ado.dr.Close();//closes the reader
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            dataGridArt.Rows.Clear();
            ado.cmd.CommandText = "select * from article";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                dataGridArt.Rows.Add(ado.dr.GetValue(0).ToString(), ado.dr.GetValue(2).ToString(), ado.dr.GetValue(3).ToString(),
                    ado.dr.GetValue(4).ToString(), ado.dr.GetValue(5).ToString());
            }//gets input from the searchbox and matches it to the database then prints the matched data in the datagrid
            ado.dr.Close();//closes the reader
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridArt.Rows.Clear();
            ado.cmd.CommandText = "select * from article where ref_Art = " + int.Parse(searchBoxArt.Text);
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                dataGridArt.Rows.Add(ado.dr.GetValue(0).ToString(), ado.dr.GetValue(2).ToString(), ado.dr.GetValue(3).ToString(),
                    ado.dr.GetValue(4).ToString(), ado.dr.GetValue(5).ToString());
            }//gets input from the searchbox and matches it to the database then prints the matched data in the datagrid
            ado.dr.Close();//closes the reader
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridArt.Rows.Clear();
            ado.cmd.CommandText = "select * from article";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                dataGridArt.Rows.Add(ado.dr.GetValue(0).ToString(), ado.dr.GetValue(2).ToString(), ado.dr.GetValue(3).ToString(),
                    ado.dr.GetValue(4).ToString(), ado.dr.GetValue(5).ToString());
            }//gets input from the searchbox and matches it to the database then prints the matched data in the datagrid
            ado.dr.Close();//closes the reader
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("remplir tout les champs svp");
                return;
            }//making sure no input box is empty, gotta be full :)
            ado.cmd.CommandText = "insert into article(ref_art, design_art,qte_stock,prix_ht_stock,taux_TVA) " +
                "values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" +
                textBox4.Text + "','" + textBox5.Text + "')";
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery(); //adding new data to database

            MessageBox.Show("done");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
           //clearing textboxes for new entry
        } 

        private void button5_Click(object sender, EventArgs e)
        {
           textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
             //clearing textboxes for new entry
            tabControl1.SelectedTab = tabPage3;
            button9.Enabled = true;
            button8.Enabled = false;
            button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("remplir tout les champs svp");
                return;
            }//making sure no input box is empty, gotta be full :)
            ado.cmd.CommandText = "update article set ref_art =" + textBox1.Text + " , design_art ='" + textBox2.Text + "' ,qte_stock" +
                " = '" + textBox3.Text + "',prix_ht_stock= '" + textBox4.Text +
                "' ,taux_TVA= '" + textBox5.Text + "' where ref_art =  " + currentArt;

            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery();
            MessageBox.Show("modification applique");
        }

        private int currentArt = 0;
        private void dataGridArt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ado.cmd.CommandText = "select * from article where ref_Art =" + dataGridArt.Rows[e.RowIndex].Cells[0].Value;
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                currentArt = int.Parse(ado.dr["ref_art"].ToString());
                textBox1.Text = ado.dr["ref_art"].ToString();
                textBox2.Text = ado.dr["design_art"].ToString();
                textBox3.Text =  ado.dr["qte_stock"].ToString();
                textBox4.Text = ado.dr["prix_ht_stock"].ToString();
                textBox5.Text = ado.dr["taux_TVA"].ToString();
                
              
            }
            ado.dr.Close();
            tabControl1.SelectedTab = tabPage3;
            button9.Enabled = true;
            button8.Enabled = false;
            button7.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ado.cmd.CommandText = "delete from article where ref_art =" + currentArt;
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery();
            MessageBox.Show("suppression faite");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            dataGridArt.Rows.Clear();
            ado.cmd.CommandText = "select * from article";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                dataGridArt.Rows.Add(ado.dr.GetValue(0).ToString(), ado.dr.GetValue(2).ToString(), ado.dr.GetValue(3).ToString(),
                     ado.dr.GetValue(4).ToString(), ado.dr.GetValue(5).ToString());
            }//gets input from the searchbox and matches it to the database then prints the matched data in the datagrid
            ado.dr.Close();//closes the reader
        }
    }
}
