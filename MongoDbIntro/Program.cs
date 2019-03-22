using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using MongoDbIntro.Core;
using System;
using System.Collections.Generic;

namespace MongoDbIntro
{
    class Program
    {
        const string DATABASENAVN = "";
        const string COLLECTIONNAVN = "";
        const string DATABASEUSERNAME = "";
        const string DATABASEPASSWORD = "";
        const string CONNECTIONSSTRING = "";
        static void Main(string[] args)
        {

            Opret();
           //// var liste = repo.HentDatabaseCollection("csharp");
           // Console.WriteLine("The list of collections are :");
           // foreach (var item in liste)
           // {
           //     Console.WriteLine(item);
           // }
            //var dblist = mr.GetDatabaseList();
            //Console.WriteLine("The list of databases are :");
            //foreach (var item in dblist)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine("Hello World!");
            //WithCoreEventsSubscription(d);
        }
        private static void Opret()
        {
            Udvikler u = new Udvikler { Name = "Jakob" };


            List<Viden> videnList = new List<Viden>();
            Viden v = new Viden { Sprog = "C#", Rating = 10 };

            videnList.Add(v);

            u.Viden = videnList;
            MongoDBRepository repo = new MongoDBRepository(CONNECTIONSSTRING, DATABASENAVN, COLLECTIONNAVN);
            string res = repo.CreateIndex();
            //repo.OpretUdvikler(u);

            Console.WriteLine();
        }
        
    }
}
