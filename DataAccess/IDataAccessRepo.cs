using MVPPatternModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataAccessRepo
    {
        IEnumerable<Product> SelectAll();
        Product Select(int id);
    }
}
