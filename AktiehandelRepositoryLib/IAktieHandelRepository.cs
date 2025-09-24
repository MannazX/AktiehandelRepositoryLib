
namespace AktiehandelRepositoryLib
{
	public interface IAktieHandelRepository
	{
		void Add(AktieHandel ah);
		void Delete(int id);
		IEnumerable<AktieHandel> Get(int? antal = null, string? orderBy = null);
		IEnumerable<AktieHandel> GetOrderBy(string? orderBy);
		List<AktieHandel> GetAll();
		AktieHandel GetById(int id);
		void Update(int id, AktieHandel data);
	}
}