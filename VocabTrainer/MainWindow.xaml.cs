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

        private int[] answersIds = new int[4];
        private int realAnswer, nb;
        private Random rng = new Random();

        public MainWindow()
        {
            string[] lines, tmp;

            InitializeComponent();

            lines = File.ReadAllLines(Path.ChangeExtension("words", ".csv"));
            nb = lines.Length;

            foreach (string line in lines)
            {
                tmp = line.Split(';');
                questions.Add(tmp[0]);
                answers.Add(tmp[1]);
            }

            newQuestion();
        }

        private void newQuestion()
        {
            answersIds = new int[4];

            answersIds[0] = rng.Next(nb);

            do{answersIds[1] = rng.Next(nb);
            } while (answersIds[1] == answersIds[0]);

            do{answersIds[2] = rng.Next(nb);
            } while (answersIds[2] == answersIds[0] || answersIds[2] == answersIds[1]);
            
            do{answersIds[3] = rng.Next(nb);
            } while (answersIds[3] == answersIds[0] || answersIds[3] == answersIds[1] || answersIds[3] == answersIds[2]);

            realAnswer = rng.Next(4);

            question.Content = questions[answersIds[realAnswer]];
            answer1.Content = answers[answersIds[0]];
            answer2.Content = answers[answersIds[1]];
            answer3.Content = answers[answersIds[2]];
            answer4.Content = answers[answersIds[3]];
        }

        private void result(int answerClicked)
        {
            if (answerClicked == realAnswer)
            {
                MessageBox.Show("True");
            }
            else
            {
                MessageBox.Show("False");
            }
        }

        private void Answer1_Click(object sender, RoutedEventArgs e)
        {
            result(0);
        }

        private void Answer2_Click(object sender, RoutedEventArgs e)
        {
            result(1);
        }

        private void Answer3_Click(object sender, RoutedEventArgs e)
        {
            result(2);
        }

        private void Answer4_Click(object sender, RoutedEventArgs e)
        {
            result(3);
        }
    }
}
