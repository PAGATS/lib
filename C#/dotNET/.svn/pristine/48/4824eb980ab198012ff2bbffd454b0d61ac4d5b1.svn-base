using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.Analysis.Signal;

namespace tbSpectrum
{
    public partial class Form1 : Form
    {
        Spectrum sp1, sp2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sp1 = new Spectrum();
            sp2 = new Spectrum();

            double[] wv = new double[4096];
            double[] pw = new double[4096];

            for(int i = 0 ; i < wv.Length ; i++)
            {
                wv[i] = i;
                pw[i] = i;
            }

            sp1.Add(wv, pw);

            for (int i = 0; i < wv.Length; i++)
            {
                wv[i] = i;
                pw[i] = i + 1;
            }

            sp2.Add(wv, pw);

            Spectrum sp = sp2 * sp1;

            sp = sp / 2;

            Spectrum asp = sp;
            
            double a = sp[100];

            Spectrum tsp = sp.SubSpectrum(0, 100);

            double sum = sp.Power(-100, 100);

        }

    }
}

