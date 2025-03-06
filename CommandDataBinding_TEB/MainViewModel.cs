using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CommandDataBinding_TEB
{
    public class MainViewModel
    {
        public ObservableCollection<Person> People { get; set; }
        public ICommand ShowAlertCommand { get; }

        public MainViewModel()
        {
            // Inicjalizacja listy os�b
            People = new ObservableCollection<Person>
            {
                new Person { Name = "Jan Kowalski" },
                new Person { Name = "Anna Nowak" },
                new Person { Name = "Piotr Wi�niewski" }
            };

            // Inicjalizacja komendy
            ShowAlertCommand = new Command<Person>(async (person) =>
            {
                if (person != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Wybrana osoba", $"Witaj, {person.Name}", "OK");
                }
            });
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}
