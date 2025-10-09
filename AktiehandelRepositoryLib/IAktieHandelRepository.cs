
namespace AktiehandelRepositoryLib
{
	public interface IAktieHandelRepository
	{
		AktieHandel Add(AktieHandel ah);
		AktieHandel Delete(int id);
		IEnumerable<AktieHandel> GetByAntal(int? antal = null);
		IEnumerable<AktieHandel> GetOrderBy(string? orderBy);
		List<AktieHandel> GetAll();
		AktieHandel GetById(int id);
		AktieHandel Update(int id, AktieHandel data);
	}
}