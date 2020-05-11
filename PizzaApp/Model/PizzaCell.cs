using System;
using PizzaApp.extensions;

namespace PizzaApp
{
    public class PizzaCell
    {
        public Pizza pizza { get; set; }

        public bool IsFavorite { get; set; }

        public string ImageSourceFav { get { return IsFavorite ? "star2.png" : "star1.png"; } }

        public PizzaCell()
        {
        }
    }
}
