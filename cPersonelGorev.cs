using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace kafemasyon
{
    internal class cPersonelGorev
    {
        cGenel gnl = new cGenel();

        private int _personelGorevId;
        public int PersonelGorevId { get => _personelGorevId; set => _personelGorevId = value; }


        private string _tanim;
        public string Tanim { get => _tanim; set => _tanim = value; }

        public void PersonelGorevGetir(ComboBox cb)
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString); //veri tabanına bağlandı
            SqlCommand cmd = new SqlCommand("Select * from personelGorevleri", con);
            SqlDataReader dr = null;


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cPersonelGorev c = new cPersonelGorev();
                    c._personelGorevId = Convert.ToInt32(dr["ID"].ToString());
                    c._tanim = dr["GOREV"].ToString();
                    cb.Items.Add(c);
                }
            }


            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            dr.Close();
            con.Close();
        }



        public string PersonelGorevTanim(int per)
        {
            string sonuc = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select GOREV from personelGorevleri where ID=@perId", con);

            cmd.Parameters.Add("perId", SqlDbType.Int).Value = per;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = cmd.ExecuteScalar().ToString();
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            con.Close();

            return sonuc;



        }

        public override string ToString()
        {
            return _tanim;
        }










    }
}
