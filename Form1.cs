using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Runtime;
using System.Runtime.InteropServices;
using System.IO;
using RE7FOV.Util;

namespace RE7FOV
{
    public partial class Form1 : Form
    {
        ulong fovAddr;
        int fovValue;
        int actualFOVValue;
        IniFile config;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            fovBar.Enabled = false;
            config = new IniFile();
            if (!File.Exists("RE7FOV.ini")) config.Write("FOV", "4", "RE7FOV"); //Default to "4" ("90" in-game) because who realistically uses 70 FOV lmao
            await FindRE7();
        }

        Random random = new Random();

        async Task FindRE7()
        {
            while (true)
            {
                if (Memory.GetProcess("re7")) break;
                Text = "RE7FOV - Game Not Found";
                await Task.Delay(1000);
            }
            Text = $"RE7FOV - {Memory.process.ProcessName}.exe";
            SetFOV();
            /*while (true)
            {
                ulong hAddr = Memory.ReadMemory<ulong>((ulong)Memory.process.MainModule.BaseAddress + 0x0822AB00); //RE7 process base address + Health pointer address
                float health = Memory.ReadMemory<float>(hAddr + 0x2C4); //Health value + offset in memory
                if (health > 0 && health != 1000f) //Health is temporarily set to 1000 once a save is loaded and gets properly assigned once the player takes control of Ethan
                {
                    SetFOV();
                    break;
                }
                else
                {
                    await Task.Delay(1000);
                }
                if (fovValueLabel.Text != "Not in-game")
                    fovValueLabel.Text = "Not in-game";
            }*/
        }

        async void SetFOV()
        {
            ulong baseAddr = (ulong)Memory.process.MainModule.BaseAddress + 0x081F4EF8;
            ulong tempAddr = Memory.ReadMemory<ulong>(baseAddr);

            ulong[] offsets = { 0x28, 0x78, 0xA8, 0x28, 0x30, 0x60 };

            for (int i = 0; i < 6; i++)
            {
                tempAddr = Memory.ReadMemory<ulong>(tempAddr + offsets[i]);
                await Task.Delay(100);
            }
            fovAddr = tempAddr + 0x28;
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
    }
}
