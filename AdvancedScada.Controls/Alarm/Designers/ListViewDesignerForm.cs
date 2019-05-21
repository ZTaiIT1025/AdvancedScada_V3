using AdvancedScada.Controls.Properties;
using AdvancedScada.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AdvancedScada.Controls.Alarm.Designers
{
    public partial class ListViewDesignerForm : Form
    {
        public string path = string.Empty;
        private string SelectTab;

        public ListViewDesignerForm()
        {
            InitializeComponent();
            var queryFromResourceFile = Resources.Settings;
            path = queryFromResourceFile; // "C:\\Settings.ini";
        }

        private void ListViewDesignerForm_Load(object sender, EventArgs e)
        {
            try
            {
                for (var i = 0; i < ListBoxSelected.Items.Count; i++)
                    nListBoxSelected.Add(Convert.ToString(ListBoxSelected.Items[i]));
                ControlToEdit._nListViewColumnsColor.Clear();
                ListBoxSelected.Items.Clear();
                // Open the file to read from.
                var queryFromResourceFile = Resources.Settings;
                path = queryFromResourceFile; // "C:\\Settings.ini";
                if (File.Exists(path))
                {
                    var ItemsCount = inicls.GetIniValue("Display Format", "ListBoxSelectedItemsCount", path);
                    for (var i = 0; string.CompareOrdinal(i.ToString(), ItemsCount) < 0; i++)
                        ListBoxSelected.Items.Add(inicls.GetIniValue("Display Format",
                            "ListBoxSelected.Items" + Convert.ToString(i), path));
                    Button6.BackColor =
                        Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "Button6.BackColor", path)));
                    Button7.BackColor =
                        Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "Button7.BackColor", path)));
                    Button8.BackColor =
                        Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "Button8.BackColor", path)));
                    Button9.BackColor =
                        Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "Button9.BackColor", path)));
                    Button5.BackColor =
                        Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "BackGround.BackColor", path)));
                    ChkAlarmOff.Checked = bool.Parse(inicls.GetIniValue("Alarm Status", "ChkAlarmOff", path));
                    ChkAlarmOn.Checked = bool.Parse(inicls.GetIniValue("Alarm Status", "ChkAlarmOn", path));
                    ChkAlarmVariation.Checked =
                        bool.Parse(inicls.GetIniValue("Alarm Status", "ChkAlarmVariation", path));
                    ChkAlarmAck.Checked = bool.Parse(inicls.GetIniValue("Alarm Status", "ChkAlarmAck", path));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ControlToEdit._nListViewColumns.Clear();

                for (var i = 0; i < ListBoxSelected.Items.Count; i++)
                    ControlToEdit._nListViewColumns.Add(Convert.ToString(ListBoxSelected.Items[i]));
                // Create a file to write to.


                if (File.Exists(path) == false)
                {
                    File.CreateText(path);
                    var ListBoxSelectedItemsCount = ListBoxSelected.Items.Count.ToString();
                    inicls.SetIniValue("Display Format", " ListBoxSelectedItemsCount", ListBoxSelectedItemsCount, path);
                    for (var i = 0; i < ListBoxSelected.Items.Count; i++)
                        inicls.SetIniValue("Display Format", "ListBoxSelected.Items" + Convert.ToString(i),
                            ControlToEdit._nListViewColumns[i], path);
                }
                else
                {
                    var ListBoxSelectedItemsCount = ListBoxSelected.Items.Count.ToString();
                    inicls.SetIniValue("Display Format", " ListBoxSelectedItemsCount", ListBoxSelectedItemsCount, path);
                    for (var i = 0; i < ListBoxSelected.Items.Count; i++)
                        inicls.SetIniValue("Display Format", "ListBoxSelected.Items" + Convert.ToString(i),
                            ControlToEdit._nListViewColumns[i], path);
                    inicls.SetIniValue("Alarm Status", ChkAlarmOff.Name, $"{ChkAlarmOff.Checked}",
                        path);
                    inicls.SetIniValue("Alarm Status", ChkAlarmOn.Name, $"{ChkAlarmOn.Checked}", path);
                    inicls.SetIniValue("Alarm Status", ChkAlarmVariation.Name,
                        $"{ChkAlarmVariation.Checked}", path);
                    inicls.SetIniValue("Alarm Status", ChkAlarmAck.Name, $"{ChkAlarmAck.Checked}",
                        path);
                }

                ControlToEdit.RListViewColumns();
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var Selected_txt = Convert.ToString(ListBoxSelected.SelectedItem);

                if (Selected_txt != null) // التحقق من عدم خلو اختيار قيمة فارغة
                    if (!ListBoxNonSelected.Items.Contains(Selected_txt)
                    ) // يتم التحقق هل النص موجود سلفا باللست بوكس أما لا حتى لا يضاف مرة أخرى
                    {
                        ListBoxNonSelected.Items.Add(Selected_txt);
                        ListBoxSelected.Items.RemoveAt(ListBoxSelected.SelectedIndex);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                var MyIndex = 0;
                string MyItem = null;
                MyIndex = ListBoxSelected.SelectedIndex;
                MyItem = ListBoxSelected.Text;

                if (MyIndex == 0) return;

                ListBoxSelected.Items.RemoveAt(ListBoxSelected.SelectedIndex);
                ListBoxSelected.Items.Insert(MyIndex - 1, MyItem);
                ListBoxSelected.SelectedIndex = MyIndex - 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                var MyIndex = 0;
                string MyItem = null;
                MyIndex = ListBoxSelected.SelectedIndex;
                MyItem = ListBoxSelected.Text;

                if (MyIndex == ListBoxSelected.Items.Count - 1) return;

                ListBoxSelected.Items.RemoveAt(ListBoxSelected.SelectedIndex);
                ListBoxSelected.Items.Insert(MyIndex + 1, MyItem);
                ListBoxSelected.SelectedIndex = MyIndex + 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button6_Click(dynamic sender, EventArgs e)
        {
            try
            {
                ColorDialog1.ShowDialog();

                if (sender.Name == "Button6")
                {
                    Button6.BackColor = ColorDialog1.Color;
                    ControlToEdit._nListViewColumnsColor.Add(Button6.BackColor);
                    inicls.SetIniValue("Alarm Type", "Button6.BackColor", Button6.BackColor.ToArgb().ToString(), path);
                }

                if (sender.Name == "Button7")
                {
                    Button7.BackColor = ColorDialog1.Color;
                    ControlToEdit._nListViewColumnsColor.Add(Button7.BackColor);
                    inicls.SetIniValue("Alarm Type", "Button7.BackColor", Button7.BackColor.ToArgb().ToString(), path);
                }

                if (sender.Name == "Button8")
                {
                    Button8.BackColor = ColorDialog1.Color;
                    ControlToEdit._nListViewColumnsColor.Add(Button8.BackColor);
                    inicls.SetIniValue("Alarm Type", "Button8.BackColor", Button8.BackColor.ToArgb().ToString(), path);
                }

                if (sender.Name == "Button9")
                {
                    Button9.BackColor = ColorDialog1.Color;
                    ControlToEdit._nListViewColumnsColor.Add(Button9.BackColor);
                    inicls.SetIniValue("Alarm Type", "Button9.BackColor", Button9.BackColor.ToArgb().ToString(), path);
                }

                if (sender.Name == "Button5")
                {
                    Button5.BackColor = ColorDialog1.Color;
                    ControlToEdit._nListViewColumnsColor.Add(Button5.BackColor);
                    inicls.SetIniValue("Alarm Type", "BackGround.BackColor", Button5.BackColor.ToArgb().ToString(),
                        path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CheckBox_Check(System.Windows.Forms.Control root)
        {
            foreach (System.Windows.Forms.Control ctrl in root.Controls)
            {
                CheckBox_Check(ctrl);
                if (ctrl is CheckBox) ((CheckBox)ctrl).Checked = true;
            }
        }

        public static void CheckBox_UCheck(System.Windows.Forms.Control root)
        {
            foreach (System.Windows.Forms.Control ctrl in root.Controls)
            {
                CheckBox_Check(ctrl);
                if (ctrl is CheckBox) ((CheckBox)ctrl).Checked = false;
            }
        }

        private void BtnCheckAll_Click(object sender, EventArgs e)
        {
            try
            {
                switch (SelectTab)
                {
                    case "tbAlarmLevel":
                        CheckBox_Check(tbAlarmLevel);
                        break;
                    case "tbAlarmZone":
                        CheckBox_Check(tbAlarmZone);
                        break;
                    case "tbDisplayType":
                        CheckBox_Check(tbDisplayType);
                        break;
                    case "tbAlarmStatus":
                        CheckBox_Check(tbAlarmStatus);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BtnUCheckAll_Click(object sender, EventArgs e)
        {
            try
            {
                switch (SelectTab)
                {
                    case "tbAlarmLevel":
                        CheckBox_UCheck(tbAlarmLevel);
                        break;
                    case "tbAlarmZone":
                        CheckBox_UCheck(tbAlarmZone);
                        break;
                    case "tbDisplayType":
                        CheckBox_UCheck(tbDisplayType);
                        break;
                    case "tbAlarmStatus":
                        CheckBox_UCheck(tbAlarmStatus);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var Selected_txt = Convert.ToString(ListBoxNonSelected.SelectedItem);

                if (Selected_txt != null) // التحقق من عدم خلو اختيار قيمة فارغة
                    if (!ListBoxSelected.Items.Contains(Selected_txt)
                    ) // يتم التحقق هل النص موجود سلفا باللست بوكس أما لا حتى لا يضاف مرة أخرى
                    {
                        ListBoxSelected.Items.Add(Selected_txt);
                        ListBoxNonSelected.Items.RemoveAt(ListBoxNonSelected.SelectedIndex);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void tbAlarmLevel_Click(object sender, EventArgs e)
        {
            try
            {
                SelectTab = tbAlarmLevel.Name;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbAlarmZone_Click(object sender, EventArgs e)
        {
            SelectTab = tbAlarmZone.Name;
        }

        private void tbDisplayType_Click(object sender, EventArgs e)
        {
            SelectTab = tbDisplayType.Name;
        }

        private void tbAlarmStatus_Click(object sender, EventArgs e)
        {
            SelectTab = tbAlarmStatus.Name;
        }

        #region Properties

        private readonly IniClass inicls = new IniClass();
        private readonly List<string> nListBoxSelected = new List<string>();

        public HMIAlarmMan ControlToEdit { get; set; }

        #endregion
    }
}