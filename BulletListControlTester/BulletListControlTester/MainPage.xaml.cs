using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace BulletListControlTester
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> ListItems { get; set; } = new ObservableCollection<string>(new List<string>
        {
            "Bacon ipsum dolor amet et tongue sausage exercitation. Burgdoggen picanha boudin eiusmod, biltong venison laboris fugiat id.",
            "Doner beef ipsum ball tip, veniam turducken short loin biltong. Pork loin cupidatat tenderloin rump excepteur pancetta sirloin fugiat ut leberkas adipisicing boudin laboris.",
            "Exercitation do dolore, labore fugiat salami."
        });

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
