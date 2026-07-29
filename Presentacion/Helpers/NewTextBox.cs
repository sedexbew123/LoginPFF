using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion.Helpers
{
    [DefaultEvent("TextChanged")]
    [ToolboxItem(true)]

    //Constructor
    public class NewTextbox : UserControl
    {
        #region Campos Privados
        private readonly TextBox _txt = new TextBox();

        private int _borderRadius = 3;
        private int _borderSize = 2;
        private Color _borderColor = Color.FromArgb(78, 157, 94);
        private bool _focused = false;

        private string _placeholderText = "";
        private Color _placeholderColor = Color.Gray;
        private Color _textColorNormal = SystemColors.WindowText;
        private bool _isPlaceholder = false;
        private bool _ignoreTextChanged = false;

        private bool _useSystemPasswordChar = false;
        private char _actualPasswordChar = '\0';
        private bool _isPasswordMode = false;

        private int _placeholderOffsetY = 0;
        private int _placeholderExtraWidth = 16;
        private int _innerTextBoxHeight = 0;
        #endregion

        public NewTextbox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;
            Height = 40;
            Padding = new Padding(6, 6, 6, 6);

            // CONFIGURAR TextBox UNA SOLA VEZ
            _txt.BorderStyle = BorderStyle.None;
            _txt.BackColor = BackColor;
            _txt.ForeColor = ForeColor;
            Controls.Add(_txt);

            // EVENTOS - UNA SOLA SUSCRIPCIÓN CADA UNO
            _txt.TextChanged += Txt_TextChanged;
            _txt.GotFocus += Txt_GotFocus;
            _txt.LostFocus += Txt_LostFocus;
            _txt.KeyPress += Txt_KeyPress;

            this.Resize += NewTextbox_Resize;
            this.GotFocus += (s, e) => _txt.Focus();
            this.LostFocus += (s, e) => { _focused = false; Invalidate(); };
            this.Click += (s, e) => _txt.Focus();

            this.TabStop = true;
            _txt.TabStop = false;

            _textColorNormal = ForeColor;
            UpdateTxtPosition();

            SetPlaceholder();
            _textColorNormal = ForeColor;
            _useSystemPasswordChar = _txt.UseSystemPasswordChar;
            SetPlaceholder();
            _txt.MouseDown += Txt_MouseDown;

            _txt.Font = this.Font;
        }

        #region Eventos del TextBox Interno
        private void Txt_TextChanged(object sender, EventArgs e)
        {
            if (!_ignoreTextChanged)
            {
                if (_isPlaceholder && _txt.Text.Length > 0)
                {
                    RemovePlaceholder();
                }
                OnTextChanged(e);
            }
        }

        private void Txt_GotFocus(object sender, EventArgs e)
        {
            _focused = true;
            if (_isPlaceholder)
            {
                RemovePlaceholder();
            }
            Invalidate();
        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            _focused = false;
            Invalidate();
            SetPlaceholder();
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_isPlaceholder && !char.IsControl(e.KeyChar))
            {
                RemovePlaceholder();
            }
            OnKeyPress(e);
        }

        private void Txt_MouseDown(object sender, MouseEventArgs e)
        {
            if (_isPlaceholder)
            {
                RemovePlaceholder();
            }
        }
        #endregion

        #region Propiedades de Apariencia

        [Category("Apariencia")]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = value < 0 ? 0 : value;
                if (_borderRadius > Height) _borderRadius = Height;
                UpdateTxtPosition();
                Invalidate();
            }
        }

        [Category("Apariencia")]
        public int BorderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = value < 0 ? 0 : value;
                UpdateTxtPosition();
                Invalidate();
            }
        }

        [Category("Apariencia")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                if (_txt != null) _txt.BackColor = value;
                Invalidate();
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                if (_txt != null) _txt.ForeColor = value;
                Invalidate();
            }
        }
        #endregion

        #region Propiedades de Texto y Password
        [Category("Texto")]
        public override string Text
        {
            get => _isPlaceholder ? string.Empty : (_txt.Text ?? string.Empty);
            set
            {
                _isPlaceholder = false;
                _txt.ForeColor = _textColorNormal;

                _txt.Text = value ?? string.Empty;

                if (string.IsNullOrEmpty(_txt.Text))
                    SetPlaceholder();
            }
        }

        public override Font Font
        {
            get => base.Font;
            set
            {
                if (value != null)
                {
                    base.Font = value;
                    _txt.Font = value;
                    // Asegura que el placeholder no se corte al redimensionar
                    NewTextbox_Resize(this, EventArgs.Empty);
                }
            }
        }

        [Category("Texto")]
        public bool UseSystemPasswordChar
        {
            get => _isPasswordMode;
            set
            {
                _isPasswordMode = value;
                _actualPasswordChar = value ? '●' : '\0'; // Usamos el círculo de password
                ActualizarVisualizacionPassword();
            }
        }

        private void ActualizarVisualizacionPassword()
        {
            if (_isPlaceholder)
            {
                _txt.PasswordChar = '\0';
            }
            else
            {
                _txt.PasswordChar = _actualPasswordChar;
            }
        }

        [Category("Texto")]
        public char PasswordChar
        {
            get => _txt.PasswordChar;
            set => _txt.PasswordChar = value;
        }

        [Browsable(false)]
        public int SelectionStart
        {
            get => _txt.SelectionStart;
            set => _txt.SelectionStart = value;
        }

        [Browsable(false)]
        public int SelectionLength
        {
            get => _txt.SelectionLength;
            set => _txt.SelectionLength = value;
        }
        #endregion

        #region Propiedades PlaceHolder y Layout Especial
        [Category("Texto")]
        public string PlaceholderText
        {
            get => _placeholderText;
            set
            {
                _placeholderText = value ?? "";
                SetPlaceholder();
            }
        }

        [Category("Texto")]
        public Color PlaceholderColor
        {
            get => _placeholderColor;
            set
            {
                _placeholderColor = value;
                if (_isPlaceholder && _txt != null) _txt.ForeColor = _placeholderColor;
                Invalidate();
            }
        }

        [Category("Layout")]
        [Description("Desplazamiento vertical del texto placeholder en píxeles (positivo baja el texto).")]
        public int PlaceholderOffsetY
        {
            get => _placeholderOffsetY;
            set
            {
                _placeholderOffsetY = value;
                UpdateTxtPosition();
                Invalidate();
            }
        }

        [Category("Layout")]
        [DefaultValue(16)]
        [Description("Ajuste horizontal: píxeles extra que se suman al ancho disponible para el texto.")]
        public int PlaceholderExtraWidth
        {
            get => _placeholderExtraWidth;
            set
            {
                _placeholderExtraWidth = value;
                UpdateTxtPosition();
                Invalidate();
            }
        }

        [Category("Layout")]
        [Description("Altura fija del TextBox interno en píxeles. 0 = altura automática según la fuente.")]
        public int InnerTextBoxHeight
        {
            get => _innerTextBoxHeight;
            set
            {
                _innerTextBoxHeight = value < 0 ? 0 : value;
                UpdateTxtPosition();
                Invalidate();
            }
        }
        #endregion

        #region Métodos de Dibujo
        private GraphicsPath GetRoundedPath(RectangleF rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2f;

            if (diameter > rect.Height) diameter = rect.Height;
            if (diameter > rect.Width) diameter = rect.Width;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            RectangleF rectSurface = new RectangleF(0.5f, 0.5f, this.Width - 1f, this.Height - 1f);

            float halfBorderSize = _borderSize / 2f;
            RectangleF rectBorder = new RectangleF(
                rectSurface.X + halfBorderSize,
                rectSurface.Y + halfBorderSize,
                rectSurface.Width - _borderSize,
                rectSurface.Height - _borderSize);

            if (_borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, _borderRadius))
                using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, _borderRadius))
                using (Pen penBorder = new Pen(_borderColor, _borderSize))
                {
                    using (SolidBrush brushBack = new SolidBrush(this.BackColor))
                    {
                        e.Graphics.FillPath(brushBack, pathSurface);
                    }

                    if (_borderSize > 0)
                    {
                        penBorder.Alignment = PenAlignment.Center;
                        e.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                using (Pen penBorder = new Pen(_borderColor, _borderSize))
                {
                    e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                }
            }

            if (_focused)
            {
                using (Pen penUnderline = new Pen(_borderColor, 2))
                {
                    float yLine = this.Height - 2.5f;
                    e.Graphics.DrawLine(penUnderline, _borderRadius, yLine, this.Width - _borderRadius, yLine);
                }
            }
        }
        #endregion

        #region Métodos públicos y privados
        public void Clear()
        {
            this.Text = string.Empty;
        }
        public void SelectAll()
        {
            _txt.SelectAll();
        }

        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(_txt.Text) && !string.IsNullOrEmpty(_placeholderText))
            {
                _isPlaceholder = true;
                _ignoreTextChanged = true;

                _txt.PasswordChar = '\0';
                _txt.ForeColor = _placeholderColor;
                _txt.Text = _placeholderText;

                _ignoreTextChanged = false;
            }
        }

        private void RemovePlaceholder()
        {
            if (_isPlaceholder)
            {
                _ignoreTextChanged = true;
                _isPlaceholder = false;
                _txt.Text = string.Empty;
                _txt.ForeColor = _textColorNormal;

                // Aplicamos el círculo de contraseña si el modo está activo
                ActualizarVisualizacionPassword();

                _ignoreTextChanged = false;
            }
        }
        #endregion

        #region Lógica de Posicionamiento (Layout)
        private void UpdateTxtPosition()
        {
            if (_txt is null) return;

            if (_borderRadius > Height) _borderRadius = Height;

            int leftInset = Padding.Left;
            _txt.Left = leftInset;

            int cornerInset = (_borderRadius > 0) ? Math.Max(12, _borderRadius + 6) : 12;
            int rightInset = Padding.Right + _borderSize + cornerInset + 4;

            int newWidth = Width - _txt.Left - rightInset + _placeholderExtraWidth;
            _txt.Width = Math.Max(0, newWidth);

            _txt.Top = Math.Max(0, (Height - _txt.Height) / 2 + _placeholderOffsetY);
            _txt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateTxtPosition();
            if (_txt != null) _txt.Invalidate();
            Invalidate();
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            UpdateTxtPosition();
        }

        private void NewTextbox_Resize(object sender, EventArgs e)
        {
            UpdateTxtPosition();

            if (_borderRadius > Height) _borderRadius = Height;
            if (_txt != null) _txt.Invalidate();
            Invalidate();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateTxtPosition();
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent != null)
            {
                Parent.SizeChanged -= Parent_SizeChanged;
                Parent.SizeChanged += Parent_SizeChanged;
            }
            UpdateTxtPosition();
        }

        private void Parent_SizeChanged(object sender, EventArgs e)
        {
            UpdateTxtPosition();
            if (_txt != null) _txt.Invalidate();
            Invalidate();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            UpdateTxtPosition();
        }
        #endregion
    }
}