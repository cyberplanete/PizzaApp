using System;
using PizzaApp.extensions;

namespace PizzaApp
{
    public class Pizza
    {
        public string nom { get; set; }

        public int prix { get; set; }

        public string[] ingredients { get; set; }

        public string imageUrl { get; set; }


        public string PrixEuros { get { return prix + " €"; } }

        public string IngredientStr { get { return String.Join(" , " , ingredients ); } } 

        public string Titre { get { return nom.ToPremiereLettreMajuscule(); } }

        public Pizza()
        {
        }
    }
}
