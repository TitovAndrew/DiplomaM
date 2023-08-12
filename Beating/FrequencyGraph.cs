using System;

namespace Beating
{
    class FrequencyGraph : Graph
    {
        public float A { set; get; }  // Амплитуда
        public float W { set; get; }  // Частота

        public FrequencyGraph()
        {
            A = 1.0f;
            W = 1.0f;
        }

        protected override float F(float t)  // Функция частотного графика
        {
            return A * (float)Math.Cos(W * t);
        }
    }
}
