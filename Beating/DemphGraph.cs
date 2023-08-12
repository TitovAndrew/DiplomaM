using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beating
{
    class DemphGraph : Graph
    {
        public float A { set; get; } // Амплитуда
        public float W { set; get; } // Частота
        public float C { set; get; } // Коэф демпфирования

        public DemphGraph()
        {
            A = 1.0f;
            W = 1.0f;
            C = 1.0f;
        }

        protected override float F(float t)  // Функция частотного графика
        {
            return A * (float)Math.Exp(-C * t) * (float)Math.Cos(W * t); //Math.Sqrt(1) * t); //Вроде как 1 здесь - что-то типо частоты
        }
    }
}

