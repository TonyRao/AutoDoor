using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Runtime.InteropServices;

namespace AutoDoor
{
    public partial class Form1 : Form
    {
        string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        int tg = 0;
        SerialPort ScannerPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        SerialPort DoorPort = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
        string[] Students;
        int Delay = 1000;
        int Timeout = 0;
        TimeSpan start = DateTime.Parse("7:00 am").TimeOfDay;
        TimeSpan end = DateTime.Parse("2:00 pm").TimeOfDay;
        TimeSpan LunchStart = DateTime.Parse("10:10 am").TimeOfDay;
        TimeSpan LunchEnd = DateTime.Parse("10:50 am").TimeOfDay;

        //Function to handle all key events, EVEN WHEN THE FORM IS NOT FOCUSED
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private static readonly int VK_SNAPSHOT = 0x4F; //O key --- // 0x2C; //This is the print-screen key.

        //Assume the timer is setup with Interval = 16 (corresponds to ~60FPS).
        //private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
        }

        public string[] getCOMPortNames()
        {
            // Get a list of serial port names.
            //TODO: Get-WMIObject Win32_SerialPort
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                MessageBox.Show(port);
            }

            return ports;
        }

        public string getCOMInformationViaPowershell()
        {
            Process process = new Process();
            // Configure the process using the StartInfo properties.
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = "Get-WMIObject Win32_SerialPort | select-object name";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            process.WaitForExit();// Waits here for the process to exit.

            return process.StandardOutput.ReadToEnd();
        }

        //Meant to encrypt 06 numbers in students json file
        //TODO: set up synergy between encryptDataAes, and DPAPI for data encryption
        public byte[] encryptDataAes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        //Meant to decrypt 06 numbers in students json file via aes
        public string decryptDataAes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                PushLog("Door Opened(Test Button Pushed)");
                OpenDoor();
            }
            catch
            {
                MessageBox.Show("Invalid Ports");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string temp ="";
            if (Timeout != Int32.Parse(textBox5.Text))
            {
                Timeout = Int32.Parse(textBox5.Text);
                temp += "Updated TimeOut \n";
            }

            start = DateTime.Parse(textBox1.Text).TimeOfDay;
            end = DateTime.Parse(textBox6.Text).TimeOfDay;
            LunchStart = DateTime.Parse(textBox7.Text).TimeOfDay;
            LunchEnd = DateTime.Parse(textBox8.Text).TimeOfDay;

            if (File.Exists("students.txt") == true)
            {
                if (Students != File.ReadAllLines("students.txt"))
                {
                    Students = File.ReadAllLines("students.txt");
                    temp += $"Updated {Students.Length} Students\n";
                }
            }
            else
            {
                MessageBox.Show("Missing Students.txt");
            }
            if(temp == "")
            {
                MessageBox.Show("Nothing was updated.");
            }
            else
            {
                MessageBox.Show(temp);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Toggle();
        }
        public void PushLog(string IncomingText, string mode="none")
        {
            string logStatement = '\n' + "[" + DateTime.Now + "]" + "    " + IncomingText;
            if (mode == "none")
            {
                
                File.AppendAllText($"{localAppDataPath}\\Autodoor.log", $"{logStatement}{Environment.NewLine}");
                richTextBox1.Text += (logStatement);
            }

            if (mode == "debug")
            {
                File.AppendAllText($"{localAppDataPath}\\Autodoor.debug.log", $"{logStatement}{Environment.NewLine}");
            }

            if (mode == "anomaly")
            {
                File.AppendAllText($"{localAppDataPath}\\Autodoor.log", $"{logStatement}{Environment.NewLine}");
                File.AppendAllText($"{localAppDataPath}\\Autodoor.anom.log", $"{logStatement}{Environment.NewLine}");
            }
        }

        public void Toggle()
        {
            //toggle start / stop
            if (tg == 0)
            {
                tg = 1;
                PushLog("Starting AutoDoor");
                //disable button and runs port finder
                button1.Enabled = false; button1.Text = "Stop"; button2.Enabled = false;
                button2.Enabled = true;
                if (File.Exists("students.txt") == true)
                {
                    start = DateTime.Parse(textBox1.Text).TimeOfDay;
                    end = DateTime.Parse(textBox6.Text).TimeOfDay;
                    LunchStart = DateTime.Parse(textBox7.Text).TimeOfDay;
                    LunchEnd = DateTime.Parse(textBox8.Text).TimeOfDay;
                    Students = File.ReadAllLines("students.txt");
                    ManualDoorSetPort();
                }
                else
                {
                    PushLog("Failed to Start");
                    MessageBox.Show("Missing students.txt");
                    Toggle();
                }
                //enables button once port finder is done
                button1.Enabled = true;
            }
            else
            {
                tg = 0;
                PushLog("Stopping AutoDoor");
                button2.Enabled = false;
                ScannerPort.Close();
                DoorPort.Close();
                button1.Text = "Start";
            }
        }
        public void ManualDoorSetPort()
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                ScannerPort.PortName = "COM" + textBox2.Text;
                DoorPort.PortName = "COM" + textBox3.Text;
                ScannerPort.Open();
                DoorPort.Open();
                ScannerPort.DataReceived += sp_DataReceived;
            }
            else
            {
                PushLog("Failed to Start");
                MessageBox.Show("COM ports are not defined");
                Toggle();
            }
        }
        public void OpenDoor()
        {
            DoorPort.Write("1");
            Thread.Sleep(Delay);
            DoorPort.Write("0");
            Thread.Sleep(Timeout);
        }
        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string IncomingData = ScannerPort.ReadExisting();
            Checker(IncomingData);
        }

        public void anamolyDetection(string entry)
        {
            MessageBox.Show("anomaly detected");
            char firstCharinEntry = entry[0];
            if (char.IsLetter(firstCharinEntry))
            {
                MessageBox.Show("If triggered");
            }
        }

        public void Checker(string Data)
        {
            if (Data == "3XHF3K6XGIKXPSCY")
            {
                PushLog("Administrator Open Door ["+Data+"]");
                OpenDoor();
                return;
            }
            if (CheckTime() == true )
            {
                if(string.IsNullOrEmpty(Data))
                {
                    PushLog($"Null or empty detected: [{Data}]", "debug");
                    return;
                }
                string StudentOutput = Array.Find(Students, (student => student == Data));
                if (StudentOutput == Data)
                {
                    PushLog("User [" + Data + "] Valid");
                    OpenDoor();
                    return;
                }
                else
                {
                    PushLog("User [" + Data + "] Invalid");
                    return;
                }
            }
            else
            {
                PushLog("Out of Time Scan by [" + Data + "]");
                return;
            }


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        private bool CheckTime() 
        {
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end) && ((now < LunchStart) || (now > LunchEnd)) && (DateTime.Now.DayOfWeek != DayOfWeek.Saturday) && (DateTime.Now.DayOfWeek != DayOfWeek.Sunday))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // scroll it automatically
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            short keyState = GetAsyncKeyState(VK_SNAPSHOT);

            //Check if the MSB is set. If so, then the key is pressed.
            bool prntScrnIsPressed = ((keyState >> 15) & 0x0001) == 0x0001;

            //Check if the LSB is set. If so, then the key was pressed since
            //the last call to GetAsyncKeyState
            bool unprocessedPress = ((keyState >> 0) & 0x0001) == 0x0001;

            if (prntScrnIsPressed)
            {
                //TODO Execute client code...
                MessageBox.Show("prntScrn pressed");
            }

            if (unprocessedPress)
            {
                //TODO Execute client code...
                MessageBox.Show("prntScrn pressed");
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {

            if (GetAsyncKeyState(0x04) != 0) //0x02 is right click
            {
                PushLog("Door opened remotely by mouse");
                OpenDoor();
            }
        }
    }
}
