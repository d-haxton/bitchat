using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitchat.Encryption
{
    class ECDSAEncryption
    {
        public string publickey { get; set; }
        public string privatekey { get; set; }
        public string encryptedMessage { get; set; }
        public string decryptedMessage { get; set; }
        public string plaintextMessage { get; set; }
        string path = Directory.GetCurrentDirectory();
        private const string pythonScriptLocation = "C:\\Python27\\ECDSAEncryption.py";

        public string run_cmd(string cmd, string args)
        {
            string result = "";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:\\Python27\\python.exe";
            start.Arguments = string.Format("{0} {1}", cmd, args);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    result = result + reader.ReadToEnd();
                }
            }
            return result;
        }

        public ECDSAEncryption(string publickey, string privatekey)
        {
            //string[] lines = ECDSAEncryption.py;
            // WriteAllLines creates a file, writes a collection of strings to the file, 
            // and then closes the file.
            //System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);

            this.publickey = publickey;
            this.privatekey = privatekey;
        }

        public void encrypt(string message)
        {
            encryptedMessage = run_cmd(pythonScriptLocation, "-e -i " + message + " -k " + publickey);
        }

        public void decrypt(string message)
        {
            decryptedMessage = run_cmd(pythonScriptLocation, "-d -i " + message + " -k " + privatekey);
        }
        public void decrypt()
        {
            decryptedMessage = run_cmd(pythonScriptLocation, "-d -i " + encryptedMessage + " -k " + privatekey);
        }

        public void generate()
        {
            run_cmd(pythonScriptLocation, "-g");
        }
    }
}
