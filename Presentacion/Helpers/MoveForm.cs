using System;

namespace Presentacion.Helpers
{
    internal class MoveForm
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "ReleaseCapture")]

        internal extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage")]

        internal extern static void SendMessage(System.IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
    }
}
