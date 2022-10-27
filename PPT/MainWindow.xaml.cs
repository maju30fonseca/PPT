using System;
using System.Collections.Generic;
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

namespace PPT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        enum jogada { Pedra , Papel , Tesoura }
        enum Resultado { Jogador, Bot, Empate}
        jogada jogador = new jogada();
        jogada bot = new jogada();
        Random rdm = new Random();
        Resultado ganhador = new Resultado();
       
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnPedra_Click(object sender, RoutedEventArgs e)
        {
            
           imgPedra.Visibility = Visibility.Visible;
            imgPapel.Visibility = Visibility.Hidden;
            imgTesoura.Visibility = Visibility.Hidden;
            jogador = jogada.Pedra;
            
            escolhabot();
            VerificarGanhador();
            
        }

        private void btnPapel_Click(object sender, RoutedEventArgs e)
        {
            imgPapel.Visibility = Visibility.Visible;
            imgPedra.Visibility = Visibility.Hidden;
            imgTesoura.Visibility = Visibility.Hidden;
            jogador = jogada.Papel;
            
            escolhabot();
            VerificarGanhador(); 
        }

        private void btnTesoura_Click(object sender, RoutedEventArgs e)
        {
           imgTesoura.Visibility = Visibility.Visible;
           imgPedra.Visibility = Visibility.Hidden;
            imgPapel.Visibility = Visibility.Hidden;
            jogador = jogada.Tesoura;
            
            escolhabot();
            VerificarGanhador();
        }
        void escolhabot()
        {
         
            int numero = rdm.Next(1, 4);
            
            if (numero == 1)
                
            {
                
                bot = jogada.Pedra;
                imgPedraBot.Visibility = Visibility.Visible;
                imgTesouraBot.Visibility = Visibility.Hidden;
                imgPapelBot.Visibility = Visibility.Hidden;
            }
            else if(numero == 2)
            {
                
                bot = jogada.Papel;
                imgPapelBot.Visibility = Visibility.Visible;
                imgTesouraBot.Visibility = Visibility.Hidden;
                imgPedraBot.Visibility = Visibility.Hidden;

            }
            else if(numero == 3)
            {
                
                bot = jogada.Tesoura;
                imgTesouraBot.Visibility = Visibility.Visible;
                imgPedraBot.Visibility = Visibility.Hidden;
                imgPapelBot.Visibility = Visibility.Hidden;
            }
        }
        void VerificarGanhador()
        {
            switch (jogador)
            {
                case jogada.Pedra:
                    if (bot == jogada.Pedra)
                        ganhador = Resultado.Empate;
                    else if (bot == jogada.Papel)
                        ganhador = Resultado.Bot;
                    else if (bot == jogada.Tesoura)
                        ganhador = Resultado.Jogador;
                    break;

                case jogada.Papel:
                    if (bot == jogada.Pedra)
                        ganhador = Resultado.Jogador;
                    else if (bot == jogada.Papel)
                        ganhador = Resultado.Empate;
                    else if (bot == jogada.Tesoura)
                        ganhador = Resultado.Bot;
                    break;
                case jogada.Tesoura:
                    if (bot == jogada.Pedra)
                        ganhador = Resultado.Bot;
                    else if (bot == jogada.Papel)
                        ganhador = Resultado.Jogador;
                    else if (bot == jogada.Tesoura)
                        ganhador = Resultado.Empate;
                    break;

            }

            if(ganhador == Resultado.Jogador)
            {
                contadorJogador.Text = (int.Parse(contadorJogador.Text) + 1).ToString();
                txtVencedor.Text = "Jogador vence a rodada!";


            }
            else if(ganhador == Resultado.Bot)
            {
                contadorBot.Text = (int.Parse(contadorBot.Text) + 1).ToString();
                txtVencedor.Text = "Computador vence a rodada!";
            }
            else
            {
                txtVencedor.Text = "Empatou!";
            }
        }
       
    }
}
