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

namespace lab_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Alphabet { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            
            int numb_let = 0;
            string finish_text = string.Empty;
            string start_text = EncodeInputTextBox.Text.ToUpper();
            int key = Convert.ToInt32(EncodeKeyTextBox.Text);
            for (int i = 0; i < start_text.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    if (Alphabet[j] == start_text[i])
                    {
                        numb_let = j;
                        break;
                    }
                }

                numb_let = ((numb_let + 1) * key % Alphabet.Length);
                finish_text += Alphabet[numb_let - 1];

            }

            EncodeResultTextBox.Text = finish_text;
        }

        private void DecodeButton_Click(object sender, RoutedEventArgs e)
        {
            int numb_let = 1;
            string finish_text = "";
            string start_text = DecodeInputTextBox.Text.ToUpper();
            /*if (textBox_key_code != textBox_key_decode)
            {
                DialogResult result = MessageBox.Show(
               "Ошибка",
               "Ключи не совпадают",
               MessageBoxButtons.YesNo
               );
            }
            DialogResult result = MessageBox.Show(
                "Ошибка",
                "Ключи не совпадают",
                MessageBoxButtons.YesNo
                );*/
            int key = Convert.ToInt32(DecodeKeyTextBox.Text);
            for (int i = 0; i < start_text.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    if (start_text[i] == Alphabet[j])
                    {
                        numb_let = j;
                        break;
                    }
                }
                if ((numb_let + 1) % key == 0 && numb_let > key)
                {
                    numb_let = (numb_let + 1) / key % Alphabet.Length;
                }
                else
                {
                    while ((numb_let + 1) % key != 0)
                    {

                        numb_let += Alphabet.Length;

                    }
                    numb_let = (numb_let + 1) / key % Alphabet.Length;

                }
                finish_text += Alphabet[numb_let - 1];
            }

            DecodeResultTextBox.Text = finish_text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string alphabetLenght = Alphabet.Length.ToString();
            EncodeNTextBox.Text = alphabetLenght;
            DecodeNTextBox.Text = alphabetLenght;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EncodeInputTextBox.Clear();
            EncodeResultTextBox.Clear();
            DecodeResultTextBox.Clear();
            DecodeInputTextBox.Clear();
        }
    }
}
