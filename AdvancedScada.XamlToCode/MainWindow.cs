using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Markup;
using AdvancedScada.ConvertControls;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
namespace AdvancedScada.XamlToCode
{
    public partial class MainWindow : XtraForm
    {
        private bool _validXaml;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConvert_ItemClick(object sender, ItemClickEventArgs e)
        {
            _validXaml = true;
            statusInfo.Caption = string.Empty;

            //// Grab the text for the XAML source
            //TextRange range = new TextRange(this.txtXAML.Document.ContentStart, this.txtXAML.Document.ContentEnd);


            if (!string.IsNullOrEmpty(txtXAML.Text))
            {


                if (cboxConvertControls.Checked)
                {
                    var srcCode = new XamlConvertor().ConvertToString(txtXAML.Text);
                    txtCode.Text = srcCode;
                    tbXamlToCode.SelectedTabPageIndex = 1;
                }
                else
                {

                    // Generate and display the XAMl visual tree
                    GenerateXAMLVisualTree(txtXAML.Text);
                    // Only continue if the XAML is valid
                    if (_validXaml)
                    {
                        var cnv = new XamlToCodeConverter();

                        // Generate the code for this XAML
                        var srcCode = cnv.Convert(txtXAML.Text);


                        txtCode.Text = srcCode;
                        tbXamlToCode.SelectedTabPageIndex = 1;
                        // Compile the code and show the visual tree for the code
                        var res = cnv.CompileAssemblyFromLastCodeCompileUnit();
                        if (res.Errors.Count > 0)
                            foreach (CompilerError err in res.Errors)
                            {
                                var errorMsg = string.Format("Line: {0}, Column: {1}: {2}", err.Line, err.Column,
                                    err.ErrorText);
                                Debug.WriteLine(errorMsg);
                                statusInfo.Caption = errorMsg;
                            }
                    }
                }
            }
        }
        private void GenerateXAMLVisualTree(string xaml)
        {
            using (var ms = new MemoryStream(xaml.Length))
            {
                using (var sw = new StreamWriter(ms))
                {
                    try
                    {
                        sw.Write(xaml);
                        sw.Flush();

                        ms.Seek(0, SeekOrigin.Begin);

                        // Load the Xaml
                        // object content = ActivityXamlServices.Load(ms);


                    }
                    catch (XamlParseException x)
                    {
                        Debug.WriteLine("XAML Parse error: Line:{0}, Position:{1}, Error: {2}", x.LineNumber, x.LinePosition, x.Message);
                        statusInfo.Caption = x.Message;
                        _validXaml = false;
                    }
                    catch (Exception ex)
                    {
                        // Generic message
                        statusInfo.Caption = ex.Message;
                        _validXaml = false;
                    }
                }
            }
        }

        private void barBtnDeleteList_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtCode.Clear();
            txtXAML.Clear();
        }

        private void barBtnBaek_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tbXamlToCode.SelectedTabPageIndex == 1)
                tbXamlToCode.SelectedTabPageIndex = 0;
        }

        private void barBtnCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtCode.Text == string.Empty) return;
            Clipboard.SetText(txtCode.Text);
        }
    }
}
