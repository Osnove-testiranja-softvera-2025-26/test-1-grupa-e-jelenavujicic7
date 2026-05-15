using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2026_GrupaE.Exceptions
{
    public class InvalidPlayerPositionException: Exception
    {
        public InvalidPlayerPositionException()
        {

        }

        public InvalidPlayerPositionException(string message) : base(message)
        {

        }
    }
}
