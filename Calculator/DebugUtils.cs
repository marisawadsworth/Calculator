using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Calculator
{
    public static class DebugUtils
    {
        public static async void MessageBox(String message)
        {
            var dialog = new MessageDialog(message);

            dialog.Title = "Debugging Message Box";

            await dialog.ShowAsync();
        }

        public static async Task<int> MessageBox(String message, String titel)
        {
            var dialog = new MessageDialog(message);

            dialog.Title = titel;
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });

            var res = await dialog.ShowAsync();

            return (int)res.Id;
        }
    }
}
