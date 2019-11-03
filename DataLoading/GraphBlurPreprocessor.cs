using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoading
{
    class GraphBlurPreprocessor : IGraphPreprocessor
    {
        public GraphBlurPreprocessor(double[] blurWindow)
        {
            this.blurWindow = new BlurWindow(blurWindow);
            offset = blurWindow.Length / 2;
        }

        BlurWindow blurWindow { get; }
        int offset { get; }
        
        double[] tempContainer;
        List<RawGraph> data;

        public void ModifySamples(List<RawGraph> data)
        {
            AllocateResources(data);
            BlurAllGraphs();
            DeallocateResources();
        }

        private void AllocateResources(List<RawGraph> data)
        {
            this.data = data;
            int maxLength = (from graph in data select graph.Samples.Length).Max();
            tempContainer = new double[maxLength];

            blurWindow.Samples = tempContainer;
        }

        private void DeallocateResources()
        {
            tempContainer = blurWindow.Samples = null;
            data = null;
        }


        private void BlurAllGraphs()
        {
            foreach (var graph in data)
                BlurSamples(graph.Samples);
        }

        private void BlurSamples(double[] samples)
        {
            CreateCopyToTempContainer(samples);

            for (int i = offset; i < samples.Length - offset; i++)
                samples[i] = blurWindow.ComputeValueOn(i);
        }
        
        private void CreateCopyToTempContainer(double[] samples)
        {
            for (int i = 0; i < samples.Length; i++)
                tempContainer[i] = samples[i];
        }
    }

    class BlurWindow
    {
        public BlurWindow(double[] valuesOfBlur)
        {
            if (valuesOfBlur.Length % 2 != 1)
                throw new UnvalidFormatOfBlurWindowException("Lenght of valuesOfBlur have to be odd");

            blur = valuesOfBlur;
            offset = Size / 2;
        }

        public double[] Samples { get; set; }
        
        double[] blur;
        
        public int Size => blur.Length;

        private int offset;

        public double ComputeValueOn(int index)
        {
            double sum = 0;

            for (int i = 0; i < blur.Length; i++)
                sum += blur[i] * Samples[i + index - offset];

            return sum;
        }
    }

    class UnvalidFormatOfBlurWindowException : ArgumentException 
    {
        public UnvalidFormatOfBlurWindowException(string message) : base(message) { }

        public UnvalidFormatOfBlurWindowException() { }
    }
}
