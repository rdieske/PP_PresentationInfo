using PP_ShapeInfo.Helper;
using PP_ShapeInfo.Services;
using System.Windows;

namespace PP_ShapeInfo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileHandler fileHandler = new FileHandler(new ApplicationService(), new FileHelper());
        public MainWindow()
        {
            InitializeComponent();
        }
        private void FileDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                fileHandler.HandleFileOpen(files);
            }
        }
    }
}
