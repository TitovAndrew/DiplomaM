using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BeatingServer
{
    class ServerFileWorker
    {
        string PathToFile = Environment.CurrentDirectory + "\\serverstats.sts";

        public void SaveStats(List<string> all_stats_list)
        {
            File.WriteAllLines(PathToFile, all_stats_list);
        }

        public void SaveStat(string message)
        {
            using (StreamWriter WriteIntoFile = new StreamWriter(PathToFile, true, Encoding.UTF8))
            {
                WriteIntoFile.Write(message + "\n");
            }
        }
    }
}
