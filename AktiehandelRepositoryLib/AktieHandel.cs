using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace AktiehandelRepositoryLib
{
	public class AktieHandel
	{
		public int HandelsId { get; set; }
		public string Navn { get; set; }
		public int Antal { get; set; }
		public double HandelsPris { get; set; }

        public AktieHandel(int handelsID, string navn, int antal, double handelsPris)
        {
			if (navn == null)
			{
				throw new ArgumentException("Navn kan ikke være null");
			}
			else if (navn.Length < 4)
			{
				throw new ArgumentException("Navn kan ikke være midnre end fire tegn");
			}
			HandelsId = handelsID;
			Navn = navn;
			Antal = antal;
			HandelsPris = handelsPris;
        }
    }
}
