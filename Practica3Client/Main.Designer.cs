namespace Practica3Client {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.output = new System.Windows.Forms.TextBox();
            this.readD0 = new System.Windows.Forms.Button();
            this.readD1 = new System.Windows.Forms.Button();
            this.readA0 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trackAO0 = new System.Windows.Forms.TrackBar();
            this.writeOutput = new System.Windows.Forms.Button();
            this.outputAnalogValue = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAO0)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(15, 19);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(324, 193);
            this.output.TabIndex = 0;
            // 
            // readD0
            // 
            this.readD0.Location = new System.Drawing.Point(15, 19);
            this.readD0.Name = "readD0";
            this.readD0.Size = new System.Drawing.Size(101, 23);
            this.readD0.TabIndex = 1;
            this.readD0.Text = "D0";
            this.readD0.UseVisualStyleBackColor = true;
            this.readD0.Click += new System.EventHandler(this.readD0_Click);
            // 
            // readD1
            // 
            this.readD1.Location = new System.Drawing.Point(129, 19);
            this.readD1.Name = "readD1";
            this.readD1.Size = new System.Drawing.Size(99, 23);
            this.readD1.TabIndex = 2;
            this.readD1.Text = "D1";
            this.readD1.UseVisualStyleBackColor = true;
            this.readD1.Click += new System.EventHandler(this.readD1_Click);
            // 
            // readA0
            // 
            this.readA0.Location = new System.Drawing.Point(239, 19);
            this.readA0.Name = "readA0";
            this.readA0.Size = new System.Drawing.Size(100, 23);
            this.readA0.TabIndex = 3;
            this.readA0.Text = "A0";
            this.readA0.UseVisualStyleBackColor = true;
            this.readA0.Click += new System.EventHandler(this.readA0_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.readD0);
            this.groupBox1.Controls.Add(this.readA0);
            this.groupBox1.Controls.Add(this.readD1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 55);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Read Inputs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.outputAnalogValue);
            this.groupBox2.Controls.Add(this.writeOutput);
            this.groupBox2.Controls.Add(this.trackAO0);
            this.groupBox2.Location = new System.Drawing.Point(13, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 95);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Write Output AO0";
            // 
            // trackAO0
            // 
            this.trackAO0.Location = new System.Drawing.Point(6, 19);
            this.trackAO0.Maximum = 2047;
            this.trackAO0.Name = "trackAO0";
            this.trackAO0.Size = new System.Drawing.Size(343, 45);
            this.trackAO0.TabIndex = 0;
            this.trackAO0.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackAO0.Scroll += new System.EventHandler(this.trackAO0_Scroll);
            // 
            // writeOutput
            // 
            this.writeOutput.Location = new System.Drawing.Point(273, 66);
            this.writeOutput.Name = "writeOutput";
            this.writeOutput.Size = new System.Drawing.Size(75, 23);
            this.writeOutput.TabIndex = 1;
            this.writeOutput.Text = "Write Value";
            this.writeOutput.UseVisualStyleBackColor = true;
            this.writeOutput.Click += new System.EventHandler(this.writeOutput_Click);
            // 
            // outputAnalogValue
            // 
            this.outputAnalogValue.Location = new System.Drawing.Point(6, 68);
            this.outputAnalogValue.Name = "outputAnalogValue";
            this.outputAnalogValue.ReadOnly = true;
            this.outputAnalogValue.Size = new System.Drawing.Size(100, 20);
            this.outputAnalogValue.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.output);
            this.groupBox3.Location = new System.Drawing.Point(13, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(355, 231);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logs Output";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 419);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "Client Remote PLC";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAO0)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button readD0;
        private System.Windows.Forms.Button readD1;
        private System.Windows.Forms.Button readA0;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar trackAO0;
        private System.Windows.Forms.TextBox outputAnalogValue;
        private System.Windows.Forms.Button writeOutput;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

