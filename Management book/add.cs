using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;



namespace Management_book
{
    public partial class add : Form
    {
        sql d = new sql();
        List<string> list = new List<string>();
        MemoryStream ma = new MemoryStream();
        public int state;
        public add()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form cat = new cat();
            bunifuTransition1.ShowSync(cat);
        }

        private void add_Load(object sender, EventArgs e)
        {
            try {
                d.con.ConnectionString = @"Data Source=DESKTOP-1JHKSTN\SQLEXPRESS;Initial Catalog=BOOK;Integrated Security=True";
                d.connecter();
                d.cmd.Connection = d.con;
                d.cmd.CommandText = "select nom from CATe ";
                var rd = d.cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(Convert.ToString(rd[0]));
                }
                int i = 0;
                while (i < list.LongCount())
                {
                    cat_txt.Items.Add(list[i]);
                    i++;

                }             

            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                d.deconnecter();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (nom_txt.Text== ""|| auther_txt.Text==""||cat_txt.Text==""||prix_txt.Text=="")
            {
                MessageBox.Show("Complétez vos informations");
            }
            else {
                if (state == 0)
                {
                    //ajoute
                    cover.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Png);
                    var _cover = ma.ToArray();
                    d.con.ConnectionString = @"Data Source=DESKTOP-1JHKSTN\SQLEXPRESS;Initial Catalog=BOOK;Integrated Security=True";
                    d.connecter();
                    d.cmd.Connection = d.con;
                    d.cmd.CommandText = "insert into BOOKS (Titel,Auther,CAT,Price,Date,Rate,Cover) values(@Titel,@Auther,@CAT,@Price,@Date,@Rate,@Cover)";
                    d.cmd.Parameters.AddWithValue("@Titel", nom_txt.Text);
                    d.cmd.Parameters.AddWithValue("@Auther", auther_txt.Text);
                    d.cmd.Parameters.AddWithValue("@CAT", cat_txt.Text);
                    d.cmd.Parameters.AddWithValue("@Price", prix_txt.Text);
                    d.cmd.Parameters.AddWithValue("@Date", date_txt.Value);
                    d.cmd.Parameters.AddWithValue("@Rate", rate_txt.Value);
                    d.cmd.Parameters.AddWithValue("@Cover", _cover);
                    d.cmd.ExecuteNonQuery();
                    MessageBox.Show("ajoute ok");
                    d.deconnecter();
                }
                else
                {
                    //modifier
                    cover.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Png);
                    var _cover = ma.ToArray();
                    d.con.ConnectionString = @"Data Source=DESKTOP-1JHKSTN\SQLEXPRESS;Initial Catalog=BOOK;Integrated Security=True";
                    d.connecter();
                    d.cmd.Connection = d.con;
                    d.cmd.CommandText = "update BOOKS set Titel=@Titel,Auther=@Auther,CAT=@CAT,Price=@Price,Date=@Date,Rate=@Rate,Cover=@Cover where id=@id";
                    d.cmd.Parameters.AddWithValue("@Titel", nom_txt.Text);
                    d.cmd.Parameters.AddWithValue("@Auther", auther_txt.Text);
                    d.cmd.Parameters.AddWithValue("@CAT", cat_txt.Text);
                    d.cmd.Parameters.AddWithValue("@Price", prix_txt.Text);
                    d.cmd.Parameters.AddWithValue("@Date", date_txt.Value);
                    d.cmd.Parameters.AddWithValue("@Rate", rate_txt.Value);
                    d.cmd.Parameters.AddWithValue("@Cover", _cover);
                    d.cmd.Parameters.AddWithValue("@id", state);
                    d.cmd.ExecuteNonQuery();
                    MessageBox.Show("modifier ok");
                    d.deconnecter(); 

                }
                d.cmd.Parameters.Clear();
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dia = new OpenFileDialog();
            var rus = dia.ShowDialog();
            if (rus == DialogResult.OK)
            {
                cover.Image = Image.FromFile(dia.FileName);

            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
