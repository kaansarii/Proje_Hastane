﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string TCno; //public bir değişken tanımladm

        sqlBaglantisi bgl = new sqlBaglantisi();
        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTC.Text = TCno; //maskedtex'deki değere TCno'yu taşıdık 

            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar where HastaTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",MskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[6].ToString();
                MskTelefon.Text = dr[3].ToString();
                TxtSifre.Text = dr[4].ToString();
                CmbCinsiyet.Text = dr[5].ToString();

            }
            bgl.baglanti().Close();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Hastalar set HastaAd=@p1, HastaSoyad=@p6, HastaTelefon=@p3, HastaSifre=@p4, HastaCinsiyet=@p5 where HastaTC=@p2", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut2.Parameters.AddWithValue("@p6",TxtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3",MskTelefon.Text);
            komut2.Parameters.AddWithValue("@p4",TxtSifre.Text);
            komut2.Parameters.AddWithValue("@p5",CmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p2",MskTC.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
