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
            KeyDown += new KeyEventHandler(Form1_KeyDown);  // Delete 키로 다중 삭제 작업 처리

            Initialize();

            List<Control> controls = new List<Control>() { fileListBox, FileUploadButton, parsingButton, parsingCheckBox, savePathTextBox, selectFileType, label1 };

            AdjustListBoxSizeAndPosition(fileListBox, selectFileType);
            AdjustFontSize(controls);
            Controls.Add(fileListBox);
            Controls.Add(selectFileType);
            fileListBox.DoubleClick += fileListBox_DoubleClick;

            // 이벤트 핸들러에서 폼의 크기 변경에 반응해, 크기 및 위치 조정
            Resize += (sender, e) => AdjustListBoxSizeAndPosition(fileListBox, selectFileType);
            Resize += (sender, e) => AdjustFontSize(controls);
        }

        void SettingForm1(Form form)
        {
            form.Size = new Size(700, 500);
            form.BackColor = Color.LightGray;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "파싱 보조 프로그램 1.11v";
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
            selectFileType.SelectedIndex = 1;
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

            parsingCheckBox.Left = ClientSize.Width * 70 / 100;
            parsingCheckBox.Top = ClientSize.Height * 27 / 100;
            parsingCheckBox.Width = ClientSize.Width * 20 / 100;
            parsingCheckBox.Height = ClientSize.Height * 8 / 100;

            selectFileType.Left = ClientSize.Width * 70 / 100;
            selectFileType.Top = ClientSize.Height * 34 / 100;
            selectFileType.Width = ClientSize.Width * 20 / 100;
            selectFileType.Height = ClientSize.Height * 6 / 100;

            savePathTextBox.Left = ClientSize.Width * 50 / 100;
            savePathTextBox.Top = ClientSize.Height * 90 / 100;
            savePathTextBox.Width = ClientSize.Width * 45 / 100;
            savePathTextBox.Height = ClientSize.Height * 8 / 100;

            label1.Left = ClientSize.Width * 50 / 100;
            label1.Top = ClientSize.Height * 86 / 100;
            label1.Width = ClientSize.Width * 45 / 100;
            label1.Height = ClientSize.Height * 8 / 100;

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
                    case "FileUploadButton": sizeMultiplier = 1; break;
                    case "parsingButton": sizeMultiplier = 1; break;
                    case "parsingCheckBox": sizeMultiplier = 0.86f; break;
                    case "savePathTextBox": sizeMultiplier = 0.78f; break;
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
                Filter = "YAML Files (*.yml)|*.yml|All Files (*.*)|*.*"
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
            Regex regex = new Regex("\"([^\"]*)\"");

            string directoryPath = savePathTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                MessageBox.Show("해당 경로는 존재하지 않는 경로입니다. 다시 설정해주세요.", "경로 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (string filePath in selectedFiles)
            {
                string fileContent = File.ReadAllText(filePath);
                var matches = regex.Matches(fileContent);

                string newFilePath = TestForInsertDirectoryPath(filePath);

                using (StreamWriter writer = new StreamWriter(newFilePath))
                {
                    foreach (Match match in matches)
                    { 
                        string output;
                        if (Settings.IncludeQuotes)
                        {
                            output = Settings.IncludeQuotes ? $"\"{match.Groups[1].Value}\"" : match.Groups[1].Value;
                        } else
                        {
                            output = Settings.IncludeQuotes ? $"{match.Groups[1].Value}" : match.Groups[1].Value;
                        }
                        writer.WriteLine(output);
                    }
                }
            }
        }

        string TestForInsertDirectoryPath(string filePath)
        {
            string directoryPath = savePathTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(directoryPath))
            {
                // 입력한 경로에 새 파일 이름을 추가
                string fileName = Path.GetFileNameWithoutExtension(filePath) + selectFileType.SelectedItem.ToString();
                return Path.Combine(directoryPath, fileName);
            } else
            {
                // 기존 파일 위치에 새 파일 생성
                return Path.ChangeExtension(filePath, selectFileType.SelectedItem.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.IncludeQuotes = !Settings.IncludeQuotes;
        }

        private void savePathTextBox_TextChanged(object sender, EventArgs e)
        {

        }

    }

    public static class Settings
    {
        public static bool IncludeQuotes { get; set; } = false; // 큰 따옴표("") 포함 여부
    }
}
