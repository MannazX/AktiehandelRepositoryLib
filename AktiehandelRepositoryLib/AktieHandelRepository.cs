using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktiehandelRepositoryLib
{
	public class AktieHandelRepository
	{
		private List<AktieHandel> _handelList;
		private int _nextId;

        /// <summary>
        /// 
        /// </summary>
        public AktieHandelRepository()
        {
            _handelList = new List<AktieHandel>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AktieHandel> GetAll()
        {
            return _handelList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ah"></param>
        public void Add(AktieHandel ah)
        {
            _handelList.Add(ah);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            AktieHandel found = GetById(id);
            if (found != null)
            {
                _handelList.Remove(found);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
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
