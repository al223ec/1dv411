using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public class DiagramService : IDiagramService
    {
        public IEnumerable<DiagramData> GetDiagramData(string query)
        {

            return new List<DiagramData>{
                new DiagramData{
                    Data = "test"
                },
            };
        }

        #region IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                   // _unitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
