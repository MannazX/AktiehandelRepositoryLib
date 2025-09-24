
namespace AktiehandelRepositoryLib
{
	public interface IAktieHandelRepository
	{
		void Add(AktieHandel ah);
		void Delete(int id);
		IEnumerable<AktieHandel> GetByAntal(int? antal = null);
		IEnumerable<AktieHandel> GetOrderBy(string? orderBy);
		List<AktieHandel> GetAll();
		AktieHandel GetById(int id);
		void Update(int id, AktieHandel data);
	}
}