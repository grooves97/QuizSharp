using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;


namespace RegistrationForm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            users.Add(new User() { Email="grooves97@gmail.com", Password="123",City="Astana",Phone=8777,Age=10});
            users.Add(new User() { Email="serik@gmail.com",Password="123",City="Astana",Phone=7788,Age=30});

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<User>));

            using (FileStream fs = new FileStream("./people.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, users);
            }


            Console.ReadLine();
        }
    }
}
