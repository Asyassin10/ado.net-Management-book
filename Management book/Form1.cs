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
    public partial class Form1 : Form
    {
        sql d = new sql();
        MemoryStream ma = new MemoryStream();
        List<string> list = new List<string>();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            try { 
            d.con.ConnectionString = @"Data Source=DESKTOP-4A435TC\SQLEXPRESS;Initial Catalog=BOOK;Integrated Security=True";
            d.connecter();
            if (d.dt.Rows != null)
            {
                d.dt.Clear();
            }
            d.cmd.CommandText = "select id as Arrangement,Titel,Auther,Price,Cat,Date from BOOKS";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            dataGridView1.DataSource = d.dt;
            d.dt.Load(d.dr);
            d.dr.Close();

            d.deconnecter();
            }
            catch { }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            add ajout = new add();
            ajout.state = 0;
            ajout.bunifuThinButton21.ButtonText = "Ajoute";
            bunifuTransition1.ShowSync(ajout);


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            add ajout = new add();
            ajout.bunifuThinButton21.ButtonText = "Modifier";
            ajout.state = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            bunifuTransition1.ShowSync(ajout);
            try
            {
                d.con.ConnectionString = @"Data Source=DESKTOP-4A435TC\SQLEXPRESS;Initial Catalog=BOOK;Integrated Security=True";
                d.connecter();
                d.cmd.Connection = d.con;
                d.cmd.CommandText = "select Titel,Auther,Price,Cat,Date,Rate from BOOKS where id=@id";   
                d.cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                var rd = d.cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(Convert.ToString(rd[0]));
                    list.Add(Convert.ToString(rd[1]));
                    list.Add(Convert.ToString(rd[2]));
                    list.Add(Convert.ToString(rd[3]));
                    list.Add(Convert.ToString(rd[4]));
                    list.Add(Convert.ToString(rd[5]));               
                } 

                ajout.nom_txt.Text = list[0];
                ajout.auther_txt.Text = list[1];
                ajout.prix_txt.Text = list[2];
                ajout.cat_txt.Text = list[3];
                ajout.date_txt.Text = list[4];
                ajout.rate_txt.Text = list[5];
                d.deconnecter();
                //read image
                d.connecter();
                d.cmd.CommandText = "select Cover from BOOKS WHERE id=@idimage";
                d.cmd.Parameters.AddWithValue("@idimage", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                byte[] img = (byte[])d.cmd.ExecuteScalar();
                ma.Write(img, 0, img.Length);
                ajout.cover.Image = Image.FromStream(ma);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                d.deconnecter();
            }

            d.cmd.Parameters.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try {
                d.con.ConnectionString = @"Data Source=DESKTOP-4A435TC\SQLEXPRESS;Initial Catalog=BOOK;Integrated Security=True";
                d.connecter();
                d.cmd.Connection = d.con;              
                d.cmd.CommandText = "delete from BOOKS where id=@id";
                d.cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
                d.cmd.ExecuteNonQuery();
                MessageBox.Show("supprimer done");
                d.deconnecter();
                d.cmd.Parameters.Clear();
                }
            catch { }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                d.con.ConnectionString = @"Data Source=DESKTOP-4A435TC\SQLEXPRESS;Initial Catalog=BOOK;Integrated Security=True";
                d.connecter();
                if (d.dt.Rows != null)
                {
                    d.dt.Clear();
                }
                d.cmd.CommandText = "select id as Arrangement,Titel,Auther,Price,Cat,Date from BOOKS";
                d.cmd.Connection = d.con; 
                d.dr = d.cmd.ExecuteReader();
                d.dt.Load(d.dr);
                dataGridView1.DataSource = d.dt;
                d.dt.Load(d.dr);
                d.dr.Close();

                d.deconnecter();
            }
            catch { }

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            daites dt = new daites();
            bunifuTransition1.ShowSync(dt);                     
            try
            {
                d.con.ConnectionString = @"Data Source=DESKTOP-4A435TC\SQLEXPRESS;Initial Catalog=BOOK;Integrated Security=True";
                d.connecter();
                d.cmd.Connection = d.con;
                d.cmd.CommandText = "select Titel,Auther,Price,Cat,Date,Rate from BOOKS where id=@id";
                d.cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                var rd = d.cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(Convert.ToString(rd[0]));
                    list.Add(Convert.ToString(rd[1]));
                    list.Add(Convert.ToString(rd[2]));
                    list.Add(Convert.ToString(rd[3]));
                    list.Add(Convert.ToString(rd[4]));
                    list.Add(Convert.ToString(rd[5]));
                }

                dt.nom_txt.Text = list[0];
                dt.auther_txt.Text = list[1];
                dt.prix_txt.Text = list[2];
                dt.cat_txt.Text = list[3];
                dt.date_txt.Text = list[4];
                dt.rate_txt.Text = list[5];
                d.deconnecter();
                //read image
                d.connecter();
                d.cmd.CommandText = "select Cover from BOOKS WHERE id=@idimage";
                d.cmd.Parameters.AddWithValue("@idimage", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                byte[] img = (byte[])d.cmd.ExecuteScalar();
                ma.Write(img, 0, img.Length);
                dt.cover.Image = Image.FromStream(ma);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                d.deconnecter();
            }

            d.cmd.Parameters.Clear();
        }
    }

}

