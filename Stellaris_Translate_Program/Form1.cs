using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Stellaris_Translate_Program
{
    public partial class Form1 : Form
    {
        private List<string> selectedFiles = new List<string>(); // 파일의 전체 이름 목록
        private Dictionary<string, string> fileMap = new Dictionary<string, string>(); // 파일명 => 전체 경로
        ListBox fileListBox;
        ComboBox selectFileType;
        float fontSize;

        public Form1()
        {
            InitializeComponent();
            SettingForm1(this);
            KeyPreview = true;  // 폼에서 키보드 이벤트를 미리 보기 위해 설정
            KeyDown += new KeyEventHandler(Form1_KeyDown);  // 이벤트 헨들러
            KeyUp += new KeyEventHandler(Form1_KeyUp);

            Initialize();

            List<Control> controls = new List<Control>() { fileListBox, FileUploadButton, parsingButton, parsingCheckBox, savePathTextBox, selectFileType, label1, savePathTextBox2, label2, useNameCheckBox, combineButton, savePathTextBox3, label3 };

            AdjustListBoxSizeAndPosition(fileListBox, selectFileType);
            AdjustFontSize(controls);
            Controls.Add(fileListBox);
            Controls.Add(selectFileType);
            fileListBox.DoubleClick += fileListBox_DoubleClick;

            // 이벤트 핸들러에서 폼의 크기 변경에 반응해, 크기 및 위치 조정
            Resize += (sender, e) => Form1_Resize(sender, e, controls);

            // 이벤트 핸들러 추가
            savePathTextBox.Click += new EventHandler(savePathTextBox_Click);
            savePathTextBox2.Click += new EventHandler(savePathTextBox2_Click);
            savePathTextBox3.Click += new EventHandler(savePathTextBox3_Click);
        }
        private void Form1_Resize(object sender, EventArgs e, List<Control> controls)
        {
            // 폼이 최소화되었는지 확인
            if (WindowState == FormWindowState.Minimized)
            {
                return;
            }

            AdjustListBoxSizeAndPosition(fileListBox, selectFileType);
            AdjustFontSize(controls);
        }

        void SettingForm1(Form form)
        {
            form.Size = new Size(700, 550);
            form.BackColor = Color.LightGray;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "파싱 보조 프로그램 1.2v";
        }
        void Initialize()
        {
            fileListBox = new ListBox
            {
                Name = "fileListBox",
                SelectionMode = SelectionMode.MultiExtended,
            };

            selectFileType = new ComboBox
            {
                Name = "selectFileType",
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new System.Drawing.Point(10, 10)
            };
            selectFileType.Items.AddRange(new string[] { ".yml", ".txt" });
            selectFileType.SelectedIndex = 0;
        }
                void UIThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // 예외 처리 로직
            MessageBox.Show("예기치 않은 오류가 발생했습니다: " + e.Exception.Message, "오류. khsopop00@gmail.com << 이 주소로 개발자에게 문의 해 주세요.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ListBox fileListBox = Controls.OfType<ListBox>().FirstOrDefault(x => x.Name == "fileListBox");
                if (fileListBox != null && fileListBox.SelectedItems.Count > 0)
                {
                    var itemsToRemove = fileListBox.SelectedItems.Cast<string>().ToList();
                    foreach (var item in itemsToRemove)
                    {
                        fileListBox.Items.Remove(item);
                        selectedFiles.Remove(fileMap[item]);
                    }
                }
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                FileUploadButton.Text = "파일 추가";
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                FileUploadButton.Text = "파일 업로드";
            }
        }

        private void AdjustListBoxSizeAndPosition(ListBox listBox, ComboBox selectFileType)
        {
            listBox.Left = ClientSize.Width * 5 / 100;
            listBox.Top = ClientSize.Height * 5 / 100;
            listBox.Width = ClientSize.Width * 40 / 100;
            listBox.Height = ClientSize.Height * 93 / 100;

            FileUploadButton.Left = ClientSize.Width * 70 / 100;
            FileUploadButton.Top = ClientSize.Height * 5 / 100;
            FileUploadButton.Width = ClientSize.Width * 20 / 100;
            FileUploadButton.Height = ClientSize.Height * 8 / 100;

            parsingButton.Left = ClientSize.Width * 70 / 100;
            parsingButton.Top = ClientSize.Height * 16 / 100;
            parsingButton.Width = ClientSize.Width * 20 / 100;
            parsingButton.Height = ClientSize.Height * 8 / 100;

            combineButton.Left = ClientSize.Width * 70 / 100;
            combineButton.Top = ClientSize.Height * 48 / 100;
            combineButton.Width = ClientSize.Width * 20 / 100;
            combineButton.Height = ClientSize.Height * 8 / 100;

            parsingCheckBox.Left = ClientSize.Width * 70 / 100;
            parsingCheckBox.Top = ClientSize.Height * 27 / 100;
            parsingCheckBox.Width = ClientSize.Width * 20 / 100;
            parsingCheckBox.Height = ClientSize.Height * 8 / 100;

            useNameCheckBox.Left = ClientSize.Width * 70 / 100;
            useNameCheckBox.Top = ClientSize.Height * 34 / 100;
            useNameCheckBox.Width = ClientSize.Width * 20 / 100;
            useNameCheckBox.Height = ClientSize.Height * 8 / 100;

            selectFileType.Left = ClientSize.Width * 70 / 100;
            selectFileType.Top = ClientSize.Height * 40 / 100;
            selectFileType.Width = ClientSize.Width * 20 / 100;
            selectFileType.Height = ClientSize.Height * 6 / 100;

            savePathTextBox.Left = ClientSize.Width * 50 / 100;
            savePathTextBox.Top = ClientSize.Height * 90 / 100;
            savePathTextBox.Width = ClientSize.Width * 45 / 100;
            savePathTextBox.Height = ClientSize.Height * 8 / 100;

            savePathTextBox2.Left = ClientSize.Width * 50 / 100;
            savePathTextBox2.Top = ClientSize.Height * 76 / 100;
            savePathTextBox2.Width = ClientSize.Width * 45 / 100;
            savePathTextBox2.Height = ClientSize.Height * 8 / 100;

            savePathTextBox3.Left = ClientSize.Width * 50 / 100;
            savePathTextBox3.Top = ClientSize.Height * 62 / 100;
            savePathTextBox3.Width = ClientSize.Width * 45 / 100;
            savePathTextBox3.Height = ClientSize.Height * 8 / 100;

            label1.Left = ClientSize.Width * 50 / 100;
            label1.Top = ClientSize.Height * 86 / 100;
            label1.Width = ClientSize.Width * 45 / 100;
            label1.Height = ClientSize.Height * 8 / 100;

            label2.Left = ClientSize.Width * 50 / 100;
            label2.Top = ClientSize.Height * 72 / 100;
            label2.Width = ClientSize.Width * 45 / 100;
            label2.Height = ClientSize.Height * 8 / 100;

            label3.Left = ClientSize.Width * 50 / 100;
            label3.Top = ClientSize.Height * 58 / 100;
            label3.Width = ClientSize.Width * 45 / 100;
            label3.Height = ClientSize.Height * 8 / 100;
        }

        void AdjustFontSize(List<Control> controlsToResize)
        {
            fontSize = Math.Min(ClientSize.Width / 50, ClientSize.Height / 40);
            foreach (Control ctrl in controlsToResize)
            {
                float sizeMultiplier;
                switch (ctrl.Name)
                {
                    case "fileListBox": sizeMultiplier = 0.78f; break;
                    case "combineButton": sizeMultiplier = 1f; break;
                    case "FileUploadButton": sizeMultiplier = 1; break;
                    case "parsingButton": sizeMultiplier = 1; break;
                    case "useNameCheckBox": sizeMultiplier = 0.72f; break;
                    case "parsingCheckBox": sizeMultiplier = 0.86f; break;
                    case "savePathTextBox": sizeMultiplier = 0.78f; break;
                    case "savePathTextBox2": sizeMultiplier = 0.78f; break;
                    case "savePathTextBox3": sizeMultiplier = 0.78f; break;
                    case "selectFileType": sizeMultiplier = 0.86f; break;
                    default: sizeMultiplier = 0.8f; break;
                }
                ctrl.Font = new Font(ctrl.Font.FontFamily, fontSize * sizeMultiplier, ctrl.Font.Style);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void fileListBox_DoubleClick(object sender, EventArgs e)
        {
            // 선택된 항목을 삭제
            ListBox fileListBox = sender as ListBox;
            if (fileListBox != null && fileListBox.SelectedItem != null)
            {
                string selectedItem = fileListBox.SelectedItem.ToString();
                fileListBox.Items.Remove(selectedItem);
                selectedFiles.Remove(fileMap[selectedItem]);
            }
        }

        private void FileUploadButton_Click(object sender, EventArgs e)
        {
            bool isShiftPressed = (ModifierKeys & Keys.Shift) == Keys.Shift;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "All Files (*.*)|*.*|YAML Files (*.yml)|*.yml"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Shift 키를 누르지 않은 상태로 버튼을 클릭했고, 파일을 열 때도 Shift 키를 누르지 않았다면, 목록 초기화. 
                if (!isShiftPressed && (ModifierKeys & Keys.Shift) != Keys.Shift)
                {
                    selectedFiles.Clear();
                    ListBox fileListBox = Controls.OfType<ListBox>().FirstOrDefault(x => x.Name == "fileListBox");
                    fileListBox?.Items.Clear();
                    fileMap.Clear();
                }

                foreach (string filePath in openFileDialog.FileNames)
                {
                    if (!selectedFiles.Contains(filePath)) // 중복 검사
                    {
                        selectedFiles.Add(filePath);
                        ListBox fileListBox = Controls.OfType<ListBox>().FirstOrDefault(x => x.Name == "fileListBox");

                        string fileName = Path.GetFileName(filePath); // 전체 경로에서 파일명만 추출
                        fileListBox.Items.Add(fileName); // 파일명만 ListBox에 추가
                        fileMap[fileName] = filePath;
                    }
                }
            }
        }
        private void ParseFileButton_Click(object sender, EventArgs e)
        {
            if (selectedFiles.Count == 0)
            {
                MessageBox.Show("파싱할 파일이 존재하지 않습니다.", "파일이 없음", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string directoryPath1 = savePathTextBox.Text.Trim();
            string directoryPath2 = savePathTextBox2.Text.Trim();

            if (string.IsNullOrEmpty(directoryPath1) || (Settings.MakeNameFile && string.IsNullOrEmpty(directoryPath2)))
            {
                DialogResult result = MessageBox.Show("경로가 비어있습니다. 동일한 위치에 파일을 생성하시겠습니까?", "경고!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                if (string.IsNullOrEmpty(directoryPath1))
                {
                    directoryPath1 = Path.GetDirectoryName(selectedFiles.First());
                }
                if (Settings.MakeNameFile && string.IsNullOrEmpty(directoryPath2))
                {
                    directoryPath2 = Path.GetDirectoryName(selectedFiles.First());
                }
            }

            int successCount = 0;
            int errorCount = 0;

            foreach (string filePath in selectedFiles)
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    List<string> extractedTexts = new List<string>();
                    List<string> precedingTexts = new List<string>();

                    foreach (string line in lines)
                    {
                        int firstQuotePos = line.IndexOf('\"');
                        if (firstQuotePos != -1)
                        {
                            // 첫 번째 따옴표부터 끝까지 문자열 추출
                            string extractedText = line.Substring(firstQuotePos);
                            extractedTexts.Add(extractedText);

                            // 첫 번째 따옴표 앞의 문자열 추출
                            string precedingText = line.Substring(0, firstQuotePos).Trim();
                            precedingTexts.Add(precedingText);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(TestForInsertDirectoryPath(filePath, directoryPath1, false)))
                    {
                        foreach (string text in extractedTexts)
                        {
                            string output = Settings.IncludeQuotes ? text : text.Trim('"'); // IncludeQuotes 설정에 따라 따옴표 포함 여부 결정
                            writer.WriteLine(output);
                        }
                    }

                    if (Settings.MakeNameFile)
                    {
                        using (StreamWriter writer = new StreamWriter(TestForInsertDirectoryPath(filePath, directoryPath2, true)))
                        {
                            foreach (string precedingText in precedingTexts)
                            {
                                writer.WriteLine(precedingText);
                            }
                        }
                    }

                    successCount++;
                } catch (Exception ex)
                {
                    MessageBox.Show($"파일을 파싱하는 중 오류가 발생했습니다: {Path.GetFileName(filePath)}\n{ex.Message}", "파싱 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorCount++;
                }
            }

            if (errorCount > 0)
            {
                MessageBox.Show($"{successCount}개의 파일이 성공적으로 파싱되었습니다.\n{errorCount}개의 파일에서 오류가 발생했습니다.", "파싱 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show($"{successCount}개의 파일이 성공적으로 파싱되었습니다.", "파싱 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        string TestForInsertDirectoryPath(string filePath, string directoryPath, bool isPreceding)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath) + (isPreceding ? ".precedingTexts" : "") + selectFileType.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(directoryPath))
            {
                return Path.Combine(directoryPath, fileName);
            } else
            {
                return Path.Combine(Path.GetDirectoryName(filePath), fileName);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.IncludeQuotes = !Settings.IncludeQuotes;
        }

        private void useNameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.MakeNameFile = !Settings.MakeNameFile;
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void savePathTextBox_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    savePathTextBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void savePathTextBox2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    savePathTextBox2.Text = fbd.SelectedPath;
                }
            }
        }

        private void savePathTextBox3_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    savePathTextBox3.Text = fbd.SelectedPath;
                }
            }
        }

        private void combineButton_Click(object sender, EventArgs e)
        {
            string targetDirectory = savePathTextBox3.Text.Trim();
            string selectedFileType = selectFileType.SelectedItem.ToString();

            if (string.IsNullOrEmpty(targetDirectory))
            {
                MessageBox.Show("결합된 파일을 저장할 경로를 입력해주세요.", "경로 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(targetDirectory))
            {
                try
                {
                    Directory.CreateDirectory(targetDirectory);
                } catch (Exception ex)
                {
                    MessageBox.Show($"올바르지 않은 경로입니다: {ex.Message}", "경로 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var fileGroups = selectedFiles.GroupBy(file => Path.GetFileNameWithoutExtension(file).Replace(".precedingTexts", ""))
                                           .Where(group => group.Count() == 2)
                                           .ToList();

            int isSuccessCombine = 0;
            foreach (var group in fileGroups)
            {
                var originalFile = group.FirstOrDefault(file => !file.Contains(".precedingTexts"));
                var precedingFile = group.FirstOrDefault(file => file.Contains(".precedingTexts"));

                if (originalFile != null && precedingFile != null)
                {
                    string[] contentLines = File.ReadAllLines(originalFile);
                    string[] precedingLines = File.ReadAllLines(precedingFile);

                    if (contentLines.Length != precedingLines.Length)
                    {
                        MessageBox.Show($"파일 행의 길이가 일치하지 않습니다: {Path.GetFileName(originalFile)}", "결합 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    string combinedFilePath = Path.Combine(targetDirectory, Path.GetFileNameWithoutExtension(originalFile) + selectedFileType);
                    using (StreamWriter writer = new StreamWriter(combinedFilePath))
                    {
                        writer.WriteLine("l_korean:"); // 첫 번째 줄에 추가
                        for (int i = 0; i < contentLines.Length; i++)
                        {
                            writer.WriteLine($"{precedingLines[i]} {contentLines[i]}");
                        }
                    }
                    isSuccessCombine++;
                }
            }
            if (isSuccessCombine > 0)
            {

                MessageBox.Show($"{isSuccessCombine}개의 파일이 성공적으로 결합되었습니다.", "결합 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show($"결합할 파일이 없습니다.", "결합 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public static class Settings
    {
        public static bool IncludeQuotes { get; set; } = false; // 큰 따옴표("") 포함 여부
        public static bool MakeNameFile { get; set; } = false; // 이름만 정렬한 파일을 생성할 지 여부
    }
}
