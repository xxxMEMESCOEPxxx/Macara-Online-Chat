using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeView1.SelectedNode.Tag == "use")
            {
                listBox1.Items.Clear();
                listBox1.Refresh();
                listBox1.Items.Add("How to use Macara Online Chat:");
                //listBox1.Items.Add("");
            }
            if (treeView1.SelectedNode.Tag == "conn")
            {
                listBox1.Items.Clear();
                listBox1.Refresh();
                listBox1.Items.Add("How to connect to a server:");
                listBox1.Items.Add("");
                listBox1.Items.Add("");
                listBox1.Items.Add("At the top right corner, there are 2 text boxes. One is labeled 'Username', and the other 'Room IP'.");
                listBox1.Items.Add("");
                listBox1.Items.Add("The text box labeled 'Username' is where you put a name so other users can Identify you in the server.");
                listBox1.Items.Add("You must put a name in order to connect to a server.");
                listBox1.Items.Add("");
                listBox1.Items.Add("The text box labeled 'Room IP' is where you put the IP Address of the server you want to connect to.");
                listBox1.Items.Add("This is important because the IP specifies the specific room that you want to join.");
                listBox1.Items.Add("You must put an IP in order to connect to a server. If you don't, this program won't know what server");
                listBox1.Items.Add("you want to connect to.");
                listBox1.Items.Add("");
                listBox1.Items.Add("");
                listBox1.Items.Add("When you have entered all the required information, you can click the button next to the text box");
                listBox1.Items.Add("labeled as 'Room IP'. The button's text will say 'Connect'.");
            }
            if (treeView1.SelectedNode.Tag == "help")
            {
                listBox1.Items.Clear();
                listBox1.Refresh();
                listBox1.Items.Add("This is the Macara Online Chat Document. Please Expand and select a topic to continue");
            }
            if (treeView1.SelectedNode.Tag == "disscon")
            {
                listBox1.Items.Clear();
                listBox1.Refresh();
                listBox1.Items.Add("How to disconnect from a server: ");
                listBox1.Items.Add("");
                listBox1.Items.Add("");
                listBox1.Items.Add("In the top right corne rof this program, there is a button that is labeled as 'Disconnect'.");
                listBox1.Items.Add("Click this button to leave a server.");
                listBox1.Items.Add("(NOTE: If you want to rejoin a server, you must restart the application and click on the button");
                listBox1.Items.Add("in the top left corner that is labled as 'Connect'!)");
            }
            if (treeView1.SelectedNode.Tag == "username")
            {
                listBox1.Items.Clear();
                listBox1.Refresh();
                listBox1.Items.Add("This is a text box located in the top right corner. It is labeled as 'Username'.");
                listBox1.Items.Add("You must enter a username before connecting to a server, so other users can identify you on the server.");
                listBox1.Items.Add("NOTE: You cannot change your username while connected to a server!");

            }
            if (treeView1.SelectedNode.Tag == "roomip")
            {
                listBox1.Items.Clear();
                listBox1.Refresh();
                listBox1.Items.Add("This is a text box located in the top right corner. It is labeled as 'Room IP'.");
                listBox1.Items.Add("You must enter a room IP Address before connecting to a server, so the chat client knows what server");
                listBox1.Items.Add("that it should attempt to connect with.");

            }
            if (treeView1.SelectedNode.Tag == "preserv")
            {
                listBox1.Items.Clear();
                listBox1.Refresh();
                listBox1.Items.Add("This is a button in the top left corner that is labeled as 'Previous Server (USERNAME, @ROOM IP)'.");
                listBox1.Items.Add("This button allows you to quickly and easily connect to the last server you connected to.");
                listBox1.Items.Add("(NOTE: You must have connected to a server previously before using this button!)");

            }
            if (treeView1.SelectedNode.Tag == "msgsend")
            {
                listBox1.Items.Clear();
                listBox1.Refresh();
                listBox1.Items.Add("Near the bottom of this application, you will see a text box next to a button");
                listBox1.Items.Add("labelad 'Send'. This is where you type a message to send.");
                listBox1.Items.Add("When you are ready to send your message, press ENTER or click the 'Send' button.");
                listBox1.Items.Add("");

            }
        }
    }
}
