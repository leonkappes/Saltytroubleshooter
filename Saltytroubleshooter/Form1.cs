using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saltytroubleshooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Init UI
            progress.Visible = true;
            progressText.Visible = true;
            progressText.Text = "Überprüfe Salty-Installation";
            progress.Value = 0;
            progress.Maximum = 10;
            progress.Step = 1;
            progress.PerformStep();

            //Perform installation-validation
            if (!CheckInstallation())
                PrompInstallation();

            //Progess UI
            progressText.Text = "Überprüfe DNS-Einstellungen";
            progress.PerformStep();

            //Perform NSLOOKUP of lh.saltmine.de
            if(!DNSResolves())
            {
                progress.PerformStep();
                progressText.Text = "Korrigiere DNS-Einstellungen";
                PrompDNSFix();
            }

            progress.Value = progress.Maximum;
            progressText.Text = "Troubleshooter abgeschlossen...";

            PrompRestart();
        }

        private void PrompRestart()
        {
            var result = MessageBox.Show("Um alle Änderungen anzuwenden muss ihr PC neugestartet werden! Soll der PC direkt neustarten?",
                    "Abgeschlossen",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
            }
            this.Close();
        }

        private bool CheckInstallation()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TS3Client", "plugins", "SaltyChat");
            if (Directory.Exists(path))
            {
                return true;
            }
            return false;
        }

        private void PrompInstallation()
        {
            var result = MessageBox.Show("Saltychat ist entweder nicht installiert oder ist inkorrekt installiert!\n Möchtest du Salty herunterladen?",
                    "Salty nicht gefunden",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://saltmine.de/saltychat/download/stable");

            }
            this.Close();
        }

        private bool DNSResolves()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry("lh.saltmine.de");
            if (hostEntry.AddressList[0].ToString() != "127.0.0.1")
                return false;
            return true;
        }

        private void PrompDNSFix()
        {
            var result = MessageBox.Show("Deine DNS-Einstellungen sind inkorrekt udn verhindern, dass du spielen kannst.\nSoll dies automatisch behoben werden(erfordert Admin-Berechtigungen)?",
                    "DNS-Einstellungen inkorrekt",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                string[] Dns = { "1.1.1.1", "1.0.0.1", "2606:4700:4700::1111", "2606:4700:4700::1001" };
                var CurrentInterface = GetActiveEthernetOrWifiNetworkInterface();
                if (CurrentInterface == null) this.Close();

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();
                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Caption"].ToString().Contains(CurrentInterface.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }
                }

            }
            else
            {
                this.Close();
            }
        }

        public static NetworkInterface GetActiveEthernetOrWifiNetworkInterface()
        {
            var Nic = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(
             a => a.OperationalStatus == OperationalStatus.Up &&
             (a.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || a.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
             a.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily.ToString() == "InterNetwork"));

            return Nic;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Entwickelt von Leon Kappes (Lee/Elsinar) für immortal-roleplay.one - Code auf Github verfügbar und unter der MIT-Lizenz verfügbar!",
                   "Klick nicht so blöd! - Easter-Egg!!!!",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
