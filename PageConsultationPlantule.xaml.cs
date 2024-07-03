using Canabis.Models;
using sommatif3.Models;
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
    /// Interaction logic for PageConsultationPlantule.xaml
    /// </summary>
    public partial class PageConsultationPlantule : Page
    {
        List<string> listInformation = new List<string>();
        public PageConsultationPlantule()
        {
            InitializeComponent();
        }

        private void btRecherche_Click(object sender, RoutedEventArgs e)
        {
            listInformation = plantuleControler.trouverPlantuleInfo(tbId.Text);

            lbEtatSante.Content = listInformation[0];
            lbDate.Content = listInformation[1];
            lbProvenance.Content = listInformation[2];
            lbDescription.Content = listInformation[3];
            lbStade.Content = listInformation[4];
            lbEntreposage.Content = listInformation[5];
            lbQuantiteActif_inActif.Content = listInformation[6];
            lbItemRetireInventaire.Content = listInformation[7];
            tbNote.Text = listInformation[8];
            lbResponsable.Content = listInformation[9];

            listInformation.Clear();
            plantuleControler.trouverPlantuleInfo(tbId.Text).Clear();
        }
    }
}
