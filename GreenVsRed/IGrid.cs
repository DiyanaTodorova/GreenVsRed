using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed
{
    interface IGrid
    {

        int Rows { get;}
        int Cols { get;  }
        Cell[,] Values { get; }

        void FillCell(bool value, int row, int col);
        void GenerateNextGeneration();
        


    }
}
