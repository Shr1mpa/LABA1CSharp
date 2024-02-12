using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LABA1.Classes
{
    public interface IRepository <T>
    {
        void save(T student, String fileName);
        void load(String fileName);
    }
}
