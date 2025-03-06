using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CommandDataBinding_TEB
{
    public class MainViewModel
    {
        public ObservableCollection<Person> People { get; set; }
        public ICommand ShowAlertCommand { get; }
        public ICommand NavigateToProfileCommand { get; }

        public MainViewModel()
        {
            // Inicjalizacja listy os�b
            People = new ObservableCollection<Person>
                {
                    new Person { Name = "Jan Kowalski", ImageUrl = "person1.png", Age=18,Description = "Mam na imi� Janek, ucz� si� w Technikum Teb Edukacja ��d�.", Gender="M�czyzna", Hobby="Jazda na rowerze, Rysowanie, Siatk�wka" },
                    new Person { Name = "Anna Nowak", ImageUrl = "person3.webp",Age=19 ,Description = "Opis Ani Nowak", Gender="Kobieta", Hobby="Programowanie, Gotowanie, Czytanie Biblii" },
                    new Person { Name = "Piotr Wi�niewski", ImageUrl = "person2.png", Age=17, Description = "Opis Piotra Wi�niewskiego", Gender="M�czyzna", Hobby="Gra na gitarze, �piewanie, Jogging" }
                };

            // Inicjalizacja komendy
            ShowAlertCommand = new Command<Person>(async (person) =>
            {
                if (person != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Informacja", $"Wybrano: {person.Name}", "OK");
                }
            });

            // Inicjalizacja komendy nawigacji
            NavigateToProfileCommand = new Command<Person>(async (person) =>
            {
                if (person != null)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new ProfilePage(person));
                }
            });
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Hobby { get; set; }
    }
}
