using System;
using System.IO;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Emissions_Expiration_Due.xaml
    /// </summary>
    public partial class Emissions_Expiration_Due : Window
    {
        public Emissions_Expiration_Due()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).DataGridBinding("SELECT * FROM [Work Order]", "WOBind", WODatagrid);
        }
        public static object LoadTemplate(string templatePath)
        {
            object template;

            // get the needed template paths
            string absolutePath = Path.GetFullPath(templatePath);
            string directoryPath = Path.GetDirectoryName(absolutePath);

            using (FileStream inputStream = File.OpenRead(absolutePath))
            {
                var pc = new ParserContext
                {
                    // It is critical to have the trailing backslash here
                    // will not work without it!
                    BaseUri = new Uri(directoryPath + "\\")
                };

                template = XamlReader.Load(inputStream, pc);
            }

            return template;
        }

        public static void ConvertToXps(FixedDocument fixedDoc, Stream outputStream)
        {
            var package = Package.Open(outputStream, FileMode.Create);
            var xpsDoc = new XpsDocument(package, CompressionOption.Normal);
            XpsDocumentWriter xpsWriter = XpsDocument.CreateXpsDocumentWriter(xpsDoc);

            // xps documents are built using fixed document sequences
            var fixedDocSeq = new FixedDocumentSequence();
            var docRef = new DocumentReference();
            docRef.BeginInit();
            docRef.SetDocument(fixedDoc);
            docRef.EndInit();
            ((IAddChild)fixedDocSeq).AddChild(docRef);

            // write out our fixed document to xps
            xpsWriter.Write(fixedDocSeq.DocumentPaginator);

            xpsDoc.Close();
            package.Close();
        }
    }
}
