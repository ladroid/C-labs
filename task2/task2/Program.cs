using System;

namespace task2
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			Triangle tr = new Triangle ("Triangle", 18, 18, 36, 12, 23);
			Triangle tr1 = new Triangle ("Triangle", 18, 18, 36, 12, 23);
			Triangle tr2 = new Triangle ("Triangle", 18, 18, 36, 12, 23);

			Triangle[] arr = { tr, tr1, tr2 };
			Picture pic = new Picture (arr);
			pic.SumAllAreas ();
			//Console.WriteLine (pic.SumAllAreas);

			tr.CallTriangles ();
			tr.Perimeter ();
			tr.GetArea ();
		}
	}

	interface IShape
	{
		string GetName(string Name);
		double GetArea();
	}

	public class Triangle : IShape 
	{
		protected double side;
		protected double side2;
		protected double side3;
		protected double height;
		protected double radian;
		protected string name;
		protected double Area;

		public Triangle(string name, double side, double side2, double side3, double height, double radian)
		{
			if (side >= 0 && side2 >= 0 && side3 >= 0 && height >= 0) 
			{
				this.side = side;
				this.side2 = side2;
				this.side3 = side3;
				this.height = height;
				if (radian >= 0 && radian < 180) {
					this.radian = radian;
				} 
				else 
				{
					throw new Exception ("Critical error: Triangle is not exist");
				}
			} 
			else 
			{
				throw new Exception ("Critical error: Value can not be negative");
			}
		}
		public void CallTriangles()
		{
			if (side == side2 || side2 == side3 || side3 == side) {
				Console.WriteLine ("Isoscales Triangle");
				IsoscalesTriangle ist = new IsoscalesTriangle (name, side, side2, side3, height, radian);
				ist.Perimeters ();
				ist.GetAreas ();
				Console.WriteLine (ist.Perimeters ());
				Console.WriteLine (ist.GetAreas ());
			} 
			else if (side == side2 && side2 == side3 && side3 == side) {
				Console.WriteLine ("Equilateral Triangle");
				EquilateralTriangle eqt = new EquilateralTriangle (name, side, side2, side3, height, radian);
				eqt.Perimeters ();
				eqt.GetAreas ();
				Console.WriteLine (eqt.Perimeters ());
				Console.WriteLine (eqt.GetAreas ());
			} 
			else if(side3 == Math.Pow(side, 2.0) + Math.Pow(side2, 2.0)) {
				Console.WriteLine ("Right triangle");
				RightTriangle rgh = new RightTriangle (name, side, side2, side3, height, radian);
				rgh.Perimeters ();
				rgh.GetAreas ();
				Console.WriteLine (rgh.Perimeters ());
				Console.WriteLine (rgh.GetAreas ());
			}
			else 
			{
				Perimeter ();
				GetArea ();
				Console.WriteLine (Perimeter ());
				Console.WriteLine (GetArea ());
			}
		}
		public virtual string GetName(string Name)
		{
			return "Shape: " + Name;
		}
		public double GetArea()
		{
			double area = (side * height) / 2;
			return area;
		}
		public double Perimeter()
		{
			double P = side + side2 + side3;
			return P;
		}
		public double CountAreas()
		{
			Area += GetArea ();
			return Area;
		}
	}

	public class IsoscalesTriangle : Triangle
	{
		public IsoscalesTriangle(string name, double side, double side2, double side3, double height, double radian) : 
		base(name, side, side2, side3, height, radian) 
		{}
		public double GetAreas()
		{
			return base.GetArea ();
		}
		public double Perimeters()
		{
			return base.Perimeter ();
		}
		public double CountAreas()
		{
			return base.CountAreas ();
		}
	}

	public class EquilateralTriangle : Triangle
	{
		public EquilateralTriangle(string name, double side, double side2, double side3, double height, double radian) : 
		base(name, side, side2, side3, height, radian) 
		{}
		public double GetAreas()
		{
			return base.GetArea ();
		}
		public double Perimeters()
		{
			return base.Perimeter ();
		}
		public double CountAreas()
		{
			return base.CountAreas ();
		}
	}

	public class RightTriangle : Triangle
	{
		public RightTriangle(string name, double side, double side2, double side3, double height, double radian) : 
		base(name, side, side2, side3, height, radian) 
		{}
		public double GetAreas()
		{
			return base.GetArea ();
		}
		public double Perimeters()
		{
			return base.Perimeter ();
		}
		public double CountAreas()
		{
			return base.CountAreas ();
		}
	}

	public class Picture
	{
		private Triangle[] tring;
		private double tr;

		public Picture(Triangle[] tring)
		{
			if (tring.Length < 1) {
				throw new Exception ("Object of arrays are too less");
			} 
			else 
			{
				this.tring = tring;
			}
		}
		public void SumAllAreas()
		{
			foreach (Triangle triang in tring) 
			{
				triang.CountAreas ();
				tr = triang.CountAreas ();
			}
			Console.WriteLine (tr);
		}
	}
}
