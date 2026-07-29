using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion.Helpers
{
    [ToolboxItem(true)]
    public class NewComboBox : UserControl
    {
        #region Campos Privados
        private Color _backgroundColor = Color.FromArgb(78, 157, 94);
        private Color _textColor = Color.White;
        private Color _arrowColor = Color.White;
        private Color _dropdownListBackColor = Color.FromArgb(240, 240, 240);
        private ComboBox cmbList;
        private DropDownWindow _dropDownWindow;
        private bool _isTabFocus = false;
        private int _borderSize = 2;
        #endregion

        public NewComboBox()
        {
            cmbList = new ComboBox();

            this.SetStyle(ControlStyles.UserPaint |
                         ControlStyles.ResizeRedraw |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.SupportsTransparentBackColor, true);

            cmbList.DrawMode = DrawMode.OwnerDrawFixed;
            cmbList.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbList.Visible = false;
            cmbList.Width = this.Width;
            cmbList.Location = new Point(0, 0);
            cmbList.BackColor = Color.White;
            cmbList.DrawItem += cmbList_DrawItem;

            cmbList.SelectedIndexChanged += (s, e) =>
            {
                this.Invalidate();
            };

            this.BackColor = Color.White;
            this.Size = new Size(150, 40);
            this.Controls.Add(cmbList);

            cmbList.DropDown += (s, e) =>
            {
                if (this.DesignMode) return;

                COMBOBOXINFO info = new COMBOBOXINFO();
                info.cbSize = Marshal.SizeOf(info);
                if (GetComboBoxInfo(cmbList.Handle, ref info))
                {
                    if (_dropDownWindow == null) _dropDownWindow = new DropDownWindow(this);
                    if (_dropDownWindow.Handle != IntPtr.Zero) _dropDownWindow.ReleaseHandle();
                    _dropDownWindow.AssignHandle(info.hwndList);
                }
            };

            cmbList.SelectedIndexChanged += (s, e) =>
            {
                this.Invalidate();
                OnSelectedIndexChanged(e);
            };

            cmbList.DropDownClosed += (s, e) =>
            {
                _isTabFocus = false;
                this.Refresh();
            };
        }

        #region Eventos Públicos
        private Color _accentColor = Color.FromArgb(78, 157, 94);
        private Color _borderColor = Color.FromArgb(78, 157, 94);

        [Category("Action")]
        public event EventHandler SelectedIndexChanged;

        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, e);
        }
        #endregion

        #region Propiedades de Apariencia Personalizada
        [Category("Custom Appearance")]
        public Color AccentColor
        {
            get => _accentColor;
            set { _accentColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("Grosor del borde del control.")]
        public int BorderSize
        {
            get => _borderSize;
            set { _borderSize = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        public Color ArrowColor
        {
            get => _arrowColor;
            set { _arrowColor = value; this.Invalidate(); }
        }

        [Category("Modern Appearance")]
        public Color DropdownListBackColor
        {
            get => _dropdownListBackColor;
            set { _dropdownListBackColor = value; this.Invalidate(); }
        }
        #endregion

        #region Métodos de Dibujo Personalizado
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            bool mostrarFoco = _isTabFocus || cmbList.DroppedDown;
            Color colorBorde = mostrarFoco ? Color.FromArgb(78, 157, 94) : _borderColor;

            int grosorActual = mostrarFoco ? _borderSize : 1;

            using (Pen p = new Pen(colorBorde, grosorActual))
            {
                if (mostrarFoco)
                {
                    // Ajuste para que el borde grueso no se salga del control
                    g.DrawRectangle(p, grosorActual / 2, grosorActual / 2,
                                   this.Width - grosorActual - 1, this.Height - grosorActual - 1);
                }
                else
                {
                    g.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
                }
            }

            int btnWidth = 26;
            using (Pen arrowPen = new Pen(colorBorde, 1.8f))
            {
                int size = 3;
                int cX = (this.Width - btnWidth) + (btnWidth / 2);
                int cY = this.Height / 2;
                g.DrawLine(arrowPen, cX - size, cY - 1, cX, cY + 2);
                g.DrawLine(arrowPen, cX, cY + 2, cX + size, cY - 1);
            }

            string txt = cmbList.SelectedIndex >= 0 ? (cmbList.SelectedItem != null ? cmbList.SelectedItem.ToString() : "") : this.Text;
            if (!string.IsNullOrEmpty(txt))
            {
                Rectangle rectTexto = new Rectangle(4, 0, this.Width - btnWidth - 2, this.Height);
                TextRenderer.DrawText(g, txt, this.Font, rectTexto, this.ForeColor,
                  TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding);
            }
        }

        private void cmbList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            Graphics g = e.Graphics;
            Color hoverColor = Color.FromArgb(245, 245, 245);

            g.FillRectangle(Brushes.White, e.Bounds);

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                using (SolidBrush sb = new SolidBrush(hoverColor))
                    g.FillRectangle(sb, e.Bounds);

                using (SolidBrush accent = new SolidBrush(_borderColor))
                    g.FillRectangle(accent, e.Bounds.X, e.Bounds.Y, 3, e.Bounds.Height);
            }

            string itemText = cmbList.Items[e.Index] != null ? cmbList.Items[e.Index].ToString() : "";

            int margenLista = 1;
            Rectangle textRect = new Rectangle(e.Bounds.X + margenLista, e.Bounds.Y,
                                             e.Bounds.Width - margenLista, e.Bounds.Height);

            TextRenderer.DrawText(g, itemText, this.Font, textRect, Color.FromArgb(64, 64, 64),
                                 TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }
        #endregion

        #region API Windows
        private class DropDownWindow : NativeWindow
        {
            private NewComboBox _parent;
            [DllImport("user32.dll")] private static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")] private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            public DropDownWindow(NewComboBox parent) => _parent = parent;

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == 0x85) // WM_NCPAINT
                {
                    IntPtr hdc = GetWindowDC(m.HWnd);
                    if (hdc != IntPtr.Zero)
                    {
                        using (Graphics g = Graphics.FromHdc(hdc))
                        {
                            using (Pen p = new Pen(_parent.BorderColor, 2))
                            {
                                g.DrawRectangle(p, 0, 0, _parent.cmbList.DropDownWidth - 1,
                                               _parent.cmbList.DroppedDown ? (uint)GetWindowHeight(m.HWnd) - 1 : 0);
                            }
                        }
                        ReleaseDC(m.HWnd, hdc);
                    }
                }
            }

            [DllImport("user32.dll")]
            private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
            private int GetWindowHeight(IntPtr hWnd)
            {
                GetWindowRect(hWnd, out RECT r);
                return r.Bottom - r.Top;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COMBOBOXINFO
        {
            public int cbSize; public RECT rcItem; public RECT rcButton;
            public int stateButton; public IntPtr hwndCombo; public IntPtr hwndItem; public IntPtr hwndList;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT { public int Left, Top, Right, Bottom; }

        [DllImport("user32.dll")]
        public static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi);
        #endregion

        #region Propiedades de Compatibilidad
        [Category("Behavior")]
        public DrawMode DrawMode
        {
            get => cmbList.DrawMode;
            set => cmbList.DrawMode = value;
        }

        [Category("Appearance")]
        public ComboBoxStyle DropDownStyle
        {
            get => cmbList.DropDownStyle;
            set => cmbList.DropDownStyle = value;
        }

        [Category("Appearance")]
        public FlatStyle FlatStyle
        {
            get => cmbList.FlatStyle;
            set => cmbList.FlatStyle = value;
        }

        [Category("Behavior")]
        public bool FormattingEnabled
        {
            get => cmbList.FormattingEnabled;
            set => cmbList.FormattingEnabled = value;
        }

        [Category("Appearance")]
        public int ItemHeight
        {
            get => cmbList.ItemHeight;
            set { cmbList.ItemHeight = value; this.Invalidate(); }
        }

        [Category("Appearance")]
        public override Color BackColor
        {
            get => base.BackColor;
            set { base.BackColor = value; cmbList.BackColor = value; this.Invalidate(); }
        }

        [Category("Appearance")]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set { base.ForeColor = value; cmbList.ForeColor = value; this.Invalidate(); }
        }

        [Category("Behavior")]
        public int SelectedIndex
        {
            get { return cmbList.SelectedIndex; }
            set
            {
                if (cmbList.SelectedIndex != value)
                {
                    cmbList.SelectedIndex = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Data")]
        public object SelectedItem
        {
            get => cmbList.SelectedItem;
            set => cmbList.SelectedItem = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => cmbList.Text ?? string.Empty;
            set
            {
                cmbList.Text = value ?? string.Empty;
                this.Invalidate();
            }
        }

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ComboBox.ObjectCollection Items => cmbList.Items;
        #endregion

        #region Gestión de foco
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate();
        }
        #endregion

        //Herencia
        #region Overrides de Eventos
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _isTabFocus = true;
            this.Refresh();
            cmbList.DropDownWidth = this.Width;
            cmbList.DroppedDown = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (cmbList != null) cmbList.Width = this.Width;
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (Control.MouseButtons == MouseButtons.None) _isTabFocus = true;
            this.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            _isTabFocus = false;
            this.Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (cmbList.Items.Count > 0 && !cmbList.DroppedDown)
            {
                if (e.Delta > 0 && cmbList.SelectedIndex > 0) cmbList.SelectedIndex--;
                else if (e.Delta < 0 && cmbList.SelectedIndex < cmbList.Items.Count - 1) cmbList.SelectedIndex++;
            }
        }
        #endregion
    }
}