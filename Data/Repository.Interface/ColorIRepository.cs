using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
     public interface ColorIRepository : GenericIRepository<Color>
    {
        Task<Color> GetColorByName(string label);
    }
}
