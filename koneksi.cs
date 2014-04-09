using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ExportDataToXML
{
	/// <summary>
	/// Description of koneksi.
	/// </summary>
	public class koneksi
	{
		public MySqlConnection konek;
		
		string konfigKoneksi = "server=localhost; database=db_crud; uid=root; pwd=";
		public void bukaKoneksi()
		{
			konek = new MySqlConnection(konfigKoneksi);
			konek.Open();
		}
		public void tutuKoneksi()
		{
			konek = new MySqlConnection(konfigKoneksi);
			konek.Close();
		}
	}
}
