using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace pfe
{
    public partial class Article : Form
    {
        private connection ado = new connection();

        public Article()
        {
            InitializeComponent();
        }

        private FilterInfoCollection FilterInfoCollection;
        private VideoCaptureDevice captureDevice;

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

        private void button5_Click(object sender, EventArgs e)
        {
            //clearing textboxes for new entry
            tabControl1.SelectedTab = tabPage3;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            ado.cmd.CommandText = "select idf_fac_frs from facture_frs where idf_frs = " + comboBox2.Text;
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                comboBox3.Items.Add(ado.dr["idf_fac_frs"]);
            }
            ado.dr.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "" ||
                   textBox6.Text == "" || textBox7.Text == "" ||
                   textBox8.Text == "" || textBox9.Text == "" || textBox11.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("empty textboxes");
                return;
            }
            ado.cmd.CommandText = "insert into facture_frs(idf_frs,idf_fac_frs, date_fac_frs) values (" + int.Parse(comboBox2.Text) + "," + int.Parse(textBox1.Text) + ",'" +dateTimePicker1.Text + "')";
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery();

            ado.cmd.CommandText = "insert into article(ref_art,idf_rayon,design_art,qte_stock,prix_ht_stock,taux_TVA) values (" + int.Parse(textBox4.Text) + "," + int.Parse(textBox8.Text) + ",'" + textBox9.Text + "'," + int.Parse(textBox6.Text)
                                  + "," + float.Parse(textBox7.Text)
                                  + "," + float.Parse(textBox11.Text) + ")";
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery();

            ado.cmd.CommandText = "insert into ligne_fac_frs(ref_art,idf_fac_frs, qte_achete,prix_achat) values (" + int.Parse(textBox4.Text) + "," + int.Parse(comboBox3.Text) +
                                  "," + int.Parse(textBox6.Text) + "," + float.Parse(textBox5.Text) + ")";
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "" ||
               textBox6.Text == "" || textBox7.Text == "" ||
               textBox8.Text == "" || textBox9.Text == "" || textBox11.Text == "")
            {
                MessageBox.Show("empty textboxes");
                return;
            }
            ado.cmd.CommandText = "insert into article(ref_art,idf_rayon,design_art,qte_stock,prix_ht_stock,taux_TVA) values (" + int.Parse(textBox4.Text) + "," + int.Parse(textBox8.Text) + ",'"
                                  + textBox9.Text + "'," + int.Parse(textBox6.Text)
                                  + "," + float.Parse(textBox7.Text)
                                  + "," + float.Parse(textBox11.Text) + ")";
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery();

            ado.cmd.CommandText = "insert into ligne_fac_frs(ref_art,idf_fac_frs, qte_achete,prix_achat) values (" + int.Parse(textBox4.Text) + "," + int.Parse(comboBox3.Text) +
                                  "," + int.Parse(textBox6.Text) + "," + float.Parse(textBox5.Text) + ")";
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}