using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataLoading
{
    class Translator : TextReader
    {
        private TextReader input;

        public Translator(TextReader input)
        {
            this.input = input;
            CreatePatternMacherAndBuffer();
            FillBuffer();
        }

        PatternMacher<int> patternMacher;
        BufferOfFixedSize<int> buffer;

        public override int Read()
        {
            int toReturn = ReadWirhCarrReturn();

            while (toReturn == '\r')
                toReturn = ReadWirhCarrReturn();

            return toReturn;
        }

        public int ReadWirhCarrReturn()
        {
            int toReturn = GetCharToReturn();

            SaveChar(input.Read());

            return toReturn;
        }

        int GetCharToReturn()
        {
            int charToWrite = buffer.GetOldest();

            if (nextCommaHasToBeTranslated && charToWrite == ',')
            {
                nextCommaHasToBeTranslated = false;
                return '.';
            }
            else
                return charToWrite;
        }

        bool nextCommaHasToBeTranslated = false;

        void SaveChar(int ch)
        {
            buffer.PushItem(ch);

            if (patternMacher.PatternMaches())
                nextCommaHasToBeTranslated = true;
        }

        void CreatePatternMacherAndBuffer()
        {
            buffer = new BufferOfFixedSize<int>(7);

            Predicate<int> IsNum = ch => 0 <= ch - '0' && ch - '0' < 10;
            Predicate<int> IsComma = ch => ch == ',';

            List<Predicate<int>> conditions = new List<Predicate<int>> { IsNum, IsComma, IsNum, IsNum, IsNum, IsNum, IsNum };

            patternMacher = new PatternMacher<int>(conditions, buffer);
        }

        void FillBuffer()
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer.PushItem((char)input.Read());
            }
        }


        public override void Close()
        {
            input.Close();
        }
    }

    class PatternMacher<T>
    {
        public PatternMacher(List<Predicate<T>> conditions, BufferOfFixedSize<T> testedInput)
        {
            this.testedInput = testedInput;
            this.conditions = conditions;
        }

        List<Predicate<T>> conditions;

        BufferOfFixedSize<T> testedInput;

        public bool PatternMaches()
        {
            for (int i = 0; i < conditions.Count; i++)
                if (!conditions[i](testedInput[i]))
                    return false;

            return true;
        }
    }

    class BufferOfFixedSize<T>
    {
        T[] buffer;

        public int Length => buffer.Length;

        public BufferOfFixedSize(int size)
        {
            buffer = new T[size];
            topItem = 3;
        }

        private int topItem;


        public T GetOldest() => this[0];

        public void PushItem(T item)
        {
            topItem = (topItem + 1) % Length;
            buffer[topItem] = item;
        }


        public T this[int index]
        {
            get
            {
                if (!IsInRange(index))
                    throw new IndexOutOfRangeException();

                return buffer[(1 + index + topItem) % Length];
            }
        }

        private bool IsInRange(int index) => (0 <= index && index < buffer.Length);
    }

}
