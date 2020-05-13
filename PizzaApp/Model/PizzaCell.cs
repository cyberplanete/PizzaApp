using System;
using System.ComponentModel;
using System.Windows.Input;
using PizzaApp.extensions;
using Xamarin.Forms;

namespace PizzaApp
{
    public class PizzaCell: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Pizza pizza { get; set; }

        public bool IsFavorite { get; set; }

        public string ImageSourceFav { get { return IsFavorite ? "star2.png" : "star1.png"; } }

        // depuis le xaml Source="{Binding ImageSourceFav}" Command="FavClickCommand"
        public ICommand FavClickCommand { get; set; }

        public Action<PizzaCell> favChangedAction { get; set; }

        public PizzaCell()
        {
            FavClickCommand = new Command((obj) =>
                {
                    string paramString = obj as string; 
                    Console.WriteLine("FavClickCommand:" + paramString);
                    //Si true alors faux, si faux alors vrai -- Permet d'alterner l'image
                    IsFavorite = !IsFavorite;
                    //Binding Xaml de ImageSourceFav -- Mise à jour de l'image favoris
                    OnPropertyChanged("ImageSourceFav");
                    
                    favChangedAction.Invoke(this);
                }
            );
        }

        protected void OnPropertyChanged(string name)
        {
            if(PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
    }
}
