using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TringoModel.DataSructures;
using TringoModel.DataSructures.Simple;

namespace DataLoading
{
    class Parser : IDisposable
    {
        public Parser( TextReader input)
        {
            this.input = input; 
        }

        TextReader input;
        string currLine = null;
        bool lastLineHasBeenProccesed = true;

        private static IGraphInfo UnvalidGraphInfo = null;

        public IGraphInfo GetNextGraphInfo()
        {
            currLine = GetNextLine();

            if (!LineHasGraphFormat())
            {
                lastLineHasBeenProccesed = false;
                return UnvalidGraphInfo;
            }

            lastLineHasBeenProccesed = true;
            return CreateNewGraphInfoFromCurrLine();
        }

        private bool LineHasGraphFormat()
            => currLine.Contains(NameLabel) && currLine.Contains(SampleCountLabel) && currLine.Contains(SamplingFequencyLabel);

        int lineNum = 0;
        private string GetNextLine() 
        {
            if (lastLineHasBeenProccesed)
            {
                lineNum++;
                return input.ReadLine();
            }
            else
                return currLine;
        }

        private IGraphInfo CreateNewGraphInfoFromCurrLine()
        {
            MutableGraphInfo graphInfo = new MutableGraphInfo();

            graphInfo.Name = GetNameOfGraph();
            graphInfo.SamplingFrequency = GetSamplingFrequencyOfGraph();
            graphInfo.SamplesCount = GetSampleCount();

            return graphInfo;
        }

        readonly string NameLabel = "Label: ";
        private string GetNameOfGraph()
        {
            int startIndex = currLine.GetStartIndexOf(NameLabel) + NameLabel.Length;

            string name = GetWord(startIndex, boundaryChar: ':');

            return name;
        }

        readonly string SamplingFequencyLabel = "Sampling frequency: ";
        private double GetSamplingFrequencyOfGraph()
        {
            int startIndex = currLine.GetStartIndexOf(SamplingFequencyLabel) + SamplingFequencyLabel.Length;

            string freqString = GetWord(startIndex, boundaryChar: ' ');
            double freq = double.Parse(freqString);

            return freq;
        }

        readonly string SampleCountLabel = "Number of points: ";
        private int GetSampleCount()
        {
            int startIndex = currLine.GetStartIndexOf(SampleCountLabel) + SampleCountLabel.Length;

            string countString = GetWord(startIndex, boundaryChar: ' ');
            int count = int.Parse(countString);

            return count;
        }

        private string GetWord(int startIndex, char boundaryChar)
        {
            int iterator = startIndex;

            StringBuilder sb = new StringBuilder();

            while (currLine[iterator] != boundaryChar)
                sb.Append(currLine[iterator++]);

            return sb.ToString();
        }

        public double?[] LineOfSamples = null;

        public void UpdateLineOfSamples()
        {
            currLine = GetNextLine();

            if(currLine == null)
            {
                LineOfSamples = null;
                return;
            }

            if (!LineHasSamplesFormat())
                throw new NotValuesLineException();

            ParseCurrLineToLineOfSamples();
            lastLineHasBeenProccesed = true;
        }

        char[] valuesSeparators = { ',' };
        public void ParseCurrLineToLineOfSamples()
        {
            string[] samplesStrings = currLine.Split(valuesSeparators);

            UpdateLengthOfLineOfSamplesArray(samplesStrings.Length);

            for (int i = 0; i < samplesStrings.Length; i++)
                if (samplesStrings[i] != "")
                    LineOfSamples[i] = double.Parse(samplesStrings[i]);
                else
                    LineOfSamples[i] = null;
        }

        private void UpdateLengthOfLineOfSamplesArray(int newLength)
        {
            if (LineOfSamples == null || LineOfSamples.Length != newLength)
                LineOfSamples = new double?[newLength];
        }

        public void SkipUnwantedLines()
        {
            currLine = GetNextLine();

            while (!LineHasSamplesFormat())
            {
                lastLineHasBeenProccesed = true;
                currLine = GetNextLine();
            }

            lastLineHasBeenProccesed = false;
        }

        private bool LineHasSamplesFormat() => currLine != null && currLine.Length != 0 && (IsNum(currLine[0]) || IsMinusSign(currLine[0]));
        private bool IsNum(char ch) => '0' <= ch && ch <= '9';
        private bool IsMinusSign(char ch) => ch == '-';

        public void Dispose()
        {
            input.Dispose();
        }

        public void Close()
        {
            input.Close();
        }
    }

    class NotValuesLineException : FormatException { }
}
