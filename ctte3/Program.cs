using System;

namespace ctte3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var car1 = new Car("BMW", "Black");
            // var bus1 = new Bus{
            //     Color = "Yellow",
            //     Name = "School Bus"
            // };

            Console.WriteLine($"Car Info: {car1.brand}, {car1.color}");
            //Console.WriteLine($"Bus Info: {bus1.Name}, {bus1.Color}");

            var car2 = ("Honda", "Red"); // Unnamed tuple (item1, item2)
            Console.WriteLine($"Car Info: {car2.Item1}, {car2.Item2}");

            var bus2 = (Name: "Public Transport bus", Color: "Red"); // Name tuple 
            Console.WriteLine($"Bus Info: {bus2.Name}, {bus2.Color}");

            var coordinate1 = (x: 1, y: 1);
            var coordinate2 = (x: 1, y: 1);

            var isEqual = coordinate1 == coordinate2;

            Console.WriteLine($"Is Coordinate 1 = Coordinate 2 ? {isEqual}");


            var busA = new Bus("School Bus", "Yellow");
            var busB = new Bus("School Bus", "Yellow");
            var busC = new Bus("Public Transport", "Red");
            Bus busD = null;

            Console.WriteLine($"busA.Equals(busB): {busA.Equals(busB)}");
            Console.WriteLine($"busA == busB : {busA == busB}");
            Console.WriteLine($"busA.Equals(busD) {busA.Equals(busD)}");
            Console.WriteLine($"busA.Equals(busC): {busA.Equals(busC)}");
            Console.WriteLine($"busA == busC : {busA == busC}");


            if(busA.Color == busB.Color 
                    && busA.Name == busB.Name)
            {

            }
        }

        record Car (string brand, string color);

        // bus1.Equal(bus2);
        class Bus : IEquatable<Bus> {
            public string Name { get; private set; } // init
            public string Color { get; private set; } // init

            public Bus(string name, string color)
            {
                if(string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Bus must have a name");
                }
                
                Name = name;
                Color = color;
            }

            public override bool Equals(object obj) => this.Equals(obj as Bus);

            public bool Equals(Bus b)
            {
                if(b is null)
                {
                    return false;  
                }

                if(Object.ReferenceEquals(this, b))
                {
                    return true;
                }

                if(this.GetType() != b.GetType())
                {
                    return false;
                }

                return (Name == b.Name) && (Color == b.Color);
            }

            public static bool operator == (Bus b1, Bus b2)
            {
                if(b1 is null)
                {
                    if(b2 is null)
                    {
                        return true;
                    }

                    return false;
                }

                return b1.Equals(b2);
            }

            public static bool operator !=(Bus b1, Bus b2) => !(b1 == b2);
        }
    }

    
}
