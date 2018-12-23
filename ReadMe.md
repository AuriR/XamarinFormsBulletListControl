# Bullet List Control for Xamarin.Forms

## So why would I build this?
Word has a beautiful bullet list format for text. HTML does, too. It's a great way of showing data in an immediately understood, organized way. Yet, there isn't a built-in bullet-list in XAML. Sure, I could use a ListView, but that felt pretty heavy. I just wanted a list of strings to show up in a list. So, I built this Xamarin.Forms control. I hope you enjoy it.

## How do I use it?
Add it to your XAML like any other custom control, and bind the Items property to some IEnumerable, like so:

At the top:
<pre><code>
     <ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
			 ...
             xmlns:customControls="clr-namespace:AurisIdeas.Controls;assembly=AurisIdeas.Controls"
			 ...
             >
</code><pre>

In your XAML content:
<pre><code>
     <customControls:BulletListControl Items="{Binding OfferLocations}" Margin="15,0,15,5" />
</code><pre>

## Can I customize anything?

Sure thing. Just change the BulletCharacter or BulletImage property. I'm still playing with all the customization options. Hey, it's a beta. Feel free to contribute :)
