//Copyright (C) Dmitry Koval
//Данный код не является коммерческим и распространяется под лицензией MIT.
using Blaze3DCreator.GameProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Blaze3DCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += onMainWindow_Loaded;
            Closing += OnMainWindow_Closing;
        }

        

        private void onMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= onMainWindow_Loaded;
            OpenProjectBrowserDialog();
        }
        private void OnMainWindow_Closing(object? sender, CancelEventArgs e)
        {
            Closing -= OnMainWindow_Closing;
            Project.Current?.Unload();
        }
        private void OpenProjectBrowserDialog()
        {
            var projectBrowser = new ProjectBrowserDialog();
            if(projectBrowser.ShowDialog() == false || projectBrowser.DataContext == null)
            {
                Application.Current.Shutdown();
            }
            else
            {
                Project.Current?.Unload();
                DataContext = projectBrowser.DataContext;

            }
        }
    }
}
