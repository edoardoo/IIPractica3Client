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
        public String TCP_TEXT_START = "Start Connection";
        public String TCP_TEXT_STOP = "Stop Connection";

        private AsynchronousClient client;
        System.Threading.Thread tcpClient;

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
        private void initSocket() {
            client = new AsynchronousClient(output, connectionButton);
            tcpClient = new System.Threading.Thread(
               new System.Threading.ThreadStart(client.StartClient)
            );
            tcpClient.IsBackground = true;
            tcpClient.Start();
        }

        private void killSocket() {
            client.closeSocket();
            tcpClient.Abort();
        }
        private void sendMessage( String message ) {
            try {
                client.sendMessage(message);
            }catch( Exception ex) {

            }

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

        private void closeButton_Click(object sender, EventArgs e) {
            killSocket();
            Application.Exit();
        }

        private void connection_Click(object sender, EventArgs e) {
            if( connectionButton.Text == TCP_TEXT_START) {
                statusTimer.Enabled = true;
                initSocket();
            } else {
                killSocket();
                connectionButton.Text = TCP_TEXT_START;
                addLogMessage("Closed socket.") ;
            }
        }

        
        private void statusTimer_Tick(object sender, EventArgs e) {
            try {
                    String tcpStatus = client.getSocketStatus();
                    status.Text = tcpStatus;
               
            } catch (Exception ex) {
                status.Text = "Offline";
             }
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
