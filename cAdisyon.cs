using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace kafemasyon
{
    internal class cAdisyon
    {
        cGenel gnl = new cGenel();

        #region fields
        private int _ID;
        private int _ServisTurNo;
        private decimal _Tutar;
        private DateTime _Tarih;
        private int _PersonelId;
        private int _Durum;
        private int _MasaId;

        #endregion
         #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int ServisTurNo { get => _ServisTurNo; set => _ServisTurNo = value; }
        public decimal Tutar { get => _Tutar; set => _Tutar = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public int Durum { get => _Durum; set => _Durum = value; }
        public int MasaId { get => _MasaId; set => _MasaId = value; } 
        #endregion

        //CONTROLLED+
        public int getbyAddition(int MasaId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 ID From adisyon Where MASAID=@MasaId Order by ID desc", con);

            cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = MasaId;
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MasaId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }
            finally { con.Close(); }



            return MasaId; 
                
        } // açık olan masanın adisyon numarası gönderilir.

        public bool setByAdditionNew(cAdisyon Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into adisyon(SERVISTURNO,TARIH,PERSONELID,MASAID,DURUM) values (@ServisTurNo, @Tarih,@PersonelID, @MasaId, @Durum)", con);
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ServisTurNo", SqlDbType.Int).Value = Bilgiler.ServisTurNo;

                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = Bilgiler.Tarih;
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = Bilgiler.PersonelId;
                cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = Bilgiler.MasaId;
                cmd.Parameters.Add("@Durum", SqlDbType.Bit).Value = 0;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex) 
            { 
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }

        public void additionclose(int adisyonID, int durum)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update adisyon set durum=@durum where ID=@adisyonId", con);


            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("adisyonId", System.Data.SqlDbType.Int).Value = adisyonID;
                cmd.Parameters.Add("durum", System.Data.SqlDbType.Int).Value = durum;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            


        }

        public int paketAdisyonIdbulAdedi()
        {
            int miktar = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select count(*) as Sayi from adisyon where (Durum=0) and (SERVISTURNO=2)", con);


             if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                try
            {
                miktar = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            


            return miktar;
        }

        public void acikPaketAdisyonlar(ListView lv) 
        {
            lv.Items.Clear();


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select paketSiparis.MUSTERIID, Musteriler.Ad + ' ' + Musteriler.Soyad as Musteri, Adisyon.ID from " +
                "paketSiparis Inner Join musteriler on musteriler.ID=paketSiparis.MUSTERIID Inner join adisyon on adisyon.ID=paketSiparis.ADISYONID" +
                "where adisyon.Durum=0", con);
            SqlDataReader dr = null;
            
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr=cmd.ExecuteReader();
                int sayac = 0;

                while(dr.Read())
                {
                    lv.Items.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Musteri"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adisyonID"].ToString());
                    sayac++;
                }
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }
            finally 
            {
                dr.Close();
                con.Dispose();
                con.Close(); 
            }





        }

    }
}
