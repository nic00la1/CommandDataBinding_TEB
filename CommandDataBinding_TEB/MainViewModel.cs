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
                    new Person { Name = "Jan Kowalski", ImageUrl = "person1.png", Description = "Opis Jana Kowalskiego" },
                    new Person { Name = "Anna Nowak", ImageUrl = "person3.webp", Description = "Opis Anny Nowak" },
                    new Person { Name = "Piotr Wi�niewski", ImageUrl = "person2.png", Description = "Opis Piotra Wi�niewskiego" }
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
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
