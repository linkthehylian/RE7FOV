using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RE7FOV.Util
{
    internal class Memory
    {
        public static Process process;
        public static IntPtr processHandle;
        public static string processName;
        const int PROCESS_WM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;

        public static bool GetProcess(string ProcessName)
        {
            if (ProcessName == "") return false;
            try
            {
                processName = ProcessName;
                process = Process.GetProcessesByName(processName)[0];
                processHandle = Import.OpenProcess(PROCESS_VM_OPERATION | PROCESS_WM_READ | PROCESS_VM_WRITE, false, process.Id);
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public static T ReadMemory<T>(ulong address) where T : struct
        {
            byte[] dataBuffer = new byte[Marshal.SizeOf(typeof(T))];
            int bytesRead = 0;
            Import.ReadProcessMemory((int)processHandle, address, dataBuffer, dataBuffer.Length, ref bytesRead);
            return ByteArrayToStructure<T>(dataBuffer);
        }

        public static void WriteMemory<T>(ulong address, object value)
        {
            byte[] buffer = StructureToByteArray(value);
            int bytesRead = 0;
            Import.WriteProcessMemory((int)processHandle, address, buffer, buffer.Length, ref bytesRead);
        }

        /// <summary>
        /// Credits to C0re
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        private static T ByteArrayToStructure<T>(byte[] data) where T : struct
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            try { return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T)); }
            finally { handle.Free(); }
        }

        /// <summary>
        /// Credits to C0re
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static byte[] StructureToByteArray(object value)
        {
            int size = Marshal.SizeOf(value);
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(value, ptr, true);
            Marshal.Copy(ptr, bytes, 0, size);
            Marshal.FreeHGlobal(ptr);
            return bytes;
        }
    }
}
