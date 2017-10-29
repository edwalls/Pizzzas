using Pizzzas.Helpers;
using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pizzzas.Implementation
{
    /// <summary>
    /// Implementation of pizza store
    /// </summary>
    public class PizzzasStore : IPizzzasStore
    {
        private IPizzaFactorySettings _settings;
        private IPizzaFactory _pizzaFactory;
        private IPizzaTopFactory _pizzaTopFactory;

        /// <summary>
        /// Constuctor for Pizza Store
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="pizzaFactory"></param>
        /// <param name="pizzaTopFactory"></param>
        public PizzzasStore(IPizzaFactorySettings settings, IPizzaFactory pizzaFactory, IPizzaTopFactory pizzaTopFactory)
        {
            _settings = settings ?? throw new ArgumentException(string.Format($"{nameof(settings)} is null."));
            _pizzaFactory = pizzaFactory ?? throw new ArgumentException(string.Format($"{nameof(pizzaFactory)} is null.")); ;
            _pizzaTopFactory = pizzaTopFactory ?? throw new ArgumentException(string.Format($"{nameof(pizzaTopFactory)} is null.")); ;            
        }

        /// <summary>
        /// MNethod that simulates the create pizzas 
        /// </summary>
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

        /// <summary>
        /// Simulates the time of cooking 
        /// </summary>
        /// <param name="pizza"></param>
        public void Bake(IPizza pizza)
        {            
            System.Threading.Thread.Sleep(pizza.GetCookTime());
        }

        /// <summary>
        /// Method that returns ramdom pizza
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method that return aramdom list of tops
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Ends the process
        /// </summary>
        public void EndProcess()
        {
            WriteReport("");
            WriteReport("-- End process --");
        }

        /// <summary>
        /// Reset the output files for report
        /// </summary>
        private void ResetFileReports()
        {
            File.WriteAllText(".\\PizzaFactoryReport.txt", string.Empty);
            File.WriteAllText(".\\PizzaFactoryErrorReport.txt", string.Empty);
        }

        /// <summary>
        /// Method that writes the details of the pizza 
        /// </summary>
        /// <param name="message"></param>
        private void WriteReport(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            using (var sw = new StreamWriter(".\\PizzaFactoryReport.txt", true))
            {
                sw.WriteLine(message);
            }            
        }

        /// <summary>
        /// Method that write any exception to exception report file
        /// </summary>
        /// <param name="exception"></param>
        private void WriteException(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception.Message);
            using (var sw = new StreamWriter(".\\PizzaFactoryErrorReport.txt", true))
            {
                sw.WriteLine(exception.Message);
            }
            
        }

        /// <summary>
        /// Get the num of target pizzas
        /// </summary>
        /// <returns></returns>
        public int NumPizzasTarget()
        {
            return _settings.GeneralSettings.NumTargetPizzas;
        }

    }
}
