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

        //Set some state strings
        public String TCP_TEXT_START = "Start Connection";
        public String TCP_TEXT_STOP = "Stop Connection";
        //Server settings
        private SimpleTcpClient client;
        private Parameters parameters = new Parameters();
        private static int port;
        private static string address;
        Timer saveButtonTimer;


        public Main() {

            InitializeComponent();
            setSettings();
            setSaveTimer();
        }

        public void setSaveTimer() {
            saveButtonTimer = new Timer();
            saveButtonTimer.Interval = 2000;
            saveButtonTimer.Tick += new EventHandler(restoreSaveButton);
        }

        public void setSettings() {
            addressTextBox.Text = address = parameters.getSectionByName("Connection").getParameterByName("address").getValue();
            port  = Int32.Parse( parameters.getSectionByName("Connection").getParameterByName("port").getValue());
            portTextBox.Text = port.ToString(); 
        }
        public static String GetTimestamp(DateTime value) {
            //prepare date for logs
            return value.ToString("[ yyyy/MM/dd HH:mm:ss ]");
        }

        public void addLogFromServer(String message) {
            //Add log message specyfing that it's received from server
            //Loggin the data received.
            this.UIThread(delegate {
                String value = message.Substring(29, message.Length - 29 - 4);
                addLogMessage( 
                    "Received message from server: " + message + "."+ System.Environment.NewLine +
                    "The value returned is: " + value + "."+ System.Environment.NewLine +
                    " In decimal: " + Int32.Parse( value , System.Globalization.NumberStyles.HexNumber ) +". ");
                //addLogMessage("Received " + value);
            });
        }
        public void addLog(String message) {

            //Adding the log, async way
            this.UIThread(delegate {

                String timeStamp = GetTimestamp(DateTime.Now);
                addLogMessage( message );

            });
        }


        public void addLogMessage(String message) {
            //Add the log to the TextBox
            String timeStamp = GetTimestamp(DateTime.Now);
            output.AppendText(timeStamp + " " + message.ToString() + System.Environment.NewLine + "\n\r");
        }
        private void initSocket() {
            //Initializing the Socket
            addLog("Connecting client to " + address + " and port " + port + "...");
            try {
                //Creating the client and signaling the state to the interface
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
            //When data is received frome the server add it to the logs.
            addLogFromServer(e.MessageString);
        }

        private void killSocket() {
            //Shutdown the socket gracefully.
            try {
                client.Disconnect();
                connectionButton.Text = TCP_TEXT_START;

            } catch ( Exception ex) {
                //nothing to do here.
            }
        }
        private void sendMessage( String message ) {
            //Send the message to the server.
            try {
                addLog("Sending message: " + message);
                client.WriteLine(message);
                
            } catch ( Exception ex ) {
                addLog("Error sending message: " + ex);
            }

        }

        private void readD0_Click(object sender, EventArgs e) {
            //Send the message to read Digital 0
            sendMessage("0000000001RR*");

        }
        private void readD1_Click(object sender, EventArgs e) {
            //Send the message to read Digital 1

            sendMessage("0000010001RR*");
        }

        private void readA0_Click(object sender, EventArgs e) {
            //Send the message to read Analog 0

            sendMessage("0002320001RR*");

        }

        private void trackAO0_Scroll(object sender, EventArgs e) {
            //When a scroll of the Analog Output is detected, signal it to the interface.

            outputAnalogValue.Text = trackAO0.Value.ToString("X");

        }

        private void writeOutput_Click(object sender, EventArgs e) {
            //Send the message to write Analog 1
            sendMessage("000236"+outputAnalogValue.Text.PadLeft(4,'0')+"WR*");
        }

        private void closeButton_Click(object sender, EventArgs e) {
            //Close the socket and shutdown the app.
            killSocket();
            Application.Exit();
        }

        private void connection_Click(object sender, EventArgs e) {
            //Toggle the connection
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
            //Timer used to check if the connectino is still alive.
            //NOTE: the TcpClient.Connected attribute is known to be buggy/inefficient
            // as written official Microsoft page: https://msdn.microsoft.com/en-us/library/system.net.sockets.tcpclient.connected%28v=vs.110%29.aspx
            try {
                status.Text = (client.TcpClient.Connected) ? "Online" : "Offline";
            }catch( Exception ex) {
                status.Text = "Offline";
            }
        }

        private void addressTextBox_KeyPress(object sender, KeyPressEventArgs e) {
          
        }

        private void portTextBox_Enter(object sender, EventArgs e) {
            if (portTextBox.Text == "Port") {
                portTextBox.Text = "";
            }
        }

        private void portTextBox_Leave(object sender, EventArgs e) {
            if (portTextBox.Text == "") {
                portTextBox.Text = "Port";
            } else {
                port = Int32.Parse( portTextBox.Text );
            }
        }

        private void addressTextBox_Enter(object sender, EventArgs e) {
            if (addressTextBox.Text == "Address") {
                addressTextBox.Text = "";
            }
        }

        private void addressTextBox_Leave(object sender, EventArgs e) {
            if (addressTextBox.Text == "") {
                addressTextBox.Text = "Address";

            }else {
                address = addressTextBox.Text;
            }
        }

        private void saveParams_Click(object sender, EventArgs e) {
            parameters.getSectionByName("Connection").getParameterByName("address").setValue( addressTextBox.Text );
            parameters.getSectionByName("Connection").getParameterByName("port").setValue( portTextBox.Text );
            parameters.saveParameters();
            saveParams.Text = "Saved!";

            saveButtonTimer.Enabled = true;
        }

        private void restoreSaveButton(Object myObject, EventArgs myEventArgs ) {
            saveParams.Text = "Save Parameters";
            saveButtonTimer.Enabled = false;

        }
    }
    static class FormExtensions {
        //Used to manipulate interface on multiple thread.
        static public void UIThread(this Form form, MethodInvoker code) {
            if (form.InvokeRequired) {
                form.Invoke(code);
                return;
            }
            code.Invoke();

        }
    }   
}
