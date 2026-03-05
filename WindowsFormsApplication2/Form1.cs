using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox_jsonPath.Text = AppDomain.CurrentDomain.BaseDirectory + "input";
            textBox_FileSorting.Text = textBox_jsonPath.Text;

            if (!Directory.Exists(textBox_jsonPath.Text))
            {
                Directory.CreateDirectory(textBox_jsonPath.Text);
            }
        }

        public class Data
        {
            public string version { get; set; }
            public Flags flags { get; set; }
            public List<Shapes> shapes { get; set; }
            public string imagePath { get; set; }
            public string imageData { get; set; }
            public int imageHeight { get; set; }
            public int imageWidth { get; set; }
        }
        public class Flags{}
        public class Shapes
        {
            public string label { get; set; }
            public List<double[]> points { get; set; }//坐标
            public string group_id { get; set; }
            public string shape_type { get; set; }
            public Flags flags { get; set; }
        }
        //public class Info
        //{
        //    public List<TitleProperty> Title { get; set; } //属性的名字，必须与json格式字符串中的"key"值一样。
        //    public string PreSum { get; set; }
        //    public List<CalculateFeature> CalculateSum { get; set; }//数组处理
        //    public string[] Float { get; set; }//数组处理
        //    public List<RowCells> TableCell;//泛型处理   
        //}
        /// <summary>
        /// 读取并修改txt文件内容
        /// </summary>
        /// <param name="Path">文件地址</param>
        /// <param name="name">文件名</param>
        public bool ReadTxtContent(FileInfo file)
        {
            try
            {
                string Path = file.FullName;
                string name = file.Name;

                StreamReader sr = new StreamReader(Path, Encoding.Default);

                Data data = JsonConvert.DeserializeObject<Data>(sr.ReadToEnd());

                sr.Close();

                //data.imageData = "";//清空不需要的图片base64

                data.imagePath = "rgb.png";//图片路径统一为rgb.png

                if (string.IsNullOrEmpty(textBox_afterLabel.Text))
                {
                    var shapesCopy = data.shapes.ToList();
                    shapesCopy.RemoveAll(o => o.label != textBox_frontLabel.Text); // 删除所有标签为textBox2.Text的元素
                    if(shapesCopy.Count < 1)
                    {
                        log("无有效json" + Path);
                        return false;
                    }
                    else
                    {
                        data.shapes = shapesCopy;
                    }
                }
                else
                {
                    for (int i = 0; i < data.shapes.Count; i++)
                    {
                        if (string.IsNullOrEmpty(textBox_frontLabel.Text))
                        {
                            data.shapes[i].label = textBox_afterLabel.Text;
                        }
                        else if (data.shapes[i].label == textBox_frontLabel.Text)
                        {
                            data.shapes[i].label = textBox_afterLabel.Text;
                        }
                    }
                }

                int a = textBox_jsonPath.Text.Length;//输入的地址
                int b = Path.Length;//文件全地址
                name = Path.Substring(a, b - a);//文件全地址-输入地址

                string DirectoryNameNew = file.DirectoryName.Substring(a, file.DirectoryName.Length - a);//文件父目录-输入地址

                WriteTxt(JsonConvert.SerializeObject(data, Formatting.Indented), name, DirectoryNameNew, file.DirectoryName);
                return true;
            }
            catch(Exception ex)
            {
                log("读取并修改txt文件内容错误：" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 生成修改后文件
        /// </summary>
        /// <param name="content">生成文件的内容</param>
        /// <param name="name">生成文件的文件名</param>
        public static void WriteTxt(string content, string name,string DirectoryNameNew,string DirectoryNameOld)
        {
            string[] parentDirectory = name.Split('\\');
            string sub_path = "";
            for (int i = 0; i < parentDirectory.Length - 1; i++)
            {
                sub_path += parentDirectory[i] + "\\";
            }

            int a = sub_path.Length;
            if(a > 0)
            {
                a--;
            }
            //a = "\\20230812100348470".Length;
            //a = "\\202212061906590000".Length;
            string path = AppDomain.CurrentDomain.BaseDirectory + "output" + name.Substring(0,a);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = path + "\\" + name.Substring(a, name.Length - a);
            if (!System.IO. File.Exists(path))
            {
                FileStream fs = System.IO.File.Create(path);
                fs.Close();
            }
            if (System.IO.File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default);
                sw.WriteLine(content);
                sw.Close();
            }
        }

        public partial class FileGet
        {
            public static List<FileInfo> lst = new List<FileInfo>();
            public static List<string> PathList = new List<string>();
            /// <summary>
            /// 获得目录下所有文件或指定文件类型文件(包含所有子文件夹)
            /// </summary>
            /// <param name="path">文件夹路径</param>
            /// <param name="extName">扩展名可以多个 例如 .mp3.wma.rm</param>
            /// <returns>List<FileInfo></returns>
            public static void getFile(string path, string extName)
            {
                lst.Clear();
                getdir(path, extName);
            }
            /// <summary>
            /// 递归获取指定类型文件,包含子文件夹
            /// </summary>
            /// <param name="path">文件夹路径</param>
            /// <param name="extName">扩展名可以多个 例如 .mp3.wma.rm</param>
            public static void getdir(string path, string extName)
            {
                try
                {
                    string[] dir = Directory.GetDirectories(path); //文件夹列表
                    DirectoryInfo fdir = new DirectoryInfo(path);
                    FileInfo[] file = fdir.GetFiles();
                    //FileInfo[] file = Directory.GetFiles(path); //文件列表
                    if (file.Length != 0 || dir.Length != 0) //当前目录文件或文件夹不为空
                    {
                        foreach (FileInfo f in file) //显示当前目录所有文件
                        {
                            if (string.IsNullOrEmpty(extName))
                            {
                                lst.Add(f);
                            }
                            else if (extName.ToLower().IndexOf(f.Extension.ToLower()) >= 0 && !string.IsNullOrEmpty(f.Extension))
                            {
                                lst.Add(f);
                            }
                        }
                        foreach (string d in dir)
                        {
                            getdir(d, extName);//递归
                        }
                    }
                }
                catch (Exception ex)
                {
                    log("getdir错误：" + ex.Message);
                    throw ex;
                }
            }

            public static void getpath(string path)
            {
                FileGet.PathList.Clear();
                getpath1(path);
            }


            public static void getpath1(string path)
            {
                try
                {
                    //PathList.Add(path);
                    string[] dir = Directory.GetDirectories(path); //文件夹列表
                    DirectoryInfo fdir = new DirectoryInfo(path);
                    FileInfo[] file = fdir.GetFiles();
                    //FileInfo[] file = Directory.GetFiles(path); //文件列表
                    foreach (string d in dir)
                    {
                        PathList.Add(d);
                        getpath1(d);//递归
                    }
                }
                catch (Exception ex)
                {
                    log("getdir错误：" + ex.Message);
                    throw ex;
                }
            }


            /// <summary>
            /// 递归获取指定类型文件,包含子文件夹
            /// </summary>
            /// <param name="path">文件夹路径</param>
            /// <param name="extName">扩展名可以多个 例如 .mp3.wma.rm</param>
            public static void getdirOnlyHere(string path, string extName)
            {
                try
                {
                    string[] dir = Directory.GetDirectories(path); //文件夹列表
                    DirectoryInfo fdir = new DirectoryInfo(path);
                    FileInfo[] file = fdir.GetFiles();
                    //FileInfo[] file = Directory.GetFiles(path); //文件列表
                    if (file.Length != 0 || dir.Length != 0) //当前目录文件或文件夹不为空
                    {
                        foreach (FileInfo f in file) //显示当前目录所有文件
                        {
                            if (string.IsNullOrEmpty(extName))
                            {
                                lst.Add(f);
                            }
                            else if (extName.ToLower().IndexOf(f.Extension.ToLower()) >= 0 && !string.IsNullOrEmpty(f.Extension))
                            {
                                lst.Add(f);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    log("getdir错误：" + ex.Message);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="content">日志内容</param>
        /// <param name="name"></param>
        public static void log(string content, string time = "")
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "log";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (string.IsNullOrEmpty(time))
                path = path + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            else
                path = path + "\\" + time + ".txt";
            if (!System.IO.File.Exists(path))
            {
                FileStream fs = System.IO.File.Create(path);
                fs.Close();
            }
            if (System.IO.File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8);
                sw.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff ") + content);
                sw.Close();
            }
        }

        private void button_jsonRevise_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    jsonRevise();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void jsonRevise()
        {
            FileGet.getFile(textBox_jsonPath.Text, comboBox_fileType.Text);
            int i = 0;
            int error = 0;
            int OK = 0;
            progressBar_jsonRevise.Maximum = FileGet.lst.Count;
            progressBar_jsonRevise.Value = 0;
            foreach (FileInfo file in FileGet.lst)
            {
                if (ReadTxtContent(file))
                    OK++;
                else
                    error++;
                progressBar_jsonRevise.Value++;
                label_log.Text = $"{++i}/{FileGet.lst.Count} 正常文件：{OK} 错误文件：{error}";
            }
            MessageBox.Show("修改结束");
        }
        #region 文件排序
        private void button_FileSorting_Click(object sender, EventArgs e)
        {
            try
            {
                //当前目录下的图片
                DirectoryInfo dir = new DirectoryInfo(textBox_FileSorting.Text);
                FileInfo[] files = dir.GetFiles();
                FileSorting(files);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        void FileSorting(FileInfo[] files)
        {
            Task.Factory.StartNew(() =>
            {
                button_FileSorting.Enabled = false;
                button_FileSorting_AllSubdirectories.Enabled = false;
                progressBar_FileSorting.Maximum = files.Length;
                progressBar_FileSorting.Value = 0;
                DateTime time = DateTime.Now;
                dictionary.Clear();
                foreach (FileInfo file in files)
                {
                    string[] names = file.Name.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    string name = "";
                    if (names.Length > 1)//有文件名和格式
                    {
                        //for (int i = 0; i < names.Length - 1; i++)
                        //{
                        //    name += names[i] + ".";
                        //}
                        //name = name.Remove(name.Length - 1, 1);
                        string suffix = names[names.Length - 1];//后缀
                        if (suffix == "png" || suffix == "PNG" || suffix == "jpg" || suffix == "JPG" || suffix == "jpge" || suffix == "JPGE" || suffix == "json" || suffix == "JSON")
                        {
                            name = file.FullName.Remove(file.FullName.Length - suffix.Length, suffix.Length);
                            if (!dictionary.ContainsKey(name))
                            {
                                dictionary.Add(name, time.ToString("yyyyMMddHHmmssfff"));
                                time = time.AddMilliseconds(1);
                            }
                            string path = AppDomain.CurrentDomain.BaseDirectory + "file" + "\\" + dictionary[name];
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }

                            if (radioButton1.Checked)
                            {
                                //移动文件
                                file.MoveTo(Path.Combine(path, "rgb." + suffix));
                                //file.MoveTo(Path.Combine(path, file.Name));//移动文件
                            }
                            else
                                file.CopyTo(Path.Combine(path, "rgb." + suffix));//复制文件
                        }
                    }
                    progressBar_FileSorting.Value++;
                    label_FileSorting.Text = string.Format("{0}/{1}", progressBar_FileSorting.Value, progressBar_FileSorting.Maximum);
                }
                button_FileSorting.Enabled = true;
                button_FileSorting_AllSubdirectories.Enabled = true;
            });
        }
        #endregion

        private void button_FileSorting_AllSubdirectories_Click(object sender, EventArgs e)
        {
            FileGet.getFile(textBox_FileSorting.Text, ".png.json.jpg.jpge");
            FileSorting(FileGet.lst.ToArray());
        }
    }
}
