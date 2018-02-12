using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using Tournois.ClassesMetier;



namespace Tournois.coucheAccesDB
{
    public class AccesDB
    {

        private SqlConnection SqlConn;

        // Constructeur

        public AccesDB()
        {
            try
            {
                SqlConn = new SqlConnection("Integrated security=true;" +
                                            "user id=ROLAND-PC\rolan;" +
                                            "Data Source=ROLAND-PC\\SQLEXPRESS;" +
                                            "Initial Catalog=TOURNOIS;");
                SqlConn.Open();
            }

            catch (Exception e)
            {
                throw new ExceptionAccesDB("Connexion à la DB", e.Message);
            }
        }

        // Lister les joueurs

        public List<joueurs> ListerJoueurs()
        {
            List<joueurs> liste = null;
            SqlCommand sqlCmd = new SqlCommand();

            try
            {
                sqlCmd.CommandText = "select idj, nom, prenom, classement  from joueurs  order by idj";

                sqlCmd.Connection = SqlConn;

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    liste = new List<joueurs>();

                    do
                    {
                        liste.Add(new joueurs(Convert.ToInt32(sqlReader["idj"]),
                                              Convert.ToString(sqlReader["nom"]),
                                              Convert.ToString(sqlReader["prenom"]),
                                              Convert.ToInt32(sqlReader["classement"])));
                    }
                    while (sqlReader.Read());
                }

                sqlReader.Close();

            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(sqlCmd.CommandText, e.Message);
            }

            return liste;

        }

        // Compter les joueurs


        public int CompterLesJoueurs()

        {
            int nbJ;
            SqlCommand sqlCmd = new SqlCommand();

            try
            {
                sqlCmd.CommandText = "SELECT COUNT(*) from joueurs";

                sqlCmd.Connection = SqlConn;

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                sqlReader.Read();

                if (sqlReader[0] == DBNull.Value)
                    nbJ = 0;
                else
                    nbJ = Convert.ToInt32(sqlReader[0]);
            }

            catch (Exception e)
            {
                throw new ExceptionAccesDB(sqlCmd.CommandText, e.Message);
            }

            return nbJ;

        }


        // Trouver un joueur

        public int TrouverUnJoueurs(int idj)
        {
            int leJoueur = 0;
            SqlCommand sqlCmd = new SqlCommand();

            try
            {
                sqlCmd.CommandText = "select idj from joueurs where idj = @idj";

                sqlCmd.Connection = SqlConn;

                sqlCmd.Parameters.Add("@idj", SqlDbType.Int).Value = idj;

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                    leJoueur = Convert.ToInt32(sqlReader["idj"]);

                sqlReader.Close();
            }

            catch (Exception e)
            {
                throw new ExceptionAccesDB(sqlCmd.CommandText, e.Message);
            }

            return leJoueur;

        }

        // Creer joueurs

        public int CreerJoueurs(joueurs Joueurs)
        {
            SqlCommand sqlCmd = new SqlCommand();

            try
            {
                
                sqlCmd.CommandText = "select max(idj) + 1 " + "from joueurs";
                sqlCmd.Connection = SqlConn;

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                sqlReader.Read();

                if (sqlReader[0] == DBNull.Value)
                    Joueurs.idj = 1;

                if (Joueurs.idj > 8)
                    Console.WriteLine("Il y a déjà 8 joueurs inscrits.");

                else
                    Joueurs.idj = Convert.ToInt32(sqlReader[0]);

                sqlReader.Close();

                sqlCmd.CommandText = "insert into joueurs(idj,nom,prenom,classement)" +
                              "values(@idj,@nom,@prenom,@classement)";

                sqlCmd.Parameters.Add("@idj", SqlDbType.Int).Value = Joueurs.idj;
                sqlCmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = Joueurs.nom;
                sqlCmd.Parameters.Add("@prenom", SqlDbType.VarChar).Value = Joueurs.prenom;
                sqlCmd.Parameters.Add("@classement", SqlDbType.Int).Value = Joueurs.classement;

                return sqlCmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw new ExceptionAccesDB(sqlCmd.CommandText, e.Message);
            }


        }

        // Supprimer des joueurs sur base de l'idj

        public int SupprimerJoueurs(int idj)
        {
            SqlCommand sqlCmd = new SqlCommand();

            try
            {
                sqlCmd.Connection = SqlConn;

                sqlCmd.Parameters.Add("@idj", SqlDbType.Int).Value = idj;

                sqlCmd.CommandText = "delete from joueurs where idj = @idj";

                return sqlCmd.ExecuteNonQuery();



            }

            catch (Exception e)
            {
                throw new ExceptionAccesDB(sqlCmd.CommandText, e.Message);
            }


        }

        // Lister les arbitres

        public List<arbitres> ListerArbitres()
        {
            List<arbitres> liste = null;
            SqlCommand sqlCmd = new SqlCommand();

            try
            {
                sqlCmd.CommandText = "select ida, nom, prenom, experience  from arbitres  order by ida";

                sqlCmd.Connection = SqlConn;

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    liste = new List<arbitres>();

                    do
                    {
                        liste.Add(new arbitres(Convert.ToInt32(sqlReader["ida"]),
                                              Convert.ToString(sqlReader["nom"]),
                                              Convert.ToString(sqlReader["prenom"]),
                                              Convert.ToInt32(sqlReader["experience"])));
                    }
                    while (sqlReader.Read());
                }

                sqlReader.Close();

            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(sqlCmd.CommandText, e.Message);
            }

            return liste;

        }


        // Lister les tables

        public List<tables> ListerTables()
        {
            List<tables> liste = null;
            SqlCommand sqlCmd = new SqlCommand();

            try
            {
                sqlCmd.CommandText = "select idt, position from tables  order by idt";

                sqlCmd.Connection = SqlConn;

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    liste = new List<tables>();

                    do
                    {
                        liste.Add(new tables(Convert.ToInt32(sqlReader["idt"]),
                                              Convert.ToInt32(sqlReader["position"])));
                    }
                    while (sqlReader.Read());
                }

                sqlReader.Close();

            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(sqlCmd.CommandText, e.Message);
            }

            return liste;

        }


        // Créer rencontre quart de finale (idp = 4)

        public int CreerRencontre()

        {
            rencontres Rencontres = new rencontres();
            Rencontres.idr = 1;

            SqlCommand sqlCmd = new SqlCommand();

           int ok = 0;
           
            try
            {
                int[] t = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 }; // morceau pour avoir un tableau avec des valeurs mélangées
                int i;
                Random rand = new Random();

                for (i = 0; i < 8; i++)
                {
                    int r = rand.Next(1, 8);

                    int tmp = t[i];
                    t[i] = t[r];
                    t[r] = tmp;
                }
                int n = 1;
                i = 0;
                while (n < 5)
                {

                    sqlCmd.Connection = SqlConn;

                    Rencontres.joueur1 = t[i];
                    Rencontres.joueur2 = t[i + 1];

                    i = i + 2;
                         
                            Rencontres.tables = n;
                            Rencontres.arbitre = n;
                            Rencontres.idp = 4;

                            sqlCmd.Parameters.Clear();
                            sqlCmd.CommandText = "insert into rencontres(idr,joueur1,joueur2,vainqueur,tables,arbitre,phase,score)" +
                                          " values(@idr,@joueur1,@joueur2,null,@tables,@arbitre,@phase,null)";

                            sqlCmd.Parameters.Add("@idr", SqlDbType.Int).Value = Rencontres.idr;
                            sqlCmd.Parameters.Add("@joueur1", SqlDbType.Int).Value = Rencontres.joueur1;
                            sqlCmd.Parameters.Add("@joueur2", SqlDbType.Int).Value = Rencontres.joueur2;
                            //sqlCmd.Parameters.Add("@vainqueur", SqlDbType.Int).Value = NE PAS METTRE LA VALEUR ICI MAIS DIRECT DANS LA REQUETE SQL
                            sqlCmd.Parameters.Add("@tables", SqlDbType.Int).Value = Rencontres.tables;
                            sqlCmd.Parameters.Add("@arbitre", SqlDbType.Int).Value = Rencontres.arbitre;
                            sqlCmd.Parameters.Add("@phase", SqlDbType.Int).Value = Rencontres.idp;
                            //sqlCmd.Parameters.Add("@score", SqlDbType.Char).Value = NE PAS METTRE LA VALEUR ICI MAIS DIRECT DANS LA REQUETE SQL

                            ok = ok + sqlCmd.ExecuteNonQuery();

                        Rencontres.idr = Rencontres.idr + 1;
                        n++;
                    }
            }

            catch (Exception e)
            {
                throw new ExceptionAccesDB(sqlCmd.CommandText, e.Message);
            }
                return ok;

        }


            // Lister les rencontres

            public List<rencontres> ListerRencontres()
            {
                List<rencontres> liste = null;
                SqlCommand sqlCmd = new SqlCommand();

                try
                {
                    sqlCmd.CommandText = "select idr,joueur1,joueur2,vainqueur,table,arbitre,idp,score  from rencontres  order by idr";

                    sqlCmd.Connection = SqlConn;

                    SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                    if (sqlReader.Read())
                    {
                        liste = new List<rencontres>();

                        do
                        {
                            liste.Add(new rencontres(Convert.ToInt32(sqlReader["idr"]),
                                                  Convert.ToInt32(sqlReader["joueur1"]),
                                                  Convert.ToInt32(sqlReader["joueur2"]),
                                                  Convert.ToInt32(sqlReader["vainqueur"]),
                                                  Convert.ToInt32(sqlReader["table"]),
                                                  Convert.ToInt32(sqlReader["arbitre"]),
                                                  Convert.ToInt32(sqlReader["idp"]),
                                                  Convert.ToString(sqlReader["score"])));
                        }
                        while (sqlReader.Read());
                    }

                    sqlReader.Close();

                }
                catch (Exception e)
                {
                    throw new ExceptionAccesDB(sqlCmd.CommandText, e.Message);
                }

                return liste;

            }


            // Mettre un gagnant sur une rencontre


        }

    } 

