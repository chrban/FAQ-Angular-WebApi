using System;
using System.Collections.Generic;
using System.Linq;
using FAQ_Web_Api_Angular.Models;
using System.Web;

namespace FAQ_Web_Api_Angular
{
    public class PopulateDatabase // fyller databasen med data
    {

        public static void Populate()
        {
            var faqsToBe = new List<Faq>
            {

                new Faq {category = "Levering", question = "Når kommer varen jeg har bestillt?", answer = "Normal leveringstid er 4-5 virkedager. Bor du i veldig langt nord i Norge kan det ta opptil en uke lenger.", top = 4 },
                new Faq {category = "Levering", question = "Hvor i Norge leverer dere?", answer = "Vi leverer til hele Norge.", top = 3 },
                new Faq {category = "Levering", question = "Hvordan pakkes produktene?", answer = "Produktene pakkes inn i esker fyllt med bobleplast. Bobpleplasten kan poppes separat.", top = 3 },
                new Faq {category = "Levering", question = "Jeg har endret adresse etter at jeg bestille varer, hva skjer da?", answer = "Det burde du tenkt på før. Pakken din er mest sannsynlig blirr borte i all forvirringen og du har bare deg selv å skylde på.", top = 5 },
                new Faq {category = "Levering", question = "Kan man bestille utenfor Norge?", answer = "Nei, desverre. Vi leverer kun til Norge.", top = 1 },
                new Faq {category = "Bruker", question = "Jeg har glemt passordet mitt, hva skal jeg gjøre?", answer = "Trykk på 'Glemt passord' under menyen 'Logg inn', Her kan du skrive inn e-post adressen din, og vi sender deg et nytt midlertidig passord.", top = 5 },
                new Faq {category = "Bruker", question = "Kan jeg endre brukerinformasjon?", answer = "Ja. Dette gjør du ved å logge og trykke på brukernavenet ditt.", top = 7 },
                new Faq {category = "Bruker", question = "Hvordan kan jeg slette kundeprofilen min?", answer = "Send oss en epost på kaffeplaneten@gmail.com så skal vi vurdere det.", top = 2 },
                new Faq {category = "Bruker", question = "Er min personalia lagret trygt hos dere?", answer = "Ja, dette ligger supersikkert og kryptert i våre systemer. Informasjon vi har solgt videre til eksterne tredjeparter kan vi ikke gå god for.", top = 4 },
                new Faq {category = "Support", question = "Posten sier de ikke finner pakken min, hva skal jeg gjøre?", answer = "Send oss en e-post på kaffeplaneten@gmail.com så tar vi det derfra.", top = 4 },
                new Faq {category = "Support", question = "Jeg kan ikke legge til produkter i handlekurven, gjør jeg noe feil?", answer = "Dette er en klassisk brukerfeil.  Restart enheten din og spaser to runder rundt kaffetrakteren. Hvis du fortsatt opplever problemer kan til nød sende oss en epost på kaffeplaneten@gmail.com", top = 4 },
                new Faq {category = "Support", question = "Betalingsløsningen deres fungerer ikke med kortet mitt!", answer = "Helt korrekt. Betalingssystemet fungerer ikke for noen kort, da nettbutikken ikke er aktiv for øyeblikket.", top = 2 },
                new Faq {category = "Produkt", question = "Inneholder produktene dere fører palmeolje?", answer = "Nei. Vi håper ikke det. Hvis vi finner ut at et produkt inneholder palmeolje banker vi produsenten så fort vi har mulighet.", top = 9 },
                new Faq {category = "Produkt", question = "Produktet mitt smaker rart! Hva skal dere gjøre med det?", answer = "Vi legger oss paddeflate. Vi skulle selfølgelig informert om at aktuelt produkt ikke smaker godt.  ", top = 2 },
                new Faq {category = "Produkt", question = "Kan jeg bestille varer som ikke finnes på lager?", answer = "Ja, om du forhåndsbetaler er dette i orden. Det finnes ingen garanti for at produktet kommer tilbake på lager.", top = 5 },
                new Faq {category = "Produkt", question = "Kan dere anbefale noen produkter?", answer = "Klart vi kan! Meld deg på vår mailingliste ved å sende en epost til kaffeplaneten@gmail.com", top = 2 }
             };

            var questionsToBe = new List<Question>
            {
                new Question { title = "Endre leveringsadresse", question = "Hei! Jeg bare lurte på hvordan jeg endrer min egen leveringsadrsse?", name = "Ulf Ulfesen", email = "ulf@hioa.no"  },
                new Question { title = "Hvor står prisen?", question = "Hor mye koster koffeinfri kaffe i løsvekt? finner ikke denne informasjonen noe sted..", name = "Ole Hansen", email = "ole@idole.no" },
                new Question { title = "Aldersgrense", question = "Hallo! Mitt spørsmål idag er om dere har aldersgrense på produktene som inneholder mest koffein? det er jo slik med energidrikker...", name = "Mikkel Brorsen", email = "revenmikkel@broshan.no" },
                new Question { title = "Jeg angrer!" , question = "Hei! Jeg har bestillt et produkt jeg anger inderlig på at jeg bestilte.. Hvordan kan jeg angre meg? har dere en ctl-z knapp eller lignende?", name = "Robin Rapunsel", email = "robban@tappa.no" },
                new Question { title = "Leveringstid" , question = "Hvor blir det av varene jeg bestillte? Nå synes jeg det har gått for lang tid.. Jeg bestillte de igår og de har enda ikke kommet.. ", name = "Ann Gakkgakk", email = "duck@face.no" }
            };


            using (var db = new FaqContext())
            {

                faqsToBe.ForEach(f => db.Faqs.Add(f));
                questionsToBe.ForEach(q => db.Questions.Add(q));
                db.SaveChanges();
            }



        }



    }
}