using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using Microsoft.Ink;

namespace Ablesen.ViewModels
{
    public class AblesungViewModelBase : ViewModelBase
    {
        public AblesungViewModelBase()
        {
            Signature = new StrokeCollection();
            (Signature as INotifyCollectionChanged).CollectionChanged += delegate
            {
                StrokeAblesen();
            };
        }
        public StrokeCollection Signature { get; }

        private string _eingabe;

        public string Eingabe
        {
            get => _eingabe;
            set
            {
                _eingabe = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _clickCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(ClearStrokes, () => Signature.Any()));
            }
        }

        private ICommand _strokeAblesenCommand;
        public ICommand StrokeAblesenCommand
        {
            get
            {
                return _strokeAblesenCommand ?? (_strokeAblesenCommand = new CommandHandler(StrokeAblesen, () => Signature.Any()));
            }
        }

        private void ClearStrokes()
        {
            Signature.Clear();
        }

        private void StrokeAblesen()
        {
            using (var ms = new MemoryStream())
            {
                Signature.Save(ms);

                var myInkCollector = new InkCollector();

                var ink = new Ink();
                ink.Load(ms.ToArray());

                using (var context = new RecognizerContext())
                {
                    if (ink.Strokes.Count > 0)
                    {
                        context.Strokes = ink.Strokes;

                        RecognitionStatus status;

                        var result = context.Recognize(out status);

                        if (status == RecognitionStatus.NoError)
                            Eingabe = result.TopString;
                        else
                            MessageBox.Show("Recognition failed");

                    }
                    else
                        MessageBox.Show("No stroke detected");
                }
            }
        }
    }
}