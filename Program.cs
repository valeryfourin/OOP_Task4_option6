using System;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace taskFourTriangles
{


     class Point
    {
        private double x, y, z;

        public double X
        {
            set
            {
                x = value;
            }
            get { return x; }
        }
        public double Y
        {
            set
            {
                y = value;
            }
            get { return y; }
        }
        public double Z
        {
            set
            {
                z = value;
            }
            get { return z; }
        }

        public string DisplayPointCoordinates(double x, double y, double z)
        {
            return $"( {x}; {y}; {z})";
        }

        private double area, perim, xy, yz, xz, halfperim, r, R;

        public double sideLength(Point point1, Point point2) // метод для розрахунку сторони трикутника
        {
            double side = Math.Sqrt(Math.Pow(point2.x - point1.x, 2) + Math.Pow(point2.y - point1.y, 2) + Math.Pow(point2.z - point1.z, 2));
            return side;
        }

        public double HalfPerim(Point point1, Point point2, Point point3) // метод для розрахунку півпериметру трикутника
        {
            halfperim = (sideLength(point1, point2) + sideLength(point2, point3) + sideLength(point1, point3)) / 2;
            return halfperim;

        }
        

        public double TriangleArea(Point point1, Point point2, Point point3) // метод для розрахунку площі трикутника
        {
            xy = sideLength(point1, point2);
            yz = sideLength(point2, point3);
            xz = sideLength(point1, point3);
            halfperim = HalfPerim(point1, point2, point3);
            area = Math.Sqrt(halfperim * (halfperim - xy)*(halfperim - yz)*(halfperim - xz));
            return area;
        }

        public double TrianglePerim(Point point1, Point point2, Point point3) // метод для розрахунку периметру трикутника
        {
            xy = sideLength(point1, point2);
            yz = sideLength(point2, point3);
            xz = sideLength(point1, point3);
            perim = xy + yz + xz;
            return perim;
        }

        public double InscribedRadius(Point point1, Point point2, Point point3) // метод для розрахунку радіусу вписаного у трикутника кола
        {
            xy = sideLength(point1, point2);
            yz = sideLength(point2, point3);
            xz = sideLength(point1, point3);
            halfperim = HalfPerim(point1, point2, point3);
            r = Math.Sqrt(((halfperim - xy) * (halfperim - yz) * (halfperim - xz)) /halfperim);
            return r;

        }

        public double CircumscribedRadius(Point point1, Point point2, Point point3) // метод для розрахунку радіусу описаного навколо трикутника кола
        {
            xy = sideLength(point1, point2);
            yz = sideLength(point2, point3);
            xz = sideLength(point1, point3);
            area = TriangleArea(point1, point2, point3);
            R = (xy * yz * xz) / (4 * area);
            return R;
        }

        public void Read(StreamReader stream)   // метод для зчитування даних з файлу
        {
            X = Convert.ToDouble(stream.ReadLine());
            Y = Convert.ToDouble(stream.ReadLine());
            Z = Convert.ToDouble(stream.ReadLine());
        }

        public void Write(StreamWriter stream)  // метод для записування даних у файл
        {
            stream.WriteLine(X);
            stream.WriteLine(Y);
            stream.WriteLine(Z);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            while (true) {


                Console.WriteLine("If you want to input data write '1'," +
                    "If you want to read data from file write '2': ");

                string answer = Console.ReadLine();
                Point pointA = new Point();
                Point pointB = new Point();
                Point pointC = new Point();

                if (answer == "1") // вивід з клавіатури
                {
                    bool flag1 = true;
                    bool flag2 = true;
                    bool flag3 = true;
                    bool flag4 = true;
                    bool flag5 = true;
                    bool flag6 = true;
                    bool flag7 = true;
                    bool flag8 = true;
                    bool flag9 = true;

                    // вводимо координати для точки А з перевірками

                    while (flag1 == true)
                    {
                        try
                        {
                            flag1 = false;
                            Console.WriteLine("Please input an abscissa of A: ");
                            pointA.X = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            flag1 = true;
                            Console.WriteLine("Error. Input appropriate data type!");
                            continue;
                        }

                    }

                    while (flag2 == true)
                    {
                        try
                        {
                            flag2 = false;
                            Console.WriteLine("Please input an ordinata of A: ");
                            pointA.Y = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            flag2 = true;
                            Console.WriteLine("Error. Input appropriate data type!");
                            continue;
                        }

                    }

                    while (flag3 == true)
                    {
                        try
                        {
                            flag3 = false;
                            Console.WriteLine("Please input an applicata of A: ");
                            pointA.Z = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            flag3 = true;
                            Console.WriteLine("Error. Input appropriate data type!");
                            continue;
                        }

                    }

                    Console.WriteLine($"Coordinates of A: {pointA.DisplayPointCoordinates(pointA.X, pointA.Y, pointA.Z)}");


                    // вводимо координати для точки B з перевірками

                    while (flag4 == true)
                    {
                        try
                        {
                            flag4 = false;
                            Console.WriteLine("\nPlease input an abscissa of B: ");
                            pointB.X = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            flag4 = true;
                            Console.WriteLine("Error. Input appropriate data type!");
                            continue;
                        }

                    }

                    while (flag5 == true)
                    {
                        try
                        {
                            flag5 = false;
                            Console.WriteLine("Please input an ordinata of B: ");
                            pointB.Y = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            flag5 = true;
                            Console.WriteLine("Error. Input appropriate data type!");
                            continue;
                        }

                    }

                    while (flag6 == true)
                    {
                        try
                        {
                            flag6 = false;
                            Console.WriteLine("Please input an applicata of B: ");
                            pointB.Z = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            flag6 = true;
                            Console.WriteLine("Error. Input appropriate data type!");
                            continue;
                        }

                    }

                    Console.WriteLine($"Coordinates of B: {pointB.DisplayPointCoordinates(pointB.X, pointB.Y, pointB.Z)}");


                    // вводимо координати для точки C з перевірками

                    while (flag7 == true)
                    {
                        try
                        {
                            flag7 = false;
                            Console.WriteLine("\nPlease input an abscissa of C: ");
                            pointC.X = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            flag7 = true;
                            Console.WriteLine("Error. Input appropriate data type!");
                            continue;
                        }

                    }

                    while (flag8 == true)
                    {
                        try
                        {
                            flag8 = false;
                            Console.WriteLine("Please input an ordinata of C: ");
                            pointC.Y = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            flag8 = true;
                            Console.WriteLine("Error. Input appropriate data type!");
                            continue;
                        }

                    }

                    while (flag9 == true)
                    {
                        try
                        {
                            flag9 = false;
                            Console.WriteLine("Please input an applicata of C: ");
                            pointC.Z = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            flag9 = true;
                            Console.WriteLine("Error. Input appropriate data type!");
                            continue;
                        }

                    }

                    Console.WriteLine($"Coordinates of C: {pointC.DisplayPointCoordinates(pointC.X, pointC.Y, pointC.Z)}");

                    // демонстрація основних методів класу Point

                    double area = pointA.TriangleArea(pointA, pointB, pointC);
                    Console.WriteLine($"Area of triangle ABC is {area}");

                    double perim = pointA.TrianglePerim(pointA, pointB, pointC);
                    Console.WriteLine($"Perimeter of triangle ABC is {perim}");

                    double r = pointA.InscribedRadius(pointA, pointB, pointC);
                    Console.WriteLine($"The radius of a circle inscribed in a triangle ABC is {r}");

                    double R = pointA.CircumscribedRadius(pointA, pointB, pointC);
                    Console.WriteLine($"The radius of the circle described around the triangle ABC is {R}");

                    break;

                }
                else if (answer == "2") // вивід з файлу
                {
                    //Console.WriteLine("Please enter the name of the source file: ");
                    //string fileName = Console.ReadLine();

                    StreamReader sr = new StreamReader(@"E:\university\ооп\taskFourTriangles\bin\Debug\netcoreapp3.1\coordinates_read.txt");
                    StreamWriter sw = new StreamWriter(@"E:\university\ооп\taskFourTriangles\bin\Debug\netcoreapp3.1\coordinates_write.txt"); 

                    pointA.Read(sr);
                    sw.WriteLine($"Coordinates of A: {pointA.DisplayPointCoordinates(pointA.X, pointA.Y, pointA.Z)}");

                    pointB.Read(sr);
                    sw.WriteLine($"Coordinates of B: {pointB.DisplayPointCoordinates(pointB.X, pointB.Y, pointB.Z)}");

                    pointC.Read(sr);
                    sw.WriteLine($"Coordinates of C: {pointC.DisplayPointCoordinates(pointC.X, pointC.Y, pointC.Z)}");

                    double area = pointA.TriangleArea(pointA, pointB, pointC);
                    sw.WriteLine($"Area of triangle ABC is {area}");

                    double perim = pointA.TrianglePerim(pointA, pointB, pointC);
                    sw.WriteLine($"Perimeter of triangle ABC is {perim}");

                    double r = pointA.InscribedRadius(pointA, pointB, pointC);
                    sw.WriteLine($"The radius of a circle inscribed in a triangle ABC is {r}");

                    double R = pointA.CircumscribedRadius(pointA, pointB, pointC);
                    sw.WriteLine($"The radius of the circle described around the triangle ABC is {R}");

                    Console.WriteLine("Done. Check the file.");

                    sr.Close();
                    sw.Close();

                    break;
                }
                else
                {
                    Console.WriteLine("Try again.");
                    continue;
                }
            }
        }
    }
}
