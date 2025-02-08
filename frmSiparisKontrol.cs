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
    public partial class frmSiparisKontrol : Form
    {
        public frmSiparisKontrol()
        {
            InitializeComponent();
        }

        private void frmSiparisKontrol_Load(object sender, EventArgs e)
        {
            cAdisyon c = new cAdisyon();
            int butonSayisi = c.paketAdisyonIdbulAdedi();
            c.acikPaketAdisyonlar(lvMusteriler);
            int alt = 50;
            int sol = 1;
            int bol = Convert.ToInt32(Math.Ceiling(Math.Sqrt(butonSayisi)));

            for (int i = 0;i< butonSayisi; i++)
            {
                Button btn = new Button();
                btn.AutoSize = false;
                btn.Size = new Size(179, 50);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Name = lvMusteriler.Items[i - 1].SubItems[0].Text;
                btn.Text =  lvMusteriler.Items[i - 1].SubItems[1].Text;
                btn.Font = new Font(btn.Font.FontFamily.Name,18);
                btn.Location = new Point(sol, alt);
                btn.Controls.Add(btn);

                sol += btn.Width + 5;

                if(i==2 )
                {
                    sol = 1;
                    alt += 50;
                }
            }








        }
    }
}
