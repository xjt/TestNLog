namespace TestNLog
{
    partial class Form_Log
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxEx1 = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.SuspendLayout();
            // 
            // richTextBoxEx1
            // 
            this.richTextBoxEx1.BackColorRichTextBox = System.Drawing.SystemColors.InfoText;
            // 
            // 
            // 
            this.richTextBoxEx1.BackgroundStyle.Class = "RichTextBoxBorder";
            this.richTextBoxEx1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.richTextBoxEx1.DetectUrls = false;
            this.richTextBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxEx1.ForeColor = System.Drawing.Color.Chartreuse;
            this.richTextBoxEx1.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n{\\colortbl ;\\red127\\green255\\blue0;}\r\n\\viewkind4\\uc1\\pa" +
    "rd\\cf1\\lang2052\\f0\\fs18\\par\r\n}\r\n";
            this.richTextBoxEx1.Size = new System.Drawing.Size(721, 262);
            this.richTextBoxEx1.TabIndex = 2;
            // 
            // Form_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 262);
            this.Controls.Add(this.richTextBoxEx1);
            this.Name = "Form_Log";
            this.Text = "运行日志";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.RichTextBoxEx richTextBoxEx1;
    }
}