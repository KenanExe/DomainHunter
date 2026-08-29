using System.Runtime.InteropServices;

namespace DomainChecker
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        // Win32 Ports
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        public const uint SWP_NOSIZE = 0x0001;
        public const uint SWP_NOMOVE = 0x0002;
        public const uint SWP_NOACTIVATE = 0x0010;

        [STAThread]
        static void Main()
        {

            IntPtr consoleHandle = GetConsoleWindow();
            if (consoleHandle != IntPtr.Zero)
            {
                SetWindowPos(consoleHandle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
            }

            ApplicationConfiguration.Initialize();
            SqlCrateDataBase.CreateDatabase();
            Application.Run(new Form1());
        }
    }
}