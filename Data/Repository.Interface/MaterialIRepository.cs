using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface MaterialIRepository : GenericIRepository<Material>
    {
        Task<Material> GetMaterialByName(string label);

    }
}
