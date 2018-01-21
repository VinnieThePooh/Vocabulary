using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocabulary.Core.DataAccess;
using Vocabulary.Infrastructure;

namespace Vocabulary.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CreateDb();
            Console.ReadKey(true);
        }



        static void CreateDb()
        {
            Console.Write("Creating db...");
            Database.SetInitializer(new DefaultIfNotExistDbInitializer());
            var context = new VocabularyContext();
            context.Database.Initialize(true);
            Console.WriteLine("completed successfully");
        }

    }
}
