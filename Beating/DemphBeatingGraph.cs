using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beating
{
    class DemphBeatingGraph : Graph
    {
        public float A1 { set; get; }  // Амплитуда 1

        public float A2 { set; get; }  // Амплитуда 2

        public float AW { set; get; }  // Средняя частота

        public float DW { set; get; }  // Разница частот

        public float W1 { set; get; }  // Частота

        public float W2 { set; get; }  // Частота

        public float C1 { set; get; }  // Коэф демпфирования

        public float C2 { set; get; }  // Коэф демпфирования


        public DemphBeatingGraph()
        {
            AW = 1.0f;
            DW = 1.0f;
            A1 = 1.0f;
            A2 = 1.0f;
            W1 = 1.0f;
            W2 = 1.0f;
            C1 = 1.0f;
            C2 = 1.0f;
        }

        protected override float F(float t)  // Функция графика биений
        {
            return A1 * (float)Math.Exp(-C1 * t) * (float)Math.Cos(W1 * t) + A2 * (float)Math.Exp(-C2 * t) * (float)Math.Cos(W2 * t);
            // A1 * (float)Math.Cos(W1 * t) //A1 * (float)Math.Cos(AW * t - 0.5 * DW * t) + A2 * (float)Math.Cos(AW * t + 0.5 * DW * t);
        }

        public float BeatingFrequency()
        {
            return AW * (1 + 0.5f * Math.Abs(A2 - A1) / (A1 + A2) * DW / AW);
        }

        public float OscillationPeriod()
        {
            return (float)Math.PI * 2 / BeatingFrequency();
        }

        public float BeatingPeriod()
        {
            return (float)Math.PI * 2 / DW;
        }
    }
}
