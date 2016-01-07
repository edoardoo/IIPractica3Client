using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3Client {
    public partial class Main : Form {
       
        public Main() {

            InitializeComponent();
  
        }
        public void addLog(String message) {
            this.UIThread(delegate {
                addLogMessage("Received message from server: " + message);

            });
        }
        

        public void addLogMessage(String message) {
            output.AppendText(message.ToString() + System.Environment.NewLine + "\n\r");
        }
        
        private void sendMessage( String message ) {

            AsynchronousClient client = new AsynchronousClient(output, message);
            System.Threading.Thread tcpClient;
            tcpClient = new System.Threading.Thread(
               new System.Threading.ThreadStart(client.StartClient)
            );
            tcpClient.IsBackground = true;
            tcpClient.Start();
        }

        private void readD0_Click(object sender, EventArgs e) {

            sendMessage("0000000001RR*");

        }
        private void readD1_Click(object sender, EventArgs e) {
            sendMessage("0000010001RR*");
        }

        private void readA0_Click(object sender, EventArgs e) {
            sendMessage("0002320001RR*");

        }

        private void trackAO0_Scroll(object sender, EventArgs e) {
            outputAnalogValue.Text = trackAO0.Value.ToString("X");

        }

        private void writeOutput_Click(object sender, EventArgs e) {
            sendMessage("000236"+outputAnalogValue.Text.PadLeft(4,'0')+"WR*");
        }
    }
    static class FormExtensions {
        static public void UIThread(this Form form, MethodInvoker code) {
            if (form.InvokeRequired) {
                form.Invoke(code);
                return;
            }
            code.Invoke();

        }
    }
}
