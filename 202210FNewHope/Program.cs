using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _202210FNewHope
{
    class Program
    {
        class Telefon
        {
            public string telefonszám;
            protected string PIN;
            public string tulajdonos;
            public static List<Telefon> lista = new List<Telefon>(); // nem az egyes telefonok tulajdonsága, hanem a classé!

            public Telefon(string telefonszám, string PIN, string tulajdonos) 
            {
                this.telefonszám = telefonszám;
                this.PIN = PIN;
                this.tulajdonos = tulajdonos;

                Telefon.lista.Add(this);
                // ezt néha így írom: (this.telefonszám, this.PIN, this.tulajdonos) = (telefonszám, PIN, tulajdonos);

                Console.WriteLine("létrejött a telefon!!!");
            }
            public Telefon(string telefonszám) :this(telefonszám, "1234", "")
            {
                // ez akkor futna le, mikor a másik konstruktor már lefutott.
            }

            
            public void Névváltoztatás()
            {
                Console.WriteLine("Add meg a PIN-kódot!");
                string megadottpin = Console.ReadLine();
                if (this.PIN == megadottpin)
                {
                    Console.WriteLine("Helyes PIN-kód! Adja meg az új nevet!");
                    string új_név = Console.ReadLine();
                    this.tulajdonos = új_név;
                }
                else
                {
                    Console.WriteLine("Tedd vissza apád telóját!");
                }
            }


            public override string ToString()
            {
                return $"{tulajdonos} telefonja: {telefonszám}";
            }

            ~Telefon()
            {
                Console.WriteLine("elpusztult a telefon");
            }

            private void PIN_megváltoztatása()
            {
                Console.WriteLine("Add meg a PIN-kódot!");
                string megadottpin = Console.ReadLine();
                if (this.PIN == megadottpin)
                {
                    Console.WriteLine("Helyes PIN-kód! Adja meg az új PIN-t!");
                    string új_PIN = Console.ReadLine();
                    this.PIN = új_PIN;
                }
                else
                {
                    Console.WriteLine("Tedd vissza apád telóját!");
                }
            }

            public virtual void Típus_Kiírása()
            {
                Console.WriteLine("régi típusú telefon");
            }
        }

        class Telefon2 : Telefon
        {
            string PUK;
            public Telefon2(string telefonszám, string PIN, string PUK, string tulajdonos) : base(telefonszám, PIN, tulajdonos)
            {
                this.PUK = PUK;
            }
            public override void Típus_Kiírása()
            {
                Console.WriteLine("új típusú telefon");
            }
        }


        static void Main(string[] args)
        {
            ///Telefont csinálunk. 
            // Egy telefonnak legyen 
            // - Telefonszáma
            // - PIN kódja
            // - Tulajdonos

            Telefon telefon = new Telefon("06507894562", "1234", "János");
            
            Telefon telefon2 = new Telefon("06512123962", "1324", "Jácint");
            Telefon telefon3 = new Telefon("06512213463", "1342", "József");
            telefon3.Típus_Kiírása();
            Console.WriteLine(telefon);

            telefon.Névváltoztatás();

            Console.WriteLine(telefon);

            Console.WriteLine(Telefon.lista.Count);

            Telefon2 t2 = new Telefon2("06557894562", "1234", "43211234", "Jeremiás");
            t2.Típus_Kiírása();


        }
    }
}
