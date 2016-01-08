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
            this.components = new System.ComponentModel.Container();
            this.output = new System.Windows.Forms.TextBox();
            this.readD0 = new System.Windows.Forms.Button();
            this.readD1 = new System.Windows.Forms.Button();
            this.readA0 = new System.Windows.Forms.Button();
            this.readInputs = new System.Windows.Forms.GroupBox();
            this.writeOutputs = new System.Windows.Forms.GroupBox();
            this.outputAnalogValue = new System.Windows.Forms.TextBox();
            this.writeOutput = new System.Windows.Forms.Button();
            this.trackAO0 = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.connectionButton = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.readInputs.SuspendLayout();
            this.writeOutputs.SuspendLayout();
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
            this.output.Size = new System.Drawing.Size(685, 264);
            this.output.TabIndex = 0;
            // 
            // readD0
            // 
            this.readD0.Location = new System.Drawing.Point(27, 30);
            this.readD0.Name = "readD0";
            this.readD0.Size = new System.Drawing.Size(99, 23);
            this.readD0.TabIndex = 1;
            this.readD0.Text = "D0";
            this.readD0.UseVisualStyleBackColor = true;
            this.readD0.Click += new System.EventHandler(this.readD0_Click);
            // 
            // readD1
            // 
            this.readD1.Location = new System.Drawing.Point(225, 30);
            this.readD1.Name = "readD1";
            this.readD1.Size = new System.Drawing.Size(99, 23);
            this.readD1.TabIndex = 2;
            this.readD1.Text = "D1";
            this.readD1.UseVisualStyleBackColor = true;
            this.readD1.Click += new System.EventHandler(this.readD1_Click);
            // 
            // readA0
            // 
            this.readA0.Location = new System.Drawing.Point(126, 30);
            this.readA0.Name = "readA0";
            this.readA0.Size = new System.Drawing.Size(99, 23);
            this.readA0.TabIndex = 3;
            this.readA0.Text = "A0";
            this.readA0.UseVisualStyleBackColor = true;
            this.readA0.Click += new System.EventHandler(this.readA0_Click);
            // 
            // readInputs
            // 
            this.readInputs.Controls.Add(this.readD0);
            this.readInputs.Controls.Add(this.readA0);
            this.readInputs.Controls.Add(this.readD1);
            this.readInputs.Enabled = false;
            this.readInputs.Location = new System.Drawing.Point(13, 12);
            this.readInputs.Name = "readInputs";
            this.readInputs.Size = new System.Drawing.Size(355, 81);
            this.readInputs.TabIndex = 4;
            this.readInputs.TabStop = false;
            this.readInputs.Text = "Read Inputs";
            // 
            // writeOutputs
            // 
            this.writeOutputs.Controls.Add(this.outputAnalogValue);
            this.writeOutputs.Controls.Add(this.writeOutput);
            this.writeOutputs.Controls.Add(this.trackAO0);
            this.writeOutputs.Enabled = false;
            this.writeOutputs.Location = new System.Drawing.Point(374, 12);
            this.writeOutputs.Name = "writeOutputs";
            this.writeOutputs.Size = new System.Drawing.Size(355, 81);
            this.writeOutputs.TabIndex = 5;
            this.writeOutputs.TabStop = false;
            this.writeOutputs.Text = "Write Output AO0";
            // 
            // outputAnalogValue
            // 
            this.outputAnalogValue.Location = new System.Drawing.Point(264, 19);
            this.outputAnalogValue.Name = "outputAnalogValue";
            this.outputAnalogValue.ReadOnly = true;
            this.outputAnalogValue.Size = new System.Drawing.Size(75, 20);
            this.outputAnalogValue.TabIndex = 2;
            // 
            // writeOutput
            // 
            this.writeOutput.Location = new System.Drawing.Point(264, 45);
            this.writeOutput.Name = "writeOutput";
            this.writeOutput.Size = new System.Drawing.Size(75, 23);
            this.writeOutput.TabIndex = 1;
            this.writeOutput.Text = "Write Value";
            this.writeOutput.UseVisualStyleBackColor = true;
            this.writeOutput.Click += new System.EventHandler(this.writeOutput_Click);
            // 
            // trackAO0
            // 
            this.trackAO0.Location = new System.Drawing.Point(6, 30);
            this.trackAO0.Maximum = 2047;
            this.trackAO0.Name = "trackAO0";
            this.trackAO0.Size = new System.Drawing.Size(222, 45);
            this.trackAO0.TabIndex = 0;
            this.trackAO0.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackAO0.Scroll += new System.EventHandler(this.trackAO0_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.output);
            this.groupBox3.Location = new System.Drawing.Point(13, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(716, 300);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logs Output";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(654, 413);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // connectionButton
            // 
            this.connectionButton.Location = new System.Drawing.Point(13, 412);
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.Size = new System.Drawing.Size(97, 23);
            this.connectionButton.TabIndex = 8;
            this.connectionButton.Text = "Start Connection";
            this.connectionButton.UseVisualStyleBackColor = true;
            this.connectionButton.Click += new System.EventHandler(this.connection_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(116, 418);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(37, 13);
            this.status.TabIndex = 9;
            this.status.Text = "Offline";
            // 
            // statusTimer
            // 
            this.statusTimer.Enabled = true;
            this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 443);
            this.ControlBox = false;
            this.Controls.Add(this.status);
            this.Controls.Add(this.connectionButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.writeOutputs);
            this.Controls.Add(this.readInputs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Client Remote PLC";
            this.readInputs.ResumeLayout(false);
            this.writeOutputs.ResumeLayout(false);
            this.writeOutputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAO0)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button readD0;
        private System.Windows.Forms.Button readD1;
        private System.Windows.Forms.Button readA0;
        private System.Windows.Forms.GroupBox readInputs;
        private System.Windows.Forms.GroupBox writeOutputs;
        private System.Windows.Forms.TrackBar trackAO0;
        private System.Windows.Forms.TextBox outputAnalogValue;
        private System.Windows.Forms.Button writeOutput;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button connectionButton;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Timer statusTimer;
    }
}

