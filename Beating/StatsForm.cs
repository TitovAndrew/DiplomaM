using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Beating
{
    public partial class StatsForm : Form
    {
        string writePath = Environment.CurrentDirectory + "\\stats.sts";
        List<string> all_stats_list = new List<string>();
        FileWorker fw;
        public StatsForm()
        {
            InitializeComponent();
            FillAllStats();
            all_stats_list.Clear();
            fw = new FileWorker();
            foreach (var item in AllStats.Items)
            {
                all_stats_list.Add((string)item);
            }
        }

        void FillAllStats() 
        {
            using (StreamReader fs = new StreamReader(writePath, System.Text.Encoding.UTF8))
            {
                string line;
                //string[] arr_lines;
                while ((line = fs.ReadLine()) != null)
                {
                    all_stats_list.Add(line);
                    Console.WriteLine(line);
                }
                //string[] arr_concepts = concept.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                //for (int i = 0; i < arr_concepts.Length; i++)
                //{
                //    all_stats_list.Add(arr_concepts[i]);
                //}
                UpdateListBox(AllStats, all_stats_list); // Обновляем листобкс

            }
        }

        void UpdateListBox(ListBox listBox, List<string> list)
        {
            //Thread thread = new Thread(SampleThreadMethod);
            //thread.Start();
            try
            {
                for (int i = 0; i < list.Count; i++)
                    listBox.Items.Add(list[i]);
            }
            catch
            {
                MessageBox.Show("Не удалось обновить список");
            }
            //thread.Abort();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            List<string> tmp_list = new List<string>();
            string delete_concept = null; // Понятие, которое будем удалять
            foreach (var item in AllStats.SelectedItems)
            {
                delete_concept = (string)item;
            }
            // Ищем объект в списке и добавляем все остальные в новый список, кроме того, что удаляем
            foreach (var item in all_stats_list)
            {
                if (!delete_concept.Equals(item))
                {
                    tmp_list.Add(item);
                }
            }
            all_stats_list.Clear();
            // Вовзращаем в наш список, теперь не имея удаленного объекта
            foreach (var item in tmp_list)
            {
                all_stats_list.Add(item);
            }
            AllStats.Items.Clear();
            UpdateListBox(AllStats, all_stats_list); // Обновляем листобкс
            buttonDelete.Enabled = false;
        }

        private void AllStats_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            fw.SaveStats(all_stats_list);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            fw.SaveStats(all_stats_list);
            Close();
        }
    }
}
