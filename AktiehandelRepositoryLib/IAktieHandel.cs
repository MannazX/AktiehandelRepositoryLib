namespace AktiehandelRepositoryLib
{
	public interface IAktieHandel
	{
		int Antal { get; set; }
		int HandelsId { get; }
		double HandelsPris { get; set; }
		string Navn { get; set; }
	}
}