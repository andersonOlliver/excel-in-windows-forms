using Dotnet.Teste.App.Http;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using MessageBox = System.Windows.MessageBox;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

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
            operacoesDG.Columns.Clear();
            operacoesDG.ItemsSource = result;
        }


        private void Agrupar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.Print((sender as ComboBox)?.SelectedValue.ToString());
            var result = _client.GetOperations((sender as ComboBox)?.SelectedValue.ToString());
            operacoesDG.Columns.Clear();
            operacoesDG.ItemsSource = result;
        }

        private async void BaixarCSV_Click(object sender, RoutedEventArgs e)
        {
            var groupBy = Agrupar.SelectedValue?.ToString() ?? "todos";
            var exportDialog = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*",
                FileName = $"{groupBy}.csv"
            };

            if (exportDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    await _client.DownloadCsvAsync(groupBy, exportDialog.FileName);
                    MessageBox.Show("Arquivo criado com sucesso!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.Write(ex);
                }
            }

        }

        private async void BaixarExcel_Click(object sender, RoutedEventArgs e)
        {
            var groupBy = Agrupar.SelectedValue?.ToString() ?? "todos";
            var exportDialog = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Excel Worksheets|*.xls| All Files (*.*)|*.*",
                FileName = $"{groupBy}.xls"
            };

            if (exportDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    await _client.DownloadExcelAsync(groupBy, exportDialog.FileName);
                    MessageBox.Show("Arquivo criado com sucesso!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.Write(ex);
                }
            }
        }
    }
}