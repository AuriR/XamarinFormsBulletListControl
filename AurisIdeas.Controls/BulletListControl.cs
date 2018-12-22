using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AurisIdeas.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    class BulletedListControl : ContentView, IBulletListControl
    {
        #region Bindable Properties

        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
            nameof(Items),
            typeof(IEnumerable<string>),
            typeof(BulletedListControl),
            defaultValue: new List<string>(),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ItemsPropertyChanged
            );

        public static readonly BindableProperty BulletImageProperty = BindableProperty.Create(nameof(BulletImageProperty), typeof(Stream), typeof(Stream));

        public static readonly BindableProperty BulletCharacterProperty = BindableProperty.Create(nameof(BulletCharacter), typeof(string), typeof(string));

        #endregion

        #region Constructors

        public BulletedListControl()
        {
            // Assuming Items will be set via binding. Otherwise, call Render() to render empty... but why?
            Render();
        }

        public BulletedListControl(IEnumerable<string> items)
        {
            if (items != null) Items = items;

            Render();
        }

        #endregion

        #region Class Variables and Properties

        /// <inheritdoc />
        public IEnumerable<string> Items
        {
            get => base.GetValue(ItemsProperty) as IEnumerable<string>;
            set => base.SetValue(ItemsProperty, value);
        }

        /// <inheritdoc />
        public string BulletCharacter { get; set; } = DefaultBulletCharacter;

        private const string DefaultBulletCharacter = "\u2022";

        /// <inheritdoc />
        public Stream BulletImage { get; set; } = null;

        public Thickness ListItemMargin { get; set; } = new Thickness(1);

        public Thickness ListLayoutPadding { get; set; } = new Thickness(1);

        #endregion

        #region Rendering

        public void Render()
        {
            if (Items == null || !Items.Any()) return;

            // Create the container.
            var parentLayout = new StackLayout { HorizontalOptions = LayoutOptions.Fill, Padding = new Thickness(1) };

            // Render the list.
            foreach (var item in Items)
            {
                // Make sure they provided a good bullet.
                if (string.IsNullOrWhiteSpace(BulletCharacter) && BulletImage == null)
                    BulletCharacter = DefaultBulletCharacter;

                // Choose the bullet. Default to text if no image defined.
                var bullet = !string.IsNullOrWhiteSpace(BulletCharacter) && BulletImage != null
                ? (View)new Label { Text = BulletCharacter, Margin = ListLayoutPadding, FontSize = 14, VerticalTextAlignment = TextAlignment.Start }
                : new Image { Source = ImageSource.FromStream(() => BulletImage) };

                // Create the horizontal container.
                var container = new StackLayout { HorizontalOptions = LayoutOptions.Fill, Orientation = StackOrientation.Horizontal };
                container.Children.Add(bullet);
                container.Children.Add(new Label { Text = item, VerticalTextAlignment = TextAlignment.Start });
                parentLayout.Children.Add(container);
            }

            // Render.
            this.Content = parentLayout;
        }

        #endregion

        #region Events

        /// <summary>
        /// Handles new bound item data coming in.
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void ItemsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null || !(newValue is IEnumerable<string>)) return;
            var control = (BulletedListControl)bindable;
            control.Items = newValue as IEnumerable<string>;
            control.Render();
        }

        #endregion

    }
}
