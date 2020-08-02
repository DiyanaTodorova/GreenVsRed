using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed
{
    public  class Cell: ICell
    {
        private bool value;
        private int xIndex;
        private int yIndex;
        

        public Cell(bool value,int x, int y)
        {
            this.Value = value;
            this.XIndex = xIndex;
            this.YIndex = yIndex;
        }

        public bool Value
        {
            get
            {
                return this.value;
            }
             set
            {
                this.value = value;
            }
        }
        public int XIndex
        {
            get
            {
                return this.xIndex; 
            }
             private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("X index cannot be negative!");
                }
                this.xIndex = value;
            }
        }

        public int YIndex
        {
            get
            {
                return this.yIndex;
            }
             private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Y index cannot be negative!");
                }
                this.yIndex = value;
            }
        }

        
        
    }
}
