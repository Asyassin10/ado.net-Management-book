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


namespace Management_book
{
    public partial class cat : Form
    {
        sql d = new sql();
        public cat()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (cat_txt.Text == "")
            {
                MessageBox.Show("Le nom de la classe n'existe pas");
            }
            else {
                d.con.ConnectionString = @"Data Source=DESKTOP-4A435TC\SQLEXPRESS;Initial Catalog=BOOK;Integrated Security=True";
                d.connecter();
                d.cmd.Connection = d.con;
                d.cmd.CommandText = "insert into CATe (nom) values (@nom) ";
                d.cmd.Parameters.AddWithValue("@nom", cat_txt.Text);
                d.cmd.ExecuteNonQuery();
                MessageBox.Show("ajoute ok");

                d.deconnecter();
            }
            
        }
    }
}
