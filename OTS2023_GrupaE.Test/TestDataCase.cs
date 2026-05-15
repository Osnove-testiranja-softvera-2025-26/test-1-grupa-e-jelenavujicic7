using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2026_GrupaE.Test
{
    internal class TestDataCase
    {
        public static IEnumerable MoveUp_SuccessfulMove_PlayerPositionChanged_TestData
        {
            get
            {
                yield return new TestCaseData(5, 15, 2, 14);
                yield return new TestCaseData(5, 14, 2, 13);
                yield return new TestCaseData(5, 13, 2, 12);

            }
        }
    }
}
