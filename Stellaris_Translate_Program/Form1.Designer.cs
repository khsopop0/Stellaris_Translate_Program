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
            this.savePathTextBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.useNameCheckBox = new System.Windows.Forms.CheckBox();
            this.combineButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.savePathTextBox3 = new System.Windows.Forms.TextBox();
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
            this.savePathTextBox.Location = new System.Drawing.Point(367, 372);
            this.savePathTextBox.Multiline = true;
            this.savePathTextBox.Name = "savePathTextBox";
            this.savePathTextBox.Size = new System.Drawing.Size(313, 34);
            this.savePathTextBox.TabIndex = 3;
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
            this.label1.Location = new System.Drawing.Point(364, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "저장 경로 (내용 파일)";
            // 
            // savePathTextBox2
            // 
            this.savePathTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savePathTextBox2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.savePathTextBox2.Location = new System.Drawing.Point(367, 305);
            this.savePathTextBox2.Multiline = true;
            this.savePathTextBox2.Name = "savePathTextBox2";
            this.savePathTextBox2.Size = new System.Drawing.Size(311, 36);
            this.savePathTextBox2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(364, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "저장 경로 (이름 파일)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // useNameCheckBox
            // 
            this.useNameCheckBox.AutoSize = true;
            this.useNameCheckBox.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.useNameCheckBox.Location = new System.Drawing.Point(530, 178);
            this.useNameCheckBox.Name = "useNameCheckBox";
            this.useNameCheckBox.Size = new System.Drawing.Size(174, 16);
            this.useNameCheckBox.TabIndex = 7;
            this.useNameCheckBox.Text = "파싱 시 이름 파일을 별도로 저장";
            this.useNameCheckBox.UseVisualStyleBackColor = true;
            this.useNameCheckBox.CheckedChanged += new System.EventHandler(this.useNameCheckBox_CheckedChanged);
            // 
            // combineButton
            // 
            this.combineButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.combineButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.combineButton.Location = new System.Drawing.Point(530, 211);
            this.combineButton.Name = "combineButton";
            this.combineButton.Size = new System.Drawing.Size(134, 33);
            this.combineButton.TabIndex = 8;
            this.combineButton.Text = "파일 결합";
            this.combineButton.UseVisualStyleBackColor = true;
            this.combineButton.Click += new System.EventHandler(this.combineButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(364, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "저장 경로 (결합 파일)";
            // 
            // savePathTextBox3
            // 
            this.savePathTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savePathTextBox3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.savePathTextBox3.Location = new System.Drawing.Point(367, 248);
            this.savePathTextBox3.Multiline = true;
            this.savePathTextBox3.Name = "savePathTextBox3";
            this.savePathTextBox3.Size = new System.Drawing.Size(311, 36);
            this.savePathTextBox3.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 418);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.savePathTextBox3);
            this.Controls.Add(this.combineButton);
            this.Controls.Add(this.useNameCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.savePathTextBox2);
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
        private System.Windows.Forms.TextBox savePathTextBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox useNameCheckBox;
        private System.Windows.Forms.Button combineButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox savePathTextBox3;
    }
}

