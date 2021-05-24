using System;
using System.Timers;
using System.Collections.Generic;

namespace Behavioral
{
    // Push Implementation

    public interface Display
    {
        void display();
    }
    public interface Observer
    {
        void update(Object data);
    }
    public interface Subject
    {
        void addObserver(Observer observer);
        void removeObserver(Observer observer);
        void notifyObservers(Object data);
    }

    public class Data
    {
        public decimal temperature { get; set; }
        public decimal humidity { get; set; }
        public decimal pressure { get; set; }

        public Data(decimal temp, decimal humidity, decimal pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            this.pressure = pressure;
        }
    }

    public class WeatherData : Subject
    {
        public List<Observer> observers { get; set; }
        public decimal temperature { get; set; }
        public decimal humidity { get; set; }
        public decimal pressure { get; set; }

        public WeatherData()
        {
            this.observers = new List<Observer>();
            temperature = 0;
            humidity = 0;
            pressure = 0;
        }

        public void addObserver(Observer observer)
        {
            this.observers.Add(observer);
        }
        public void removeObserver(Observer observer)
        {
            this.observers.Remove(observer);
        }
        public void notifyObservers(Object data)
        {
            observers.ForEach(Observer =>
            {
                Observer.update(data);
            });
        }

        public void setMeasurements(decimal temp, decimal humidity, decimal pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            this.pressure = pressure;
            Data data = new Data(this.temperature, this.humidity, this.pressure);
            this.notifyObservers(data);
        }

    }

    public class CurrentCondtions : Observer, Display
    {
        public Subject subject { get; set; }
        public decimal temperature { get; set; }
        public decimal humidity { get; set; }
        public decimal pressure { get; set; }
        public CurrentCondtions(Subject subject)
        {
            this.subject = subject;
            subject.addObserver(this);
        }
        public void update(Object data)
        {
            // update the props
            Data weatherData = (Data)data;
            this.temperature = weatherData.temperature;
            this.humidity = weatherData.humidity;
            this.pressure = weatherData.pressure;
            this.display();
        }
        public void display()
        {
            Console.WriteLine($"This is Current Conditions Display --- Temperature - {this.temperature}  Humidity - {this.humidity}  Pressure - {this.pressure}");
        }
    }

    public class StatisticsDisplay : Observer, Display
    {
        public Subject subject { get; set; }
        public decimal temperature { get; set; }
        public decimal humidity { get; set; }
        public decimal pressure { get; set; }
        public StatisticsDisplay(Subject subject)
        {
            this.subject = subject;
            subject.addObserver(this);
        }
        public void update(Object data)
        {
            // update the props
            Data weatherData = (Data)data;
            this.temperature = weatherData.temperature;
            this.humidity = weatherData.humidity;
            this.pressure = weatherData.pressure;
            this.display();
        }
        public void display()
        {
            Console.WriteLine($"This is Statistics Display --- Temperature - {this.temperature}  Humidity - {this.humidity}  Pressure - {this.pressure}");
        }
    }

    public class ForecastDisplay : Observer, Display
    {
        public Subject subject { get; set; }
        public decimal temperature { get; set; }
        public decimal humidity { get; set; }
        public decimal pressure { get; set; }
        public ForecastDisplay(Subject subject)
        {
            this.subject = subject;
            subject.addObserver(this);
        }
        public void update(Object data)
        {
            // update the props
            Data weatherData = (Data)data;
            this.temperature = weatherData.temperature;
            this.humidity = weatherData.humidity;
            this.pressure = weatherData.pressure;
            this.display();
        }
        public void display()
        {
            Console.WriteLine($"This is Forecast Display --- Temperature - {this.temperature}  Humidity - {this.humidity}  Pressure - {this.pressure}");
        }
    }


    // Pull Implementation
    /*
    public interface Display
    {
        void display();
    }
    public interface Observer
    {
        void update(Subject subject);
    }
    public interface Subject
    {
        void addObserver(Observer observer);
        void removeObserver(Observer observer);
        void notifyObservers();
    }

    public class WeatherData : Subject
    {
        public List<Observer> observers { get; set; }
        public decimal temperature { get; set; }
        public decimal humidity { get; set; }
        public decimal pressure { get; set; }

        public WeatherData()
        {
            this.observers = new List<Observer>();
            temperature = 0;
            humidity = 0;
            pressure = 0;
        }

        public void addObserver(Observer observer)
        {
            this.observers.Add(observer);
        }
        public void removeObserver(Observer observer)
        {
            this.observers.Remove(observer);
        }
        public void notifyObservers()
        {
            observers.ForEach(Observer =>
            {
                Observer.update(this);
            });
        }

        public void setMeasurements(decimal temp, decimal humidity, decimal pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            this.pressure = pressure;
            this.notifyObservers();
        }

    }

    public class CurrentCondtions : Observer, Display
    {
        public Subject subject { get; set; }
        public decimal temperature { get; set; }
        public decimal humidity { get; set; }
        public decimal pressure { get; set; }
        public CurrentCondtions(Subject subject)
        {
            this.subject = subject;
            subject.addObserver(this);
        }
        public void update(Subject subject)
        {
            // update the props
            dynamic data = null;
            if (subject is WeatherData)
            {
                data = (WeatherData)subject;
            }
            this.temperature = data.temperature;
            this.humidity = data.humidity;
            this.pressure = data.pressure;
            this.display();
        }
        public void display()
        {
            Console.WriteLine($"This is Current Conditions Display --- Temperature - {this.temperature}  Humidity - {this.humidity}  Pressure - {this.pressure}");
        }
    }

    public class StatisticsDisplay : Observer, Display
    {
        public Subject subject { get; set; }
        public decimal temperature { get; set; }
        public decimal humidity { get; set; }
        public decimal pressure { get; set; }
        public StatisticsDisplay(Subject subject)
        {
            this.subject = subject;
            subject.addObserver(this);
        }
        public void update(Subject subject)
        {
            // update the props
            dynamic data = null;
            if (subject is WeatherData)
            {
                data = (WeatherData)subject;
            }
            this.temperature = data.temperature;
            this.humidity = data.humidity;
            this.pressure = data.pressure;
            this.display();
        }
        public void display()
        {
            Console.WriteLine($"This is Statistics Display --- Temperature - {this.temperature}  Humidity - {this.humidity}  Pressure - {this.pressure}");
        }
    }

    public class ForecastDisplay : Observer, Display
    {
        public Subject subject { get; set; }
        public decimal temperature { get; set; }
        public decimal humidity { get; set; }
        public decimal pressure { get; set; }
        public ForecastDisplay(Subject subject)
        {
            this.subject = subject;
            subject.addObserver(this);
        }
        public void update(Subject subject)
        {
            // update the props
            dynamic data = null;
            if (subject is WeatherData)
            {
                data = (WeatherData)subject;
            }
            this.temperature = data.temperature;
            this.humidity = data.humidity;
            this.pressure = data.pressure;
            this.display();
        }
        public void display()
        {
            Console.WriteLine($"This is Forecast Display --- Temperature - {this.temperature}  Humidity - {this.humidity}  Pressure - {this.pressure}");
        }
    }
    */
    public class ObserverTest
    {
        public static WeatherData weatherData = null;
        public static void Test()
        {
            weatherData = new WeatherData();
            Display currentConditionsDisplay = new CurrentCondtions(weatherData);
            Display statisticsDisplay = new StatisticsDisplay(weatherData);
            Display forecastDisplay = new ForecastDisplay(weatherData);

            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Elapsed += OnTimeElapsed;
            timer.AutoReset = true;
            timer.Enabled = true;

            Console.WriteLine("Press the Enter key to exit anytime... ");
            Console.ReadLine();

            // Releasing Timer resources once done
            timer.Stop();
            timer.Dispose();
        }

        public static void OnTimeElapsed(object source, ElapsedEventArgs e)
        {
            var random = new Random(100);
            weatherData.setMeasurements(Convert.ToDecimal(random.NextDouble() * 100), Convert.ToDecimal(random.NextDouble() * 100), Convert.ToDecimal(random.NextDouble() * 100));
        }
    }

}