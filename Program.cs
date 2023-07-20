
using System.Data.SqlClient;

namespace DBKitapYazarOrnek
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SqlConnection conn;
            SqlDataReader reader;
            string yazarlar = "";
            string kitaplar = "";

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KUTUPHANE;";

            conn = new SqlConnection(connectionString);
            conn.Open();

            Console.WriteLine("Bağlantı başarılı!!!");

            /*
            //yazar ekleme
            Console.WriteLine("Yazar adı ve soyadı giriniz: ");
            string yazarAdi = Console.ReadLine();
            string yazarSoyadi = Console.ReadLine();

            string insertString = "INSERT INTO YAZAR VALUES('"+yazarAdi+"', '"+yazarSoyadi+"')";

            SqlCommand cmd = new SqlCommand(insertString, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Kayıt başarıyla eklendi!!!");
            cmd.Dispose();

            */



            //yazar okuma
            string queryString = "Select * From YAZAR";

            SqlCommand cmd2 = new SqlCommand(queryString, conn);
            reader = cmd2.ExecuteReader();

            Console.WriteLine("Yazar Listesi:");
            Console.WriteLine("ID: \t Yazar Adi: \t Yazar Soyadi: ");
            while (reader.Read())
            {
                yazarlar += reader.GetValue(0) + "\t";
                yazarlar += reader.GetValue(1) + "\t";
                yazarlar += reader.GetValue(2) + "\n";
            }

            Console.WriteLine(yazarlar);
            reader.Close();
            cmd2.Dispose();



            ////kitap ekleme
            //Console.WriteLine("Kitap adi giriniz: ");
            //string kitapAdi = Console.ReadLine();
            //Console.WriteLine("Kitabın sayfa sayısını giriniz: ");
            //int sayfa = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Yazar ID giriniz: ");
            //int yazarId = Convert.ToInt32(Console.ReadLine());

            //string insertKitap = "INSERT INTO KITAP(kitap_Adi, sayfa_Sayisi, yazar_Id) VALUES('" + kitapAdi + "', '" + sayfa + "', '" + yazarId + "')";

            //SqlCommand cmd3 = new SqlCommand(insertKitap, conn);
            //cmd3.ExecuteNonQuery();
            //Console.WriteLine("Kayıt başarıyla eklendi!!!");

            //cmd3.Dispose();


            // kitap okuma
            string queryString2 = "Select * From KITAP";

            SqlCommand cmd4 = new SqlCommand(queryString2, conn);
            reader = cmd4.ExecuteReader();

            Console.WriteLine("Kitap Listesi:");
            Console.WriteLine("Yazar Id: \t Kitap Adi: \t Sayfa Sayisi: \t Eklenme Tarihi: ");
            while (reader.Read())
            {
                kitaplar += reader.GetValue(0) + "\t";
                kitaplar += reader.GetValue(1) + "\t";
                kitaplar += reader.GetValue(2) + "\t";
                kitaplar += reader.GetValue(4) + "\n";
            }

            Console.WriteLine(kitaplar);
            
            reader.Close();
            cmd4.Dispose(); //bellekten atma, class'da yaratılıyor. bellekte(heapte) yer tutuluyor
            
            
            
            conn.Close();

        }
    }
}
