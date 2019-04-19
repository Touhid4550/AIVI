using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using AiviALAPHAreload.Properties;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace AiviALAPHAreload
{
    public partial class aiviMainForm : Form
    {
        string cdata;
        string temp;
        string text;
        string high;
        string low;
        string humidity;
        string sunrise;
        string sunset;
        string speed;
        string city;
        string tfcond;
        string tfhigh;
        string tflow;
        Random rnd = new Random();
        List<string> MsgList = new List<string>();
        List<string> MsgLink = new List<string>();
        int count = 1;
        int timer = 11;
        int EmailNum = 0;
        int mailcheck = 300;
        DateTime now = DateTime.Now;
       


        void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum = rnd.Next(1, 10);
            string checkinternet = NetworkInterface.GetIsNetworkAvailable().ToString();
            checkinternet.Replace("True", "Connected");
            checkinternet.Replace("False", "Disconnected");
            string speech = e.Result.Text;
            switch (speech)
            {

                //GREETINGS
                case "Hello":
                case "Hello Aivi":
                    now = DateTime.Now;
                    if (now.Hour >= 5 && now.Hour < 12)
                    { Aivi.SpeakAsync("Goodmorning " + Settings.Default.User); }
                    if (now.Hour >= 12 && now.Hour < 18)
                    { Aivi.SpeakAsync("Good afternoon " + Settings.Default.User); }
                    if (now.Hour >= 18 && now.Hour < 24)
                    { Aivi.SpeakAsync("Good evening " + Settings.Default.User); }
                    if (now.Hour < 5)
                    { Aivi.SpeakAsync("Hello " + Settings.Default.User + ", it's getting late"); }
                    break;

                case "Goodbye":
                case "Goodbye Aivi":
                case "Close Aivi":
                    Aivi.Speak("Farewell");
                    Close();
                    break;

                case "Aivi":
                    ranNum = rnd.Next(1, 5);
                    if (ranNum == 1) { QEvent = ""; Aivi.SpeakAsync("Yes sir"); }
                    else if (ranNum == 2) { QEvent = ""; Aivi.SpeakAsync("Yes?"); }
                    else if (ranNum == 3) { QEvent = ""; Aivi.SpeakAsync("How may I help?"); }
                    else if (ranNum == 4) { QEvent = ""; Aivi.SpeakAsync("How may I be of assistance?"); }
                    break;

                case "What's my name?":
                    Aivi.SpeakAsync(Settings.Default.User);
                    break;

                case "Who are you":
                    Aivi.SpeakAsync("My name is Aivi. I m your personal Assistant");
                    break;

                case "introduce yourself":
                case "Aivi introduce yourself":
                    Aivi.SpeakAsync("Ok.  My name is Aivi. I'm an artificial intelligence softwre. designed by my masters to help u with your device.");
                    Aivi.SpeakAsync("i can read email, weather report, i can search web for you, i can fix and tell you about your appointments, anything that you need like a personal assistant do, you can ask me question i will reply to you.For now my capability is limited.But i can help you with almost everithing");

                    break;





                case "Stop talking":
                    Aivi.SpeakAsyncCancelAll();
                    ranNum = rnd.Next(1, 5);
                    if (ranNum == 5)
                    { Aivi.Speak("fine"); }
                    break;

                //CONDITION OF DAY
                case "What time is it":
                    now = DateTime.Now;
                    string time = now.GetDateTimeFormats('t')[0];
                    Aivi.SpeakAsync(time);
                    break;

                case "What day is it":
                    Aivi.SpeakAsync(DateTime.Today.ToString("dddd"));
                    break;

                case "Whats the date":
                case "Whats todays date":
                    Aivi.SpeakAsync(DateTime.Today.ToString("dd-MM-yyyy"));
                    break;

               case "Hows the weather":
                case "todays weather":
                case "tell me about the weather":
                case "how is the weather today":
                case "Whats it like outside":
                GetWeather("");
                    if (QEvent == "connected")
                    {
                        Aivi.SpeakAsync("The weather in " + GetWeather("city") + " is " + GetWeather("text"));
                        Aivi.SpeakAsync(" at " + GetWeather("temp") + " degrees.");
                        Aivi.SpeakAsync("There is a humidity of " + GetWeather("humidity"));
                        Aivi.SpeakAsync(" and a windspeed of " + GetWeather("speed") + " miles per hour");
                        Aivi.SpeakAsync("Sunrise at" + GetWeather("sunrise") + "And Sunset at" + GetWeather("sunset"));
                        
                    }
                    else if (QEvent == "failed")
                    {
                        Aivi.SpeakAsync("I could not access the server, are you sure you have the right W O E I D?");
                    }
                     
                    break;

                case "What will tomorrow be like":
                case "Whats tomorrows forecast":
                case "Whats tomorrow like":
                     GetWeather("");
                    if (QEvent == "connected")
                    {

                    Aivi.SpeakAsync("Tomorrows forecast is " + GetWeather("tfcond") + " with a high of " + GetWeather("tfhigh") + " and a low of " + GetWeather("tflow"));
                    
                    }
                    else if (QEvent == "failed")
                    {
                        Aivi.SpeakAsync("I could not connect to the weather service");
                    }
                    break;

                case "Whats the temperature":
                case "Whats the temperature outside":
                         GetWeather("");

                         if (QEvent == "connected")
                         {
                             Aivi.SpeakAsync(GetWeather("temp") + " degrees");
                         }

                         else if (QEvent == "failed")
                         {
                             Aivi.SpeakAsync("I could not connect to the weather service");
                         }
                    break;



                case "where is my location":
                case "my location":
                case "whire i am":
                    GetWeather("");

                    if (QEvent == "connected")
                    {
                        Aivi.SpeakAsync("You are in "+GetWeather("city")+"city");
                    }

                    else if (QEvent == "failed")
                    {
                        Aivi.SpeakAsync("I could not connect to the weather service");
                    }
                    break;  



                    //face recognization

                case "open fgace recognization":
                    FaceRecognization FR = new FaceRecognization();
                    FR.Show();
                    break;
                
                //APPLICATION COMMANDS
                case "Switch Window":
                    SendKeys.Send("%{TAB " + count + "}");
                    count += 1;
                    break;

                case "Close window":
                    SendKeys.Send("%{F4}");
                    break;

                case "Out of the way":
                    if (WindowState == FormWindowState.Normal)
                    {
                        WindowState = FormWindowState.Minimized;
                        Aivi.SpeakAsync("My apologies");
                    }
                    break;

                case "Come back":
                    if (WindowState == FormWindowState.Minimized)
                    {
                        Aivi.SpeakAsync("Alright");
                        WindowState = FormWindowState.Normal;
                    }
                    break;

                case "Show default commands":
                    string[] defaultcommands = (File.ReadAllLines(@"Default Commands.txt"));
                    Aivi.SpeakAsync("Very well");
                    CommandModule.Items.Clear();
                    CommandModule.SelectionMode = SelectionMode.None;
                    CommandModule.Visible = true;
                    foreach (string command in defaultcommands)
                    {
                        CommandModule.Items.Add(command);
                    }
                    CommandModule.Items.Add("Aivi Come Back Online");
                    break;

                case "Show shell commands":
                    Aivi.SpeakAsync("Here we are");
                    CommandModule.Items.Clear();
                    CommandModule.SelectionMode = SelectionMode.None;
                    CommandModule.Visible = true;
                    foreach (string command in ArrayShellCommands)
                    {
                        CommandModule.Items.Add(command);
                    }
                    break;

                case "Show social commands":
                    Aivi.SpeakAsync("Alright");
                    CommandModule.Items.Clear();
                   CommandModule.SelectionMode = SelectionMode.None;
                    CommandModule.Visible = true;
                    foreach (string command in ArraySocialCommands)
                    {
                        CommandModule.Items.Add(command);
                    }
                    break;

                case "Show web commands":
                    Aivi.SpeakAsync("Ok");
                 CommandModule.Items.Clear();
                CommandModule.SelectionMode = SelectionMode.None;
                    CommandModule.Visible = true;
                    foreach (string command in ArrayWebCommands)
                    {
                        CommandModule.Items.Add(command);
                    }
                    break;
                case "Show Music Library":
                    CommandModule.SelectionMode = SelectionMode.One;
                    CommandModule.Items.Clear();
                    CommandModule.Visible = true;
                    i = 0;
                    foreach (string file in FileLocations)
                    {
                        if (file.Contains(".mp3") || file.Contains(".m4a") || file.Contains(".wav"))
                        { CommandModule.Items.Add(FileNames[i]); i += 1; }
                        else { i += 1; }
                    }
                    QEvent = "Play music file";
                    break;

                case "Show Video Library":
                    CommandModule.SelectionMode = SelectionMode.One;
                    CommandModule.Items.Clear();
                    CommandModule.Visible = true;
                    i = 0;
                    foreach (string file in FileLocations)
                    {
                        if (file.Contains(".mp4") || file.Contains(".avi") || file.Contains(".mkv"))
                        { CommandModule.Items.Add(FileNames[i]); i += 1; }
                        else { i += 1; }
                    }
                    QEvent = "Play video file";
                    break;

                case "Show Email List":
                    CommandModule.SelectionMode = SelectionMode.One;
                    CommandModule.Items.Clear();
                    CommandModule.Visible = true;
                    foreach (string line in MsgList)
                    {
                        CommandModule.Items.Add(line);
                    }
                    QEvent = "Checkfornewemails";
                    break;

                case "Show listbox":
                    CommandModule.Visible = true;
                    break;

                case "Hide listbox":
                    CommandModule.Visible = false;
                    break;


                case "Open Music Player":
                case "Music Player":
                    MediaPlayer Mp = new MediaPlayer();
                    Mp.Show();
                    break;

                //SHUTDOWN RESTART LOG OFF
                /* case "Shutdown":
                     if (ShutdownTimer.Enabled == false)
                     {
                         QEvent = "shutdown";
                         Aivi.SpeakAsync("I will shutdown shortly");
                         lblTimer.Visible = true;
                         ShutdownTimer.Enabled = true;
                     }
                     break;

                 case "Log off":
                     if (ShutdownTimer.Enabled == false)
                     {
                         QEvent = "logoff";
                         Aivi.SpeakAsync("Logging off");
                         lblTimer.Visible = true;
                         ShutdownTimer.Enabled = true;
                     }
                     break;

                case "Restart":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "restart";
                        Aivi.SpeakAsync("I will be back shortly");
                        lblTimer.Visible = true;
                        ShutdownTimer.Enabled = true;
                    }
                    break; */

                case "Abort":
                    if (ShutdownTimer.Enabled == true)
                    {
                        timer = 31;
                        lblTimer.Text = timer.ToString();
                        ShutdownTimer.Enabled = false;
                        lblTimer.Visible = false;
                    }
                    break;

                    //OTHER
                case "I want to add custom commands":
                case "I want to add a custom command":
                case "I want to add a command":
                    CustomSettings customwindow = new CustomSettings();
                    customwindow.Show();
                    break;

                case "Update commands":
                    Aivi.SpeakAsync("This may take a few seconds");
                    _recognizer.UnloadGrammar(shellcommandgrammar);
                    _recognizer.UnloadGrammar(webcommandgrammar);
                    _recognizer.UnloadGrammar(socialcommandgrammar);
                    ArrayShellCommands = File.ReadAllLines(scpath);
                    ArrayShellResponse = File.ReadAllLines(srpath);
                    ArrayShellLocation = File.ReadAllLines(slpath);
                    ArrayWebCommands = File.ReadAllLines(webcpath);
                    ArrayWebResponse = File.ReadAllLines(webrpath);
                    ArrayWebURL = File.ReadAllLines(weblpath);
                    ArraySocialCommands = File.ReadAllLines(socpath);
                    ArraySocialResponse = File.ReadAllLines(sorpath);
                    try
                    { shellcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArrayShellCommands))); _recognizer.LoadGrammar(shellcommandgrammar); }
                    catch
                    { Aivi.SpeakAsync("I've detected an in valid entry in your shell commands, possibly a blank line. Shell commands will cease to work until it is fixed."); }
                    try
                    { webcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArrayWebCommands))); _recognizer.LoadGrammar(webcommandgrammar); }
                    catch
                    { Aivi.SpeakAsync("I've detected an in valid entry in your web commands, possibly a blank line. Web commands will cease to work until it is fixed."); }
                    try
                    { socialcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArraySocialCommands))); _recognizer.LoadGrammar(socialcommandgrammar); }
                    catch
                    { Aivi.SpeakAsync("I've detected an in valid entry in your social commands, possibly a blank line. Social commands will cease to work until it is fixed."); }
                    Aivi.SpeakAsync("All commands updated");
                    break;
                    

                case "Refresh libraries":
                    Aivi.SpeakAsync("Loading libraries");
                    try { _recognizer.UnloadGrammar(Allfiles); }
                    catch { Aivi.SpeakAsync("Previous grammar was invalid"); }
                    QEvent = "ReadDirectories";
                    ReadDirectories();
                    break;
                case "Change video directory":
                    Aivi.SpeakAsync("Please choose a directory to load your video files");
                    VideoFBD.SelectedPath = Settings.Default.VideoFolder;
                    VideoFBD.Description = "Please select your video directory";
                    DialogResult videoresult = VideoFBD.ShowDialog();
                    if (videoresult == DialogResult.OK)
                    {
                        Settings.Default.VideoFolder = VideoFBD.SelectedPath; 
                        Settings.Default.Save();
                        QEvent = "ReadDirectories";
                        ReadDirectories();
                    }
                    break;
                case "Change music directory":
                    Aivi.SpeakAsync("Please choose a directory to load your music files");
                    MusicFBD.SelectedPath = Settings.Default.MusicFolder;
                    MusicFBD.Description = "Please select your music directory";
                    DialogResult musicresult = MusicFBD.ShowDialog();
                    if (musicresult == DialogResult.OK)
                    {
                        Settings.Default.MusicFolder = MusicFBD.SelectedPath; Settings.Default.Save();
                        QEvent = "ReadDirectories";
                        ReadDirectories();
                    }
                    break;

                case "Stop listening":
                    Aivi.SpeakAsync("I will await further commands");
                    _recognizer.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                    changelisten = true;
                    break;

                    //GMAIL NOTIFICATION
                case "Check for new emails":
                    QEvent = "Checkfornewemails";
                    Aivi.SpeakAsyncCancelAll();
                    EmailNum = 0;
                    CheckForEmails();
                    break;
                case "Open the email":
                    try
                    {
                        Aivi.SpeakAsyncCancelAll();
                        Aivi.SpeakAsync("Very well");
                        System.Diagnostics.Process.Start(MsgLink[EmailNum]);
                    }
                    catch { Aivi.SpeakAsync("There are no emails to read"); }
                    break;
                    // websearch

                   
               case "I WANT TO SEARCH SOMETHING":
               case "search for":
                    string Speech = e.Result.Text;
                     Aivi.SpeakAsync("what do you want to search");


                   //if (Speech == "I WANT TO SEARCH SOMETHING")
                  /* {
                        QEvent = Speech;
                        Aivi.SpeakAsync("what do you want to search");
                        Speech = string.Empty;
                    }*/

                    if (Speech != string.Empty)
                    {
                        System.Diagnostics.Process.Start("http://google.com/search?q=" + Speech);
                        QEvent = string.Empty;

                        int Num = rnd.Next(1, 4);
                        if (Num == 1) { Aivi.SpeakAsync("Alright, I am searching " + Speech + " in google"); }
                        else if (Num == 2) { Aivi.SpeakAsync("ok sir, I am searching " + Speech); }
                        else if (Num == 3) { Aivi.SpeakAsync("Alright, I am searching "); }
                        Speech = string.Empty;
                   }
                   break;




                case "Read the email":
                    Aivi.SpeakAsyncCancelAll();
                    try
                    {
                        Aivi.SpeakAsync(MsgList[EmailNum]);
                    }
                    catch { Aivi.SpeakAsync("There are no emails to read"); }
                    break;
                case "Next email":
                    Aivi.SpeakAsyncCancelAll();
                    try
                    {
                        EmailNum += 1;
                        Aivi.SpeakAsync(MsgList[EmailNum]);
                    }
                    catch { EmailNum -= 1; Aivi.SpeakAsync("There are no further emails"); }
                    break;
                case "Previous email":
                    Aivi.SpeakAsyncCancelAll();
                    try
                    {
                        EmailNum -= 1;
                        Aivi.SpeakAsync(MsgList[EmailNum]);
                    }
                    catch { EmailNum += 1; Aivi.SpeakAsync("There are no previous emails"); }
                    break;
                case "Clear email list":
                    Aivi.SpeakAsyncCancelAll();
                    MsgList.Clear(); MsgLink.Clear(); CommandModule.Items.Clear(); EmailNum = 0; Aivi.SpeakAsync("Email list has been cleared");
                    break;
            }
        }
        void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            switch (speech)
            {
                case "Start Listening":
                case "Aivi Come Back Online":
                        changelisten = false; _recognizer.RecognizeAsync(RecognizeMode.Multiple); startlistening.RecognizeAsyncCancel(); Aivi.SpeakAsync("Online and ready");
                    break;
            }
        }

        




        public String GetWeather(String input)
        {
            try
            {
                QEvent = "connected";

            String query = String.Format("https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text='city, state')&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");

            String lines;
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\weatherreport.txt");

            //Read the first line of text
            lines = sr.ReadLine();
            string output = query.Replace("city", lines);
            //close the file
            XmlDocument wData = new XmlDocument();


            wData.Load(output);
            XmlNamespaceManager manager = new XmlNamespaceManager(wData.NameTable);
            manager.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");


            XmlNode channel = wData.SelectSingleNode("query").SelectSingleNode("results").SelectSingleNode("channel");

            XmlNodeList nodes = wData.SelectNodes("query/results/channel");



            
                temp = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["temp"].Value;

                //condition = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["text"].Value;

                high = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["high"].Value;

                low = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["low"].Value;

                humidity = channel.SelectSingleNode("yweather:atmosphere", manager).Attributes["humidity"].Value;

                //windspeed = channel.SelectSingleNode("yweather:wind", manager).Attributes["chill"].Value;

                sunrise = channel.SelectSingleNode("yweather:astronomy", manager).Attributes["sunrise"].Value;

                sunset = channel.SelectSingleNode("yweather:astronomy", manager).Attributes["sunset"].Value;

                cdata = channel.SelectSingleNode("item").SelectSingleNode("description").InnerText;
                speed = channel.SelectSingleNode("yweather:wind", manager).Attributes["speed"].Value;

                city = channel.SelectSingleNode("yweather:location", manager).Attributes["city"].Value;
                text = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["text"].Value;

                tfcond = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["text"].Value;

                tfhigh = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["high"].Value;

                tflow = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["low"].Value;

                if (input == "temp")
                {
                    return temp;
                }
                if (input == "high")
                {
                    return high;
                }
                if (input == "low")
                {
                    return low;
                }
                if (input == "text")
                {
                    return text;
                }
                if (input == "humidity")
                {
                    return humidity;
                }
                if (input == "speed")
                {
                    return speed;
                }
                if (input == "sunrise")
                {
                    return sunrise;
                }
                if (input == "sunset")
                {
                    return sunset;
                }
                if (input == "description")
                {
                    return cdata;
                }

                if (input == "city")
                {
                    return city;
                }

                if (input == "tfcond")
                {
                    return text;
                }

                if (input == "tfhigh")
                {
                    return high;
                }

                if (input == "tflow")
                {
                    return low;
                }

                //sr.Close();
                //Console.ReadLine();
               
            }

            catch
            {
                QEvent = "failed";
                //return "Error Reciving data";
                

            }
            return "error";
        }
        private void CheckForEmails()
        {
            string GmailAtomUrl = "https://mail.google.com/mail/feed/atom";

            XmlUrlResolver xmlResolver = new XmlUrlResolver();
            xmlResolver.Credentials = new NetworkCredential(Settings.Default.GmailUser, Settings.Default.GmailPassword);
            XmlTextReader xmlReader = new XmlTextReader(GmailAtomUrl);
            xmlReader.XmlResolver = xmlResolver;
            try
            {
                XNamespace ns = XNamespace.Get("http://purl.org/atom/ns#");
                XDocument xmlFeed = XDocument.Load(xmlReader);


                var emailItems = from item in xmlFeed.Descendants(ns + "entry")
                                 select new
                                 {
                                     Author = item.Element(ns + "author").Element(ns + "name").Value,
                                     Title = item.Element(ns + "title").Value,
                                     Link = item.Element(ns + "link").Attribute("href").Value,
                                     Summary = item.Element(ns + "summary").Value
                                 };
                MsgList.Clear(); MsgLink.Clear();
                foreach (var item in emailItems)
                {
                    if (item.Title == String.Empty)
                    {
                        MsgList.Add("Message from " + item.Author + ", There is no subject and the summary reads, " + item.Summary);
                        MsgLink.Add(item.Link);
                    }
                    else
                    {
                        MsgList.Add("Message from " + item.Author + ", The subject is " + item.Title + " and the summary reads, " + item.Summary);
                        MsgLink.Add(item.Link);
                    }
                }

                if (emailItems.Count() > 0)
                {
                    if (emailItems.Count() == 1)
                    {
                        Aivi.SpeakAsync("You have 1 new email");
                    }
                    else { Aivi.SpeakAsync("You have " + emailItems.Count() + " new emails"); }
                    CommandModule.SelectionMode = SelectionMode.One;
                    CommandModule.Items.Clear();
                    CommandModule.Visible = true;
                    foreach (string line in MsgList)
                    {
                        CommandModule.Items.Add(line);
                    }
                }
                else if (QEvent == "Checkfornewemails" && emailItems.Count() == 0)
                { Aivi.SpeakAsync("You have no new emails"); QEvent = String.Empty; }
            }
            catch { Aivi.SpeakAsync("You have submitted invalid log in information"); }
        }
    }
}
