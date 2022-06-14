using csharp_bibliotecaMvc.Models;

namespace csharp_bibliotecaMvc.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BibliotecaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Autores.Any())
            {
                return;
            }
            var autori = new Autore[]
            {
                new Autore{Nome="Francesco", Cognome="Costa", DataNascita = DateTime.Parse("04/21/1984")},
                new Autore{Nome="Luca", Cognome="Sofri", DataNascita = DateTime.Parse("12/15/1964")},
                new Autore{Nome="Harper", Cognome="Lee", DataNascita = DateTime.Parse("04/28/1926")},
            };

            foreach (Autore a in autori)
            {
                context.Autores.Add(a);
            }
            context.SaveChanges();

            var fCosta = context.Autores.Where(item => item.Cognome == "Costa").First();
            var lSofri = context.Autores.Where(item => item.Cognome == "Sofri").First();
            var hLee = context.Autores.Where(item => item.Cognome == "Lee").First();


            if (context.Libris.Any())
            {
                return;
            }
            var libris = new Libro[]
            {
                new Libro{Titolo="Questa è l'America",Autori=new List<Autore>{ fCosta }, Anno=2019,Stato="Disponibile",ISBN="EUIOW34LA", Scaffale = 1},
                new Libro{Titolo="Notizie che non lo erano",Autori=new List<Autore>{ lSofri },Anno=2015,Stato="Disponibile",ISBN="SODJHTF34", Scaffale = 2},
                new Libro{Titolo="To Kill a Mokingbird",Autori=new List<Autore>{ hLee },Stato="Disponibile",Anno=1960,ISBN="SOEJ5Y4SDK", Scaffale = 4},
            };

            foreach (Libro l in libris)
            {
                context.Libris.Add(l);
            }
            context.SaveChanges();


            if (context.Utentes.Any())
            {
                return;
            }
            var utenti = new Utente[]
            {
                new Utente{Nome="Marco",Cognome="deIulio",Email="mdeiulio@icloud.com",Password="psw"},
                new Utente{Nome="Gigi",Cognome="Isab",Email="cicobn@gmail.com",Password="cicobn"},
            };

            foreach (Utente u in utenti)
            {
                context.Utentes.Add(u);
            }
            context.SaveChanges();

            var deIulio = context.Utentes.Where(item => item.Cognome == "deIulio").First();
            var Isab = context.Utentes.Where(item => item.Cognome == "Isab").First();

            var libro1 = context.Libris.Where(item => item.ISBN == "EUIOW34LA").First();
            var libro2 = context.Libris.Where(item => item.ISBN == "SODJHTF34").First();
            var libro3 = context.Libris.Where(item => item.ISBN == "SOEJ5Y4SDK").First();


            if (context.Prestitis.Any())
            {
                return;
            }
            var prestiti = new Prestito[]
            {
                new Prestito{PrestitoID="1",Inizio=DateTime.Parse("07/07/2020"),Fine=DateTime.Parse("09/09/2022"),Utente=deIulio,Libro=libro1},
                new Prestito{PrestitoID="2",Inizio=DateTime.Parse("08/08/2021"),Fine=DateTime.Parse("09/09/2021"),Utente=deIulio,Libro=libro2},
                new Prestito{PrestitoID="3",Inizio=DateTime.Parse("01/02/2022"),Fine=DateTime.Parse("08/04/2022"),Utente=Isab,Libro=libro3},
            };

            foreach (Prestito p in prestiti)
            {
                context.Prestitis.Add(p);
            }
            context.SaveChanges();

        }
    }
}
