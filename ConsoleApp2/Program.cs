using System;

namespace ConsoleApp2
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ServiceReference1.WCFOrganisationServiceClient asb = new ServiceReference1.WCFOrganisationServiceClient();
            var y  = await asb.GetPersonnelInfoAsync(63483);

        }
    }
}
