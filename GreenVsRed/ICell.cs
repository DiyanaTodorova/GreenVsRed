using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed
{
    interface ICell
    {
      bool Value { get;}
      int XIndex { get; }

      int YIndex { get; }
    }
}
