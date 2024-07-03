using sommatif3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Canabis.Views
{
    /// <summary>
    /// Interaction logic for PageConnexion.xaml
    /// </summary>
    public partial class PageConnexion : Page
    {
        public PageConnexion()
        {
            InitializeComponent();
        }

        private void btInscription_Click(object sender, RoutedEventArgs e)
        {
            // Navigation vers la page d'inscription
            NavigationService?.Navigate(new PageInscription());
        }
    

        private void btConnexion_Click(object sender, RoutedEventArgs e)
        {
            ControlerPage.mainFrameControl.MainFrame.Content = ControlerPage.PageAcceuil;
        }
    }
}
