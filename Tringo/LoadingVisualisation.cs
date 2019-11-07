using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TringoModel.DataSructures;
using DataLoading;
using System.IO;
using System.Threading;

namespace Tringo
{
    public partial class LoadingVisualisation : Form
    {
        public LoadingVisualisation(string dataPath)
        {
            InitializeComponent();
            
            
            this.dataPath = dataPath;
            Run();
        }

        public ISetOfSensors Result;
        string dataPath;
        TextReaderMonitor textReader;
        Thread loadingThread;

        public bool LoadingWasSuccesful { get; private set; } = false;
        public bool LoadingIsDone { get; private set; } = false;

        private void Run()
        {
            if (!TryOpenFile())
            {
                LoadingIsDone = true;
                this.Close();
                return;
            }

            loadingThread = new Thread(RunLoading);
            loadingThread.Start();
        }

        private bool TryOpenFile()
        {
            try
            {
                textReader = new TextReaderMonitor(new StreamReader(dataPath));
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void RunLoading()
        {
            ILoadingManager loadingManager = new TextDataLoadingManager(textReader);
            Result = loadingManager.LoadSensors();
            
            LoadingIsDone = true;
            LoadingWasSuccesful = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (loadingThread != null && !loadingThread.IsAlive)
                this.Close();

            progressBar.Value = (int)(textReader.PercentageReaded * progressBar.Maximum);
            progressBar.Refresh();

        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    class TextReaderMonitor : TextReader
    {
        public TextReaderMonitor(StreamReader baseStreamReader)
        {
            streamReader = baseStreamReader;
            Length = streamReader.BaseStream.Length;

        }

        StreamReader streamReader;

        long ReadedSoFar = 0;
        long Length { get; }

        public double PercentageReaded => (double)ReadedSoFar / (double)Length;

        long lengthOfNewLine = Environment.NewLine.Length;

        public override string ReadLine()
        {
            string toReturn = streamReader.ReadLine();
            ReadedSoFar += toReturn.Length + lengthOfNewLine;
            
            return toReturn;
        }
        public override int Read()
        {
            ReadedSoFar++;
            return streamReader.Read();
        }
        public override int Peek() => streamReader.Peek();
        public override void Close() => streamReader.Close();
    }
}
