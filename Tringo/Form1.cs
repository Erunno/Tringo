using System;
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
using TringoModel.DataProcessing.Mean;
using DataLoading;
using System.IO;
using TringoModel.DataSructures.Interval;
using MovementsCreation;

namespace Tringo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ISetOfSensors setOfSensors;
        private void bLoading_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            LoadingVisualisation loadingForm = new LoadingVisualisation(openFileDialog1.FileName);
            loadingForm.ShowDialog();

            if (!loadingForm.LoadingWasSuccesful || !loadingForm.LoadingIsDone)
                return;

            setOfSensors = loadingForm.Result;
            bCreateMovements.Enabled = true;
        }

        ISetOfMovements setOfMovements;
        private void bCreateMovements_Click(object sender, EventArgs e)
        {
            IMovementsCreationManager movCr = new FormMovementCreatorManager();
            setOfMovements = movCr.CreateSetOfMovements(setOfSensors);
        }
    }
}
