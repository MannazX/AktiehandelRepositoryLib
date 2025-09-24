using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktiehandelRepositoryLib
{
	public class AktieHandelRepository : IAktieHandelRepository
	{
		private List<AktieHandel> _handelList;

		public AktieHandelRepository()
		{
			_handelList = new List<AktieHandel>();
		}

		public AktieHandel GetById(int id)
		{
			foreach (AktieHandel ah in _handelList)
			{
				if (ah.HandelsId == id)
				{
					return ah;
				}
			}
			return null;
		}

		public List<AktieHandel> GetAll()
		{
			return _handelList;
		}

		public IEnumerable<AktieHandel> GetByAntal(int? antal = null)
		{
			IEnumerable<AktieHandel> ahList = _handelList;
			
			if (antal != null)
			{
				ahList = ahList.Where(x => x.Antal > antal);
			}
			return ahList;
		}

		public IEnumerable<AktieHandel> GetOrderBy(string? orderBy = null)
		{
			IEnumerable<AktieHandel> ahList = _handelList;
			if (orderBy != null)
			{
				if (orderBy == "Navn")
				{
					ahList = ahList.OrderBy(x => x.Navn);
				}
				else if (orderBy == "Pris")
				{
					ahList = ahList.OrderBy(x => x.HandelsPris);
				}
				else
				{
					return null;
				}
				return ahList;
			}
			else
			{
				return null;
			}
		}

		public void Add(AktieHandel ah)
		{
			_handelList.Add(ah);
		}

		public void Delete(int id)
		{
			AktieHandel found = GetById(id);
			if (found != null)
			{
				_handelList.Remove(found);
			}
		}

		public void Update(int id, AktieHandel data)
		{
			foreach (AktieHandel ah in _handelList)
			{
				if (ah.HandelsId == id)
				{
					ah.Navn = data.Navn;
					ah.Antal = data.Antal;
					ah.HandelsPris = data.HandelsPris;
				}
			}
		}
	}
}
