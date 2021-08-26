using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Threading;

namespace AutoDoor
{
    public partial class Form1 : Form
    {

        int tg = 0;
        static string port1ID = null;
        static string port2ID = null;
        SerialPort ScannerPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        SerialPort DoorPort = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
        HashSet<string> Students;
        int Delay = 1000;
        int Timeout = 0;

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
            PushLog("Door Opened(Test Button Pushed)");
            OpenDoor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string temp ="";
            if(Delay != Int32.Parse(textBox4.Text))
            {
                Delay = Int32.Parse(textBox4.Text);
                temp += "Updated Delay \n";
            }
            if (Timeout != Int32.Parse(textBox5.Text))
            {
                Timeout = Int32.Parse(textBox5.Text);
                temp += "Updated TimeOut \n";
            }
            if(Students != new HashSet<string>(File.ReadAllLines("students.txt")))
            {
                Students = new HashSet<string>(File.ReadAllLines("students.txt"));
                temp += "Updated Students \n";
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
        public void AutoDoorSetPort()
        {
            //clean string
            string comOutput = getCOMInformationViaPowershell();
            string parsedStr = comOutput.Replace("----","").Replace("name", "");

            if (parsedStr != "")
            {
                //set variables
                string[] coms = parsedStr.Split('\n');

                foreach (var com in coms)
                {
                    //Loops each line
                    if (com.Contains("STMicroelectronics Virual COM Port"))
                    {
                        PushLog("Found: " + com);
                        port1ID = com.Split('(')[1].Split(')')[0];
                    }
                    if (com.Contains("USB-SERIAL CH340"))
                    {
                        PushLog("Found: " + com);
                        port2ID = com.Split('(')[1].Split(')')[0];
                    }
                }
                if(port2ID != null && port1ID != null)
                {
                    ScannerPort.PortName = port1ID;
                    DoorPort.PortName = port2ID;
                    ScannerPort.Open();
                    DoorPort.Open();
                }
                else
                {
                    PushLog("Missing COM ports");
                    //error Message if not found or 1 is missing
                    MessageBox.Show("Cannot Auto find COM Ports \nSet Manually");
                    Toggle();
                }
            }else
            {
                PushLog("No Active COM ports");
                //if no COM Ports
                MessageBox.Show("There are no Active COM Ports");
                Toggle();
            }
        }
        public void PushLog(string IncomingText)
        {
            richTextBox1.Text += ('\n'+ "[" + DateTime.Now + "]" + "    " + IncomingText );
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
                radioButton1.Enabled = false; radioButton2.Enabled = false; button2.Enabled = true;
                Students = new HashSet<string>(File.ReadAllLines("students.txt"));
                if (radioButton1.Checked == true){
                    ManualDoorSetPort();
                }
                else
                {
                    AutoDoorSetPort();
                }
                //enables button once port finder is done
                button1.Enabled = true; radioButton1.Enabled = true; radioButton2.Enabled = true;
            }
            else
            {
                tg = 0;
                PushLog("Stopping AutoDoor");
                ScannerPort.Close();
                DoorPort.Close();
                button1.Text = "Start";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonToggler();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonToggler();
        }
        public void ManualDoorSetPort()
        {
            ScannerPort.PortName = "COM" + textBox2.Text;
            DoorPort.PortName = "COM" + textBox3.Text;
            ScannerPort.Open();
            DoorPort.Open();
            ScannerPort.DataReceived += sp_DataReceived;
        }
        public void RadioButtonToggler()
        {
            //toggles manual input on or off
            if (radioButton2.Checked == true)
            {
                PushLog("Auto Mode set");
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                PushLog("Manual Mode set");
                textBox2.Enabled = true;
                textBox3.Enabled = true;
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
        public void Checker(string Data)
        {
            if (CheckTime() == true)
            {
                if(Data.Length != 10)
                {
                    if (Data == "3XHF3K6XGIKXPSCY")
                    {
                        PushLog("User [" + Data + "] Valid");
                        OpenDoor();
                    }
                    if (Students.Contains(Data))
                    {
                        OpenDoor();
                        PushLog("User [" + Data + "] Valid");
                    }else
                    {
                        PushLog("User [" + Data + "] Invalid");
                    }
                }

            }
            else
            {
                PushLog("Out of Time Scan by [" + Data + "]");
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
            if((
                DateTime.Now.TimeOfDay.Hours >= DateTime.Parse(textBox1.Text).TimeOfDay.Hours 
                && DateTime.Now.TimeOfDay.Minutes >= DateTime.Parse(textBox1.Text).TimeOfDay.Minutes) 
                && (DateTime.Now.TimeOfDay.Hours <= DateTime.Parse(textBox6.Text).TimeOfDay.Hours 
                && DateTime.Now.TimeOfDay.Minutes <= DateTime.Parse(textBox6.Text).TimeOfDay.Minutes)

                && (DateTime.Now.TimeOfDay.Hours <= DateTime.Parse(textBox7.Text).TimeOfDay.Hours
                && DateTime.Now.TimeOfDay.Minutes <= DateTime.Parse(textBox7.Text).TimeOfDay.Minutes)
                && (DateTime.Now.TimeOfDay.Hours >= DateTime.Parse(textBox8.Text).TimeOfDay.Hours
                && DateTime.Now.TimeOfDay.Minutes >= DateTime.Parse(textBox8.Text).TimeOfDay.Minutes))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
