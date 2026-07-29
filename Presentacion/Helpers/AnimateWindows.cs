using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion.Helpers
{
    internal static class AnimateWindows
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool AnimateWindow(IntPtr hWnd, int time, AnimateWindowsFlags flags);

        [Flags]
        public enum AnimateWindowsFlags
        {
            //Tipos de Animaciones
            AW_CENTER = 0x00000010,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000,

            //Direcciones de las Animaciones

            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,

            //Acciones de las Animaciones

            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,

        }
        public static void Start(Control target, int duracionMS, AnimateWindowsFlags flags)
        {
            if (target == null)
                return;

            AnimateWindow(target.Handle, duracionMS, flags);
        }
    }
}
