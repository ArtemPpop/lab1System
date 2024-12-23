﻿using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int lowerBound;
        private int upperBound;
        private int currentGuess;


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, int uType);

    
        private const int MB_OK = 0;

        public MainWindow()
        {
            InitializeComponent();
            lowerBound = 0;
            upperBound = 100;
            ResponsePanel.Visibility = Visibility.Collapsed; 
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {

            lowerBound = 0;
            upperBound = 100;
            ResponsePanel.Visibility = Visibility.Visible;
            StartButton.Visibility = Visibility.Collapsed;
            MakeGuess(); 
        }

        private void MakeGuess()
        {
    
            currentGuess = (lowerBound + upperBound) / 2;
            GuessLabel.Content = $"Мое предположение: {currentGuess}";
        }

        private void Response_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as System.Windows.Controls.Button;

            switch (button.Name)
            {
                case "YesButton": 
                    MessageBox(IntPtr.Zero, "Ура! Я угадал ваше число!", "Игровое сообщение", MB_OK);
                    RestartGame();
                    break;
                case "LowerButton": 
                    upperBound = currentGuess - 1; 
                    MakeGuess();
                    break;
                case "HigherButton": 
                    lowerBound = currentGuess + 1; 
                    MakeGuess();
                    break;
            }
        }

        private void RestartGame()
        {
            lowerBound = 0;
            upperBound = 100;
            ResponsePanel.Visibility = Visibility.Collapsed; 
            StartButton.Visibility = Visibility.Visible; 
        }
    }
}