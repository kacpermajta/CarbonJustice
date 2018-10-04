using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonJustice
{
    class StringValues
    {
        public static string[] districts=new string[] {
            "Śródmieście",
            "Prądnik",
            "Krowodrza",           
            "Bronowice",
            "Zwierzyniec",           
            "Dębniki",
            "Łagiewniki",           
            "Swoszowice",
            "Podgórze",           
            "Czyżyny",
            "Mistrzejowice",
            "Bieńczyce",
            "W. Krzesławicekie",
            "Bieżanów",
            "Kokotów",
        };
        public static string[] factions = new string[] {
            "Mutanci",
            "Cyborgi",
            "Androidy",
            "Augamenci",
            "Antitech",
            "Nacjonaliści",
            "Fundamentaliści",
            "Anarchiści",
            "Neohipisi",



        };

        public static string[] crimes = new string[] {
            "Zabójstwo",
            "Rozboje",
            "Kradzież",
            "Napad",
            "Rabunek",
            "Napaść",

        };



        public static string eventNotification(Mechanics.CityEvent notifiedEvent)
        {
            string message="";
            if (notifiedEvent.countdown >= 10)
                message += "Planowane wydarzenie: ";
            else if (notifiedEvent.countdown > 0)
                message += "Zbliża się wydarzenie: ";
            else
                message += "Z ostatniej chwili: ";
            switch (notifiedEvent.type) {
                case Mechanics.EventType.attack:
                    return (message + "atak frakcji" + notifiedEvent.perpetrator.name + " na frakcję " + notifiedEvent.target.name + ".");
                    break;
                case Mechanics.EventType.manifestation:
                    return (message + "manifestacja przciw frakcji " + notifiedEvent.target.name + " organizowana przez frakcję " + notifiedEvent.perpetrator.name + ".");
                    break;
                case Mechanics.EventType.peace:
                    return (message + "deklaracja pokoju złożona frakcji " + notifiedEvent.target.name + " przez frakcję " + notifiedEvent.perpetrator.name + ".");
                    break;

                case Mechanics.EventType.provocation:
                    return (message + "prowokacja medialna frakcji " + notifiedEvent.perpetrator.name + " wymierzona we frakcję " + notifiedEvent.target.name + ".");
                    break;

                case Mechanics.EventType.rally:
                    return (message + "wiec frakcji " + notifiedEvent.perpetrator.name + " z gościnnym udziałem frakcji " + notifiedEvent.target.name + ".");
                    break;
                case Mechanics.EventType.sabotage:
                    return (message + "sabotaż wymierzony we frakcję " + notifiedEvent.target.name + " przygotowany przez frakcję " + notifiedEvent.perpetrator.name + ".");
                    break;
                case Mechanics.EventType.talk:
                    return (message + "pertraktacje frakcji " + notifiedEvent.perpetrator.name + " z frakcją " + notifiedEvent.target.name + ".");
                    break;



            }



            return notifiedEvent.perpetrator.name;
        }
    }
}
