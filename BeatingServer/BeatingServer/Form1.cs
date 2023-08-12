using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace BeatingServer
{
    public partial class Form1 : Form
    {
        private Thread trd;
        ServerFileWorker fileworker;
        Socket tcpListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form1()
        {
            InitializeComponent();
            fileworker = new ServerFileWorker();
            //try
            //{
            //    tcpListener.Bind(new IPEndPoint(IPAddress.Any, 8888));
            //    tcpListener.Listen(10);    // запускаем сервер
            //    Console.WriteLine("Сервер запущен. Ожидание подключений... ");
            //    textBoxStats.AppendText("Сервер запущен. Ожидание подключений..." + Environment.NewLine);
            //    //textBoxStats.Text += "Сервер запущен. Ожидание подключений...2 ";

            //    //while (true)
            //    //{
            //    //    // получаем подключение в виде TcpClient
            //    //    var tcpClient = tcpListener.Accept();

            //    //    // буфер для накопления входящих данных
            //    //    var buffer = new List<byte>();
            //    //    // буфер для считывания одного байта
            //    //    var bytesRead = new byte[1];
            //    //    // считываем данные до конечного символа
            //    //    while (true)
            //    //    {
            //    //        while (true)
            //    //        {
            //    //            var count = tcpClient.Receive(bytesRead);
            //    //            // смотрим, если считанный байт представляет конечный символ, выходим
            //    //            if (count == 0 || bytesRead[0] == '\n') break;
            //    //            // иначе добавляем в буфер
            //    //            buffer.Add(bytesRead[0]);
            //    //        }
            //    //        var message = Encoding.UTF8.GetString(buffer.ToArray());
            //    //        // если прислан маркер окончания взаимодействия,
            //    //        // выходим из цикла и завершаем взаимодействие с клиентом
            //    //        if (message == "END") break;
            //    //        Console.WriteLine($"Получено сообщение: {message}");
            //    //        textBoxStats.Text = $"Получено сообщение: {message}";
            //    //        buffer.Clear();
            //    //    }
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
        private void ThreadTask()
        {

            //int stp;
            //int newval;
            //Random rnd = new Random();
            try
            {
                tcpListener.Bind(new IPEndPoint(IPAddress.Any, 8888));
                tcpListener.Listen(10);    // запускаем сервер
                Console.WriteLine("Сервер запущен");
                Invoke(new MethodInvoker(delegate { textBoxStats.AppendText("Сервер запущен"  + Environment.NewLine); }));
                //textBoxStats.AppendText("Сервер запущен. Ожидание подключений..." + Environment.NewLine);
                while (true)
                {
                    // получаем подключение в виде TcpClient
                    var tcpClient = tcpListener.Accept();

                    // буфер для накопления входящих данных
                    var buffer = new List<byte>();
                    // буфер для считывания одного байта
                    var bytesRead = new byte[1];
                    // считываем данные до конечного символа
                    while (true)
                    {
                        while (true)
                        {
                            var count = tcpClient.Receive(bytesRead);
                            // смотрим, если считанный байт представляет конечный символ, выходим
                            if (count == 0 || bytesRead[0] == '\n') break;
                            // иначе добавляем в буфер
                            buffer.Add(bytesRead[0]);
                            Thread.Sleep(10);
                        }
                        var message = Encoding.UTF8.GetString(buffer.ToArray());
                        // если прислан маркер окончания взаимодействия,
                        // выходим из цикла и завершаем взаимодействие с клиентом
                        if (message == "END") break;
                        Console.WriteLine($"Получены данные: {message}");
                        Invoke(new MethodInvoker(delegate { textBoxStats.AppendText("Получены данные: " + message + Environment.NewLine); }));

                        fileworker.SaveStat(message);
                        //textBoxStats.AppendText("Получено сообщение: " + message + Environment.NewLine); ;
                        buffer.Clear();
                        Thread.Sleep(10);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //while (true)
            //{
            //    stp = this.progressBar1.Step * rnd.Next(-1, 2);
            //    newval = this.progressBar1.Value + stp;
            //    if (newval > this.progressBar1.Maximum)
            //        newval = this.progressBar1.Maximum;
            //    else if (newval < this.progressBar1.Minimum)
            //        newval = this.progressBar1.Minimum;
            //    this.progressBar1.Value = newval;
            //    Thread.Sleep(100);
            //}
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            Thread trd = new Thread(new ThreadStart(this.ThreadTask));
            trd.IsBackground = true;
            trd.Start();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxStats.Text = "";
        }

        private void buttonOpenStats_Click(object sender, EventArgs e)
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
