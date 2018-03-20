using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string resultText = string.Empty;
            var en = new Entities();
            var query = from e in en.MYTABLE
                        where e.ID == 1
                        select e;
            if (query.Count() == 0)
                resultText = "No result!";
            var result = query.First();
            resultText = result.USERNAME + " " + result.SEX;
            Console.WriteLine(resultText);
        }
    }
}
