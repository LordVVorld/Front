using Front.Models;
using System.Text.Json;
using System.Windows;
namespace Front.Views
{

    public partial class MainAppView : Window
    {
        public MainAppView(User user)
        {
            InitializeComponent();
            LonelyTextBox.Text = JsonSerializer.Serialize(user);
        }
    }
}
