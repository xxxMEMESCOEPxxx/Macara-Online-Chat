using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Configuration;
using System.IO;
using System.Media;
using System.Data;
using System.Drawing;
using System.Windows;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        //this.Icon = new Icon("Resources/statusnormal.ico");
        //Properties.Settings.Default.Save();  
        
        /// <summary>
        /// The .net wrapper around WinSock sockets.
        /// </summary>
        TcpClient _client;
        
        SoundPlayer Login = new SoundPlayer(@".\Media\joinserver1.wav"); //notify
        SoundPlayer simpleSound = new SoundPlayer(@".\Media\notify.wav");
        bool ismousedown = false;
        bool playsound = true;
        /// <summary>
        /// Buffer to store incoming messages from the server.
        /// </summary>
        byte[] _buffer = new byte[4096];

        public Form1()
        {
            InitializeComponent();
            _client = new TcpClient();
        }

        
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //this.Icon = new Icon("./Resources/Icons/appicon.ico");
            // Connect to the remote server. The IP address and port # could be
            // picked up from a settings file.

            //_client.Connect("127.0.0.1", 54000);

            // Start reading the socket and receive any incoming messages


            /*_client.GetStream().BeginRead(_buffer,
                                            0,
                                            _buffer.Length,
                                            Server_MessageReceived,
                                            null);*/
        }

        private void Server_MessageReceived(IAsyncResult ar)
        {
            if (ar.IsCompleted)
            {
                // End the stream read
                try
                {
                    int bytesIn = _client.GetStream().EndRead(ar);  //var
                    if (bytesIn > 0)
                    {
                        // Create a string from the received data. For this server 
                        // our data is in the form of a simple string, but it could be
                        // binary data or a JSON object. Payload is your choice.
                        var tmp = new byte[bytesIn];
                        Array.Copy(_buffer, 0, tmp, 0, bytesIn);
                        var str = Encoding.ASCII.GetString(tmp);

                        // Any actions that involve interacting with the UI must be done
                        // on the main thread. This method is being called on a worker
                        // thread so using the form's BeginInvoke() method is vital to
                        // ensure that the action is performed on the main thread.
                        BeginInvoke((Action)(() =>
                        {
                            listBox1.Items.Add(str);
                            listBox1.SelectedIndex = listBox1.Items.Count - 1;
                            System.Drawing.Color beans;
                            beans = System.Drawing.Color.Empty;
                            listBox1.SelectedIndex = -1;
                        }));
                    }

                    // Clear the buffer and start listening again
                    Array.Clear(_buffer, 0, _buffer.Length);
                    _client.GetStream().BeginRead(_buffer,
                                                    0,
                                                    _buffer.Length,
                                                    Server_MessageReceived,
                                                    null);
                }
                catch
                {
                    try
                    {
                        MessageBox.Show("Disconnected", "Disconnected", 0, MessageBoxIcon.Information);
                        listBox1.Items.Add("{SYSTEM}>> : Disconnected");
                        var servexit = Encoding.ASCII.GetBytes(Username.Text + " Left the server.");
                        _client.GetStream().Write(servexit, 0, servexit.Length);
                        _client.GetStream().Close();
                        _client.Close();
                        

                        Connect.Text = "Connect";
                        Disconnect.Text = "Disconnected";
                        Connect.Enabled = true;
                        Disconnect.Enabled = false;
                        Username.Enabled = true;
                        button1.Enabled = false;
                        textBox1.Enabled = false;

                        try
                        {
                            listBox1.Items.Clear();
                            listBox1.Refresh();
                            while (listBox1.Items.Count > 0)
                            {
                                listBox1.Items.Remove(listBox1.Items);
                                
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Failed to clear listBox1! You may have to do it manually.", "Clear Failed!", 0, MessageBoxIcon.Error);
                        }
                        listBox1.Items.Clear();
                        listBox1.Refresh();
                        MessageBox.Show("Disconnected", "Disconnected", 0, MessageBoxIcon.Asterisk);
                    }
                    catch
                    {
                        try
                        {
                            var servexit = Encoding.ASCII.GetBytes(Username.Text + " Left the server.");
                            //var LIPADDR = Encoding.ASCII.GetBytes(Username.Text, servjoin);
                            _client.GetStream().Write(servexit, 0, servexit.Length);
                            //Connect.Text = "Connect";
                            //Disconnect.Text = "Disconnected";
                            //Connect.Enabled = true;
                            //Disconnect.Enabled = false;
                            //Username.Enabled = true;
                            //button1.Enabled = false;
                            //textBox1.Enabled = false;
                            try
                            {
                                listBox1.Items.Clear();
                                listBox1.Refresh();
                                while (listBox1.Items.Count > 0)
                                {
                                    listBox1.Items.Remove(listBox1.Items);
                                    listBox1.Refresh();
                                }
                                //listBox1.Items.Remove(listBox1.Items.IndexOf(listBox1));
                            }
                            
                            catch
                            {
                                
                            }
                        }
                            
                        catch
                        {
                            
                        }
                    }
                    
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isConnected = _client.Connected;
            if(isConnected == true)
            {
                // Encode the message and send it out to the server.
                var msg = Encoding.ASCII.GetBytes(textBox1.Text);
                var usr = Encoding.ASCII.GetBytes(Username.Text + ": ");
                var otpt = Encoding.ASCII.GetBytes(Username.Text + ": " + textBox1.Text);
                if(textBox1.Text == "")
                {
                    //button1.Enabled = false;
                }
                else
                {
                    //button1.Enabled = true;
                    playsound = true;
                    _client.GetStream().Write(otpt, 0, otpt.Length);
                }
                
                
                //_client.GetStream().Write(usr, 0, usr.Length); // ( msg, 0, msg.Length); ;

                //Clear the text box and set it's focus
                textBox1.Text = "";
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("You must connect to a server first!", "Connect first", 0, MessageBoxIcon.Warning);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                TextReader txtSread = new StreamReader("CONFIG.txt");
                prevserv.Text += "(";
                prevserv.Text += txtSread.ReadLine();
                string placeholder = txtSread.ReadLine();
                prevserv.Text += ", @";
                prevserv.Text += txtSread.ReadLine();
                prevserv.Text += ")";
                txtSread.Close();
            }
            catch
            {

            }
            
            Connectionchecker();

            






        }

        private void Connect_Click(object sender, EventArgs e)
        {
            try
            {
                
                Connect.Text = "Connecting...";
                TextWriter txt = new StreamWriter("CONFIG.txt");
                txt.WriteLine(Username.Text + "\n");
                txt.WriteLine(ROOM.Text);
                txt.Close();
                string localIP;
                if (Username.Text == "")
                {
                    MessageBox.Show("Please enter a username!", "Username Error", 0, MessageBoxIcon.Warning);
                }
                else
                {
                    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                    {

                        socket.Connect("8.8.8.8", 65530);
                        IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                        localIP = endPoint.Address.ToString();
                        //MessageBox.Show(localIP);

                    }


                    //string USNM = Username.Text;
                    //ComboBox adv = new Form2(ComboBox);

                    //ComboBox txt1 = (Form2)this.Owner.comboBox1;
                    //txt1.Text = comboBox.Text;
                    //this.Close();
                    string ROOMIP = ROOM.Text;
                    int connrate = Int32.Parse(Properties.Settings.Default.connbaudrate.ToString()); // = 54000
                    try
                    {
                        _client.Connect(ROOMIP, connrate);
                        _client.GetStream().BeginRead(_buffer,
                                                    0,
                                                    _buffer.Length,
                                                    Server_MessageReceived,
                                                    null);
                        //simpleSound.Stop();
                        if (_client.Connected == true)
                        {
                            //Login.Play();
                            //simpleSound.Stop();
                            var servjoin = Encoding.ASCII.GetBytes(Username.Text + " Joined the server.");
                            
                            //var LIPADDR = Encoding.ASCII.GetBytes(Username.Text, servjoin);
                            _client.GetStream().Write(servjoin, 0, servjoin.Length);
                            playsound = false;
                            //simpleSound.Play();
                            //simpleSound.Stop();
                            try
                            {
                                //simpleSound.Stop();
                                //SoundPlayer Login = new SoundPlayer(@".\Media\joinserver.wav");
                                Login.Play();
                                //playsound = true;
                            }
                            catch
                            {
                                //simpleSound.Stop();
                            }


                        }
                        else
                        {
                            MessageBox.Show("Failed to connect to server. Check that you entered the correct IP Address, and that you have an Internet connection.", "Connection Failed", 0, MessageBoxIcon.Error);

                        }

                    }
                    catch
                    {

                        //MessageBox.Show("Failed to connect to server. Check that you entered the correct IP Address, and that you have an Internet connection.", "Connection Failed", 0, MessageBoxIcon.Error);
                    }


                    // Start reading the socket and receive any incoming messages

                    if (_client.Connected == true)
                    {
                        
                        //MessageBox.Show("Connected to server!");
                        Connect.Text = "Connected!";
                        Disconnect.Text = "Disconnect";
                        Disconnect.Enabled = true;
                        Connect.Enabled = false;
                        Username.Enabled = false;
                        button1.Enabled = true;
                        textBox1.Enabled = true;
                    }
                    else if (_client.Connected == false)
                    {
                        Connect.Text = "Connect";
                        Disconnect.Text = "Disconnected";
                        Connect.Enabled = true;
                        Disconnect.Enabled = false;
                        Username.Enabled = true;
                        button1.Enabled = false;
                        textBox1.Enabled = false;
                    }
                }
            }
            catch
            {
                Connect.Text = "Connect";
                button2.Text = "Connect";
                MessageBox.Show("Error opening file CONFIG.TXT because it is being used by another proccess!", "Error opening file", 0, MessageBoxIcon.Error);
            }

            


        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var servexit = Encoding.ASCII.GetBytes(Username.Text + " Left the server.");
                _client.GetStream().Write(servexit, 0, servexit.Length);
                listBox1.Items.Clear();
                listBox1.Refresh();
            }
            catch
            {

            }
            
            Application.Exit();
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            playsound = false;
            if (_client.Connected == true)                
            {
                
                var servexit = Encoding.ASCII.GetBytes(Username.Text + " Left the server.");
                
                _client.GetStream().Write(servexit, 0, servexit.Length);
                listBox1.Items.Clear();
                listBox1.Refresh();
                try
                {
                    try
                    {
                        Connect.Text = "Connect";
                        Disconnect.Text = "Disconnected";
                        Connect.Enabled = true;
                        Disconnect.Enabled = false;
                        Username.Enabled = true;
                        button1.Enabled = false;
                        textBox1.Enabled = false;
                        button2.Text = "Connect";
                        button2.Enabled = true;
                        _client.GetStream().Close();
                        _client.Close();
                       
                    }
                    catch
                    {
                        _client.EndConnect((IAsyncResult)_client);
                        MessageBox.Show("Failed to disconnect! You may have to do it manually.", "Disconnect Failed!", 0, MessageBoxIcon.Warning);
                    }
                    //Application.Exit();
                    //_client.Client.Disconnect(false);
                }catch
                {
                    MessageBox.Show("Failed to disconnect! You may have to do it manually.", "Disconnect Failed!", 0, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("You must be connected to a server first!", "Connect first", 0, MessageBoxIcon.Warning);
            }
            
            
        }

       

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void Connectionchecker()
        {
           
                if (_client.Connected == false)
                {
                    Connect.Text = "Connect";
                    Disconnect.Text = "Disconnected";
                    Connect.Enabled = true;
                    Disconnect.Enabled = false;
                    Username.Enabled = true;
                    button1.Enabled = false;
                    textBox1.Enabled = false;
                    button1.Enabled = false;
                    textBox1.Enabled = false;
                }

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }















        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //_client.Close();
                playsound = false;
                button2.Text = "Connecting...";

                string localIP;
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {

                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    localIP = endPoint.Address.ToString();
                    //MessageBox.Show(localIP);

                }


                //string USNM = Username.Text;

                string ROOMIP = ROOM.Text;
                try
                {
                    TextReader txtread = new StreamReader("CONFIG.txt");
                    Username.Text = txtread.ReadLine();
                    var beans = txtread.ReadLine();
                    ROOM.Text = txtread.ReadLine();
                    prevserv.Text += "(";
                    prevserv.Text += txtread.ReadLine();
                    prevserv.Text += ")";
                    txtread.Close();
                    _client.Connect(ROOMIP, 54000);
                    _client.GetStream().BeginRead(_buffer,
                                                0,
                                                _buffer.Length,
                                                Server_MessageReceived,
                                                null);
                    if (_client.Connected == true)
                    {
                        SoundPlayer Login1 = new SoundPlayer(@".\Media\joinserver.wav");
                        simpleSound.Play();
                        simpleSound.Stop();
                        var servjoin = Encoding.ASCII.GetBytes("{SERVER}: " + Username.Text + " Joined the server.");
                        //var LIPADDR = Encoding.ASCII.GetBytes(Username.Text, servjoin);
                        //simpleSound.Play();
                        playsound = false;
                        simpleSound.Stop();
                        _client.GetStream().Write(servjoin, 0, servjoin.Length);
                        //simpleSound.Play();
                        simpleSound.Stop();
                        Login1.Play();

                    }
                    else
                    {
                        MessageBox.Show("Failed to connect to server. Check that you entered the correct IP Address, and that you have an Internet connection.", "Connection Failed", 0, MessageBoxIcon.Error);
                    }
                    
                }
                catch
                {
                    button2.Text = "Connect";
                    if(_client.Connected == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Failed to connect to server. Check that you entered the correct IP Address, and that you have an Internet connection.", "Connection Failed", 0, MessageBoxIcon.Error);
                    }
                    //MessageBox.Show("Failed to connect to server. Check that you entered the correct IP Address, and that you have an Internet connection.", "Connection Failed", 0, MessageBoxIcon.Error);
                }


                // Start reading the socket and receive any incoming messages

                if (_client.Connected == true)
                {
                    //MessageBox.Show("Connected to server!");
                    button2.Text = "Connected!";
                    Connect.Text = "Connected!";
                    Connect.Enabled = false;
                    Disconnect.Text = "Disconnect";
                    Disconnect.Enabled = true;
                    button2.Enabled = false;
                    Username.Enabled = false;
                    button1.Enabled = true;
                    button2.Enabled = false;
                    textBox1.Enabled = true;
                }
                else if (_client.Connected == false)
                {
                    button2.Text = "Connect";
                    Disconnect.Text = "Disconnected";
                    button2.Enabled = true;
                    Disconnect.Enabled = false;
                    Username.Enabled = true;
                    button1.Enabled = false;
                    button2.Enabled = true;
                    textBox1.Enabled = false;
                }
            }
            catch
            {

            }
            //playsound = true;

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m = new Form2();
            m.Show();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ismousedown = true;
            MessageBox.Show("Clicked");
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(ismousedown == false)
                {
                    if(playsound == true)
                    {
                        simpleSound.Play();
                    }
                    else
                    {
                        simpleSound.Stop();
                    }
                    
                    
                }
                else
                {
                    simpleSound.Stop();
                    ismousedown = false;
                }
                
                
            }
            catch
            {
                
            }
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m2 = new Form3();
            m2.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m3 = new Form4();
            m3.Show();
        }
    }
}
