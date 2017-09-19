using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    public class ListViewFreezer
    {
        private readonly ListView _listView;
        private Label _label;

        public ListViewFreezer(ListView listView)
        {
            _listView = listView;
        }

        private void MakeLabel()
        {
            _label = new Label
            {
                Parent = _listView,
                Text = "Waiting...",
                Visible = false,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
            };

            _label.Location = new Point(_listView.Height / 2 - _label.Height / 2, _listView.Width / 2 - _label.Width / 2);
        }

        public void FreezeListView()
        {
            _listView.Enabled = false;
            _listView.Items.Clear();
            _listView.Cursor = Cursors.WaitCursor;

            if (_label == null)
                MakeLabel();
            _label.Visible = true;

            //_listView.Invalidate();
            //_label.Invalidate();
            _listView.Parent.Invalidate(_listView.Region);
        }

        public void UnfreezeListView()
        {
            _listView.Enabled = true;
            _listView.Cursor = Cursors.Default;

            if (_label != null)
                _label.Visible = false;
        }
    }
}