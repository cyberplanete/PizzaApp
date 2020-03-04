using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace PizzaApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        enum e_tri 
        { 
            TRI_AUCUN,
            TRI_NOM,
            TRI_PRIX
        }

        private e_tri filtre;

        private List<Pizza> pizzas;


     public MainPage()
        {
            InitializeComponent();

            filtre = e_tri.TRI_AUCUN; 

            //string pizzasJson = "[\n\t{ \"nom\": \"4 fromages\", \"ingredients\": [ \"cantal\", \"mozzarella\", \"fromage de chèvre\", \"gruyère\" ], \"prix\": 11, \"imageUrl\": \"https://www.galbani.fr/wp-content/uploads/2017/07/pizza_filant_montage_2_3.jpg\"},\n\t{ \"nom\": \"tartiflette\", \"ingredients\": [ \"pomme de terre\", \"oignons\", \"crème fraiche\", \"lardons\", \"mozzarella\" ], \"prix\": 14, \"imageUrl\": \"https://cdn.pizzamatch.com/1/35/1375105305-pizza-napolitain-630.JPG?1375105310\"},\n\t{ \"nom\": \"margherita\", \"ingredients\": [ \"sauce tomate\", \"mozzarella\", \"basilic\" ], \"prix\": 7, \"imageUrl\": \"https://www.misteriosocultos.com/wp-content/uploads/2018/12/pizza.jpg\"},\n\t{ \"nom\": \"indienne\", \"ingredients\": [ \"curry\", \"mozzarella\", \"poulet\", \"poivron\", \"oignon\", \"coriandre\" ], \"prix\": 10, \"imageUrl\": \"https://assets.afcdn.com/recipe/20160519/15342_w1024h768c1cx3504cy2338.jpg\"},\n\t{ \"nom\": \"mexicaine\", \"ingredients\": [ \"boeuf\", \"mozzarella\", \"maïs\", \"tomates\", \"oignon\", \"coriandre\" ], \"prix\": 13, \"imageUrl\": \"https://fac.img.pmdstatic.net/fit/http.3A.2F.2Fprd2-bone-image.2Es3-website-eu-west-1.2Eamazonaws.2Ecom.2FFAC.2Fvar.2Ffemmeactuelle.2Fstorage.2Fimages.2Fminceur.2Fastuces-minceur.2Fminceur-choix-pizzeria-47943.2F14883894-1-fre-FR.2Fminceur-comment-faire-les-bons-choix-a-la-pizzeria.2Ejpg/750x562/quality/80/crop-from/center/minceur-comment-faire-les-bons-choix-a-la-pizzeria.jpeg\"},\n\t{ \"nom\": \"chèvre et miel\", \"ingredients\": [ \"miel\", \"mozzarella\", \"fromage de chèvre\", \"roquette\"], \"prix\": 10, \"imageUrl\": \"http://gfx.viberadio.sn/var/ezflow_site/storage/images/news/conso-societe/les-4-aliments-a-eviter-de-consommer-le-soir-00018042/155338-1-fre-FR/Les-4-aliments-a-eviter-de-consommer-le-soir.jpg\"},\n\t{ \"nom\": \"napolitaine\", \"ingredients\": [ \"sauce tomate\", \"mozzarella\", \"anchois\", \"câpres\"], \"prix\": 9, \"imageUrl\": \"https://www.fourchette-et-bikini.fr/sites/default/files/pizza_tomate_mozzarella.jpg\"},\n\t{ \"nom\": \"kebab\", \"ingredients\": [ \"poulet\", \"oignons\", \"sauce tomate\", \"sauce kebab\", \"mozzarella\"], \"prix\": 11, \"imageUrl\": \"https://res.cloudinary.com/serdy-m-dia-inc/image/upload/f_auto/fl_lossy/q_auto:eco/x_0,y_0,w_3839,h_2159,c_crop/w_576,h_324,c_scale/v1525204543/foodlavie/prod/recettes/pizza-au-chorizo-et-fromage-cheddar-en-grains-2421eadb\"},\n\t{ \"nom\": \"louisiane\", \"ingredients\": [ \"poulet\", \"champignons\", \"poivrons\", \"oignons\", \"sauce tomate\", \"mozzarella\"], \"prix\": 12, \"imageUrl\": \"http://www.fraichementpresse.ca/image/policy:1.3167780:1503508221/Pizza-dejeuner-maison-basilic-et-oeufs.jpg?w=700&$p$w=13b13d9\"},\n\t{ \"nom\": \"orientale\", \"ingredients\": [ \"merguez\", \"champignons\", \"sauce tomate\", \"mozzarella\"], \"prix\": 11, \"imageUrl\": \"https://www.atelierdeschefs.com/media/recette-e30299-pizza-pepperoni-tomate-mozza.jpg\"},\n\t{ \"nom\": \"hawaïenne\", \"ingredients\": [ \"jambon\", \"ananas\", \"sauce tomate\", \"mozzarella\"], \"prix\": 12, \"imageUrl\": \"https://www.atelierdeschefs.com/media/recette-e16312-pizza-quatre-saisons.jpg\"},\n\t{ \"nom\": \"reine\", \"ingredients\": [ \"jambon\", \"champignons\", \"sauce tomate\", \"mozzarella\"], \"prix\": 8, \"imageUrl\": \"https://static.cuisineaz.com/400x320/i96018-pizza-reine.jpg\"}\n]";
            Console.WriteLine("ETAPE 1");


            //Pour le pull to refresh - activé lors du pull
            listePizzas.RefreshCommand = new Command((obj) =>
            {
                Console.WriteLine("PULLED");
                dataPizzas((pizzas) =>
                {
                    listePizzas.ItemsSource = pizzas;
                    listePizzas.IsRefreshing = false;


                });
            });
            activityIndicator.IsVisible = true;
            listePizzas.IsVisible = false;
            //Récuperation de la liste de pizzas et désactivation du loader
            dataPizzas((pizzasList) =>
            {
                listePizzas.ItemsSource = pizzasList;
                activityIndicator.IsVisible = false;
                listePizzas.IsVisible = true;

            });

            Console.WriteLine("ETAPE 4");
            //Pizzas.Add(new Pizza { Nom = "végétarienne", Prix = 7, Ingredients = new String[] { "Tomate", "Poivron", "Oignons" },ImageURL = "https://www.galbani.fr/wp-content/uploads/2017/07/pizza_parma.png" });
            //Pizzas.Add(new Pizza { Nom = "montagnarde", Prix = 15, Ingredients = new String[] { "Pomme de terre", "Poivron", "Oignons", "Bleu d'auvergne" }, ImageURL = "https://img.over-blog-kiwi.com/1/47/72/31/20150611/ob_aab11d_pizza-au-bleu-d-auvergne.jpg" });
            //Pizzas.Add(new Pizza { Nom = "carnivore", Prix = 11, Ingredients = new String[] { "Boeuf", "Poivron", "Oignons" }, ImageURL = "https://www.pizza-mario-narbonne.fr/images_pmn/carte/pizza-narbonne-carnivore-41.jpg" });
            //Pizzas.Add(new Pizza { Nom = "pécheur", Prix = 12, Ingredients = new String[] { "Crevettes", "Noix de saint Jacques", "Oignons" } , ImageURL = "https://www.eismann.fr/content/images/thumbs/0011263_pizza-du-pecheur_550.jpeg" });


        }



        private void dataPizzas(Action<List<Pizza>> action)
        {
            var webclient = new WebClient();
            const string URL = "https://drive.google.com/uc?export=download&id=1fS7tNh0FCxopePRIW75AwjaIYqvI_vHV";

            using (var webClient = new WebClient())
            {

                //Thread Main (UI)
                //pizzasJson = webclient.DownloadString(URL);
                Console.WriteLine("ETAPE 2");
                //Quand le téléchargement est terminé alors j'execute le code suivant
                webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
                {
                    Console.WriteLine("ETAPE 5");

                    try
                    {
                        Console.WriteLine("Données téléchargées " + e.Result);
                        string PizzasJson = e.Result;
                        pizzas = JsonConvert.DeserializeObject<List<Pizza>>(PizzasJson);

                        Device.BeginInvokeOnMainThread(() =>
                            {

                            //listePizzas.ItemsSource = pizzas;
                            //activityIndicator.IsVisible = false;
                            //listePizzas.IsVisible = true;
                            //listePizzas.IsRefreshing = false;

                            action.Invoke(pizzas);
                    });
                    }
                    catch (Exception exception)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                                //Thread réseau ne s'affiche pas sans invoke
                                DisplayAlert("Erreur", "Une erreur reseau s'est produite" + exception.Message, "OK");
                                action.Invoke(null);

                        });
                            //sortir pour que le code dessous ne soit pas execute


                            //Thread réseau ne s'affiche pas sans invoke
                            //DisplayAlert("Erreur", "Une erreur reseau s'est produite" + exception.Message, "OK");
                        }

                };
                Console.WriteLine("ETAPE 3");
                webclient.DownloadStringAsync(new Uri(URL));




            }
        }

        void Filtre_Clicked(object sender, System.EventArgs e)
        {
            Console.WriteLine("Filtre boutton");
            if(filtre == e_tri.TRI_AUCUN) 
            {

                filtre = e_tri.TRI_NOM;
                imageButtonFiltre.Source = "sort_nom.png";

            
            }else if (filtre == e_tri.TRI_NOM) 
            {
                filtre = e_tri.TRI_PRIX;
                imageButtonFiltre.Source = "sort_prix.png";

            }
            else 
            {
                filtre = e_tri.TRI_AUCUN;
                imageButtonFiltre.Source = "sort_none.png";
            }

            GetPizzasFromTri(filtre, pizzas);
        }

        private void GetPizzasFromTri(e_tri filtre, List<Pizza> pizzas)
        {
            List<Pizza> listPizzasFiltre;

            if (filtre == e_tri.TRI_AUCUN)
            {

                listPizzasFiltre = pizzas;


            }
            else if (filtre == e_tri.TRI_NOM)
            {

                listPizzasFiltre = pizzas.OrderBy(x => x.Nom).ToList();
            }
            else
            {
                listPizzasFiltre = pizzas.OrderBy(x => x.Prix).ToList();
            }

            listePizzas.ItemsSource = listPizzasFiltre;

        }
    }
}
