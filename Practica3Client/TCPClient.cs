using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Windows.Forms;


// State object for receiving data from remote device.
public class StateObject {
    // Client socket.
    public Socket workSocket = null;
    // Size of receive buffer.
    public const int BufferSize = 256;
    // Receive buffer.
    public byte[] buffer = new byte[BufferSize];
    // Received data string.
    public StringBuilder sb = new StringBuilder();
}

public class AsynchronousClient {
    // The port number for the remote device.
    private const int port = 11000;
    System.Windows.Forms.TextBox logsTextBox;
    // ManualResetEvent instances signal completion.
    private static ManualResetEvent connectDone =
        new ManualResetEvent(false);
    private static ManualResetEvent sendDone =
        new ManualResetEvent(false);
    private static ManualResetEvent receiveDone =
        new ManualResetEvent(false);

    // The response from the remote device.
    private static String response = String.Empty;
    public Socket socket;
    private System.Windows.Forms.Button connectionButton;
    public String TCP_TEXT_START = "Start Connection";
    public String TCP_TEXT_STOP = "Stop Connection";

    public AsynchronousClient(System.Windows.Forms.TextBox logs, System.Windows.Forms.Button connectionButton) {
        this.logsTextBox = logs;
        this.connectionButton = connectionButton;
    }


    public  void StartClient() {
        // Connect to a remote device.
        try {
            // Establish the remote endpoint for the socket.
            IPHostEntry ipHostInfo = Dns.Resolve("localhost");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket.
            Socket socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.
            socket.BeginConnect(remoteEP,
                new AsyncCallback(ConnectCallback), socket);
            connectDone.WaitOne();


        } catch (Exception e) {
            
            Console.WriteLine( "Error starting server: "+e.ToString());
            addLog(e.ToString());

        }
    }

    private void ConnectCallback(IAsyncResult ar) {
        try {
            // Retrieve the socket from the state object.
            Socket client = (Socket)ar.AsyncState;
            socket = client;
            // Complete the connection.
            client.EndConnect(ar);
            addLog("Socket connected to " +
                client.RemoteEndPoint.ToString());
            changeButton(TCP_TEXT_STOP);

            // Signal that the connection has been made.
            connectDone.Set();
        } catch (Exception e) {
            addLog(e.Message.ToString());
        }
    }

    private  void Receive(Socket client) {
        try {
            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = client;

            // Begin receiving the data from the remote device.
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReceiveCallback), state);
        } catch (Exception e) {
            addLog(e.Message.ToString());
            Console.WriteLine(e.ToString());
        }
    }

    private  void ReceiveCallback(IAsyncResult ar) {
        try {
            // Retrieve the state object and the client socket 
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;

            // Read data from the remote device.
            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0) {
                // There might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                // Get the rest of the data.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            } else {
                // All the data has arrived; put it in response.
                if (state.sb.Length > 1) {
                    response = state.sb.ToString();
                }
                // Signal that all bytes have been received.
                receiveDone.Set();
            }
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
            addLog(e.Message.ToString());

        }
    }

    public void Send(Socket client, String data) {
        // Convert the string data to byte data using ASCII encoding.
        Console.WriteLine("Sending....");
        byte[] byteData = Encoding.ASCII.GetBytes(data);
        
        addLog("Sending: " + data + " .");

        // Begin sending the data to the remote device.
        client.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), client);
    }
    private void SendCallback(IAsyncResult ar) {
        try {
            // Retrieve the socket from the state object.
            Socket client = (Socket)ar.AsyncState;

            // Complete sending the data to the remote device.
            int bytesSent = client.EndSend(ar);
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);
            addLog("Sent "+ bytesSent  + "bytes to server.");
            // Signal that all bytes have been sent.
            sendDone.Set();
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
            addLog(e.Message.ToString());

        }
    }
    private Boolean isConnected() {

        bool blockingState = socket.Blocking;
        try {
            byte[] tmp = new byte[1];

            socket.Blocking = false;
            socket.Send(tmp, 0, 0);
            return true;
        } catch (SocketException e) {
            // 10035 == WSAEWOULDBLOCK
            if (e.NativeErrorCode.Equals(10035)) {
                return true;
            } else {
                return false;
            }

        } finally {
            socket.Blocking = blockingState;
        }

    }
    public void addLog(String message) {
        MethodInvoker action = delegate {
            logsTextBox.AppendText(message + "\n\r" + System.Environment.NewLine);
        };
        logsTextBox.BeginInvoke(action);

    }
    public void changeButton(String state) {
        MethodInvoker action = delegate {
            connectionButton.Text = state;
        };
        connectionButton.BeginInvoke(action);

    }
    public String getSocketStatus() {
        return (isConnected()) ? "Online" : "Offline";
    }

    public void sendMessage(String message) {
        if (isConnected()) {
            Send(socket, message);
            sendDone.WaitOne();

            // Receive the response from the remote device.
            Receive(socket);
            receiveDone.WaitOne();

            // Write the response to the console.
            addLog("Response received : " + response);
        }



    }
    public void closeSocket() {
        // Release the socket.
        socket.Shutdown(SocketShutdown.Both);
        socket.Dispose();
        socket.Close();
    }



}
