using System;
using System.IO;
using System.Data.SQLite;


namespace BddSqlite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LECON 3 : SqLite : CREATION DE BASE DE DONNEES ET TABLE

            //SQLite est un système de gestion de base de données relationnelle (SGBDR) qui peut être intégré directement dans une application.
            //En C#, SQLite est souvent utilisé comme base de données embarquée, ce qui signifie qu'au lieu de dépendre d'un serveur de base de données distinct, votre application peut stocker et gérer les données localement à l'aide d'une base de données SQLite.
            //Cela simplifie le déploiement de l'application car il n'y a pas besoin d'installer un serveur de base de données distinct.
            //SQLite est léger, rapide et largement utilisé dans les applications mobiles, de bureau et web. En utilisant des bibliothèques telles que Entity Framework Core ou System.Data.SQLite, vous pouvez facilement intégrer SQLite dans vos applications C#.

            string bddpath = "C:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\bdd.sqlite";
            if (!File.Exists(bddpath)) CreateBDD();

            //creation de la bdd
            void CreateBDD()
            {
                SQLiteConnection.CreateFile(bddpath);
                SQLiteConnection con = new SQLiteConnection("Data Source=C:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\bdd.sqlite;Version=3");
                con.Open();

                string sql = "create table clients (nom varchar (20), prenom varchar(20))";

                SQLiteCommand command = new SQLiteCommand(sql, con);
                command.ExecuteNonQuery();

                con.Close();
            }

            //Ajouter des données dans la table clients

            void AddData(string n, string p)
            {
                SQLiteConnection con = new SQLiteConnection("Data Source=C:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\bdd.sqlite;Version=3");
                con.Open();

                string sql = "INSERT INTO clients(nom, prenom) VALUES ('" + n + "', '" + p + "')";

                SQLiteCommand command = new SQLiteCommand(sql, con);
                command.ExecuteNonQuery();

                con.Close();

            }

            //AddData("Gates", "Bill");
            //AddData("Job", "Steeve");
        
            
            //Lire la table clients
            void ReadAllData()
            {
                SQLiteConnection con = new SQLiteConnection("Data Source=C:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\bdd.sqlite;Version=3");
                con.Open();

                string sql = "SELECT * FROM clients ";

                SQLiteCommand command = new SQLiteCommand(sql, con);
                SQLiteDataReader dr = command.ExecuteReader();

                 while (dr.Read())
                {
                    Console.Write("Nom : " + dr.GetString(0));
                    Console.WriteLine(" Prenom : " + dr.GetString(1));
                }  

            }

            //ReadAllData();

            //Recupérer le prenom en fonction du nom

            void ReadPrenom(string n)
            {
                SQLiteConnection con = new SQLiteConnection("Data Source=C:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\bdd.sqlite;Version=3");
                con.Open();

                string sql = "SELECT prenom FROM clients WHERE nom='" + n + "'";

                SQLiteCommand command = new SQLiteCommand(sql, con);
                SQLiteDataReader dr = command.ExecuteReader();

                dr.Read();
                Console.WriteLine(" Prenom : " + dr.GetString(0));   

            }

            ReadPrenom("Gates");



            Console.WriteLine();
            // LECON 4: Classe Environnement
            //Elle fournit des informations sur l'environnement et la plateforme actuelle

                       //permet de retrouver la position d'un fichier ou d'un dossier dans la machine
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

                      //permet de récupérer le nom de la machine
            Console.WriteLine(Environment.MachineName);

                     //la version du système d'exploitation
            Console.WriteLine(Environment.OSVersion);

                     //La taille du système d'exploitation en 64 bits
            Console.WriteLine(Environment.Is64BitOperatingSystem);

                     // Nom d'utilisateur
            Console.WriteLine(Environment.UserName);

                     //nombre de temps écoulé depuis le démarrage du système d'exploitation en milliseconde
            Console.WriteLine(Environment.TickCount);


            Console.ReadKey();
        }
    }
}
