using System;
using PizzaApp.extensions;

namespace PizzaApp
{
    public class Pizza
    {
        public string Nom { get; set; }

        public int Prix { get; set; }

        public string[] Ingredients { get; set; }

        public string ImageURL { get; set; }


        public string PrixEuros { get { return Prix + " €"; } }

        public string IngredientStr { get { return String.Join(" , " , Ingredients ); } } 

        public string Titre { get { return Nom.ToPremiereLettreMajuscule(); } }

        public Pizza()
        {
        }
    }
}
