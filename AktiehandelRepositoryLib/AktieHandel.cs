using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace AktiehandelRepositoryLib
{
	public class AktieHandel : IAktieHandel
	{
		private static int _counter = 0;
		private int _id;
		public int HandelsId { get { return _id; } }
		public string Navn { get; set; }
		public int Antal { get; set; }
		public double HandelsPris { get; set; }

		/// <summary>
		/// Constructor for AktieHandel Objects
		/// </summary>
		/// <param name="navn"></param>
		/// <param name="antal"></param>
		/// <param name="handelsPris"></param>
		/// <exception cref="ArgumentException"></exception>
		public AktieHandel(string navn, int antal, double handelsPris)
		{
			if (navn == null)
			{
				throw new ArgumentException("Navn kan ikke være null");
			}
			else if (navn.Length < 4)
			{
				throw new ArgumentException("Navn kan ikke være midnre end fire tegn");
			}
			_counter++;
			_id = _counter;
			Navn = navn;
			Antal = antal;
			HandelsPris = handelsPris;
		}

		public override string ToString()
		{
			return $"Navn: {Navn}\nAntal: {Antal}\nHandelspris: {HandelsPris}";
		}
	}
}
