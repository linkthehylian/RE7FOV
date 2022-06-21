using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Linq;
using RE7FOV.Util;

namespace RE7FOV
{
    public partial class Main : Form
    {
        ulong fovAddr;
        int fovValue;
        int actualFOVValue;
        IniFile config;

        public Main()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
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
            if (checkBox1.Checked) //Not A Hero
                SetFOVDLC1();
            if (checkBox2.Checked) //End of Zoe
                SetFOVDLC2();
            else
                SetFOV();
        }

        async void SetFOVDLC1()
        {
            ulong baseAddr = (ulong)Memory.process.MainModule.BaseAddress + 0x08F8D9A8;
            ulong tempAddr = Memory.ReadMemory<ulong>(baseAddr);
            ulong[] fovoffsets = { 0xE8, 0x118, 0x258, 0x20, 0x10, 0x40, 0x9E8 }; //Not A Hero FOV offsets

            for (int i = 0; i < 6; i++)
            {
                tempAddr = Memory.ReadMemory<ulong>(tempAddr + fovoffsets[i]);
                await Task.Delay(100);
            }
            fovAddr = tempAddr + fovoffsets.Last();
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
            pictureBox1.Visible = true;
            if (fovValue < fovBar.Maximum + 1) fovBar.Value = fovValue;
        }

        async void SetFOVDLC2()
        {
            ulong baseAddr = (ulong)Memory.process.MainModule.BaseAddress + 0x08F8D9A8;
            ulong tempAddr = Memory.ReadMemory<ulong>(baseAddr);

            ulong[] fovoffsets = { 0xE0, 0x98, 0x120, 0x188, 0xC0, 0x60, 0x18 }; //End of Zoe FOV offsets

            for (int i = 0; i < 6; i++)
            {
                tempAddr = Memory.ReadMemory<ulong>(tempAddr + fovoffsets[i]);
                await Task.Delay(100);
            }
            fovAddr = tempAddr + fovoffsets.Last();
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
            pictureBox1.Visible = true;
            if (fovValue < fovBar.Maximum + 1) fovBar.Value = fovValue;
        }

        async void SetFOV()
        {
            ulong baseAddr = (ulong)Memory.process.MainModule.BaseAddress + 0x08F8D9A8;
            ulong tempAddr = Memory.ReadMemory<ulong>(baseAddr);

            ulong[] fovoffsets = { 0xD8, 0x178, 0xD8, 0x178, 0x50, 0x38, 0x148 }; //Main campaign FOV offsets

            for (int i = 0; i < 6; i++)
            {
                tempAddr = Memory.ReadMemory<ulong>(tempAddr + fovoffsets[i]);
                await Task.Delay(100);
            }
            fovAddr = tempAddr + fovoffsets.Last();
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
            pictureBox1.Visible = true;
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fovBar.Enabled && File.Exists("RE7FOV.ini") && int.Parse(config.Read("FOV")) != fovValue)
            {
                fovValue = Memory.ReadMemory<int>(fovAddr);
                config.Write("FOV", fovValue.ToString(), "RE7FOV");
            }
        }

        private void Main_MouseHover(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(pictureBox1, "Refresh");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Enabled = false;
                Form1_Load(sender, e);
            }
            else
            {
                checkBox2.Enabled = true;
                Form1_Load(sender, e);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Enabled = false;
                Form1_Load(sender, e);
            }
            else
            {
                checkBox1.Enabled = true;
                Form1_Load(sender, e);
            }
        }
    }
}
