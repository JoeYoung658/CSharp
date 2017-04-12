using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net.NetworkInformation;
using System.Management;
using System.Management.Instrumentation;
using System.Collections.Specialized;

namespace InternetStausChecker
{
    public partial class InvisableForm : Form
    {

        NotifyIcon InternetStatusIcon;
        Icon InternetUpIcon;
        Icon InternetDownIcon;
        Thread InternetStatusChecker;

        #region MainForm


        public InvisableForm()
        {
            InitializeComponent();

            //Loads Icons form files into objects
            InternetUpIcon = new Icon("UP.ico");
            InternetDownIcon = new Icon("Down.ico");


            //Creates notify icons and assigns default icon and shows it in the task tray
            InternetStatusIcon = new NotifyIcon();
            InternetStatusIcon.Icon = InternetUpIcon;
            InternetStatusIcon.Visible = true;


            //Creates menu items
            MenuItem aboutMenuItem = new MenuItem("About");
            MenuItem quitMenuitem = new MenuItem("Quit");

            //Creates context menu
            ContextMenu contextMenu = new ContextMenu();
            //Adds Menu items to context menu
            contextMenu.MenuItems.Add(aboutMenuItem);
            contextMenu.MenuItems.Add(quitMenuitem);

            //Adds the contextmenu to the icon
            InternetStatusIcon.ContextMenu = contextMenu;

            //Quit button
            quitMenuitem.Click += QuitMenuitem_Click;
            //About Button
            aboutMenuItem.Click += AboutMenuItem_Click;



            ///This hides the form as it is a notication tray application
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            //Starts the worker thread that checks the status of the inernet
            InternetStatusChecker = new Thread(new ThreadStart(InternetStatusTread));
            InternetStatusChecker.Start();


        }

        #endregion

        #region ContextMenus
        /// <summary>
        /// Contains the code for the quit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitMenuitem_Click(object sender, EventArgs e)
        {
            InternetStatusChecker.Abort();
            InternetStatusIcon.Dispose();
            this.Close();
        }

        /// <summary>
        /// Contains information about the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            String message = ("Internet Status Checker V.1.0 By Joe Young");
            String caption = ("About");
            MessageBox.Show(message, caption);
        }


        #endregion

        #region Threads
        /// <summary>
        /// This is the thread that pings googles DNS to check if the internet is active.
        /// </summary>
        public void InternetStatusTread()
        {
            try
            {
                //Main loop
                Ping pingSender = new Ping();
                while (true)
                { 
                    // Ping's googles DNS to test internet connection
                    try
                    {
                        
                        PingReply reply = pingSender.Send("8.8.8.8");                     
                        InternetStatusIcon.Icon = InternetUpIcon;                       
                    } catch {
                        InternetStatusIcon.Icon = InternetDownIcon;
                    }           
                    Thread.Sleep(1000);
                }
            }
            catch (ThreadAbortException)
            {
               //Thread has been aborted
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}  