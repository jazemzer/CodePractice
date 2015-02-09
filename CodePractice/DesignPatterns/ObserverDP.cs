using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DesignPatterns
{
    class ObserverDP
    {
        public static void Implementation()
        {

            #region Traditional

            CodePractice.DesignPatterns.Traditional.Client.MainFunc();

            /* Downsides
             *      1. Track Multiple subjects for each observer
             *          You will then have to pass the subject in the Update
             *      
             *      2. Tracking properties within a single subject separately
             *          Update would be triggered multiple times 
             *      
             *      3. Disposed subject/observer holding reference to another causing memory leak
             *      4. Unexpected updates - ripple effect
             */ 
            #endregion
        }
            
    
        
    }

    namespace Traditional
    {
        public class Client
        {
            public static void MainFunc()
            {
                var subject = new StockTicker();
                var google = new GoogleObserver(subject);
                var msft = new MSFTObserver(subject);

                var stocks = new List<Stock>
                {
                    new Stock{Name = "MSFT"},
                    new Stock{Name = "Google"},
                    new Stock{Name = "Google"},
                    new Stock{Name = "Google"}
                };

                foreach(var stock in stocks)
                {
                    subject.Stock = stock;
                }

            }
        }
        
        public abstract class AbstractSubject
        {
            protected List<AbstractObserver> Observers { get; set; }

            public AbstractSubject()
            {
                Observers = new List<AbstractObserver>();
            }

            public void Register(AbstractObserver observer)
            {
                Observers.Add(observer);
            }

            public void UnRegister(AbstractObserver observer)
            {
                Observers.Remove(observer);
            }

            public void Notify()
            {
                foreach(var observer in Observers)
                {
                    observer.Update();
                }
            }

        }

        public abstract class AbstractObserver
        {
            public abstract void Update();
        }

        public class Stock
        {
            public String Name { get; set; }
        }
        public class StockTicker : AbstractSubject
        {
            private Stock stock;
            public Stock Stock
            {
                get
                {
                    return stock;
                }
                set
                {
                    stock = value;
                    Notify();
                }
            }
        }

        public class GoogleObserver : AbstractObserver
        {
            // This cant go into Abstract Observer (as AbstractSubject) because then we would need casting before every use to access Stock
            private StockTicker _dataSource;


            public GoogleObserver(StockTicker subject)
            {
                _dataSource = subject;
                
                //Registering 
                _dataSource.Register(this);
            }

            public override void Update()
            {
                if(_dataSource.Stock.Name == "Google")
                {
                    Console.WriteLine(" In Google");
                }
            }
        }

        public class MSFTObserver : AbstractObserver
        {
            private StockTicker _dataSource;


            public MSFTObserver(StockTicker subject)
            {
                _dataSource = subject;

                //Registering 
                _dataSource.Register(this);
            }

            public override void Update()
            {
                if (_dataSource.Stock.Name == "MSFT")
                {
                    Console.WriteLine(" In Microsoft");
                }
            }
        }
    }
}
