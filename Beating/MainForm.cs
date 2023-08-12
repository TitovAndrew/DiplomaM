using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Beating
{
    public partial class MainForm : Form
    {
        private readonly DemphGraph graph1;
        private readonly DemphGraph graph2;
        private readonly DemphBeatingGraph beatingGraph;
        FileWorker fw;
        //string writePath = Environment.CurrentDirectory + "\\test.txt";
        //string testtext = "Привет мир!\n";
        string beatingStatus = "statusunknown";
        int indent = 0;

        Socket tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public MainForm()
        {
            InitializeComponent();
            graph1 = new DemphGraph();
            graph2 = new DemphGraph();
            beatingGraph = new DemphBeatingGraph();
            fw = new FileWorker();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
                | BindingFlags.Instance | BindingFlags.NonPublic, null,
                panelCanvas1, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
                | BindingFlags.Instance | BindingFlags.NonPublic, null,
                panelCanvas2, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
                | BindingFlags.Instance | BindingFlags.NonPublic, null,
                panelCanvas3, new object[] { true });
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            panelCanvas1.Height = (ClientSize.Height - 50) / 3;
            panelCanvas2.Location = new Point(panelControls.Width - 2, (ClientSize.Height - 50) / 3);
            panelCanvas2.Height = (ClientSize.Height - 50) / 3;
            panelCanvas3.Location = new Point(panelControls.Width - 2, (ClientSize.Height - 50) / 3 * 2);
            panelCanvas3.Height = (ClientSize.Height - 50) / 3;
            panelCanvas1.Invalidate();
            panelCanvas2.Invalidate();
            panelCanvas3.Invalidate();
        }

        private void PanelCanvas1_Paint(object sender, PaintEventArgs e)
        {
            var spaceX = 50.0f;
            var spaceY = 30.0f;
            var zero = new PointF(0, (panelCanvas1.ClientSize.Height - spaceY * 2.0f) / 2.0f);
            var rectangle = new RectangleF(spaceX, spaceY, panelCanvas1.ClientSize.Width - spaceX * 2.0f,
                panelCanvas1.ClientSize.Height - spaceY * 2.0f);

            float dW;
            if (Math.Abs(graph1.W - graph2.W) == 0)
                dW = 10.0f;
            else
                dW = (float)Math.Max(Math.PI * 2.0f / Math.Abs(graph1.W - graph2.W) * 1.5f, 0.1f);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graph1.Draw(e.Graphics, rectangle, zero, 0, -(graph1.A + graph2.A), 0.7f * dW + indent, (graph1.A + graph2.A), Color.Blue);
        }

        private void PanelCanvas2_Paint(object sender, PaintEventArgs e)
        {
            var spaceX = 50.0f;
            var spaceY = 30.0f;
            var zero = new PointF(0, (panelCanvas2.ClientSize.Height - spaceY * 2.0f) / 2.0f);
            var rectangle = new RectangleF(spaceX, spaceY, panelCanvas2.ClientSize.Width - spaceX * 2.0f,
                panelCanvas2.ClientSize.Height - spaceY * 2.0f);

            float dW;
            if (Math.Abs(graph1.W - graph2.W) == 0)
                dW = 10.0f;
            else
                dW = (float)Math.Max(Math.PI * 2.0f / Math.Abs(graph1.W - graph2.W) * 1.5f, 0.1f);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graph2.Draw(e.Graphics, rectangle, zero, 0, -(graph1.A + graph2.A), 0.7f * dW + indent, (graph1.A + graph2.A), Color.Blue);
        }

        private void ButtonSimulate_Click(object sender, EventArgs e)
        {
            graph1.DrawLine = false;
            graph2.DrawLine = false;
            beatingGraph.DrawLine = false;
            //numericUpDownA1.Value = 1;
            //numericUpDownA2.Value = 1;
            //numericUpDownW1.Value = 1;
            //numericUpDownW2.Value = 1;
            buttonCheck.Enabled = false;
            panelMeasurement.Visible = false;
            panelCanvas1.Invalidate();
            panelCanvas2.Invalidate();
            panelCanvas3.Invalidate();
            labelCheckResult.Text = "";
            buttonSave.Enabled = true;

            graph1.A = (float)numericUpDownA1.Value;
            graph1.W = (float)numericUpDownW1.Value;
            graph2.A = (float)numericUpDownA2.Value;
            graph2.W = (float)numericUpDownW2.Value;
            graph1.C = (float)numericUpDownC1.Value;
            graph2.C = (float)numericUpDownC2.Value;

            try
            {
                if (tcpClient.Connected == false)
                {
                    tcpClient.Connect("127.0.0.1", 8888);
                }
                // сообщение для отправки
                string message = "A: " + graph1.A.ToString("0.00 ") + graph2.A.ToString("0.00 ") + 
                    "   W: " + graph1.W.ToString("0.00 ") + graph2.W.ToString("0.00 ") +
                    "   C: " + graph1.C.ToString("0.000 ") + graph2.C.ToString("0.000 ") + "\n";
                // считыванием строку в массив байт
                byte[] data = Encoding.UTF8.GetBytes(message);
                
                // отправляем данные
                tcpClient.Send(data);
                Console.WriteLine("Сообщение отправлено");
                //tcpClient.Shutdown(SocketShutdown.Send);
                //tcpClient.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Соединение с сервером не установлено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (graph1.W >= 50 || graph2.W >= 50) { indent = 20; }
            else if (graph1.W >= 9 || graph2.W >= 9) { indent = 30; }
            else { indent = 150; }

            beatingGraph.A1 = graph1.A;
            beatingGraph.A2 = graph2.A;
            beatingGraph.AW = (graph1.W + graph2.W) / 2.0f;
            beatingGraph.DW = Math.Abs(graph1.W - graph2.W);
            beatingGraph.W1 = graph1.W;
            beatingGraph.W2 = graph2.W;
            beatingGraph.C1 = graph1.C;
            beatingGraph.C2 = graph2.C;

            graph1.DrawLine = true;
            graph2.DrawLine = true;
            beatingGraph.DrawLine = true;
            panelCanvas1.Invalidate();
            panelCanvas2.Invalidate();
            panelCanvas3.Invalidate();
            buttonCheck.Enabled = true;
        }

        private void PanelCanvas3_Paint(object sender, PaintEventArgs e)
        {
            var spaceX = 50.0f;
            var spaceY = 30.0f;
            var zero = new PointF(0, (panelCanvas3.ClientSize.Height - spaceY * 2.0f) / 2.0f);
            var rectangle = new RectangleF(spaceX, spaceY, panelCanvas3.ClientSize.Width - spaceX * 2.0f,
                panelCanvas3.ClientSize.Height - spaceY * 2.0f);
            float dW;
            if (Math.Abs(graph1.W - graph2.W) == 0)
                dW = 10.0f;
            else
                dW = (float)Math.Max(Math.PI * 2.0f / Math.Abs(graph1.W - graph2.W) * 1.5f, 0.1f);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            beatingGraph.Draw(e.Graphics, rectangle, zero, 0, -(graph1.A + graph2.A), 0.7f * dW + indent,
                (graph1.A + graph2.A), Color.Purple);
        }

        private void ButtonCheck_Click(object sender, EventArgs e)
        {
            var beatingFrequency = beatingGraph.BeatingFrequency();
            var beatingPeriod = beatingGraph.BeatingPeriod();
            var oscillationPeriod = beatingGraph.OscillationPeriod();

            textBoxBeatingFrequency.Text = beatingFrequency.ToString();
            textBoxOscillationPeriod.Text = oscillationPeriod.ToString();
            textBoxBeatingPeriod.Text = beatingPeriod.ToString();
            textBoxAmplitudeMin.Text = Math.Abs(beatingGraph.A1 - beatingGraph.A2).ToString("0.00");
            textBoxAmplitudeMax.Text = (beatingGraph.A1 + beatingGraph.A2).ToString("0.00");
            //panelMeasurement.Visible = true;
            buttonSave.Enabled = true;

            if ((beatingPeriod > oscillationPeriod * 6) && (graph1.W != graph2.W))
            {
                labelCheckResult.Text = "Система находится в состоянии биений";
                labelCheckResult.ForeColor = Color.Black;
                beatingStatus = "Система находится в состоянии биений";
            }
            else if ((beatingPeriod > oscillationPeriod * 4) && (graph1.W != graph2.W))
            {
                labelCheckResult.Text = "Система находится в состоянии, близкому к состоянию биений";
                labelCheckResult.ForeColor = Color.Black;
                beatingStatus = "Система находится в состоянии, близкому к состоянию биений";
            }
            else
            {
                labelCheckResult.Text = "Система не находится в состоянии биений";
                labelCheckResult.ForeColor = Color.Black;
                beatingStatus = "Система не находится в состоянии биений";
            }
            buttonCheck.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            graph1.DrawLine = false;
            graph2.DrawLine = false;
            beatingGraph.DrawLine = false;
            numericUpDownA1.Value = 1;
            numericUpDownA2.Value = 1;
            numericUpDownW1.Value = 1;
            numericUpDownW2.Value = 1;
            buttonCheck.Enabled = false;
            buttonSave.Enabled = false;
            panelMeasurement.Visible = false;
            panelCanvas1.Invalidate();
            panelCanvas2.Invalidate();
            panelCanvas3.Invalidate();
            labelCheckResult.Text = "";
        }

        private void buttonPredict_Click(object sender, EventArgs e)
        {
            var form = new PredictForm();
            form.ShowDialog();
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            graph1.Resizing = true;
            graph2.Resizing = true;
            beatingGraph.Resizing = true;
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            graph1.Resizing = false;
            graph2.Resizing = false;
            beatingGraph.Resizing = false;
            panelCanvas1.Invalidate();
            panelCanvas2.Invalidate();
            panelCanvas3.Invalidate();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.UTF8))
            //{
            //    //sw.Write(testtext);
            //    sw.Write("W1: " + graph1.W + " W2: " + graph2.W + " " + beatingStatus + "\n");
            //}
            fw.SaveStat(graph1.A.ToString("0.00"), graph2.A.ToString("0.00"), graph1.W.ToString("0.00"), graph2.W.ToString("0.00"), graph1.C.ToString("0.000"), graph2.C.ToString("0.000"), beatingStatus);
            buttonSave.Enabled = false;
        }

        private void buttonStats_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new StatsForm();
                form.ShowDialog();
            }
            catch { MessageBox.Show("Файла с сохраненной статистикой еще нет, сначала сохраните данные об опыте", "Файл не найден"); }
        }
    }
}
