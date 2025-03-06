namespace CommandDataBinding_TEB
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage(Person person)
        {
            InitializeComponent();
            BindingContext = person;
        }
    }
}
