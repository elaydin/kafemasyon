﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Threading.Tasks;


namespace kafemasyon
{
     class cPersonelHareketleri
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _ID;
        private int _PersonelId;
        private string _Islem;
        private DateTime _Tarih;
        private bool _Durum;
        #endregion

        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public string Islem { get => _Islem; set => _Islem = value; }
        public bool Durum { get => _Durum; set => _Durum = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        #endregion

        public bool PersonelActionSave(cPersonelHareketleri ph)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into personelHareketleri (PERSONELID,ISLEM,TARIH)Values(@personelId,@islem,@tarih)", con);



            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@personelId", SqlDbType.Int).Value = ph._PersonelId;
                cmd.Parameters.Add("@islem", SqlDbType.VarChar).Value = ph._Islem;
                cmd.Parameters.Add("@tarih", SqlDbType.DateTime).Value = ph._Tarih;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
    
            }

            return result;
        }


    }
}
