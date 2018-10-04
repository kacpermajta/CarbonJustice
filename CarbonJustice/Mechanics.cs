using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarbonJustice
{
    public static class Mechanics
    {
        /// <summary>
        /// Values
        /// </summary>
        public static int numFactions, numDistricts;
        static public Form1 mainForm;
        static public DistrictPopup activeDisPopup;
        static public District[] Districts;
        static public int activeDistrict;
        static public int activeFaction;
        static public int activeCrime;

        static public List< Notification> GameLog;
        static public List<CityEvent> CityLife;
        static public List<Crime> CrimeScene;

        static public Panel notificationPanel, CrimePanel;
        public static Random diceRoll;
        public static Faction[] Factions;
        public static int lifetime;
        public static float lawless;
        static int CrimeId;



        static public void Initialize(Form1 thisForm)
        {
            //lifetime = 0;
            CrimeId = 42;
            numFactions = 9;
            numDistricts = 15;
            mainForm = thisForm;
            Districts = new District[numDistricts];
            Factions = new Faction[numFactions];
            diceRoll = new Random();
            int i;
            for (i = 0; i < numDistricts; i++)
                Districts[i] = new District(i);
            for (i = 0; i < numFactions; i++)
                Factions[i] = new Faction(i);
            for (i = 0; i < numFactions; i++)
                Factions[i].initiliseRelations();

            GameLog = new List<Notification>();
            CityLife = new List<CityEvent>();
            CrimeScene = new List<Crime>();


            Crime tempCrime = new Crime();
            CrimeScene.Add(tempCrime);
            tempCrime = new Crime();
            CrimeScene.Add(tempCrime);
            tempCrime = new Crime();
            CrimeScene.Add(tempCrime);

            mayor();




        }
        public static void mayor()
        {

            GameLog.Add(new Notification("Wiadomość dla Komendanta od Prezydenta Miasta:"));

            GameLog.Add(new Notification("\"Wczorajsza pacyfikacja buntowników, choć niezbędna, była niezwykle niefortunnym wydarzeniem.\""));

            GameLog.Add(new Notification("\"Oczekuję że jako Komendant służb porządkowych dopilnujesz porządku w mieście.\""));
            GameLog.Add(new Notification("\"Nie chcę kolejnego incydentu.\""));


            GameLog.Add(new Notification("Jako Komendant służb porządkowych wiesz, że kolejny incydent to tylko kwestia czasu."));

            lifetime = 0;


        }

        /// <summary>
        /// District class, governs a part of city
        /// </summary>
        public class District
        {
            int No;
            int citizens;
            public int[] members;
            string name;
            public void repress()
            {
                Console.WriteLine("W dzielnicy "+name+ " cie nie lubia");
                GameLog.Add(new Notification("Jeśli ktokolwiek w dzielnicy " + name + " myślał o buncie, teraz pomyśli dwa razy"));
                RefreshNotifications();
                for (int i = 0; i < numFactions; i++)
                {
                    Factions[i].Upset(members[i] * 0.0004f);
                    Factions[i].Tame(members[i] * 0.0015f);
                }

                CityUpdate(1);
            }
            public void search()
            {
                Console.WriteLine("W dzielnicy " + name + " czysto");
                Mechanics.GameLog.Add(new Notification("Rutynowe przeszukania dzielnicy " + name + " ostudziły zapał potencjalnych przestępców."));
                RefreshNotifications();
                for (int i = 0; i < numFactions; i++)
                {
                    Factions[i].Tame(members[i] * 0.0004f);
                }

                CityUpdate(1);

            }
            public void propaganda()
            {
                Console.WriteLine("W dzielnicy " + name + " masz respekt");
                GameLog.Add(new Notification("Twój wizerunek w dzielnicy " + name + " znacznie się ocieplił."));
                RefreshNotifications();
                for (int i = 0; i < numFactions; i++)
                {
                    Factions[i].Upset(-members[i] * 0.0008f);
                }

                CityUpdate(1);
            }
            public District(int number)
            {
                int i;

                No = number;
                name = StringValues.districts[No];
                citizens = 100000 + diceRoll.Next(1,100000);
                members = new int[numFactions];

                for(i=0; i<numFactions;i++)
                {
                    members[i] = diceRoll.Next(0, citizens / numFactions);
                    
                }

            }


        }
        /// <summary>
        /// faction class, governs group of people
        /// </summary>
        public class Faction
        {
            public int members;
            public float happiness, battleReady;
            Dictionary<Faction, float> relations;

            public string name;
            public Faction(string thisName)
            {
                name = thisName;
            }
            public Faction(int No)
            {
                name = StringValues.factions[No];



                happiness = -1000 + diceRoll.Next(0, 2000);
                battleReady = -1000 + diceRoll.Next(0, 2000);
                members = 0;
                int i;
                for (i = 0; i < numDistricts; i++)
                    members += Districts[i].members[No];
                relations = new Dictionary<Faction, float>();

            }
            public void Upset(float amount)
            {
                happiness -= amount;
                checkDependencies();
            }
            public void Tame(float amount)
            {
                battleReady -= amount;
                checkDependencies();
            }

            public void conductPerpetrator(CityEvent thisEvent)
            {
                happiness += thisEvent.content;
                battleReady += thisEvent.warmup;
                relations[thisEvent.target] += thisEvent.sympathy;
                checkDependencies();
            }
            public void conductTarget(CityEvent thisEvent)
            {
                happiness += thisEvent.favor;
                battleReady += thisEvent.mongering;
                relations[thisEvent.perpetrator] += thisEvent.gratitude;
                checkDependencies();
            }
            public void initiliseRelations()
            {
                foreach(Faction peer in Factions)
                {
                    if (peer != this)
                        relations.Add(peer, diceRoll.Next(-1000, 1000));
                }
                
            }
            public void checkDependencies()
            {
                bool Novi;
                do
                {
                    Novi = false;
                    if (happiness > 1000f)
                    {
                        Novi = true;
                        battleReady -= happiness - 1000f;
                        happiness = 1000f;
                    }
                    if (happiness < -1000f)
                    {
                        Novi = true;
                        battleReady -= happiness + 1000f;
                        happiness = -1000f;
                    }

                    if (battleReady < -1000f)
                    {
                        Novi = true;
                        happiness -= -battleReady - 1000f;
                        battleReady = -1000f;
                    }
                    if (battleReady > 1000f)
                    {
                        Novi = false;
                       mainForm.Rebelion(this);


                    }
                } while (Novi);
                //else- Nihil Novi
            }
        }
        //static void Rebelion(Faction guilty)
        //{
        //    notificationPanel.Controls.Clear();
        //    //activeFaction = guilty;
        //    Lost popup=new Lost(guilty.name);
        //    DialogResult dialogresult = popup.ShowDialog();
            
        //    if (dialogresult == DialogResult.OK)
        //    {
        //        //                Console.WriteLine("You clicked OK");
        //    }
        //    else if (dialogresult == DialogResult.Cancel)
        //    {
        //        //                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
        //    }
        //    popup.Dispose();
        //    guilty.Tame(400f);
        //}

        public enum EventType {attack, talk, rally, manifestation, sabotage, peace, provocation }

        /// <summary>
        /// event class, governs actions of factions
        /// </summary>
        public class CityEvent
        {
            public int countdown;
            public Faction perpetrator;
            public Faction target;
            public float content;//happiness bonus for perpetrator
            public float favor;//happiness bonus for target
            public float sympathy;//relation bunus to target for perp.
            public float gratitude;//relation bonus to perp. for target
            public float warmup;//battleready bonus for perp.
            public float mongering;//battleready bonus for target
            public EventType type;
            public bool active;
            public void UpdateEvent()
                
            {
                countdown--;
                if (countdown == 4)
                    GameLog.Add(new Notification(this));
                else if (countdown==0)
                {
                    ConductEvent();
                    active = false;
                    GameLog.Add(new Notification(this));

                }


            }



            void ConductEvent()
            {
                perpetrator.conductPerpetrator(this);
                target.conductTarget(this);
                //CityLife.Remove(this);
                return;
            }
            public CityEvent()
            {
                active = true;
                perpetrator = Factions[diceRoll.Next(0, numFactions)];
                do
                {
                    target = Factions[diceRoll.Next(0, numFactions)];
                } while (target == perpetrator);
                content = (float)diceRoll.NextDouble()*100;
                favor = (float)(-100 + diceRoll.NextDouble() * 200);
                warmup = (float)(-100 + diceRoll.NextDouble() * 200);
                mongering = (float)(-100 + diceRoll.NextDouble() * 200);
                sympathy = Calculate(new float[] { content, mongering }, new float[] { warmup });
                gratitude= Calculate(new float[] { favor, warmup }, new float[] { mongering });

                if (mongering < -10f && favor < 10f)
                    type = EventType.sabotage;
                else if (content > 10f && favor < 10f)
                    type = EventType.manifestation;
                else if (favor < -10f)
                {
                    if (mongering > 10f)
                        type = EventType.attack;
                    else
                        type = EventType.provocation;

                }
                else if ((warmup > -10f && mongering > 10f) || (warmup > 10f && mongering > -10f))
                    type = EventType.rally;
                else if (favor > 10f)
                    type = EventType.talk;
                else
                    type = EventType.peace;

                countdown = 10;


            }


        }

        /// <summary>
        /// notification class, 
        /// </summary>
        public class Notification
        {
            String text;
            bool fresh;
//            bool reactionary;
            CityEvent notifiedEvent;
            bool active;


            public void Display(int Num, Panel active)
            {
                TextBox newText = new TextBox();
                newText.Text = text;
                newText.Location= new Point(20, 520-32*Num);
                newText.Size = new Size(710, 20);
                if(fresh)
                {

                    newText.Font = new Font(newText.Font, FontStyle.Bold);
                    fresh = false;
                }
                active.Controls.Add(newText);
                if(notifiedEvent!=null)
                {
                    if (notifiedEvent.active)
                    {
                        Button stopper = new Button();
                        stopper.Text = "Powstrzymaj";
                        stopper.Location = new Point(740, 520 - 32 * Num);
                        stopper.Size = new Size(110, 25);
                        //Delegate notifiedEvent.Prevent();
                        stopper.Click += new EventHandler(Prevent);
                        stopper.Tag = notifiedEvent;
                        stopper.BackColor = Color.Silver;

                        active.Controls.Add(stopper);
                    }
                    else
                    {
                        CityLife.Remove(notifiedEvent);
                        
                    }
                }

            }
            public Notification(string notText)
            {
                text = notText;
                fresh = true;
                
            }
            public Notification(CityEvent thisEvent)
            {
                text = StringValues.eventNotification(thisEvent);
                notifiedEvent = thisEvent;
                fresh = true;
            }
        }
        public class Crime
        {
            public int suspect,victim;
            float difficulty;
            District scene;
            String name;
            bool isactive;
            public Crime()
            {
                suspect = diceRoll.Next(0, numFactions);
                victim =diceRoll.Next(0, numFactions);
                name=CrimeId+".|"+ StringValues.crimes[diceRoll.Next(0, StringValues.crimes.Length)];
                difficulty = (float)(2 + diceRoll.NextDouble() * 14);
                CrimeId++;
                isactive = true;
            }
            public void Check()
            {
                if(!isactive)
                {
                    CrimeScene.Remove(this);

                }
            }
            public void Update()
            {
                Factions[suspect].Tame(-5f);
                Factions[victim].Upset(4f);
            }
            public bool Display(int Num, Panel active)
            {
                if (isactive)
                {
                    activeCrime = Num;
                    Button newButt = new Button();
                    newButt.Text = name;
                    newButt.Location = new Point(40, 70 + 40 * Num);
                    newButt.Size = new Size(160, 35);
                    newButt.Click += new EventHandler(mainForm.buttonCrime_click);
                    newButt.Tag = Num;
                    newButt.BackColor = Color.Silver;
                    active.Controls.Add(newButt);
                    return true;
                }
                else
                    return false;

            }

            public void solve()
            {
                difficulty -= 5;
                if (difficulty < 0)
                {
                    Factions[suspect].Upset(15f);
                    Factions[victim].Upset(-15f);
                    GameLog.Add(new Notification("Sprawa rozwiązana, ale frakcja " + Factions[suspect].name + " nie jest z tego zadowolona."));
                    //CrimeScene.Remove(this);
                    isactive = false;

                }
                else
                {
                    GameLog.Add(new Notification("Sprawa wymaga dalszej analizy. Frakcja " + Factions[suspect].name + " krzywo patrzy na twoje zaangażowanie."));


                }
                CityUpdate(1);

                Mechanics.RefreshNotifications();

            }
        }



        public static void Prevent(object sender, EventArgs e)
        {
            Mechanics.CityEvent thisEvent = (CityEvent)((sender as Button).Tag);
            Mechanics.GameLog.Add(new Notification("Frakcja " + thisEvent.perpetrator.name + " nie jest zadowolona z interwencji"));
            thisEvent.perpetrator.Upset(10f);
            thisEvent.active = false;
            CityLife.Remove(thisEvent);
            RefreshNotifications();
            CityUpdate(1);

        }
        static public void UpdateCrime()
        {
            foreach (Crime CrimeCase in CrimeScene)
            {
                CrimeCase.Update();


            }
            lawless += 4f;
            if(lawless>14)
            {
                Crime  tempCrime = new Crime();

                CrimeScene.Add(tempCrime);
                lawless = 0f;
            }
            RefreshCrimes();



        }
        static public void CityUpdate(int time)
        {
            UpdateCrime();

            if (time == 0)
                return;
            foreach(CityEvent listed in CityLife)
            {
                listed.UpdateEvent();

            }

            

            CityEvent tempEvent = new CityEvent();
           
            CityLife.Add(tempEvent);
            GameLog.Add(new Notification(tempEvent));
            time--;
            lifetime++;
            CityUpdate(time);
        }
        static public void RefreshNotifications()
        {
            notificationPanel.Controls.Clear();


            int i = Mechanics.GameLog.Count;

            foreach (Mechanics.Notification entry in Mechanics.GameLog)
            {
                i--;

                entry.Display(i, notificationPanel);

            }

        }

        static public void RefreshCrimes()
        {
            CrimePanel.Controls.Clear();

            //CrimePanel.AutoScroll = false;
            //CrimePanel.VerticalScroll.Enabled = true;
            //CrimePanel.VerticalScroll.Visible = true;
            Label newButt = new Label();
            newButt.Text = "Akta Kryminalne";
            newButt.TextAlign = ContentAlignment.MiddleCenter;
            newButt.Location = new Point(40, 20);
            newButt.Size = new Size(160, 25);
            
            newButt.BackColor = Color.White;
            CrimePanel.Controls.Add(newButt);

            int i;

            for (i = CrimeScene.Count-1; i >= 0; i--)
                CrimeScene[i].Check();
            i= 0;
            foreach (Mechanics.Crime entry in Mechanics.CrimeScene)
            {

                entry.Display(i, CrimePanel);
                i++;

            }
            CrimePanel.AutoScroll = true;

        }

        static public float Calculate(float[] adv, float[] disa)
        {
            int advantages = adv.Length;
            int disadvantages = disa.Length;
            float val = 0f;
            int i;
            for (i = 0; i < advantages; i++)
            {
                val += adv[i] / advantages;
            }
            for (i = 0; i < disadvantages; i++)
            {
                val -= disa[i] / disadvantages;
            }
            return val;
        }


    }
}
