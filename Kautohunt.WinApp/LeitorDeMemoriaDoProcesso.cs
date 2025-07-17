using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace Kautohunt.WinApp
{
    internal class LeitorDeMemoriaDoProcesso
    {
        private class ApiDaMemoria
        {

            [Flags]
            public enum ProcessAccessType
            {
                PROCESS_TERMINATE = 1,
                PROCESS_CREATE_THREAD = 2,
                PROCESS_SET_SESSIONID = 4,
                PROCESS_VM_OPERATION = 8,
                PROCESS_VM_READ = 16,
                PROCESS_VM_WRITE = 32,
                PROCESS_DUP_HANDLE = 64,
                PROCESS_CREATE_PROCESS = 128,
                PROCESS_SET_QUOTA = 256,
                PROCESS_SET_INFORMATION = 512,
                PROCESS_QUERY_INFORMATION = 1024
            }

            [DllImport("kernel32.dll")]
            public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);
            [DllImport("kernel32.dll")]
            public static extern int ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In][Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesRead);
            [DllImport("kernel32.dll")]
            public static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In][Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);
        }

        private Process m_ReadProcess = null;
        private IntPtr m_hProcess = IntPtr.Zero;
        public Process ReadProcess
        {
            get
            {
                return this.m_ReadProcess;
            }
            set
            {
                this.m_ReadProcess = value;
            }
        }
        public void OpenProcess()
        {
            ApiDaMemoria.ProcessAccessType dwDesiredAccess = ApiDaMemoria.ProcessAccessType.PROCESS_VM_OPERATION | ApiDaMemoria.ProcessAccessType.PROCESS_VM_READ | ApiDaMemoria.ProcessAccessType.PROCESS_VM_WRITE;
            this.m_hProcess = ApiDaMemoria.OpenProcess((uint)dwDesiredAccess, 1, (uint)this.m_ReadProcess.Id);
        }

        public byte[] ReadProcessMemory(IntPtr MemoryAddress, uint bytesToRead, out int bytesRead)
        {
            byte[] array = new byte[bytesToRead];
            IntPtr intPtr;
            ApiDaMemoria.ReadProcessMemory(this.m_hProcess, MemoryAddress, array, bytesToRead, out intPtr);
            bytesRead = intPtr.ToInt32();
            return array;
        }
        public void WriteProcessMemory(IntPtr MemoryAddress, byte[] bytesToWrite, out int bytesWritten)
        {
            IntPtr intPtr;
            LeitorDeMemoriaDoProcesso.ApiDaMemoria.WriteProcessMemory(this.m_hProcess, MemoryAddress, bytesToWrite, (uint)bytesToWrite.Length, out intPtr);
            bytesWritten = intPtr.ToInt32();
        }

    }
}
