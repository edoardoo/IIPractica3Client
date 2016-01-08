using SimpleTCP;
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
        private SimpleTcpClient client;
        private static int port = 11000;
        private static string address = "127.0.0.1";
        //private AsynchronousClient client;
        //System.Threading.Thread tcpClient;

        public Main() {

            InitializeComponent();
            
        }

        public static String GetTimestamp(DateTime value) {
            return value.ToString("[ yyyy/MM/dd HH:mm:ss ]");
        }

        public void addLogFromServer(String message) {
            this.UIThread(delegate {
                String timeStamp = GetTimestamp(DateTime.Now);
                addLogMessage( "Received message from server: " + message);

            });
        }
        public void addLog(String message) {
            this.UIThread(delegate {

                String timeStamp = GetTimestamp(DateTime.Now);
                addLogMessage( message );

            });
        }


        public void addLogMessage(String message) {
            String timeStamp = GetTimestamp(DateTime.Now);
            output.AppendText(timeStamp + " " + message.ToString() + System.Environment.NewLine + "\n\r");
        }
        private void initSocket() {

            addLog("Connecting client to " + address + " and port " + port + "...");
            try {

                this.client = new SimpleTcpClient().Connect(address, port);
                addLog("Connected!");
                connectionButton.Text = TCP_TEXT_STOP;

                //add listener for server replies.
                client.DataReceived += Client_DataReceived;

            } catch( Exception ex) {
                addLog("Error connecting: " + ex.ToString());
            }

        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e) {
            addLogFromServer(e.MessageString);
        }

        private void killSocket() {
            try {
                client.Disconnect();
                connectionButton.Text = TCP_TEXT_START;

            } catch ( Exception ex) {
                //addLog("Error disconnecting: " + ex.ToString());

            }
        }
        private void sendMessage( String message ) {
            try {
                addLog("Sending message: " + message);
                client.WriteLine(message);
                
            } catch ( Exception ex ) {
                addLog("Error sending message: " + ex);
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

                initSocket();
                readInputs.Enabled = true;
                writeOutputs.Enabled = true;
            } else {
                readInputs.Enabled = false;
                writeOutputs.Enabled = false;
                killSocket();
                connectionButton.Text = TCP_TEXT_START;
                addLogMessage("Closed socket.") ;
            }
        }

        
        private void statusTimer_Tick(object sender, EventArgs e) {
            try {
                status.Text = (client.TcpClient.Connected) ? "Online" : "Offline";
            }catch( Exception ex) {
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
