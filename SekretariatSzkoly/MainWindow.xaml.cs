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

namespace SekretariatSzkoly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    internal class Brutforce
    {
        public ICollection<char> Alphabet { get; set; }

        private ICollection<string> _calculate(int lenght)
        {
            if (lenght <= 1) return Alphabet.Select(a => a + "").ToList();
            ICollection<string> sub = _calculate(lenght - 1);
            return (from alpha in Alphabet from prior in sub select alpha + prior).ToList();
        }
        public class KMPAlgorithm
        {
            

            private static void preProcess(char[] p, int[] table, int n)
            {
                table[0] = 0;
              
                int i = 0, j = 1; 
                while (j < n)
                {
                    if (p[j] == p[i])
                    {
                        table[j] = i + 1;
                        i++; j++;
                    }
                    else
                    {
                        if (i != 0)
                        {
                            i = table[i - 1];
                        }
                        else
                        {
                            table[j] = 0;
                            j++;
                        }
                    }
                }
            }
            public static void main(String[] args)
            {
                char S[] = "abcaabcab".toCharArray();
                char p[] = "abcab".toCharArray();
                int table[] = new int[p.length];
                preProcess(p, table, p.length);
                int i = 0;
                int j = 0;
                boolean found = false; 

                while (i < S.length)
                {
                    if (S[i] == p[j])
                    {
                       
                        i++;
                        j++;
                    }
                    else
                    {
                        if (j != 0) 
                            j = table[j - 1];
                        else
                            i++;
                    }
                    if (j == p.length)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                    System.out.println("true");
        else
                    System.out.println("false");
            }
        }
        public ICollection<string> Calculate(int lenght)
        {
            return Alphabet == null ? null : _calculate(lenght);
        }
    }



#define d 10

    void rabinKarp(char pattern[], char text[], int q)
    {
        int m = strlen(pattern);
        int n = strlen(text);
        int i, j;
        int p = 0;
        int t = 0;
        int h = 1;

        for (i = 0; i < m - 1; i++)
            h = (h * d) % q; 

        for (i = 0; i < m; i++)
        {
            p = (d * p + pattern[i]) % q;
            t = (d * t + text[i]) % q;
        }

        for (i = 0; i <= n - m; i++)
        {
            if (p == t)
            {
                for (j = 0; j < m; j++)
                {
                    if (text[i + j] != pattern[j])
                        break;
                }

                if (j == m)
                    printf("Pattern is found at position:  %d \n", i + 1);
            }

            if (i < n - m)
            {
                t = (d * (t - text[i] * h) + text[i + m]) % q;

                if (t < 0)
                    t = (t + q);
            }
        }
    }

    int main()
    {
        char text[] = "ABCCDDAEFG";
        char pattern[] = "CDD";
        int q = 13;
        rabinKarp(pattern, text, q);
    }
}

