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
    /// Interaction logic for PageArchive.xaml
    /// </summary>
    public partial class PageArchive : Page
    {
        public PageArchive()
        {
            InitializeComponent();
        }

        List<string> listInformation = new List<string>();
        private void btRecherche_Click(object sender, RoutedEventArgs e)
        {
            listInformation = plantuleControler.trouverPlantuleInfo(tbIdentification.Text);

            /*lbEtatSante.Content = listInformation[0];
            lbDate.Content = listInformation[1];
            lbProvenance.Content = listInformation[2];
            lbDescription.Content = listInformation[3];
            lbStade.Content = listInformation[4];
            lbEntreposage.Content = listInformation[5];
            lbQuantiteActif_inActif.Content = listInformation[6];
            lbItemRetireInventaire.Content = listInformation[7];
            lbResponsable.Content = listInformation[8];
            tbNote.Text = listInformation[9];*/

            //grillePlante.ItemsSource = listInformation;

            //grillePlante.ItemsSource = listInformation;
            plantuleControler.trouvePlantETChargerSurDataGrid(tbIdentification.Text, grillePlante);

            listInformation.Clear();
            plantuleControler.trouverPlantuleInfo(tbIdentification.Text).Clear();

            
        }

        private void btArchive_Click(object sender, RoutedEventArgs e)
        {
            listInformation = plantuleControler.trouverPlantuleInfo(tbIdentification.Text);
            if (tbIdentification.Text != "")
            {
                try
                {
                    using (PlanteContext PC = new PlanteContext())
                    {
                        plante Plante = PC.plante.FirstOrDefault(p => p.IdPlante.Equals(tbIdentification.Text));
                        if (Plante != null)
                        {
                            using (PlanteArchiveContext EC = new PlanteArchiveContext())
                            {
                                PlanteArchive newPlanteArchive = new PlanteArchive();

                                newPlanteArchive.IdPlante = tbIdentification.Text;
                                newPlanteArchive.EtatSante = listInformation[0];
                                //newPlante.DateAjout = calendrier.SelectedDate.Value.ToShortDateString();
                                newPlanteArchive.DateAjout = DateTime.Parse(listInformation[1]);
                                newPlanteArchive.Provenance = listInformation[2];
                                newPlanteArchive.Description = listInformation[3];
                                newPlanteArchive.Stade = listInformation[4];
                                newPlanteArchive.Entreposage = listInformation[5];
                                newPlanteArchive.Active_Inactive = int.Parse(listInformation[6]);
                                newPlanteArchive.ItemRetireInventaire = listInformation[7];
                                newPlanteArchive.Note = listInformation[9];
                                newPlanteArchive.Responsable = listInformation[8];
                                newPlanteArchive.DateRetrait = DateTime.Today;

                                //save dans la base de donnee
                                EC.SaveChanges();

                                plantuleControler.trouvePlantETChargerSurDataGrid(tbIdentification.Text, grillePlante);

                            }
                        }
                        else
                        {
                            MessageBox.Show("ID invalide");
                        }

                    }
                }
                catch (Exception ex)
                {
                    //statusMessage.Text = ex.Message;
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //statusMessage.Text = "aucun champ ne doit etre vide";
                MessageBox.Show("aucun champ ne doit etre vide");
            }
            listInformation.Clear();
            plantuleControler.trouverPlantuleInfo(tbIdentification.Text).Clear();
        }

        public void ChargerListePlantules()
        {
            using (PlanteArchiveContext PC = new PlanteArchiveContext())
                try
                {
                    //var rechercheSpecialite = PC.plante.FirstOrDefault(s => s.IdPlante == specialite);
                    var MesPlante = PC.PlanteArchive.Select(p => new
                    {
                        p.IdPlante,
                        p.EtatSante,
                        p.DateAjout,
                        p.Provenance,
                        p.Description,
                        p.Stade,
                        p.Entreposage,
                        p.Active_Inactive,
                        p.ItemRetireInventaire,
                        p.Note,
                        p.Responsable,
                        p.DateRetrait,
                    }).ToList();
                    grillePlante.ItemsSource = MesPlante;
                    //statusMessage.Text = "Liste des Specialités chargée";
                }
                catch (Exception ex)
                {
                    //statusMessage.Text = ex.Message;
                    MessageBox.Show(ex.Message);
                }
        }
    }
}
