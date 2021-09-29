
namespace WFClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnParse = new System.Windows.Forms.Button();
            this.gpParseData = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ddlParseURL = new System.Windows.Forms.ComboBox();
            this.gpDataControl = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearching = new System.Windows.Forms.TextBox();
            this.lbInstances = new System.Windows.Forms.ListBox();
            this.txtPageText = new System.Windows.Forms.RichTextBox();
            this.gpParseData.SuspendLayout();
            this.gpDataControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnParse
            // 
            this.btnParse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParse.Location = new System.Drawing.Point(385, 51);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 0;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // gpParseData
            // 
            this.gpParseData.Controls.Add(this.lblStatus);
            this.gpParseData.Controls.Add(this.ddlParseURL);
            this.gpParseData.Controls.Add(this.btnParse);
            this.gpParseData.Location = new System.Drawing.Point(12, 12);
            this.gpParseData.Name = "gpParseData";
            this.gpParseData.Size = new System.Drawing.Size(466, 84);
            this.gpParseData.TabIndex = 1;
            this.gpParseData.TabStop = false;
            this.gpParseData.Text = "Choose the parsing URL";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(6, 51);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(373, 23);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status";
            // 
            // ddlParseURL
            // 
            this.ddlParseURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlParseURL.FormattingEnabled = true;
            this.ddlParseURL.Location = new System.Drawing.Point(6, 22);
            this.ddlParseURL.Name = "ddlParseURL";
            this.ddlParseURL.Size = new System.Drawing.Size(454, 23);
            this.ddlParseURL.TabIndex = 1;
            // 
            // gpDataControl
            // 
            this.gpDataControl.Controls.Add(this.txtPageText);
            this.gpDataControl.Controls.Add(this.label3);
            this.gpDataControl.Controls.Add(this.label2);
            this.gpDataControl.Controls.Add(this.label1);
            this.gpDataControl.Controls.Add(this.txtSearching);
            this.gpDataControl.Controls.Add(this.lbInstances);
            this.gpDataControl.Location = new System.Drawing.Point(12, 102);
            this.gpDataControl.Name = "gpDataControl";
            this.gpDataControl.Size = new System.Drawing.Size(466, 270);
            this.gpDataControl.TabIndex = 2;
            this.gpDataControl.TabStop = false;
            this.gpDataControl.Text = "Parsed data";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(326, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Instances:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(326, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type to search:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Parsed clear text:";
            // 
            // txtSearching
            // 
            this.txtSearching.Location = new System.Drawing.Point(326, 41);
            this.txtSearching.Name = "txtSearching";
            this.txtSearching.Size = new System.Drawing.Size(134, 23);
            this.txtSearching.TabIndex = 2;
            // 
            // lbInstances
            // 
            this.lbInstances.FormattingEnabled = true;
            this.lbInstances.ItemHeight = 15;
            this.lbInstances.Location = new System.Drawing.Point(326, 101);
            this.lbInstances.Name = "lbInstances";
            this.lbInstances.Size = new System.Drawing.Size(134, 154);
            this.lbInstances.TabIndex = 0;
            // 
            // txtPageText
            // 
            this.txtPageText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPageText.Location = new System.Drawing.Point(6, 41);
            this.txtPageText.Name = "txtPageText";
            this.txtPageText.Size = new System.Drawing.Size(314, 214);
            this.txtPageText.TabIndex = 6;
            this.txtPageText.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 384);
            this.Controls.Add(this.gpDataControl);
            this.Controls.Add(this.gpParseData);
            this.Name = "Form1";
            this.Text = "WFClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gpParseData.ResumeLayout(false);
            this.gpDataControl.ResumeLayout(false);
            this.gpDataControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.GroupBox gpParseData;
        private System.Windows.Forms.ComboBox ddlParseURL;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox gpDataControl;
        private System.Windows.Forms.ListBox lbInstances;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearching;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtPageText;
    }
}

