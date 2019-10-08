﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tringo.Monitor;
using TringoModel.DataSructures;
using TringoModel.DataSructures.DataCache;
using Tringo.TestGraphs;

namespace Tringo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Canvas testCanvas; 

        private void Button1_Click(object sender, EventArgs e)
        {
            testCanvas = new Canvas(testPictureBox);

            IGraph sin = new SinGraph();

            IGraph sinCached = new CachedGraph(sin, 2); 

            Range range = new Range(MaxValue: 1.5, MinValue: -1.5);

            testCanvas.DrawGraph(sinCached, range);

        }
    }
}