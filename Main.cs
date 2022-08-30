using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Linq;
using RE7FOV.Util;

namespace RE7FOV
{
    public partial class MainForm : Form
    {
        ulong fovAddr;
        int fovValue;
        int actualFOVValue;
        IniFile config;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            fovBar.Value = 0;
            fovValueLabel.Text = "0";
            fovBar.Enabled = false;
            config = new IniFile();
            if (!File.Exists("RE7FOV.ini")) config.Write("FOV", "7", "RE7FOV"); //Default to "7" ("105°" in-game) because who realistically uses 70 FOV lmao
            await FindRE7();
        }

        async Task FindRE7()
        {
            while (true)
            {
                if (Memory.GetProcess("re7")) break;
                Text = "RE7FOV - Game Not Found";
                await Task.Delay(1000);
            }
            Text = $"RE7FOV - {Memory.process.ProcessName}.exe";
            if (dlc1Box.Checked) //Not A Hero
                SetFOV(FOVOffsets.dlc1);
            if (dlc2Box.Checked) //End of Zoe
                SetFOV(FOVOffsets.dlc2);
            if (OldVersion()) SetFOV(FOVOffsets.dx11);
            else SetFOV(FOVOffsets.main);
        }

        bool OldVersion()
        {
            //Detect what version of RE7 is being played. "D3D12" folder and "D3D12Core.dll" file only exist in the next-gen version.
            //If the above folder and file don't exist, then the DirectX 11 version of RE7 is being played.

            string[] x = Memory.process.MainModule.FileName.Split('\\');
            string path = string.Join("\\", x.Take(x.Length - 1)) + "\\D3D12";
            if (Directory.Exists(path) && File.Exists(path + "\\D3D12Core.dll")) return false;

            return true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fovBar.Enabled && File.Exists("RE7FOV.ini") && int.Parse(config.Read("FOV")) != fovValue)
            {
                fovValue = Memory.ReadMemory<int>(fovAddr);
                config.Write("FOV", fovValue.ToString(), "RE7FOV");
            }
        }

        /// <summary>
        /// Set the FOV in-game
        /// </summary>
        /// <param name="offsets">different offsets depending on if playing DLC or not</param>
        async void SetFOV(ulong[] offsets)
        {
            switch (OldVersion())
            {
                case true:
                    ulong baseAddr = (ulong)Memory.process.MainModule.BaseAddress + 0x081F4EF8; //dx11 = 0x081F4EF8
                    ulong tempAddr = Memory.ReadMemory<ulong>(baseAddr);

                    for (int i = 0; i < offsets.Count() - 1; i++)
                    {
                        tempAddr = Memory.ReadMemory<ulong>(tempAddr + offsets[i]);
                        await Task.Delay(100);
                    }
                    fovAddr = tempAddr + offsets.Last();
                    refreshBtn.Enabled = true;
                    break;

                default:
                    dlc1Box.Enabled = true;
                    dlc2Box.Enabled = true;
                    ulong baseAddrNew = (ulong)Memory.process.MainModule.BaseAddress + 0x08F8D9A8; //Next-gen = 0x08F8D9A8
                    ulong tempAddrNew = Memory.ReadMemory<ulong>(baseAddrNew);

                    for (int i = 0; i < offsets.Count() - 1; i++)
                    {
                        tempAddrNew = Memory.ReadMemory<ulong>(tempAddrNew + offsets[i]);
                        await Task.Delay(100);
                    }
                    fovAddr = tempAddrNew + offsets.Last();
                    refreshBtn.Enabled = true;
                    break;
            }
            fovValue = GetFOVValue(); //Field of Vision value as displayed in Cheat Engine | 70 = 0, 80 = 2, 90 = 4
            if (File.Exists("RE7FOV.ini") && config.KeyExists("FOV"))
            {
                fovValue = int.Parse(config.Read("FOV"));
                fovValueLabel.Text = actualFOVValue.ToString();
                Memory.WriteMemory<int>(fovAddr, fovValue);
            }
            actualFOVValue = GetActualFOV(fovValue); //Field of Vision value as shown in-game
            fovValueLabel.Text = actualFOVValue.ToString();
            fovBar.Enabled = true;
            refreshBtn.Visible = true;
            if (fovValue < fovBar.Maximum + 1) fovBar.Value = fovValue;
        }

        int GetFOVValue()
        {
            fovValue = Memory.ReadMemory<int>(fovAddr);
            return fovValue;
        }

        int GetActualFOV(int memoryValue)
        {
            int correctFOV = 70;
            for (int i = 0; i < memoryValue; i++)
            {
                correctFOV += 5;
            }
            return correctFOV;
        }

        private void fovBar_Scroll(object sender, EventArgs e)
        {
            Memory.WriteMemory<int>(fovAddr, fovBar.Value);
            fovValue = fovBar.Value;
            fovValueLabel.Text = GetActualFOV(fovValue).ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/linkthehylian/RE7FOV");
        }

        private void Main_MouseHover(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(refreshBtn, "Refresh");
        }

        private void dlc1Box_CheckedChanged(object sender, EventArgs e)
        {
            if (dlc1Box.Checked)
            {
                dlc2Box.Enabled = false;
                MainForm_Load(sender, e);
            }
            else
            {
                dlc2Box.Enabled = true;
                MainForm_Load(sender, e);
            }
        }

        private void dlc2Box_CheckedChanged(object sender, EventArgs e)
        {
            if (dlc2Box.Checked)
            {
                dlc1Box.Enabled = false;
                MainForm_Load(sender, e);
            }
            else
            {
                dlc1Box.Enabled = true;
                MainForm_Load(sender, e);
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            MainForm_Load(sender, e);
        }
    }
}