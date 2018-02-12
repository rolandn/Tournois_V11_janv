using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournois.ClassesMetier;
using Tournois.coucheAccesDB;

namespace Tournois.couchePresentation
{
    public class Presentation
    {
        private AccesDB coucheAccesDB;

        // Constructeur : créer l'objet de type accès DB

        public Presentation()
        {
            try
            {
                coucheAccesDB = new AccesDB();
            }

            catch (ExceptionAccesDB e)
            {
                Console.WriteLine("\nAccès à la DB impossible (" + e.Message + ")");
                AccesConsole.Attendre();
            }
        }

        // Gérer le menu principal

        public void MenuPrincipal()
        {
            while (true)
            {
                AccesConsole.CreerEcran("Menu principal");
                Console.WriteLine("1 = Menu joueurs \n2 = Lister les tables \n3 = Lister les arbitres \n4 = Menu rencontres");

                try
                {
                    switch (AccesConsole.Saisirint("\nChoix: "))
                    {
                        case 1:
                            MenuJoueurs();
                            break;


                        case 2:
                            AccesConsole.CreerEcran("Lister les tables");
                            ListerTables();
                            AccesConsole.Attendre();
                            break;

                        case 3: 
                            AccesConsole.CreerEcran("Lister les arbitres");
                            ListerArbitres();
                            AccesConsole.Attendre();
                            break;

                        case 4:
                            MenuRencontres();
                            break;
                        

                        default: Console.WriteLine("\nSaisie incorrecte");
                            break;

                    }
                }

                catch (ExceptionAccesDB e)
                {
                    Console.WriteLine("\nAccès à la DB impossible (" + e.Message + ")");
                    AccesConsole.Attendre();
                 
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nErreur rencontrée (" + e.Message + ")");
                    AccesConsole.Attendre();
                }
            }

        }

        // Menu Joueurs

        public void MenuJoueurs()
        {
            while (true)
            {
                AccesConsole.CreerEcran("Menu joueurs");
                Console.WriteLine("1 = Lister les joueurs" +
                                  "\n2 = Ajouter un joueur" +
                                  "\n3 = Supprimer un joueur" +
                                  "\n4 = Modifier un joueur" +
                                  "\n5 = Lister les rencontres jouées par joueur");


                try
                {
                    switch (AccesConsole.Saisirint("\nChoix : "))
                    {
                        case 1:
                            AccesConsole.CreerEcran("Lister les joueurs");
                            ListerJoueurs();
                            AccesConsole.Attendre();
                            break;


                        case 2:
                            AccesConsole.CreerEcran("Créer un joueur");
                            CreerJoueurs();
                            AccesConsole.Attendre();
                            break;


                        case 3:
                            AccesConsole.CreerEcran("Supprimer un joueur");
                            SupprimerJoueurs();
                            AccesConsole.Attendre();
                            break;

                        default:
                            Console.WriteLine("\nSaisie incorrecte");
                            break;
                    }
                }

                catch (ExceptionAccesDB e)
                {
                    Console.WriteLine("\nAccès à la DB impossible (" + e.Message + ")");
                    AccesConsole.Attendre();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nErreur rencontrée (" + e.Message + ")");
                    AccesConsole.Attendre();
                }
            }
        }

        // Menu rencontres


        public void MenuRencontres()
        {
            while (true)
            {
                AccesConsole.CreerEcran("Menu tournois");
                Console.WriteLine("1 = Créer un nouveau tournois" +
                                  "\n2 = Recalculer les rencontres" +
                                  "\n3 = Lister les rencontres" +
                                  "\n4 = Renseigner un vainqueur");

                try
                {
                    switch (AccesConsole.Saisirint("\nChoix : "))
                    {
                        case 1:
                            AccesConsole.CreerEcran("Créer un nouveau tournois");

                            AccesConsole.Attendre();
                            break;


                        case 2:
                            AccesConsole.CreerEcran("Recalculer les rencontres");

                            AccesConsole.Attendre();
                            break;


                        case 3:
                            AccesConsole.CreerEcran("Lister les rencontres");

                            AccesConsole.Attendre();
                            break;

                        case 4:
                            AccesConsole.CreerEcran("Renseigner un vainqueur");

                            AccesConsole.Attendre();
                            break;

                        default:
                            Console.WriteLine("\nSaisie incorrecte");
                            break;
                    }
                }

                catch (ExceptionAccesDB e)
                {
                    Console.WriteLine("\nAccès à la DB impossible (" + e.Message + ")");
                    AccesConsole.Attendre();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nErreur rencontrée (" + e.Message + ")");
                    AccesConsole.Attendre();
                }

            }

        }

        // Lister les joueurs

        public void ListerJoueurs()
        {
            List<joueurs> liste = coucheAccesDB.ListerJoueurs();

            if (liste == null)
            {
                Console.WriteLine("\nIl n'y a aucun joueur dans la DB.");
                return;
            }

            Console.WriteLine("ID, Nom, Prénom et classement :\n");

            while (liste.Count > 0)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", liste[0].idj, liste[0].nom, liste[0].prenom, liste[0].classement);
                liste.RemoveAt(0);
            }
        }

        // Créer des joueurs

        public void CreerJoueurs()
        {
            joueurs Joueurs = new joueurs();

            Joueurs.nom = AccesConsole.SaisirChaine("Entrer le nom du joueur : ");
            Joueurs.prenom = AccesConsole.SaisirChaine("Entrer le prénom du joueur : ");
            Joueurs.classement = AccesConsole.Saisirint("Entrer le classement du joueur : ");

            switch (coucheAccesDB.CreerJoueurs(Joueurs))

            {
                case 0:
                    Console.WriteLine("\nL'a création n'a pas pu avoir lieu.");
                    break;
                case 2:
                    Console.WriteLine("\nIl y a déjà 8 joueurs enregistrés.");
                    break;

                default:

                    Console.WriteLine("\nL'ajout s'est bien passé.");
                    break;
            }
        }

        // Supprimer un joueur avec son idj

        public void SupprimerJoueurs()
        {
            int leJoueur;

            int idj = AccesConsole.Saisirint("Entrer l'ID du joueur à supprimer : ");
            leJoueur = coucheAccesDB.TrouverUnJoueurs(idj);

            if ( leJoueur == 0)
            {
                Console.WriteLine("\nLe joueur n'existe pas.");
                return;
            }

            string s = AccesConsole.SaisirChaine("\nVoulez-vous supprimer le joueur ?" + idj + " (o/n)?");

            if (s.CompareTo("o") == 0)
            {
                if (coucheAccesDB.SupprimerJoueurs(idj) == 0)
                    
                    Console.WriteLine("\n\nLa suppression n'a pas eu lieu !");
                    
                else             
                    Console.WriteLine("\n\nLa suppression s'est bien déroulée.");
                  
            }

        }

        // Lister les arbitres

        public void ListerArbitres()
        {
            List<arbitres> liste = coucheAccesDB.ListerArbitres();

            if (liste == null)
            {
                Console.WriteLine("\nIl n'y a aucun arbitre dans la DB.");
                return;
            }

            Console.WriteLine("\nID, Nom, Prénom et expérience :\n");

            while (liste.Count > 0)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", liste[0].ida, liste[0].nom, liste[0].prenom, liste[0].experience);
                liste.RemoveAt(0);
            }
        }


        // Lister les tables

        public void ListerTables()
        {
            List<tables> liste = coucheAccesDB.ListerTables();

            if (liste == null)
            {
                Console.WriteLine("\nIl n'y a aucun arbitre dans la DB.");
                return;
            }

            Console.WriteLine("\nID et position :\n");

            while (liste.Count > 0)
            {
                Console.WriteLine("{0}, {1}", liste[0].idt, liste[0].position);
                liste.RemoveAt(0);
            }

            // Créer un tournois = lance la création des 4 rencontres de quart de finale


            public void CreerRencontreQuart()
            {
                rencontres Rencontre = new rencontres();

            switch (coucheAccesDB.CreerRencontreQuart(Rencontre))

            {
                case 0:
                    Console.WriteLine("\nL'a création n'a pas pu avoir lieu.");
                    break;
                case 2:
                    Console.WriteLine("\nIl y a déjà 8 joueurs enregistrés.");
                    break;

                default:

                    Console.WriteLine("\nL'ajout s'est bien passé.");
                    break;
            }


        }

        }
    }


}
