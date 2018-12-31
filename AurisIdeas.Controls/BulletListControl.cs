using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AurisIdeas.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class BulletListControl : ContentView, IBulletListControl
    {
        #region Bindable Properties

        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
            nameof(Items),
            typeof(IEnumerable<string>),
            typeof(BulletListControl),
            defaultValue: new List<string>(),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ItemsPropertyChanged
            );

        public static readonly BindableProperty BulletImageProperty = BindableProperty.Create(nameof(BulletImageProperty), typeof(Stream), typeof(Stream));

        public static readonly BindableProperty BulletCharacterProperty = BindableProperty.Create(nameof(BulletCharacter), typeof(string), typeof(string), propertyChanged: BulletCharacterPropertyChanged);


        public static readonly BindableProperty BulletCharacterFontSizeProperty = BindableProperty.Create(nameof(BulletCharacterFontSize), typeof(double), typeof(double), propertyChanged: BulletCharacterFontSizePropertyChanged);


        public static readonly BindableProperty ListItemFontSizeProperty = BindableProperty.Create(nameof(ListItemFontSize), typeof(double), typeof(double), propertyChanged: ListItemFontSizePropertyChanged);


        #endregion

        #region Constructors

        public BulletListControl()
        {
            // Assuming Items will be set via binding. Otherwise, call Render() to render empty... but why?
            Render();
        }

        public BulletListControl(IEnumerable<string> items)
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

        public double ListItemFontSize { get; set; } = 12;

        public double BulletCharacterFontSize { get; set; } = 14;

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
                var bullet = !string.IsNullOrWhiteSpace(BulletCharacter) && BulletImage == null
                ? (View)new Label { Text = BulletCharacter, Margin = ListLayoutPadding, FontSize = BulletCharacterFontSize, VerticalTextAlignment = TextAlignment.Start }
                : new Image { Source = ImageSource.FromStream(() => BulletImage) };

                // Create the horizontal container.
                var container = new StackLayout { HorizontalOptions = LayoutOptions.Fill, Orientation = StackOrientation.Horizontal };
                container.Children.Add(bullet);
                container.Children.Add(new Label { Text = item, VerticalTextAlignment = TextAlignment.Start, FontSize = ListItemFontSize });
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
            var control = (BulletListControl)bindable;
            control.Items = newValue as IEnumerable<string>;
            control.Render();
        }

        /// <summary>
        /// Handles changing the bullet character font size.
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void BulletCharacterFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null || !(newValue is double)) return;
            var control = (BulletListControl)bindable;
            control.BulletCharacterFontSize = (double)newValue;
            control.Render();
        }

        /// <summary>
        /// Handles changing the character used for bullets.
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void BulletCharacterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null || !(newValue is string)) return;
            var control = (BulletListControl)bindable;
            control.BulletCharacter = (string)newValue;
            control.Render();
        }

        /// <summary>
        /// Handles changing the list item font size.
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void ListItemFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null || !(newValue is double)) return;
            var control = (BulletListControl)bindable;
            control.ListItemFontSize = (double)newValue;
            control.Render();
        }

        #endregion

    }
}
