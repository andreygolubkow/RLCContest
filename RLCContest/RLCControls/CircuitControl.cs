using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLCControls
{
    public partial class CircuitControl : UserControl
    {
        public CircuitControl()
        {
            InitializeComponent();
        }

        public void AddControl(Control control)
        {

            control.ContextMenuStrip = componentMenu;
            control.Location = new System.Drawing.Point(20, 20);
            control.MouseMove += OnDrag;
            Controls.Add(control);
        }

        private void OnDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                StartDrag(sender as ElementControl);
        }

        private void StartDrag(Control control)
        {
            var dragForm = new Form { FormBorderStyle = FormBorderStyle.None, ShowInTaskbar = false, Size = control.Size, Location = control.PointToScreen(Point.Empty), StartPosition = FormStartPosition.Manual };
            var bmp = new Bitmap(control.Width, control.Height);
            dragForm.BackgroundImage = bmp;
            control.DrawToBitmap(bmp, new Rectangle(0, 0, control.Width, control.Height));
            control.Visible = false;
            var mouseStartPos = Control.MousePosition;
            dragForm.Shown += (o, e) =>
            {
                dragForm.Size = control.Size;
            };
            dragForm.MouseMove += (o, e) =>
            {
                var mp = Control.MousePosition;
                var p = control.PointToScreen(Point.Empty);
                dragForm.Location = new Point(p.X - mouseStartPos.X + mp.X, p.Y - mouseStartPos.Y + mp.Y);
            };
            dragForm.MouseUp += (o, e) =>
            {
                if (dragForm.Bounds.IntersectsWith(Bounds))
                {
                    var target = FindControlAtPoint(this, Control.MousePosition);
                    control.Parent = target;
                    control.Location = target.PointToClient(dragForm.Location);
                }
                control.Visible = true;
                dragForm.Close();
            };
            dragForm.ShowDialog(this);
        }

        private static Control FindControlAtPoint(Control container, Point screenPos)
        {
            var pos = container.PointToClient(screenPos);
            Control child;
            foreach (Control c in container.Controls)
            {
                if (c.Visible && c.Bounds.Contains(pos))
                {
                    child = FindControlAtPoint(c, screenPos);
                    if (child == null) return c;
                    return child;
                }
            }
            return container;
        }

        private void ComponentMenuOpening(object sender, CancelEventArgs e)
        {
            //connectToolStripMenuItem.DropDownItems
            connectToolStripMenuItem.DropDownItems.Clear();
            foreach (var control in Controls)
            {
                if ( control is ElementControl )
                {
                    var item = new ToolStripMenuItem
                               {
                                   Name = ((ElementControl)control).ElementName,
                                   Text = ((ElementControl)control).ElementName
                               };
                    item.Click += OnTryConnectItem;
                    connectToolStripMenuItem.DropDownItems.Add(item);
                }
            }
        }

        private void OnTryConnectItem(object sender, EventArgs e)
        {
            
        }
    }
}
