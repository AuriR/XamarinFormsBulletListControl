# Bullet List Control for Xamarin.Forms

## What's the point?
Word has a beautiful bullet list format for text. HTML does, too. It's a great way of showing data in an immediately understood, organized way. Yet, there isn't a built-in bullet-list in XAML. Sure, I could use a ListView, but that felt pretty heavy. I just wanted a list of strings to show up in a list. So, I built this Xamarin.Forms control. I hope you enjoy it.

## Is there a NuGet package?
Yep. It's pre-release until I feel that it has all the features I'd like. It IS being used in a production app with no issues.

[Get it on NuGet][nuget]

## What's it look like?
It looks like a bullet list, just like you want :) Here's an example using the tester app:

![screenshot_tester]

Here's the bullet list used in a Production app, embedded as a custom control in a ListView:

![screenshot_dd]


## How do I use it?
Add it to your XAML like any other custom control, and bind the Items property to some IEnumerable. By default, a round bullet character is used.

Here's an example:

At the top:
```xml
     <ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
			 ...
             xmlns:customControls="clr-namespace:AurisIdeas.Controls;assembly=AurisIdeas.Controls"
			 ...
             >
```

In your XAML content:
```xml
     <customControls:BulletListControl Items="{Binding OfferLocations}" Margin="15,0,15,5" />
```

## Can I customize anything?
Sure thing. Just change the BulletCharacter or BulletImage property. I'm still playing with all the customization options. Hey, it's a beta. Feel free to contribute :)

## What if I have questions?
Hit me up on Twitter: [Auri][twitter]

## License
Auri's Ideas Controls Library - Bullet List Control

The MIT License (MIT)

Copyright (c) 2018 Auri's Ideas LLC

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

For more information about Auri's Ideas, visit https://auri.net

[screenshot_tester]: https://github.com/AuriR/XamarinFormsBulletListControl/raw/master/screenshot_tester.png "Bullet List Example Screenshot"
[screenshot_dd]: https://github.com/AuriR/XamarinFormsBulletListControl/raw/master/screenshot_dd.png "Daily Ding Example Screenshot"
[twitter]: https://twitter.com/Auri
[nuget]: https://www.nuget.org/packages/AI.Xamarin.Forms.Bullet.List/
