using ConsoleApp1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.WCFOrganisationServiceClient s1 = new ServiceReference1.WCFOrganisationServiceClient();
            ResponseMessageOfPCPersonnel s2 = s1.GetPersonnelInfo(63483);
        }
    }
}
