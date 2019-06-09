using AdvancedScada.Utils.Compression;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using Microsoft.Win32;
using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.ImagePicker
{
    public delegate void EventImageSelected(Image ImageName);
    public delegate void EventStringImageSelected(string ImageName);
    public partial class MainView : DevExpress.XtraEditors.XtraForm
    {
        public EventStringImageSelected OnStringImageSelected_Clicked = null;
        public EventImageSelected OnImagSelected_Clicked = null;
        public  string ReadKey(string keyName)
        {
            var result = string.Empty;
            try
            {
                RegistryKey regKey;
                regKey = Registry.CurrentUser.OpenSubKey(@"Software\HMI"); //HKEY_CURRENR_USER\Software\VSSCD
                if (regKey != null) result = (string)regKey.GetValue(keyName);
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return result;
        }

        public MainView()
        {
            InitializeComponent();

        }


        GalleryItemGroup[] group1 = null;
        GalleryItemGroup[] group2 = null;
        string[] dirs2 = null;
        private void MainView_Load(object sender, EventArgs e)
        {
            try
            {
                var SelectedPath = ReadKey("Symbols");
                var SelectedPath2 = ReadKey("LibraryImage");
                var dirs = Directory.GetDirectories(SelectedPath);
                dirs2 = Directory.GetDirectories(SelectedPath2);
                foreach (var item2 in dirs)
                {
                    var f = new FileInfo(item2);
                    var v = f.Name.Split('.');
                    cboxListForderSVG.Items.Add(v[0], false);
                }
                foreach (var item2 in dirs2)
                {
                    var f = new FileInfo(item2);
                    var v = f.Name.Split('.');
                    cboxListForder.Items.Add(v[0], false);
                }

                group1 = new GalleryItemGroup[dirs2.Length];
                group2 = new GalleryItemGroup[dirs.Length];
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

 


        }
        private List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }


        private void cboxListForderSVG_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                if (group2[e.Index] == null)
                    group2[e.Index] = new GalleryItemGroup();
                if (e.State == CheckState.Checked)
                {


                    string SelectedPath =  ReadKey("Symbols")+$@"\\{ cboxListForderSVG.SelectedItem.ToString()}";

                    var dirs = DirSearch(SelectedPath).ToArray();
                    SvgDocument svgDocument = null;
                    foreach (var item in dirs)
                    {
                        string newName = Path.GetFileNameWithoutExtension(item);
                        try
                        {
                            svgDocument = SvgDocument.Open(item);
                            var bitmap = svgDocument.Draw();

                            group2[e.Index].Items?.Add(new GalleryItem(bitmap, newName, item));
                            Application.DoEvents();
                            svgDocument = null;
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }

                    }
                    gcSVG.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
                    gcSVG.Gallery.ImageSize = new Size(70, 70);
                    // gcSVG.Gallery.ShowItemText = true;

                    group2[e.Index].Caption = cboxListForderSVG.SelectedItem.ToString();
                    gc.Gallery.BeginUpdate();
                    gcSVG.Gallery.Groups.Add(group2[e.Index]);
                    gc.Gallery.EndUpdate();
                    

                }
                else
                {
                    if (group2[e.Index].Items.Count > 0)
                        gcSVG.Gallery.Groups?.Remove(group2[e.Index]);
                    group2[e.Index] = null;
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }



        }

        private void cboxListForder_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                if (group1[e.Index] == null)
                    group1[e.Index] = new GalleryItemGroup();
                if (e.State == CheckState.Checked)
                {


                    string SelectedPath = ReadKey("LibraryImage")+$@"\\{cboxListForder.SelectedItem.ToString()}";

                    var dirs = DirSearch(SelectedPath).ToArray();
                    foreach (var item in dirs)
                    {
                        string newName = Path.GetFileNameWithoutExtension(item);


                        var bitmap = Image.FromFile(item);

                        group1[e.Index].Items?.Add(new GalleryItem(bitmap, newName, item));
                        Application.DoEvents();
                    }
                    gc.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
                    gc.Gallery.ImageSize = new Size(70, 70);
                    // gcSVG.Gallery.ShowItemText = true;

                    group1[e.Index].Caption = cboxListForder.SelectedItem.ToString();
                    gc.Gallery.BeginUpdate();
                    gc.Gallery.Groups.Add(group1[e.Index]);
                    gc.Gallery.EndUpdate();

                }
                else
                {
                    if (group1[e.Index].Items.Count > 0)
                        gc.Gallery.Groups?.Remove(group1[e.Index]);
                    group1[e.Index] = null;
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }


        }

        private void gc_Gallery_ItemDoubleClick(object sender, GalleryItemClickEventArgs e)
        {
            try
            {
                var bitmap = Image.FromFile(e.Item.Description);
                byte[] data = ImageCompression.ImageToByte(bitmap);
                byte[] dataCompress = ImageCompression.Compress(data);
                string FullNameBase = Convert.ToBase64String(dataCompress);

                //==================================================================
                if (OnStringImageSelected_Clicked != null) OnStringImageSelected_Clicked(FullNameBase);
                //====================================================================================
                if (OnImagSelected_Clicked != null) OnImagSelected_Clicked(bitmap);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            //this.Text =$"{e.Item.Description}";
        }
        
        private void gc_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            this.Text = $"{e.Item.Description}";
            //img = e.Item.Value;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void gc_Gallery_ItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            this.Text = e.Item.Description; //an image's path is stored in the e.Item.Desctiption


        }

        private void gcSVG_Gallery_ItemDoubleClick(object sender, GalleryItemClickEventArgs e)
        {
            try
            {
                var svgDocument = SvgDocument.Open(e.Item.Description);
                var bitmap = svgDocument.Draw();

                byte[] data = ImageCompression.ImageToByte(bitmap);
                byte[] dataCompress = ImageCompression.Compress(data);
                string FullNameBase = Convert.ToBase64String(dataCompress);

                //==================================================================
                if (OnStringImageSelected_Clicked != null) OnStringImageSelected_Clicked(FullNameBase);
                //====================================================================================
                if (OnImagSelected_Clicked != null) OnImagSelected_Clicked(bitmap);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

        }
       
    }
}
