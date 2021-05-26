using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using Dotnet.Teste.App.Http;
using Dotnet.Teste.App.Util;
using Dotnet.Teste.Core.Service;

namespace Dotnet.Teste.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            var result = _client.GetOperations();
            operacoesDG.ItemsSource = result;
        }

        //
        // private void Button_Click(object sender, RoutedEventArgs e)
        // {
        //     var progress = new SeedProgress();
        //     _dataService.Seed();
        // }


        //
        // private void BtnProcessar_Click(object sender, RoutedEventArgs e)
        // {
        //
        // }
    }
}