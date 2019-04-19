using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Media;
using System.Diagnostics;
using WMPLib;

namespace AiviALAPHAreload
{
    public partial class MediaPlayer : Form
    {
        int Top;
        int MoveX;
        int MoveY;
        SpeechRecognitionEngine speechRecognitionEngine = null;
        SpeechSynthesizer Aivi = new SpeechSynthesizer();
        WMPLib.WindowsMediaPlayer WindowsMediaPlayer = new WMPLib.WindowsMediaPlayer();
        public static String userName = Environment.UserName;
        string[] files, paths;
        string path;
        public MediaPlayer()
        {
            InitializeComponent();

            try
            {
                // create the engine
                speechRecognitionEngine = createSpeechEngine("en-US");

                // hook to events
                //speechRecognitionEngine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(engine_AudioLevelUpdated);
                speechRecognitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(engine_SpeechRecognized);

                // load dictionary
                loadGrammarAndCommands();

                // use the system's default microphone
                speechRecognitionEngine.SetInputToDefaultAudioDevice();

                // start listening
                speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
                //computer.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(computer_SpeakCompleted);
            }
            catch (Exception)
            {
                Aivi.SpeakAsync("Error player");
            }
        
        }

        private SpeechRecognitionEngine createSpeechEngine(string preferredCulture)
        {
            foreach (RecognizerInfo config in SpeechRecognitionEngine.InstalledRecognizers())
            {
                if (config.Culture.ToString() == preferredCulture)
                {
                    speechRecognitionEngine = new SpeechRecognitionEngine(config);
                    break;
                }
            }

            // if the desired culture is not found, then load default
            if (speechRecognitionEngine == null)
            {
                MessageBox.Show("The desired culture is not installed on this machine, the speech-engine will continue using "
                    + SpeechRecognitionEngine.InstalledRecognizers()[0].Culture.ToString() + " as the default culture.",
                    "Culture " + preferredCulture + " not found!");
                speechRecognitionEngine = new SpeechRecognitionEngine(SpeechRecognitionEngine.InstalledRecognizers()[0]);
            }

            return speechRecognitionEngine;
        }
        private void loadGrammarAndCommands()
        {
           // try
            {
                Choices texts = new Choices();
                string[] lines = File.ReadAllLines(Environment.CurrentDirectory + "\\mediaplayercl.txt");

                texts.Add(lines);
                Grammar wordsList = new Grammar(new GrammarBuilder(texts));
                speechRecognitionEngine.LoadGrammar(wordsList);
            }
          //  catch (Exception ex)
            {
               // throw ex;
            }
        }


        #region speechEngine events
        /// <summary>
        /// Handles the SpeechRecognized event of the engine control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Speech.Recognition.SpeechRecognizedEventArgs"/> instance containing the event data.</param>
        void engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //scvText.ScrollToEnd();
            string speech = (e.Result.Text);
            switch (speech)
            {
                //GREETINGS
                case "open play list":
                case "add play list":
                   Aivi.SpeakAsync("choose, music file from your drives");

                    browse.PerformClick();
                 
                    break;

                case "minimize":
                case "hide media player":
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Minimized;
                    TopMost = false;
                    break;
                case "show media player":
                case "show media player again":
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Normal;
                    TopMost = true;
                    break;
                case "play":
                   play.PerformClick();
                    break;
                case "fast forward":
                   // fastfarwordbuttton.PerformClick();
                    break;
                case "fast reverse":
                   // fastreversebutton.PerformClick();
                    break;
                case "resume":
                   // btnpause.PerformClick();
                    break;
                case "pause":
                   pause.PerformClick();
                    break;
                case "stop":
                   // btnstop.PerformClick();
                    break;
                case "previous":
                    previous.PerformClick();
                    break;
                case "next":
                   next.PerformClick();
                    break;
                case "full screen":
                case "maximize":
                   fullscreen.PerformClick();
                    break;
                case "mute volume":
              
                    axWindowsMediaPlayer1.settings.volume = 0;
                    trackBar1.Value = axWindowsMediaPlayer1.settings.volume;
                    break;


                case "unmute volume":

                    axWindowsMediaPlayer1.settings.volume = 60;
                    trackBar1.Value = axWindowsMediaPlayer1.settings.volume;
                    break;
                case "volume up":
                    if (axWindowsMediaPlayer1.settings.volume!=100)
                    {
                        axWindowsMediaPlayer1.settings.volume += 15;
                        trackBar1.Value = axWindowsMediaPlayer1.settings.volume;
                    }
                    else
                    {

                    }
                    break;



                case "volume down":
                    if (axWindowsMediaPlayer1.settings.volume != 0)
                    {
                        axWindowsMediaPlayer1.settings.volume -= 15;
                        trackBar1.Value = axWindowsMediaPlayer1.settings.volume;
                    }
                    else
                    {

                    }
                    break;
                case "show play list":
                    plishshow.PerformClick();
                    break;

                case "hide play list":
                    plisthide.PerformClick();
                    break;

                case "close media player":
                  button3.PerformClick();
                    break;
                case "exit full screen":
                    axWindowsMediaPlayer1.Focus();
                    axWindowsMediaPlayer1.fullScreen = false;
                    break;
            }
        }

        private void btnaddplay_Click(object sender, EventArgs e)
        {
           
        }

        private void fullscreen_Click(object sender, EventArgs e)
        {
            try
            {
               // if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    axWindowsMediaPlayer1.fullScreen = true;
                }
               // else
                {
                  //  axWindowsMediaPlayer1.fullScreen = false;
                }
            
            
            }
            catch{}

        }



        public void browse_Click(object sender, EventArgs e)
        {
            string userName = System.Environment.UserName;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\" + userName + "\\Documents\\MyMusic";
            ofd.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,3gp,flv)|*.mp3;*.wav;*.mp4;*.3gp;*.avi;*.mov;*.flv;*.wmv;*.mpg|all files|*.*";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    playlist.Items.Add(files[i]);
                }
            }

        }
        private void next_Click(object sender, EventArgs e)
        {
            try
            {
                //if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    if (playlist.SelectedIndex < (playlist.Items.Count - 1))
                    {
                        axWindowsMediaPlayer1.Ctlcontrols.next();
                        playlist.SelectedIndex += 1;
                        playlist.Update();
                    }
                    else
                    {
                        playlist.SelectedIndex = 0;
                        playlist.Update();
                    }
                }
            }
            catch { }
        }


        private void previous_Click(object sender, EventArgs e)
        {
            try
            {
                //if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    if (playlist.SelectedIndex == 0)
                    {
                        playlist.SelectedIndex = 0;
                        playlist.Update();

                    }
                    else
                    {
                        axWindowsMediaPlayer1.Ctlcontrols.previous();
                        playlist.SelectedIndex -= 1;
                        playlist.Update();
                    }
                }
            }
            catch { }
        }


        public void playlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                axWindowsMediaPlayer1.URL = paths[playlist.SelectedIndex];
            }
            catch
            {
                aiviMainForm main = new aiviMainForm();
                axWindowsMediaPlayer1.URL = main.sendpath;
            }
         
        }


        public void play_Click(object sender, EventArgs e)
        {
            try
            {/*this.axWindowsMediaPlayer1.URL = path;
            this.axWindowsMediaPlayer1.Ctlcontrols.play();*/
                // this.axWindowsMediaPlayer1.URL = Filter;
                playlist.SelectedIndex = 0;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            catch
            { }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            //this.axWindowsMedia
            
            //er1.Ctlcontrols.pause();

            try
            {
                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
                else
                {
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                }
            }
            catch { }
        }

        

        public void MediaPlayer_Load(object sender, EventArgs e)
        {
            
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.TopMost = true;
            axWindowsMediaPlayer1.PlayStateChange += axWindowsMediaPlayer1_PlayStateChange;
            axWindowsMediaPlayer1.uiMode = "none";
            trackBar1.Value = axWindowsMediaPlayer1.settings.volume;
           
        }


       


        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                playbacktimer.Enabled = true;
                playbacktimer.Interval = 100;
            }
        }

        private void playbacktimer_Tick(object sender, EventArgs e)
        {
            playbacktimer.Start();
            if (playlist.SelectedIndex < files.Length - 1)
            {
                playlist.SelectedIndex++;
                playbacktimer.Enabled = false;
            }
            else
            {
                playlist.SelectedIndex = 0;
                playbacktimer.Enabled = false;
            }
            playbacktimer.Stop();


           

           

        }


        private void uiModeOptions_OnSelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Get the selected UI mode in the list box as a string.
            string newMode = (string)(((System.Windows.Forms.ListBox)sender).SelectedItem);

            // Set the UI mode that the user selected.
            axWindowsMediaPlayer1.uiMode = newMode;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int rate = 100 * (trackBar1.Value - 10);
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Dispose();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Minimized;
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Top = 1;
            MoveX = e.X;
            MoveY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Top == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MoveX, MousePosition.Y - MoveY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Top = 0;
        }

        private void axWindowsMediaPlayer1_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
        {
           
        }

        private void plisthide_MouseHover(object sender, EventArgs e)
        {
            this.Width = 681;
            plishshow.Visible = true;
        }

        private void plishshow_MouseHover(object sender, EventArgs e)
        {
            this.Width = 927;
            plishshow.Visible = false;
        }








    }

       
}
        #endregion