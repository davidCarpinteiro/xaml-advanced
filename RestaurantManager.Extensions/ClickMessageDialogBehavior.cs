using Microsoft.Xaml.Interactivity;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RestaurantManager.Extensions
{
    public class ClickMessageDialogBehavior : DependencyObject, IBehavior
    {
        public string Message { get; set; }

        public string Title { get; set; }

        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            if (associatedObject is Button)
            {
                this.AssociatedObject = associatedObject;
                (this.AssociatedObject as Button).Click += Button_Clicked;
            }
        }

        private async void Button_Clicked(object sender, RoutedEventArgs e)
        {
            await new MessageDialog(Message, Title).ShowAsync();
        }

        public void Detach()
        {
            (this.AssociatedObject as Button).RightTapped -= Button_Clicked;
        }
    }
}