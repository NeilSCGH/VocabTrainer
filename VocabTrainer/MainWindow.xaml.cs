using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace VocabTrainer
{
    public partial class MainWindow : Window
    {

        List<string> questions = new List<string>();
        List<string> answers = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension("words", ".csv"));
            
            foreach (string line in lines)
            {
                string[] tmp = line.Split(';');
                questions.Add(tmp[0]);
                answers.Add(tmp[1]);
            }
            

        }

        private void Answer1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("neil");
        }

        private void Answer2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Answer3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Answer4_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
