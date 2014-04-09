using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
namespace CRUD_dan_Export_ke_XML
{
    public partial class FormTambahData : Form
    {
        public DataTable tabel;
        public string status = "";
        public int n_id;
        public string nma, tt_l, agm, pkerjaan;

        public FormTambahData()
        {
            InitializeComponent();
        }

        void NoIDTextChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(noID.Text.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Input harus angka");
                noID.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e) //Tombol tambah data
        {
            isiData isi = new isiData();
            tabel = isi.tambahData(Convert.ToInt32(noID.Text.ToString()), nama.Text.ToString(), ttl.Text.ToString(), agama.Text.ToString(), pekerjaan.Text.ToString());
            MessageBox.Show("Berhasil");
            this.Close();
        }
 

        private void button2_Click(object sender, EventArgs e) // Tombol Update
        {
            isiData isi = new isiData();
            tabel = isi.updateData(Convert.ToInt32(noID.Text.ToString()), nama.Text.ToString(), ttl.Text.ToString(), agama.Text.ToString(), pekerjaan.Text.ToString());
            MessageBox.Show("Berhasil");
            this.Close();
        }

        private void FormTambahData_Load(object sender, EventArgs e)
        {
            if (status == "tambah")
            {
                button1.Visible = true;
                button2.Visible = false;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = true;
                noID.Text = n_id.ToString();
                nama.Text = nma;
                ttl.Text = tt_l;
                agama.Text = agm;
                pekerjaan.Text = pkerjaan;
            }
        }
    }
}
 
