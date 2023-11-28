using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZhdanovaAA.Sprint5.TaskReview.V22.Lib
{
    public class DataService : ISprint5Task7V22
    {
        public string LoadDataAndSave(string path)
        {
            string pathSaveFile = $@"{Directory.GetCurrentDirectory()}\OutPutDataFileTask7V22.txt";

            FileInfo fileInfo = new FileInfo(pathSaveFile);
            bool fileExists = fileInfo.Exists;

            if (fileExists)
            {
                File.Delete(pathSaveFile);
            }

            string strLine = "";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string sim = ".?!:;,-()";
                    foreach (char c in line)
                    {
                        if (!sim.Contains(c.ToString()))
                        {
                            strLine += c;
                        }
                        else
                        {
                            strLine += "#";
                        }
                    }
                }
                    File.AppendAllText(pathSaveFile, strLine + Environment.NewLine);
                    strLine = "";
            }
            return pathSaveFile;
        }
    }
}
