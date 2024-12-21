namespace Lab_1
{
    partial class FormLab1
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
            this.pictureBoxInput = new System.Windows.Forms.PictureBox();
            this.pictureBoxOutput = new System.Windows.Forms.PictureBox();
            this.splitContainerPictures = new System.Windows.Forms.SplitContainer();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.panelMatrix = new System.Windows.Forms.Panel();
            this.buttonSobel = new System.Windows.Forms.Button();
            this.buttonLowPassFilter2 = new System.Windows.Forms.Button();
            this.buttonLowPassFilter1 = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonCount = new System.Windows.Forms.Button();
            this.panelParams = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox02 = new System.Windows.Forms.TextBox();
            this.textBox00 = new System.Windows.Forms.TextBox();
            this.textBox01 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBoxDenominator = new System.Windows.Forms.TextBox();
            this.textBoxNumerator = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPictures)).BeginInit();
            this.splitContainerPictures.Panel1.SuspendLayout();
            this.splitContainerPictures.Panel2.SuspendLayout();
            this.splitContainerPictures.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMatrix.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxInput
            // 
            this.pictureBoxInput.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxInput.Name = "pictureBoxInput";
            this.pictureBoxInput.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxInput.TabIndex = 0;
            this.pictureBoxInput.TabStop = false;
            // 
            // pictureBoxOutput
            // 
            this.pictureBoxOutput.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxOutput.Name = "pictureBoxOutput";
            this.pictureBoxOutput.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxOutput.TabIndex = 2;
            this.pictureBoxOutput.TabStop = false;
            // 
            // splitContainerPictures
            // 
            this.splitContainerPictures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainerPictures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerPictures.Location = new System.Drawing.Point(12, 279);
            this.splitContainerPictures.Name = "splitContainerPictures";
            // 
            // splitContainerPictures.Panel1
            // 
            this.splitContainerPictures.Panel1.Controls.Add(this.pictureBoxInput);
            // 
            // splitContainerPictures.Panel2
            // 
            this.splitContainerPictures.Panel2.Controls.Add(this.pictureBoxOutput);
            this.splitContainerPictures.Size = new System.Drawing.Size(1493, 529);
            this.splitContainerPictures.SplitterDistance = 746;
            this.splitContainerPictures.TabIndex = 3;
            // 
            // panelToolbar
            // 
            this.panelToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.panelToolbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelToolbar.Controls.Add(this.panel1);
            this.panelToolbar.Controls.Add(this.panelMatrix);
            this.panelToolbar.Controls.Add(this.panelButtons);
            this.panelToolbar.Controls.Add(this.panelParams);
            this.panelToolbar.Location = new System.Drawing.Point(12, 12);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(1492, 256);
            this.panelToolbar.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelInfo);
            this.panel1.Controls.Add(this.labelResult);
            this.panel1.Location = new System.Drawing.Point(972, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 210);
            this.panel1.TabIndex = 6;
            // 
            // labelInfo
            // 
            this.labelInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.labelInfo.Location = new System.Drawing.Point(27, 41);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(86, 32);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "—";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResult
            // 
            this.labelResult.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.labelResult.Location = new System.Drawing.Point(27, 9);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(86, 32);
            this.labelResult.TabIndex = 0;
            this.labelResult.Text = "Result:";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMatrix
            // 
            this.panelMatrix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.panelMatrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMatrix.Controls.Add(this.buttonSobel);
            this.panelMatrix.Controls.Add(this.buttonLowPassFilter2);
            this.panelMatrix.Controls.Add(this.buttonLowPassFilter1);
            this.panelMatrix.Location = new System.Drawing.Point(483, 28);
            this.panelMatrix.Name = "panelMatrix";
            this.panelMatrix.Size = new System.Drawing.Size(477, 129);
            this.panelMatrix.TabIndex = 5;
            // 
            // buttonSobel
            // 
            this.buttonSobel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.buttonSobel.Font = new System.Drawing.Font("Arial", 9F);
            this.buttonSobel.Location = new System.Drawing.Point(334, 6);
            this.buttonSobel.Name = "buttonSobel";
            this.buttonSobel.Size = new System.Drawing.Size(127, 35);
            this.buttonSobel.TabIndex = 4;
            this.buttonSobel.Text = "Sobel";
            this.buttonSobel.UseVisualStyleBackColor = false;
            this.buttonSobel.Click += new System.EventHandler(this.buttonSobel_Click);
            // 
            // buttonLowPassFilter2
            // 
            this.buttonLowPassFilter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.buttonLowPassFilter2.Font = new System.Drawing.Font("Arial", 9F);
            this.buttonLowPassFilter2.Location = new System.Drawing.Point(178, 6);
            this.buttonLowPassFilter2.Name = "buttonLowPassFilter2";
            this.buttonLowPassFilter2.Size = new System.Drawing.Size(127, 35);
            this.buttonLowPassFilter2.TabIndex = 3;
            this.buttonLowPassFilter2.Text = "Low-Pass 2";
            this.buttonLowPassFilter2.UseVisualStyleBackColor = false;
            this.buttonLowPassFilter2.Click += new System.EventHandler(this.buttonLowPassFilter2_Click);
            // 
            // buttonLowPassFilter1
            // 
            this.buttonLowPassFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.buttonLowPassFilter1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLowPassFilter1.Location = new System.Drawing.Point(18, 6);
            this.buttonLowPassFilter1.Name = "buttonLowPassFilter1";
            this.buttonLowPassFilter1.Size = new System.Drawing.Size(127, 35);
            this.buttonLowPassFilter1.TabIndex = 2;
            this.buttonLowPassFilter1.Text = "Low-Pass 1";
            this.buttonLowPassFilter1.UseVisualStyleBackColor = false;
            this.buttonLowPassFilter1.Click += new System.EventHandler(this.buttonLowPassFilter1_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtons.Controls.Add(this.buttonClear);
            this.panelButtons.Controls.Add(this.buttonSave);
            this.panelButtons.Controls.Add(this.buttonLoad);
            this.panelButtons.Controls.Add(this.buttonCount);
            this.panelButtons.Location = new System.Drawing.Point(483, 174);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(477, 65);
            this.panelButtons.TabIndex = 4;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.buttonClear.Font = new System.Drawing.Font("Arial", 9F);
            this.buttonClear.Location = new System.Drawing.Point(133, 14);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(98, 35);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.buttonSave.Font = new System.Drawing.Font("Arial", 9F);
            this.buttonSave.Location = new System.Drawing.Point(363, 14);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(98, 35);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.buttonLoad.Font = new System.Drawing.Font("Arial", 9F);
            this.buttonLoad.Location = new System.Drawing.Point(18, 14);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(98, 35);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonCount
            // 
            this.buttonCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.buttonCount.Font = new System.Drawing.Font("Arial", 9F);
            this.buttonCount.Location = new System.Drawing.Point(249, 14);
            this.buttonCount.Name = "buttonCount";
            this.buttonCount.Size = new System.Drawing.Size(98, 35);
            this.buttonCount.TabIndex = 2;
            this.buttonCount.Text = "Count";
            this.buttonCount.UseVisualStyleBackColor = false;
            this.buttonCount.Click += new System.EventHandler(this.buttonCount_Click);
            // 
            // panelParams
            // 
            this.panelParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.panelParams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelParams.Controls.Add(this.label3);
            this.panelParams.Controls.Add(this.label2);
            this.panelParams.Controls.Add(this.textBox22);
            this.panelParams.Controls.Add(this.textBox20);
            this.panelParams.Controls.Add(this.textBox21);
            this.panelParams.Controls.Add(this.textBox02);
            this.panelParams.Controls.Add(this.textBox00);
            this.panelParams.Controls.Add(this.textBox01);
            this.panelParams.Controls.Add(this.textBox12);
            this.panelParams.Controls.Add(this.textBox10);
            this.panelParams.Controls.Add(this.textBox11);
            this.panelParams.Controls.Add(this.textBoxDenominator);
            this.panelParams.Controls.Add(this.textBoxNumerator);
            this.panelParams.Controls.Add(this.label1);
            this.panelParams.Location = new System.Drawing.Point(16, 28);
            this.panelParams.Name = "panelParams";
            this.panelParams.Size = new System.Drawing.Size(447, 212);
            this.panelParams.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(196, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "X";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(116, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "/";
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox22.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.textBox22.Location = new System.Drawing.Point(323, 139);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(30, 30);
            this.textBox22.TabIndex = 11;
            this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox20.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.textBox20.Location = new System.Drawing.Point(246, 139);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(30, 30);
            this.textBox20.TabIndex = 10;
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox21.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.textBox21.Location = new System.Drawing.Point(284, 139);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(30, 30);
            this.textBox21.TabIndex = 9;
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox02
            // 
            this.textBox02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox02.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.textBox02.Location = new System.Drawing.Point(323, 60);
            this.textBox02.Name = "textBox02";
            this.textBox02.Size = new System.Drawing.Size(30, 30);
            this.textBox02.TabIndex = 8;
            this.textBox02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox00
            // 
            this.textBox00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox00.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.textBox00.Location = new System.Drawing.Point(246, 60);
            this.textBox00.Name = "textBox00";
            this.textBox00.Size = new System.Drawing.Size(30, 30);
            this.textBox00.TabIndex = 7;
            this.textBox00.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox01
            // 
            this.textBox01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox01.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.textBox01.Location = new System.Drawing.Point(284, 60);
            this.textBox01.Name = "textBox01";
            this.textBox01.Size = new System.Drawing.Size(30, 30);
            this.textBox01.TabIndex = 6;
            this.textBox01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.textBox12.Location = new System.Drawing.Point(323, 99);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(30, 30);
            this.textBox12.TabIndex = 5;
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.textBox10.Location = new System.Drawing.Point(246, 99);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(30, 30);
            this.textBox10.TabIndex = 4;
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.textBox11.Location = new System.Drawing.Point(284, 99);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(30, 30);
            this.textBox11.TabIndex = 3;
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxDenominator
            // 
            this.textBoxDenominator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBoxDenominator.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxDenominator.Location = new System.Drawing.Point(141, 99);
            this.textBoxDenominator.Name = "textBoxDenominator";
            this.textBoxDenominator.Size = new System.Drawing.Size(30, 30);
            this.textBoxDenominator.TabIndex = 2;
            this.textBoxDenominator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxNumerator
            // 
            this.textBoxNumerator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBoxNumerator.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNumerator.Location = new System.Drawing.Point(80, 99);
            this.textBoxNumerator.Name = "textBoxNumerator";
            this.textBoxNumerator.Size = new System.Drawing.Size(30, 30);
            this.textBoxNumerator.TabIndex = 1;
            this.textBoxNumerator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Матрица фильтра";
            // 
            // FormLab1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1516, 819);
            this.Controls.Add(this.panelToolbar);
            this.Controls.Add(this.splitContainerPictures);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "FormLab1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOutput)).EndInit();
            this.splitContainerPictures.Panel1.ResumeLayout(false);
            this.splitContainerPictures.Panel1.PerformLayout();
            this.splitContainerPictures.Panel2.ResumeLayout(false);
            this.splitContainerPictures.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPictures)).EndInit();
            this.splitContainerPictures.ResumeLayout(false);
            this.panelToolbar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelMatrix.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelParams.ResumeLayout(false);
            this.panelParams.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label labelInfo;

        private System.Windows.Forms.Label labelResult;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button buttonClear;

        private System.Windows.Forms.Button buttonSobel;

        private System.Windows.Forms.Button buttonLowPassFilter1;
        private System.Windows.Forms.Button buttonLowPassFilter2;

        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelMatrix;

        private System.Windows.Forms.Button buttonSave;

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonCount;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Panel panelParams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNumerator;
        private System.Windows.Forms.TextBox textBoxDenominator;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox02;
        private System.Windows.Forms.TextBox textBox00;
        private System.Windows.Forms.TextBox textBox01;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox22;

        private System.Windows.Forms.SplitContainer splitContainerPictures;

        private System.Windows.Forms.PictureBox pictureBoxInput;
        private System.Windows.Forms.PictureBox pictureBoxOutput;

        #endregion
    }
}