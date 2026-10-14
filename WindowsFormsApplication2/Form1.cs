using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2.Services;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private readonly JsonModifier _jsonModifier = new JsonModifier();

        public Form1()
        {
            InitializeComponent();

            textBox_jsonPath.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input");
            textBox_FileSorting.Text = textBox_jsonPath.Text;

            if (!Directory.Exists(textBox_jsonPath.Text))
                Directory.CreateDirectory(textBox_jsonPath.Text);
        }

        private void button_browseJson_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = textBox_jsonPath.Text;
                if (dlg.ShowDialog() == DialogResult.OK)
                    textBox_jsonPath.Text = dlg.SelectedPath;
            }
        }

        private void button_browseFileSorting_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = textBox_FileSorting.Text;
                if (dlg.ShowDialog() == DialogResult.OK)
                    textBox_FileSorting.Text = dlg.SelectedPath;
            }
        }

        private async void button_jsonRevise_Click(object sender, EventArgs e)
        {
            try
            {
                button_jsonRevise.Enabled = false;
                var files = FileHelper.GetFilesRecursively(textBox_jsonPath.Text, comboBox_fileType.Text);
                progressBar_jsonRevise.Maximum = Math.Max(1, files.Count);
                progressBar_jsonRevise.Value = 0;
                label_log.Text = "开始处理...";

                int ok = 0, error = 0, i = 0;
                await Task.Run(() =>
                {
                    foreach (var file in files)
                    {
                        string msg;
                        bool result = _jsonModifier.ProcessJsonFile(file, textBox_jsonPath.Text, textBox_frontLabel.Text?.Trim(), textBox_afterLabel.Text?.Trim(), out msg);
                        if (result) ok++; else error++;
                        i++;
                        this.BeginInvoke(new Action(() =>
                        {
                            progressBar_jsonRevise.Value = Math.Min(progressBar_jsonRevise.Maximum, i);
                            label_log.Text = $"{i}/{files.Count} 正常：{ok} 错误：{error} {(string.IsNullOrEmpty(msg) ? "" : " - " + msg)}";
                        }));
                    }
                });

                MessageBox.Show("修改结束");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                button_jsonRevise.Enabled = true;
            }
        }

        private async void button_FileSorting_Click(object sender, EventArgs e)
        {
            try
            {
                button_FileSorting.Enabled = false;
                var files = FileHelper.GetFilesInDirectory(textBox_FileSorting.Text);
                await Task.Run(() => SortFiles(files.ToArray(), radioButton1.Checked));
                MessageBox.Show("当前目录排序完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                button_FileSorting.Enabled = true;
            }
        }

        private async void button_FileSorting_AllSubdirectories_Click(object sender, EventArgs e)
        {
            try
            {
                button_FileSorting_AllSubdirectories.Enabled = false;
                var files = FileHelper.GetFilesRecursively(textBox_FileSorting.Text, ".png.json.jpg.jpge");
                await Task.Run(() => SortFiles(files.ToArray(), radioButton1.Checked));
                MessageBox.Show("所有子目录排序完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                button_FileSorting_AllSubdirectories.Enabled = true;
            }
        }

        private void SortFiles(FileInfo[] files, bool move)
        {
            try
            {
                this.BeginInvoke(new Action(() =>
                {
                    progressBar_FileSorting.Maximum = files.Length;
                    progressBar_FileSorting.Value = 0;
                }));

                var dictionary = new System.Collections.Generic.Dictionary<string, string>();
                var time = DateTime.Now;

                for (int idx = 0; idx < files.Length; idx++)
                {
                    var file = files[idx];
                    var names = file.Name.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    if (names.Length < 2)
                    {
                        UpdateSortProgress(idx + 1, files.Length);
                        continue;
                    }

                    var suffix = names[names.Length - 1];
                    var lowerSuffix = suffix.ToLower();
                    if (new[] { "png", "jpg", "jpeg", "json" }.Contains(lowerSuffix))
                    {
                        var nameWithoutSuffix = file.FullName.Substring(0, file.FullName.Length - suffix.Length - 1); // -1 for dot
                        if (!dictionary.ContainsKey(nameWithoutSuffix))
                        {
                            dictionary.Add(nameWithoutSuffix, time.ToString("yyyyMMddHHmmssfff"));
                            time = time.AddMilliseconds(1);
                        }
                        var folderName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file", dictionary[nameWithoutSuffix]);
                        if (!Directory.Exists(folderName))
                            Directory.CreateDirectory(folderName);

                        var destFile = Path.Combine(folderName, "rgb." + suffix);
                        try
                        {
                            if (move)
                                file.MoveTo(destFile);
                            else
                                file.CopyTo(destFile, true);
                        }
                        catch (Exception ex)
                        {
                            Logger.Log("SortFiles 文件操作失败: " + ex.Message);
                        }
                    }

                    UpdateSortProgress(idx + 1, files.Length);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("SortFiles 错误: " + ex.Message);
            }
            finally
            {
                this.BeginInvoke(new Action(() =>
                {
                    progressBar_FileSorting.Value = progressBar_FileSorting.Maximum;
                }));
            }
        }

        private void UpdateSortProgress(int current, int total)
        {
            this.BeginInvoke(new Action(() =>
            {
                progressBar_FileSorting.Value = Math.Min(progressBar_FileSorting.Maximum, current);
                label_FileSorting.Text = $"{current}/{total}";
            }));
        }
    }
}
