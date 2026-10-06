using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    public interface IAssegnabile
    {
        void AssegnaCantiere(int cantiere);
        void LiberaCantiere();
    }
}
