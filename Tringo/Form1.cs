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
using ViewingUtils;
using DataProcessing;

namespace Tringo
{
    public partial class TringoApp : Form
    {
        public TringoApp()
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

            bMeanComputation.Enabled = bVariationStatistics.Enabled = setOfMovements != null && setOfMovements.Movements.Count != 0;
        }

        private void bMeanComputation_Click(object sender, EventArgs e)
        {
            IMovement mean = GetMeanMovement();

            MeanGraphView form = new MeanGraphView(mean, setOfMovements);
            form.ShowDialog();
        }

        private void bVariationStatistics_Click(object sender, EventArgs e)
        {
            VarianceCalculator calc = new VarianceCalculator(samplingFrequency: 500); // TODO discuss
            IMovement mean = GetMeanMovement();

            IVarinceData data = calc.CompudeVariance(mean, setOfMovements);

            MessageBox.Show(data.ToString());
        }

        private IMovement GetMeanMovement()
        {
            MeanMovementManager meanMovementManager = new MeanMovementManager(setOfMovements);
            IMovement mean = meanMovementManager.GetMeanMovement();

            return mean;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
