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
			AktieHandel item = null;
			foreach (AktieHandel ah in _handelList)
			{
				if (ah.HandelsId == id)
				{
					item = ah;
				}
			}
			return item;
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
			if (orderBy != null)
			{
				IEnumerable<AktieHandel> ahList = _handelList;
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

		public AktieHandel Add(AktieHandel ah)
		{
			_handelList.Add(ah);
			return ah;
		}

		public AktieHandel? Delete(int id)
		{
			AktieHandel found = GetById(id);
			if (found != null)
			{
				_handelList.Remove(found);
			}
			return found;
		}

		public AktieHandel Update(int id, AktieHandel data)
		{
			AktieHandel item = GetById(id);
			item.Navn = data.Navn;
			item.Antal = data.Antal;
			item.HandelsPris = data.HandelsPris;
			_handelList[_handelList.IndexOf(item)] = item;
			return item;
		}
	}
}
