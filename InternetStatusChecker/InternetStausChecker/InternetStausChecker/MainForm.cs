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
using System.Speech.Synthesis;

namespace InternetStausChecker
{
    public partial class InvisableForm : Form
    {
        
#region Global Varibles
        private static SpeechSynthesizer synth = new SpeechSynthesizer();
        NotifyIcon InternetStatusIcon;
        Icon InternetUpIcon;
        Icon InternetDownIcon;
        Thread InternetStatusChecker;
        Boolean InternetUp = true;
        Boolean IconClose = false;
        private static Boolean MuteVoice = false;
        private static String UserName = "";
#endregion

#region MainForm


        public InvisableForm()
        {
            InitializeComponent();

            this.FormClosing += InvisableForm_FormClosing;

            //Loads Icons form files into objects
            InternetUpIcon = new Icon("UP.ico");
            InternetDownIcon = new Icon("Down.ico");


            //Creates notify icons and assigns default icon and shows it in the task tray
            InternetStatusIcon = new NotifyIcon();
            InternetStatusIcon.Icon = InternetUpIcon;
            InternetStatusIcon.Visible = true;



            //Creates menu items
            MenuItem settingsMenuItem = new MenuItem("Settings");
            MenuItem quickMuteVoiceMenuItem = new MenuItem("Quick Jarvis Mute");
            MenuItem aboutMenuItem = new MenuItem("About");
            MenuItem quitMenuitem = new MenuItem("Quit");

            //Creates context menu
            ContextMenu contextMenu = new ContextMenu();
            //Adds Menu items to context menu
            contextMenu.MenuItems.Add(settingsMenuItem);
            contextMenu.MenuItems.Add(quickMuteVoiceMenuItem);
            contextMenu.MenuItems.Add(aboutMenuItem);
            contextMenu.MenuItems.Add(quitMenuitem);

            //Adds the contextmenu to the icon
            InternetStatusIcon.ContextMenu = contextMenu;

            //Quit button
            quitMenuitem.Click += QuitMenuitem_Click;
            //About Button
            aboutMenuItem.Click += AboutMenuItem_Click;
            //muteVoiceButton
            quickMuteVoiceMenuItem.Click += quickMuteVoiceMenuItem_Click;
            //settingsMenuButton
            settingsMenuItem.Click += SettingsMenuItem_Click;



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
            IconClose = true;
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
            String message = ("Internet Status Checker V.3.0 By Joe Young");
            String caption = ("About");
            MessageBoxes(message, caption);
        }

        /// <summary>
        /// Turns off the voice alert when internet goes down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quickMuteVoiceMenuItem_Click(object sender, EventArgs e)
        {
            if (MuteVoice.Equals(false))
            {
                MuteJarvis_CheckBox(null, null);
                //MuteVoice = true;
                String message = ("Jarvis has now been muted");
                String caption = ("Info");
                MessageBoxes(message, caption);
            }
            else
            {
                MuteJarvis_CheckBox(null, null);
                //String message = ("Jarvis has now been unmuted");
                //String caption = ("Info");
                //MessageBoxes(message, caption);
            }
        }

        /// <summary>
        /// Contains the function for the settings menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
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

                        if (InternetUp.Equals(false))
                        {
                            Jarvis("Hey " + UserName +  ", the internet is back up", VoiceGender.Male);
                        }
                        InternetUp = true;
                    } catch {

                        InternetStatusIcon.Icon = InternetDownIcon;
                        Jarvis("Hey " + UserName + ", the internet has gone down", VoiceGender.Male);
                        InternetUp = false;
                        

                    }           
                    Thread.Sleep(10000);
                }
            }
            catch (ThreadAbortException)
            {
               //Thread has been aborted
            }
        }

#endregion

#region Functions

        public static void Jarvis(string message, VoiceGender voiceGender)
        {

            if (MuteVoice.Equals(false))
            {
                
                synth.SelectVoiceByHints(voiceGender);
                synth.Speak(message);
            }

        }

        public static void MessageBoxes(String message, String caption)
        {

            MessageBox.Show(message, caption);

        }

#endregion

#region FormEvents

        private void InvisavleForm_Load(object sender, EventArgs e)
        {

        }

        private void InvisableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) {

                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;

                if (IconClose.Equals(false))
                { 
                    e.Cancel = true;
                }
            }
        }

        private void MuteJarvis_CheckBox(object sender, EventArgs e)
        {
            if (MuteVoice.Equals(false))
            {
                MuteVoice = true;
                isMuted.Text = ("Jarvis is now muted");

            }
            else
            {
                MuteVoice = false;
                Jarvis("Jarvis has been unmuted", VoiceGender.Female);
                isMuted.Text = ("Jarvis is not muted");
               
            }
        }

        private void IsMuted_Click(object sender, EventArgs e)
        {
            
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            UserName = UserNameTextBox.Text;
        }
    }
#endregion
}  