﻿using Domen;
using KlijetAplikacija.Kontroleri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlijetAplikacija
{
    public partial class GlavnaFormaKlijent : Form
    {
        private const string INFO_TEKST = "Projekat iz predmeta Projektovanje Softvera (FON, 2019)";

        private KontrolerGlavneForme kontrolerGlavneForme;

        public GlavnaFormaKlijent()
        {
            InitializeComponent();

            this.pbRacuni.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbRacuni.BackColor = Color.Transparent;
            this.pbKrediti.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbKrediti.BackColor = Color.Transparent;
            this.pbTransakcije.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbTransakcije.BackColor = Color.Transparent;

            this.kontrolerGlavneForme = new KontrolerGlavneForme();
        }

        private void lblRazvijeno_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format(Konstante.GUI.INFO_TEKS, INFO_TEKST), Konstante.GUI.INFO_NASLOV, 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pbRacuni_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new MojiRacuniForma(this)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen,
                Text = String.Format(Konstante.GUI.DOBRODOSLI, new String[] {
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Ime,
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Prezime })
            }).Show();
        }

        private void pbKrediti_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new MojiKreditiForma(this)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen,
                Text = String.Format(Konstante.GUI.DOBRODOSLI, new String[] {
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Ime,
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Prezime })

            }).Show();
        }

        private void pbTransakcije_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new MojeTransakcijeForma(this)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen,
                Text = String.Format(Konstante.GUI.DOBRODOSLI, new String[] {
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Ime,
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Prezime })
            }).Show();
        }

        private void GlavnaFormaKlijent_FormClosed(object sender, FormClosedEventArgs e)
        {
            kontrolerGlavneForme.Odjava();
            Application.Exit();
        }
    }
}
