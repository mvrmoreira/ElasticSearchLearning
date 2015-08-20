using Elasticsearch.Net;
using NESTCA.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESTCA
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ElasticsearchClient();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            int totalCount = 100000;

            for (int i = 0; i < totalCount; i++)
            {
                var creditCard = new CreditCard();
                creditCard.Buyer = new Buyer();
                creditCard.InstantBuyKey = Guid.NewGuid();
                creditCard.Brand = i % 2 == 0 ? "Visa" : "Mastercard";
                creditCard.Buyer.BuyerKey = Guid.NewGuid();
                creditCard.Buyer.Name = Guid.NewGuid().ToString();

                client.Index("mundipagg", "creditcards", creditCard.InstantBuyKey.ToString(), creditCard);
            }

            stopwatch.Stop();

            decimal avg = stopwatch.ElapsedMilliseconds / totalCount;

            Console.WriteLine();
            Console.WriteLine("TOTAL: " + stopwatch.ElapsedMilliseconds + " ms");
            Console.WriteLine("AVG: " + avg + " ms / item");

            Console.ReadLine();


            //var indexResponse = client.Index("myindex", "mytype", "1", new { Hello = "World" });
        }
    }
}
