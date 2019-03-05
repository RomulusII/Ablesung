using System.Windows;
using Microsoft.Ink;
using System.IO;
using Ablesen.Model;
using Ablesen.ViewModels;
using Ablesung = Ablesen.Views.Ablesung;

namespace InkRecognition
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

            AblesungStammdaten stammdaten = new AblesungStammdaten("lSnutzer", "verwalter 1",
                "str 32", "darmstadt", "nutzer1", "nutzer2", "hvNo", "1.1.18 - 2.2.18", "WER");

            //DataContext = new ZaehlerViewModel(new AblesungsBlatt(stammdaten));

        }

        // Recognizes handwriting by using RecognizerContext
        private void buttonClick(object sender, RoutedEventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                //theInkCanvas.Strokes.Save(ms);
                var myInkCollector = new InkCollector();
                var ink = new Ink();
                ink.Load(ms.ToArray());

                using (RecognizerContext context = new RecognizerContext())
                {
                    if (ink.Strokes.Count > 0)
                    {
                        context.Strokes = ink.Strokes;
                        RecognitionStatus status;

                        var result = context.Recognize(out status);

                        if (status == RecognitionStatus.NoError)
                            //textBox1.Text = result.TopString;
                        //else
                            MessageBox.Show("Recognition failed");

                    }
                    else
                        MessageBox.Show("No stroke detected");
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //theInkCanvas.Strokes.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win2 = new Ablesung();
            win2.Show();
            this.Close();
        }
    }
}
