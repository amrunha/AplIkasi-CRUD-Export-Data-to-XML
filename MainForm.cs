using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Xml;


namespace CRUD_dan_Export_ke_XML
{
    public partial class MainForm : Form
    {
        public DataTable tabel;
        public DataGridViewButtonColumn editData, hapusData;
        public MainForm()
        {
            InitializeComponent();
        }

        void MainFormLoad(object sender, EventArgs e)
        {
            bacaData bc = new bacaData();
            tabel = bc.bacaDataSemua();
            TampilSemua(tabel);
        }
        public void TampilSemua(DataTable tabel)
        {
            tampil.DataSource = null;
            tampil.Columns.Clear();
            tampil.DataSource = tabel;
            tampil.AllowUserToAddRows = false;
            tampil.ReadOnly = true;
            //tampil.Columns[0].Visible = false;
            tampil.Columns[0].HeaderText = "Nomor ID";
            tampil.Columns[0].Width = 58; //tipe cd
            tampil.Columns[1].HeaderText = "Nama";
            tampil.Columns[1].Width = 110; //tipe cd
            tampil.Columns[2].HeaderText = "TTL";
            tampil.Columns[2].Width = 150; //nama cd
            tampil.Columns[3].HeaderText = "Agama";
            tampil.Columns[3].Width = 50; //tipe cd
            tampil.Columns[4].HeaderText = "Pekerjaan";
            tampil.Columns[4].Width = 100; //tipe cd
            //tampil.Columns[4].Visible = false;
            editData = new DataGridViewButtonColumn();
            editData.UseColumnTextForButtonValue = true;
            editData.Width = 66;
            editData.Text = "Edit";
            tampil.Columns.Add(editData);
            hapusData = new DataGridViewButtonColumn();
            hapusData.UseColumnTextForButtonValue = true;
            hapusData.Width = 66;
            hapusData.Text = "Hapus";
            tampil.Columns.Add(hapusData);
        }



        private void button1_Click(object sender, EventArgs e) // Tombol Export ke XML
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;

            XmlWriter writter = XmlWriter.Create("D://Data Export.html", setting);
            writter.WriteStartDocument();
            writter.WriteStartElement("table");
            for (int i = 0; i < tampil.Rows.Count; i++)
            {
                writter.WriteStartElement("tr");
                for (int j = 0; j < tampil.Columns.Count; j++)
                {
                    //(tampilNilai[0,j].Value.ToString(),tampilNilai[i,j].Value.ToString());
                    writter.WriteElementString("td", tampil[j, i].Value.ToString());
                }
                writter.WriteEndElement();
            }
            writter.WriteEndElement();
            writter.WriteEndDocument();
            writter.Flush();
            writter.Close();
            MessageBox.Show("Data berhasil di export ke D://Data Export.html");

        }

        private void button2_Click(object sender, EventArgs e) // Tombol Refresh
        {
            bacaData bc = new bacaData();
            tabel = bc.bacaDataSemua();
            TampilSemua(tabel);
        }

        private void button3_Click(object sender, EventArgs e) // Tombol Tambah Data
        {
            FormTambahData f1 = new FormTambahData();
            f1.status = "tambah";
            f1.ShowDialog();
        }

        private void tampil_CellContentClick(object sender, DataGridViewCellEventArgs e) // Tampil datagridview
        {
            int baris = int.Parse(e.RowIndex.ToString());
            int no_id = int.Parse(tampil[0, baris].Value.ToString());
            string nama = tampil[1, baris].Value.ToString();
            string ttl = tampil[2, baris].Value.ToString();
            string agama = tampil[3, baris].Value.ToString();
            string pekerjaan = tampil[4, baris].Value.ToString();
            if (tampil.Columns[e.ColumnIndex] == editData && baris >= 0)
            {
                FormTambahData f2 = new FormTambahData();
                f2.n_id = no_id;
                f2.nma = nama;
                f2.tt_l = ttl;
                f2.agm = agama;
                f2.pkerjaan = pekerjaan;
                f2.ShowDialog();
            }
            else if (tampil.Columns[e.ColumnIndex] == hapusData && baris >= 0)
            {
                hapusData hps = new hapusData();
                tabel = hps.hapusDataSiswa(no_id);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
 
