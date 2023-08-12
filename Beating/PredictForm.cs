using System;
using System.Drawing;
using System.Windows.Forms;

namespace Beating
{
    public partial class PredictForm : Form
    {
        private BeatingGraph beatingGraph1;
        private BeatingGraph beatingGraph2;

        public PredictForm()
        {
            InitializeComponent();
            beatingGraph1 = new BeatingGraph();
            beatingGraph2 = new BeatingGraph();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PredictForm_Resize(object sender, EventArgs e)
        {
            panelCanvas1.Height = ClientSize.Height / 2;
            panelCanvas2.Location = new Point(panelControls.Width - 2, ClientSize.Height / 2 - 1);
            panelCanvas2.Height = ClientSize.Height / 2;
            panelCanvas1.Invalidate();
            panelCanvas2.Invalidate();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            var max = 1000000.0f;
            var borderBeatin = 4;
            var fullBeating = 6;
            var frequncy = (float)numericUpDownFrequancy.Value;
            var step = (float)numericUpDownStep.Value;
            bool error = false;
            bool find = false;
            var desiredFrequency = frequncy + step;
            for (float f = frequncy + step; f < frequncy + max; f += step)
            {
                beatingGraph1.A1 = 1.0f;
                beatingGraph1.A2 = 1.0f;
                beatingGraph1.AW = (frequncy + f) / 2.0f;
                beatingGraph1.DW = Math.Abs(frequncy - f);

                var beatingPeriod = beatingGraph1.BeatingPeriod();
                var oscillationPeriod = beatingGraph1.OscillationPeriod();
                var appraisal = beatingPeriod - oscillationPeriod *
                    (radioButtonBorderLineStateBeating.Checked ? borderBeatin : fullBeating);
                var full = beatingPeriod - oscillationPeriod * fullBeating;

                if (appraisal > 0 && (radioButtonBorderLineStateBeating.Checked ? full < 0 : true))
                {
                    find = true;
                    desiredFrequency = f;
                }
                else if (find)
                {
                    textBoxW1.Text = desiredFrequency.ToString("0.###");
                    break;
                }
            }
            if (!find)
            {
                MessageBox.Show("Шаг поиска слишком большой, биений не найдено!", "Не удалось найти биение");
                error = true;
            }
            else
            {
                beatingGraph1.DrawLine = true;
                panelCanvas1.Invalidate();
                panelMeasurement.Visible = true;
            }

            find = false;
            desiredFrequency = frequncy - step;

            for (float f = frequncy - step; f > 0; f -= step)
            {
                beatingGraph2.A1 = 1.0f;
                beatingGraph2.A2 = 1.0f;
                beatingGraph2.AW = (frequncy + f) / 2.0f;
                beatingGraph2.DW = Math.Abs(frequncy - f);

                var beatingPeriod = beatingGraph2.BeatingPeriod();
                var oscillationPeriod = beatingGraph2.OscillationPeriod();
                var appraisal = beatingPeriod - oscillationPeriod *
                    (radioButtonBorderLineStateBeating.Checked ? borderBeatin : fullBeating);
                var full = beatingPeriod - oscillationPeriod * fullBeating;
                if (appraisal > 0 && (radioButtonBorderLineStateBeating.Checked ? full < 0 : true))
                {
                    find = true;
                    desiredFrequency = f;
                }
                else if (find)
                {
                    textBoxW2.Text = desiredFrequency.ToString("0.###");
                    break;
                }
            }

            if (!find)
            {
                if (!error)
                    MessageBox.Show("Шаг поиска слишком большой, биений не найдено!", "Не удалось найти биение");
            }
            else
            {
                beatingGraph2.DrawLine = true;
                panelCanvas2.Invalidate();
                panelMeasurement.Visible = true;
            }
        }

        private void PanelCanvas1_Paint(object sender, PaintEventArgs e)
        {
            var spaceX = 50.0f;
            var spaceY = 30.0f;
            var zero = new PointF(0, (panelCanvas1.ClientSize.Height - spaceY * 2.0f) / 2.0f);
            var rectangle = new RectangleF(spaceX, spaceY, panelCanvas1.ClientSize.Width - spaceX * 2.0f,
                panelCanvas1.ClientSize.Height - spaceY * 2.0f);
            float dW;
            if (beatingGraph1.DW == 0)
                dW = (float)Math.PI * 2.0f;
            else
                dW = (float)Math.Max(Math.PI * 2.0f / beatingGraph2.DW * 1.5f, 0.1f);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            beatingGraph1.Draw(e.Graphics, rectangle, zero, 0, -2.0f, dW,
                2.0f, Color.MediumSeaGreen);
        }

        private void PanelCanvas2_Paint(object sender, PaintEventArgs e)
        {
            var spaceX = 50.0f;
            var spaceY = 30.0f;
            var zero = new PointF(0, (panelCanvas2.ClientSize.Height - spaceY * 2.0f) / 2.0f);
            var rectangle = new RectangleF(spaceX, spaceY, panelCanvas2.ClientSize.Width - spaceX * 2.0f,
                panelCanvas2.ClientSize.Height - spaceY * 2.0f);
            float dW;
            if (beatingGraph2.DW == 0)
                dW = (float)Math.PI * 2.0f;
            else
                dW = (float)Math.Max(Math.PI * 2.0f / beatingGraph2.DW * 1.5f, 0.1f);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            beatingGraph2.Draw(e.Graphics, rectangle, zero, 0, -2.0f, dW,
                2.0f, Color.MediumSeaGreen);
        }

        private void PredictForm_ResizeBegin(object sender, EventArgs e)
        {
            beatingGraph1.Resizing = true;
            beatingGraph2.Resizing = true;
        }

        private void PredictForm_ResizeEnd(object sender, EventArgs e)
        {
            beatingGraph1.Resizing = false;
            beatingGraph2.Resizing = false;
            panelCanvas1.Invalidate();
            panelCanvas2.Invalidate();
        }
    }
}
