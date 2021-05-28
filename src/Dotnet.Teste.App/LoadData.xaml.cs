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
using System.Windows.Shapes;
using Dotnet.Teste.Core.Service;

namespace Dotnet.Teste.App
{
    /// <summary>
    /// Interaction logic for LoadData.xaml
    /// </summary>
    public partial class LoadData : Window
    {
        //private readonly OperationService _dataService = new OperationService();
        private CancellationTokenSource _cts;
        private const int Size = 20000;

        public LoadData()
        {
            InitializeComponent();
        }

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
                //var resultado = await _dataService.Seed(_cts.Token, progress, Size);

                //var fim = DateTime.Now;
                //AtualizarView(resultado, fim - inicio);
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
    }
}
