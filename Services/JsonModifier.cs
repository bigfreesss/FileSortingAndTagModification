using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2.Services
{
    public class JsonModifier
    {
        public class Data
        {
            public string version { get; set; }
            public object flags { get; set; }
            public List<Shape> shapes { get; set; }
            public string imagePath { get; set; }
            public string imageData { get; set; }
            public int imageHeight { get; set; }
            public int imageWidth { get; set; }
        }

        public class Shape
        {
            public string label { get; set; }
            public List<double[]> points { get; set; }
            public string group_id { get; set; }
            public string shape_type { get; set; }
            public object flags { get; set; }
        }

        /// <summary>
        /// 处理单个 json 文件：替换标签或提纯标签，并写入 output 根目录下同相对路径
        /// </summary>
        public bool ProcessJsonFile(FileInfo file, string inputRoot, string frontLabel, string afterLabel, out string message)
        {
            message = null;
            try
            {
                if (file == null || !file.Exists)
                {
                    message = "文件不存在";
                    return false;
                }

                string content;
                using (var sr = new StreamReader(file.FullName, Encoding.Default))
                {
                    content = sr.ReadToEnd();
                }

                var data = JsonConvert.DeserializeObject<Data>(content);
                if (data == null)
                {
                    message = "无法解析 JSON";
                    return false;
                }

                // 统一 imagePath 并清理 imageData
                data.imagePath = "rgb.png";
                // data.imageData = null; // 如需要可清空

                if (string.IsNullOrEmpty(afterLabel))
                {
                    // 提纯：保留 label == frontLabel 的 shapes
                    var shapesCopy = data.shapes?.Where(s => string.Equals(s.label, frontLabel, StringComparison.Ordinal)).ToList() ?? new List<Shape>();
                    if (shapesCopy.Count < 1)
                    {
                        message = "无有效 json 内容";
                        return false;
                    }
                    data.shapes = shapesCopy;
                }
                else
                {
                    // 重命名：当 frontLabel 为空则全部改名，否则只替换匹配项
                    if (data.shapes != null)
                    {
                        foreach (var s in data.shapes)
                        {
                            if (string.IsNullOrEmpty(frontLabel) || string.Equals(s.label, frontLabel, StringComparison.Ordinal))
                                s.label = afterLabel;
                        }
                    }
                }

                // 计算相对路径并写入 output 文件夹
                inputRoot = FileHelper.EnsureTrailingSeparator(inputRoot ?? "");
                string relative = FileHelper.SafeRelativePath(file.FullName, inputRoot);
                string outBase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
                string outFullPath = Path.Combine(outBase, relative);
                string outDir = Path.GetDirectoryName(outFullPath);
                if (!Directory.Exists(outDir))
                    Directory.CreateDirectory(outDir);

                string jsonOut = JsonConvert.SerializeObject(data, Formatting.Indented);
                using (var sw = new StreamWriter(outFullPath, false, Encoding.Default))
                {
                    sw.Write(jsonOut);
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("ProcessJsonFile 错误：" + ex.Message);
                message = ex.Message;
                return false;
            }
        }
    }
}