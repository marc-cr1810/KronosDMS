using System;
using System.Drawing;
using System.Windows.Forms;

namespace KronosDMS_Client.UserControls
{
    public partial class SpecialButton : Button
    {
        public SpecialButton()
        {
            InitializeComponent();

            //Set default property values for the button during startup
            SetNormalValues();
        }

        /// &lt;summary&gt;
        /// To Set button properties when not active.i.e when button not in focus.
        /// &lt;/summary&gt;

        private void SetNormalValues()
        {
            this.Font = new Font("Verdana", 8F, FontStyle.Bold);
            this.BackColor = Client.ActiveTheme.Colors.Button.Unfocused;
            this.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.Margin = new Padding(4, 1, 4, 1);
            this.Padding = new Padding(4);
            this.MinimumSize = new Size(10, 10);
            this.Cursor = Cursors.Arrow;
        }

        /// &lt;summary&gt;
        /// Set attributes to highlight button when it is under focus/active.
        /// Change the cursor also as Hand type
        /// &lt;/summary&gt;

        private void SetValuesOnFocus()
        {
            //Increase the font size and colors on focus
            //this.Font = new Font("Verdana", 10F, FontStyle.Bold);

            this.BackColor = Client.ActiveTheme.Colors.Button.Focused;
            this.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            //Set the cursor to Hand type
            this.Cursor = Cursors.Hand;
        }

        /// &lt;summary&gt;
        /// Default handler.Nothing to do here since we don't need to repaint the button.
        /// &lt;/summary&gt;
        /// &lt;param name="pe"&gt;&lt;/param&gt;
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        /// &lt;summary&gt;
        /// Event handler which call SetValuesOnFocus() method to give apecial
        /// effect to button while active
        /// &lt;/summary&gt;
        /// &lt;param name="e"&gt;&lt;/param&gt;

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            SetValuesOnFocus();
        }

        /// &lt;summary&gt;
        /// Event handler which call SetNormalValues() method to set back the button
        /// to normal state
        /// &lt;/summary&gt;
        /// &lt;param name="e"&gt;&lt;/param&gt;

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SetNormalValues();
        }
    }
}