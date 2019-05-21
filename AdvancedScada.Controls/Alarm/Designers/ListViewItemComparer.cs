using System.Collections;
using System.Windows.Forms;

namespace AdvancedScada.Controls.Alarm.Designers
{
    internal class ListViewItemComparer : IComparer
    {
        private readonly int col;

        public ListViewItemComparer()
        {
            col = 0;
        }

        public ListViewItemComparer(int column)
        {
            col = column;
        }

        public int Compare(object x, object y)
        {
            return string.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        }
    }
}