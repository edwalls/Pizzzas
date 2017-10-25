using PizzaFactory.Helpers;
using PizzaFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace PizzaFactory.Implementation
{
    public class PizzaKingStore : IPizzaKingStore
    {
        private IFactoryConfigSection _settings;
        private IPizzaFactory _pizzaFactory;
        private IPizzaTopFactory _pizzaTopFactory;

        public PizzaKingStore(IFactoryConfigSection settings, IPizzaFactory pizzaFactory, IPizzaTopFactory pizzaTopFactory)
        {
            _settings = settings ?? throw new ArgumentException(string.Format($"{nameof(settings)} is null."));
            _pizzaFactory = pizzaFactory ?? throw new ArgumentException(string.Format($"{nameof(pizzaFactory)} is null.")); ;
            _pizzaTopFactory = pizzaTopFactory ?? throw new ArgumentException(string.Format($"{nameof(pizzaTopFactory)} is null.")); ;            
        }

        public void StartProcess()
        {
            try
            {
                ResetFileReports();

                WriteReport($"++ Start process ++");
                WriteReport($"-------------------");

                int numPizzas = NumPizzasTarget();
                for (int i = 0; i < numPizzas; i++)
                {
                    try
                    {
                        IPizza freshPizza = SelectPizzaBase();
                        List<ITop> tops = SelectPizzaTops();
                        foreach (var top in tops)
                        {
                            freshPizza.AddTop(top);
                        }
                        WriteReport("");
                        WriteReport($"Start cooking order num: {i + 1}");
                        WriteReport($"-----------------------------");
                        Bake(freshPizza);
                        WriteReport(freshPizza.GetDetails());
                        WriteReport($"Pizza cooked");
                        
                    }
                    catch (Exception exception)
                    {
                        WriteException(exception);
                    }
                    
                }

            }
            catch (Exception exception)
            {
                WriteException(exception);                
            }
            finally
            {
                EndProcess();
            }            

        }

        public void Bake(IPizza pizza)
        {            
            System.Threading.Thread.Sleep(pizza.GetCookTime());
        }

        
        private IPizza SelectPizzaBase()
        {
            IPizza freshPizza;
            int pizzaBaseKey = RandomHelper.RandomNumber(1, 3);
            switch (pizzaBaseKey)
            {
                case 1:
                    freshPizza = _pizzaFactory.MakeDeepPanPizza();
                    break;
                case 2:
                    freshPizza = _pizzaFactory.MakeStuffedCrustPizza();
                    break;
                case 3:
                    freshPizza = _pizzaFactory.MakeThinAndCrispyPizza();
                    break;
                default:
                    throw new IndexOutOfRangeException($"This pizza base not exists");

            }
            return freshPizza;
        }

        private List<ITop> SelectPizzaTops()
        {
            List<ITop> tops = new List<ITop>();
            var addNumTops = RandomHelper.RandomNumber(1, _settings.GeneralSettings.MaxNumTops);
            for (int i = 0; i < addNumTops; i++)
            {
                int topKey = RandomHelper.RandomNumber(1, 3);
                switch (topKey)
                {
                    case 1:
                        tops.Add(_pizzaTopFactory.GetPeperoniTop());
                        break;
                    case 2:
                        tops.Add(_pizzaTopFactory.GetHamMushroomsTop());
                        break;
                    case 3:
                        tops.Add(_pizzaTopFactory.GetVegetableTop());
                        break;
                    default:
                        throw new IndexOutOfRangeException($"This pizza top not exists");

                }
            }
            return tops;

        }

        public void EndProcess()
        {
            WriteReport("");
            WriteReport("-- End process --");
        }

        private void ResetFileReports()
        {
            File.WriteAllText(".\\PizzaFactoryReport.txt", string.Empty);
            File.WriteAllText(".\\PizzaFactoryErrorReport.txt", string.Empty);
        }
        private void WriteReport(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            using (var sw = new StreamWriter(".\\PizzaFactoryReport.txt", true))
            {
                sw.WriteLine(message);
            }            
        }

        private void WriteException(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception.Message);
            using (var sw = new StreamWriter(".\\PizzaFactoryErrorReport.txt", true))
            {
                sw.WriteLine(exception.Message);
            }
            
        }

        public int NumPizzasTarget()
        {
            return _settings.GeneralSettings.NumTargetPizzas;
        }

        private int GetRandomIntFromRange(int minRangeValue, int maxRangeValue)
        {
            Random r = new Random();
            return r.Next(minRangeValue, maxRangeValue + 1); 
        }

    }
}
