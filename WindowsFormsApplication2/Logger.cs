using System;
using System.IO;
using System.Text;

namespace WindowsFormsApplication2.Services
{
    public static class Logger
    {
        public static void Log(string content, string time = "")
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDir, "log");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string filename = string.IsNullOrEmpty(time) ? DateTime.Now.ToString("yyyyMMdd") + ".txt" : time + ".txt";
                string fullPath = Path.Combine(path, filename);

                using (var sw = new StreamWriter(fullPath, true, Encoding.UTF8))
                {
                    sw.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff ") + content);
                }
            }
            catch
            {
                // 不抛出，以免日志失败影响主流程
            }
        }
    }
}