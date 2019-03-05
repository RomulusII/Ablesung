using System.Windows.Controls;
using Ablesen.Model;

namespace Ablesen.ViewModels
{
    public class ZaehlerViewModel : AblesungViewModelBase
    {
        public Zaehler Zaehler { get; }


        public ZaehlerViewModel(Zaehler zaehler) : base()
        {
            Zaehler = zaehler;
        }


    }
}