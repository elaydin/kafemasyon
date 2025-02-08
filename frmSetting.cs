using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kafemasyon
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();

        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            cPersoneller cp = new cPersoneller();
            cPersonelGorev cpg = new cPersonelGorev();
            string gorev = cpg.PersonelGorevTanim(cGenel._gorevId);
            if (gorev == "Müdür")
            {
                cp.personelGetbyInformation(cbPersonel);
                cpg.PersonelGorevGetir(cbGorevi);
                cp.personelBilgileriniGetirlv(lvPersoneller);
                btnYeni.Enabled = true;
                btnSil.Enabled = false;
                btnBilgiDegistir.Enabled = false;
                btnEkle.Enabled = false;
                groupBox1.Visible = true;
                groupBox3.Visible = true;
                groupBox2.Visible = false;
                groupBox4.Visible = true;
                txtSifre.ReadOnly = true;
                txtSifreTekrar.ReadOnly = true;
                lblBilgi.Text = "Mevki : Müdür / Yetki Sınırsız / Kullanıcı : " + cp.personelBilgiGetirIsim(cGenel._personelId);

            }
            else
            {
                groupBox1.Visible = false;
                groupBox3.Visible = false;
                groupBox2.Visible = true;
                groupBox4.Visible = false;
                lblBilgi.Text = "Mevki : Çalışan / Yetki Sınırlı / Kullanıcı : " + cp.personelBilgiGetirIsim(cGenel._personelId);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtYeniSifre.Text.Trim() != "" || txtYeniSifreTekrar.Text.Trim() != "")
            {


                if (txtYeniSifre.Text == txtYeniSifreTekrar.Text)
                {
                    if (txtPersonelId.Text != "")
                    {
                        cPersoneller c = new cPersoneller();
                        bool sonuc = c.personelSifreDegistir(Convert.ToInt32(txtPersonelId.Text), txtYeniSifre.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre Değiştirme işlemi başarıyla gerçekleşti.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçiniz!");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Eşleşmiyor !");
                }
            }
            else
            {
                MessageBox.Show("Şifre alanını boş bırakmayınız.");
            }

        } //CONTROLLED+

        private void cbGorevi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersonelGorev c = (cPersonelGorev)cbGorevi.SelectedItem;
            txtGorevId2.Text = Convert.ToString(c.PersonelGorevId);
        } //CONTROLLED+

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnYeni.Enabled = false;
            btnEkle.Enabled = true;
            btnBilgiDegistir.Enabled = false;
            btnSil.Enabled = false;
            txtSifre.ReadOnly = false;
            txtSifreTekrar.ReadOnly = false;

        } //CONTROLLED+

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cPersoneller c = new cPersoneller();
                    bool sonuc = c.personelSil(Convert.ToInt32(lvPersoneller.SelectedItems[0].Text));
                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt Başarıyla Silindi.");
                        c.personelBilgileriniGetirlv(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt silinirken hata oluştu!");
                    }
                }
                else
                {
                    MessageBox.Show("Kayıt Seçiniz.");
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text.Trim() != "" & txtSoyad.Text.Trim() != "" & txtSifre.Text.Trim() != "" & txtSifreTekrar.Text!= "" & txtGorevId2.Text.Trim() != "")
            {
                if ((txtSifreTekrar.Text.Trim() == txtSifre.Text.Trim()) && (txtSifre.Text.Length > 5 || txtSifreTekrar.Text.Length > 5))
                {
                    cPersoneller c = new cPersoneller();
                    c.PersonelAd = txtAd.Text.Trim();
                    c.PersonelSoyad = txtSoyad.Text.Trim();
                    c.PersonelParola = txtSifreTekrar.Text;
                    c.PersonelGorevId = Convert.ToInt32(txtGorevId2.Text);
                    bool sonuc = c.personelEkle(c);

                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt başarıyla eklenmiştir.");
                        c.personelBilgileriniGetirlv(lvPersoneller);

                    }
                    else
                    {
                        MessageBox.Show("Kayıt eklenirken hata oluştu !");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler eşleşmiyor !");
                }
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayınız.");
            }
        }

        private void btnBilgiDegistir_Click(object sender, EventArgs e)
        {
            if (txtAd.Text != "" || txtSoyad.Text != "" || txtSifreTekrar.Text != "" || txtGorevId2.Text != "")
            {
                if ((txtSifreTekrar.Text.Trim() == txtSifre.Text.Trim()) && (txtSifre.Text.Length > 5 || txtSifreTekrar.Text.Length > 5))
                {
                    cPersoneller c = new cPersoneller();
                    c.PersonelAd = txtAd.Text.Trim();
                    c.PersonelSoyad = txtSoyad.Text.Trim();
                    c.PersonelParola = txtSifreTekrar.Text;
                    c.PersonelGorevId = Convert.ToInt32(txtGorevId2.Text);
                    bool sonuc = c.personelGuncelle(c, Convert.ToInt32(txtPersoneID.Text));

                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt başarıyla eklenmiştir.");
                        c.personelBilgileriniGetirlv(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt eklenirken hata oluştu !");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler eşleşmiyor !");
                }
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayınız.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "" || textBox4.Text.Trim() != "")
            {
                if (textBox2.Text == textBox4.Text)
                {
                    if (cGenel._personelId.ToString() != "")
                    {
                        cPersoneller c = new cPersoneller();
                        bool sonuc = c.personelSifreDegistir(Convert.ToInt32(cGenel._personelId), textBox2.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre Değiştirme işlemi başarıyla gerçekleşti.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçiniz!");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Eşleşmiyor !");
                }
            }
            else
            {
                MessageBox.Show("Şifre alanını boş bırakmayınız.");
            }
        }

        private void lvPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvPersoneller.SelectedItems.Count > 0)
            {
                btnSil.Enabled = true;
                txtPersoneID.Text = lvPersoneller.SelectedItems[0].SubItems[0].Text;
                cbGorevi.SelectedIndex = Convert.ToInt32(lvPersoneller.SelectedItems[0].SubItems[1].Text) - 1;
                txtAd.Text = lvPersoneller.SelectedItems[0].SubItems[3].Text;
                txtSoyad.Text = lvPersoneller.SelectedItems[0].SubItems[4].Text;
            }
            else
            {
                btnSil.Enabled = false;
            }
        }
    }
}
