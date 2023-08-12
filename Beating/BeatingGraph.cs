using System;

namespace Beating
{
    class BeatingGraph : Graph
    {
        public float A1 { set; get; }  // Амплитуда 1

        public float A2 { set; get; }  // Амплитуда 2

        public float AW { set; get; }  // Средняя частота

        public float DW { set; get; }  // Разница частот

        public BeatingGraph()
        {
            AW = 1.0f;
            DW = 1.0f;
            A1 = 1.0f;
            A2 = 1.0f;
        }

        protected override float F(float t)  // Функция графика биений
        {
            return A1 * (float)Math.Cos(AW * t - 0.5 * DW * t) + A2 * (float)Math.Cos(AW * t + 0.5 * DW * t);
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
