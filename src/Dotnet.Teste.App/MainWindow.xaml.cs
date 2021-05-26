using System;
using System.Collections.Generic;
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
using Dotnet.Teste.App.Util;
using Dotnet.Teste.Core.Service;

namespace Dotnet.Teste.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataService _dataService = new DataService();
        private CancellationTokenSource _cts;
        private const int Size = 20000;

        public MainWindow()
        {
            InitializeComponent();
        }
        //
        // private void Button_Click(object sender, RoutedEventArgs e)
        // {
        //     var progress = new SeedProgress();
        //     _dataService.Seed();
        // }

        private async void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            BtnProcessar.IsEnabled = false;

            _cts = new CancellationTokenSource();

            PgsProgresso.Maximum = Size;

            LimparView();

            var inicio = DateTime.Now;

            BtnCancelar.IsEnabled = true;
            var progress = new Progress<string>(str =>
                PgsProgresso.Value++);

            try
            {
                var resultado = await _dataService.Seed(_cts.Token, progress, Size);

                var fim = DateTime.Now;
                AtualizarView(resultado, fim - inicio);
            }
            catch (OperationCanceledException)
            {
                TxtTempo.Text = "Operação cancelada pelo usuário";
            }
            finally
            {
                BtnProcessar.IsEnabled = true;
                BtnCancelar.IsEnabled = false;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LimparView()
        {
            LstResultados.ItemsSource = null;
            TxtTempo.Text = null;
            PgsProgresso.Value = 0;
        }

        private void AtualizarView(IEnumerable<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{elapsedTime.Seconds}.{elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count()} clientes em {tempoDecorrido}";

            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }
        //
        // private void BtnProcessar_Click(object sender, RoutedEventArgs e)
        // {
        //
        // }
    }
}