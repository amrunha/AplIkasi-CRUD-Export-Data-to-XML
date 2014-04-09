using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ExportDataToXML
{
	/// <summary>
	/// Description of bacaData.
	/// </summary>
	public class bacaData
	{
		MySqlDataAdapter adapter;
		MySqlCommand komand;
		koneksi classKoneksi;
		DataTable tabel;
		string sql="";
		public DataTable bacaDataSemua()
		{
			classKoneksi = new koneksi();
			sql = "select * from tbl_siswa";
			tabel = new DataTable();
			try {
				classKoneksi.bukaKoneksi();
				komand = new MySqlCommand(sql);
				adapter = new MySqlDataAdapter(sql,classKoneksi.konek);
				adapter.Fill(tabel);
			} catch (Exception) {
				MessageBox.Show("error");
			}
			return tabel;
		}
	}
}
