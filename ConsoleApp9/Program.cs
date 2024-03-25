using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp9.Program.MorseCodeConverter;

namespace ConsoleApp9
{
    internal class Program
    {
        public class City
        {
            private int population;

            public int Population
            {
                get { return population; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Некорректное значение для количества жителей.");
                    population = value;
                }
            }

            public City(int population)
            {
                Population = population;
            }

            public static City operator +(City city, int increase)
            {
                return new City(city.Population + increase);
            }

            public static City operator -(City city, int decrease)
            {
                int newPopulation = city.Population - decrease;
                if (newPopulation < 0)
                    newPopulation = 0;
                return new City(newPopulation);
            }

            public static bool operator ==(City city1, City city2)
            {
                if (ReferenceEquals(city1, null) && ReferenceEquals(city2, null))
                    return true;
                if (ReferenceEquals(city1, null) || ReferenceEquals(city2, null))
                    return false;
                return city1.Population == city2.Population;
            }

            public static bool operator !=(City city1, City city2)
            {
                return !(city1 == city2);
            }

            public static bool operator <(City city1, City city2)
            {
                return city1.Population < city2.Population;
            }

            public static bool operator >(City city1, City city2)
            {
                return city1.Population > city2.Population;
            }

            public override bool Equals(object obj)
            {
                City other = obj as City;
                return other != null && Population == other.Population;
            }

            public override int GetHashCode()
            {
                return Population.GetHashCode();
            }
        }
        public class MorseCodeConverter
        {
            private Dictionary<char, string> morseCodeDictionary;

            public MorseCodeConverter()
            {
                InitializeMorseCodeDictionary();
            }

            public string ConvertToMorseCode(string text)
            {
                StringBuilder morseCode = new StringBuilder();

                foreach (char character in text.ToLower())
                {
                    if (morseCodeDictionary.ContainsKey(character))
                    {
                        string morseSymbol = morseCodeDictionary[character];
                        morseCode.Append(morseSymbol + " ");
                    }
                    else
                    {
                        morseCode.Append("  "); // Двойной пробел для обозначения пробела между словами
                    }
                }

                return morseCode.ToString().Trim();
            }

            private void InitializeMorseCodeDictionary()
            {
                morseCodeDictionary = new Dictionary<char, string>()
        {
            {'a', ".-"},
            {'b', "-..."},
            {'c', "-.-."},
            {'d', "-.."},
            {'e', "."},
            {'f', "..-."},
            {'g', "--."},
            {'h', "...."},
            {'i', ".."},
            {'j', ".---"},
            {'k', "-.-"},
            {'l', ".-.."},
            {'m', "--"},
            {'n', "-."},
            {'o', "---"},
            {'p', ".--."},
            {'q', "--.-"},
            {'r', ".-."},
            {'s', "..."},
            {'t', "-"},
            {'u', "..-"},
            {'v', "...-"},
            {'w', ".--"},
            {'x', "-..-"},
            {'y', "-.--"},
            {'z', "--.."},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},
            {'0', "-----"},
            {' ', "  "}
        };
            }

            public class MusicalInstrument
            {
                protected string name;

                public MusicalInstrument(string name)
                {
                    this.name = name;
                }

                public virtual void Sound()
                {
                    Console.WriteLine($"Музыкальный инструмент {name} издает звук.");
                }

                public void Show()
                {
                    Console.WriteLine($"Название музыкального инструмента: {name}");
                }

                public virtual void Desc()
                {
                    Console.WriteLine($"Описание музыкального инструмента {name}.");
                }

                public virtual void History()
                {
                    Console.WriteLine($"Музыкальный инструмент {name} был создан в таком-то году.");
                }
            }

            public class Violin : MusicalInstrument
            {
                public Violin(string name) : base(name)
                {
                }

                public override void Sound()
                {
                    Console.WriteLine($"Скрипка {name} издает звук посредством скрежета смычка по струнам.");
                }

                public override void Desc()
                {
                    Console.WriteLine($"Скрипка {name} — струнный сочлененный смычковый музыкальный инструмент.");
                }

                public override void History()
                {
                    Console.WriteLine($"Скрипка {name} была создана в XVII веке.");
                }
            }

            public class Trombone : MusicalInstrument
            {
                public Trombone(string name) : base(name)
                {
                }

                public override void Sound()
                {
                    Console.WriteLine($"Тромбон {name} издает звук посредством резкого затягивания и раздвигания кулисы.");
                }

                public override void Desc()
                {
                    Console.WriteLine($"Тромбон {name} — медный духовой музыкальный инструмент с кулисой для регулировки высоты звука.");
                }

                public override void History()
                {
                    Console.WriteLine($"Тромбон {name} имеет длинную историю, которая начинается в XV веке.");
                }
            }

            public class Ukulele : MusicalInstrument
            {
                public Ukulele(string name) : base(name)
                {
                }

                public override void Sound()
                {
                    Console.WriteLine($"Укулеле {name} издает звук посредством перебора струн пальцами.");
                }

                public override void Desc()
                {
                    Console.WriteLine($"Укулеле {name} — струнный пластиковый или деревянный музыкальный инструмент.");
                }

                public override void History()
                {
                    Console.WriteLine($"Укулеле {name} является традиционным инструментом Гавайев.");
                }
            }

            public class Cello : MusicalInstrument
            {
                public Cello(string name) : base(name)
                {
                }

                public override void Sound()
                {
                    Console.WriteLine($"Виолончель {name} издает звук посредством смычка или перебора струн.");
                }

                public override void Desc()
                {
                    Console.WriteLine($"Виолончель {name} — струнный смычковый оркестровый музыкальный инструмент.");
                }

                public override void History()
                {
                    Console.WriteLine($"Виолончель {name} является одним из старейших инструментов и имеет длинную историю.");
                }
            }
        }
        static void Main(string[] args)
        {
            City city1 = new City(500000);
            City city2 = new City(700000);

            City city3 = city1 + 100000;
            City city4 = city2 - 200000;

            bool equal = city1 == city2;
            bool notEqual = city1 != city2;

            bool lessThan = city1 < city2;
            bool greaterThan = city2 > city3;

            bool equalsMethod = city1.Equals(city4);


            MorseCodeConverter converter = new MorseCodeConverter();

            Console.Write("Введите текст: ");
            string text = Console.ReadLine();

            string morseCode = converter.ConvertToMorseCode(text);
            Console.WriteLine($"Текст в азбуке Морзе: {morseCode}");


            MusicalInstrument instrument;

            instrument = new Violin("Страдивариус");
            instrument.Sound();
            instrument.Show();
            instrument.Desc();
            instrument.History();

            instrument = new Trombone("Слайд-тромбон");
            instrument.Sound();
            instrument.Show();
            instrument.Desc();
            instrument.History();

            instrument = new Ukulele("Классическое");
            instrument.Sound();
            instrument.Show();
            instrument.Desc();
            instrument.History();

            instrument = new Cello("Амати");
            instrument.Sound();
            instrument.Show();
            instrument.Desc();
            instrument.History();
        }
    }
}
