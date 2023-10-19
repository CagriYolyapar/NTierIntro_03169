using  Project.BLL.DesignPatterns.GenericRepository.EFConcRep;

using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _cRep = new CategoryRepository();
           
        }
        CategoryRepository _cRep;
        private void btnKategoriler_Click(object sender, EventArgs e)
        {
            KategorileriListele();
           
        }

        public void KategoriEkle(string isim)
        {
            Category c = new Category { CategoryName = isim };
            _cRep.Add(c);
        }

        private void KategorileriListele()
        {
            lstKategoriler.DataSource = _cRep.GetActives();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            KategoriEkle(txtIsim.Text);
            KategorileriListele();
        }
    }
}
