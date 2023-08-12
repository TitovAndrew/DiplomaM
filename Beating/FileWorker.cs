using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Beating
{
    class FileWorker
    {
        string PathToFile = Environment.CurrentDirectory + "\\stats.sts";
        
        public void SaveStats(List<string> all_stats_list)
        {
            File.WriteAllLines(PathToFile, all_stats_list);
        }
        
        public void SaveStat(string a1, string a2, string w1, string w2, string c1, string c2, string beatingStatus)
        {
            using (StreamWriter WriteIntoFile = new StreamWriter(PathToFile, true, Encoding.UTF8))
            {
                WriteIntoFile.Write("A1: " + a1 + "     A2: " + a2 + "     W1: " + w1 + "     W2: " + w2 + "     C1: " + c1 + "     C1: " + c2 + "     " + beatingStatus + "\n");
            }
        }
    }
}
