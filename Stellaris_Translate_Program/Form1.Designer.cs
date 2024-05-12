namespace Stellaris_Translate_Program
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FileUploadButton = new System.Windows.Forms.Button();
            this.parsingButton = new System.Windows.Forms.Button();
            this.parsingCheckBox = new System.Windows.Forms.CheckBox();
            this.savePathTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FileUploadButton
            // 
            this.FileUploadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FileUploadButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FileUploadButton.Location = new System.Drawing.Point(544, 39);
            this.FileUploadButton.Name = "FileUploadButton";
            this.FileUploadButton.Size = new System.Drawing.Size(134, 33);
            this.FileUploadButton.TabIndex = 0;
            this.FileUploadButton.Text = "파일 업로드";
            this.FileUploadButton.UseVisualStyleBackColor = true;
            this.FileUploadButton.Click += new System.EventHandler(this.FileUploadButton_Click);
            // 
            // parsingButton
            // 
            this.parsingButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.parsingButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.parsingButton.Location = new System.Drawing.Point(544, 97);
            this.parsingButton.Name = "parsingButton";
            this.parsingButton.Size = new System.Drawing.Size(134, 25);
            this.parsingButton.TabIndex = 1;
            this.parsingButton.Text = "텍스트 파싱";
            this.parsingButton.UseVisualStyleBackColor = true;
            this.parsingButton.Click += new System.EventHandler(this.ParseFileButton_Click);
            // 
            // parsingCheckBox
            // 
            this.parsingCheckBox.AutoSize = true;
            this.parsingCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.parsingCheckBox.Location = new System.Drawing.Point(530, 140);
            this.parsingCheckBox.Name = "parsingCheckBox";
            this.parsingCheckBox.Size = new System.Drawing.Size(150, 19);
            this.parsingCheckBox.TabIndex = 2;
            this.parsingCheckBox.Text = "파싱 시 큰 따옴표 포함";
            this.parsingCheckBox.UseVisualStyleBackColor = true;
            this.parsingCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // savePathTextBox
            // 
            this.savePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savePathTextBox.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.savePathTextBox.Location = new System.Drawing.Point(367, 354);
            this.savePathTextBox.Multiline = true;
            this.savePathTextBox.Name = "savePathTextBox";
            this.savePathTextBox.Size = new System.Drawing.Size(367, 52);
            this.savePathTextBox.TabIndex = 3;
            this.savePathTextBox.TextChanged += new System.EventHandler(this.savePathTextBox_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(367, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "저장 경로";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 418);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savePathTextBox);
            this.Controls.Add(this.parsingCheckBox);
            this.Controls.Add(this.parsingButton);
            this.Controls.Add(this.FileUploadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FileUploadButton;
        private System.Windows.Forms.Button parsingButton;
        private System.Windows.Forms.CheckBox parsingCheckBox;
        private System.Windows.Forms.TextBox savePathTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
    }
}

