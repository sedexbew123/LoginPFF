using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion.Helpers
{
    public class NewButton : Button
    {
        #region Campos de Estado
        private bool _isHovered = false;
        private bool _isFocused = false;
        #endregion

        #region Propiedades de Apariencia
        [Category("Apariencia"), Description("Si es true, el botón siempre será perfectamente redondo en los extremos.")]
        public bool AutoCapsula { get; set; } = false;

        [Category("Apariencia")]
        public bool ActivarAntiAlias { get; set; } = true;

        [Category("Apariencia")]
        public System.Drawing.Color ColorInicio { get; set; } = System.Drawing.Color.FromArgb(135, 202, 158);

        [Category("Apariencia")]
        public System.Drawing.Color ColorFin { get; set; } = System.Drawing.Color.FromArgb(90, 170, 118);

        [Category("Apariencia")]
        public System.Drawing.Color ColorHoverInicio { get; set; } = System.Drawing.Color.FromArgb(155, 222, 178);

        [Category("Apariencia")]
        public System.Drawing.Color ColorHoverFin { get; set; } = System.Drawing.Color.FromArgb(110, 190, 138);

        [Category("Apariencia")]
        public System.Drawing.Color ColorTabInicio { get; set; } = System.Drawing.Color.FromArgb(122, 194, 150);

        [Category("Apariencia")]
        public System.Drawing.Color ColorTabFin { get; set; } = System.Drawing.Color.FromArgb(84, 163, 110);

        [Category("Apariencia")]
        public bool UsarHoverPersonalizado { get; set; } = true;

        [Category("Apariencia")]
        public bool UsarTabPersonalizado { get; set; } = true;

        [Category("Apariencia")]
        public System.Drawing.Color ColorBorde { get; set; } = System.Drawing.Color.Black;

        [Category("Apariencia")]
        public float GrosorBorde { get; set; } = 1f;

        [Category("Apariencia")]
        public int RadioBorde { get; set; } = 1;
        #endregion

        public NewButton()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                          ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = System.Drawing.Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            this.SetStyle(ControlStyles.Selectable, true);
        }
        protected override bool ShowFocusCues
        {
            get { return false; }
        }
        #region Eventos de Actualización
        protected override void OnMouseEnter(EventArgs e) { _isHovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _isHovered = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnGotFocus(EventArgs e) { _isFocused = true; Invalidate(); base.OnGotFocus(e); }
        protected override void OnLostFocus(EventArgs e) { _isFocused = false; Invalidate(); base.OnLostFocus(e); }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(Parent?.BackColor ?? BackColor);

            if (ActivarAntiAlias)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            }

            if (Parent != null)
            {
                using (var brushFondo = new SolidBrush(Parent.BackColor))
                    g.FillRectangle(brushFondo, ClientRectangle);
            }

            float m = 2.2f;
            RectangleF rect = new RectangleF(m, m, Width - (m * 2.1f), Height - (m * 2.1f));

            float radioFinal;
            if (AutoCapsula)
            {
                radioFinal = rect.Height / 2f;
            }
            else
            {
                radioFinal = Math.Min(RadioBorde, rect.Height / 2f);
                if (radioFinal <= 0) radioFinal = 0.1f;
            }

            using (GraphicsPath path = GetRoundedPath(rect, radioFinal))
            {
                System.Drawing.Color c1 = (_isFocused && UsarTabPersonalizado) ? ColorTabInicio :
                                         (_isHovered && UsarHoverPersonalizado) ? ColorHoverInicio : ColorInicio;
                System.Drawing.Color c2 = (_isFocused && UsarTabPersonalizado) ? ColorTabFin :
                                         (_isHovered && UsarHoverPersonalizado) ? ColorHoverFin : ColorFin;

                using (var brush = new LinearGradientBrush(rect, c1, c2, 90f))
                    g.FillPath(brush, path);

                if (GrosorBorde > 0)
                {
                    using (Pen pen = new Pen(ColorBorde, GrosorBorde))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        g.DrawPath(pen, path);
                    }
                }
            }

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                sf.Trimming = StringTrimming.EllipsisCharacter;
                sf.FormatFlags = StringFormatFlags.NoWrap;

                using (SolidBrush textBrush = new SolidBrush(this.ForeColor))
                {
                    g.DrawString(this.Text, this.Font, textBrush, ClientRectangle, sf);
                }
            }
        }

        private GraphicsPath GetRoundedPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float d = radius * 2f;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}