using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Microsoft.Win32.SafeHandles;

namespace GreenVsRed
{
    public class Grid:IGrid
    {
        
        private int rows;
        private int cols;
        private List<Cell[,]> Generations;
        public int Rows
        {
            get
            {
                return this.rows;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rows cannot  be negative number!");
                }
                if(value>=1000)
                {
                    throw new ArgumentException("Rows cannot be more than 1000");
                }

                this.rows = value;
            }
        }
        public int Cols
        {
            get
            {
                return this.cols;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cols cannot  be negative number!");
                }
                if (value >= 1000)
                {
                    throw new ArgumentException("Cols cannot be more than 1000");
                }

                this.cols = value;
            }
        }
        public Cell[,] Values { get; private set; }
        

        public Grid(int rows, int cols)
        {
            this.Values = new Cell[rows, cols];
            this.Rows = rows;
            this.Cols = cols;
            this.Generations = new List<Cell[,]>();
        }

        public void  FillCell(bool value, int row, int col)
        {
            Values[row, col] = new Cell(value, row, col);
        }

        public void GenerateNextGeneration()
        {
            
            var temp = this.Values.Clone() as Cell[,];
           
            this.Generations.Add(temp);
            var newGen = new Cell[this.Rows,this.Cols];
            

            for(int row = 0; row < this.Rows; row++)
            {
                for(int col =0; col < this.Cols; col++)
                {
                    int greenNeighbors = CountGreenNeigbours(this.Values[row, col], row, col);
                    if (this.Values[row, col].Value)
                    {
                        
                        if(greenNeighbors != 2 && greenNeighbors !=3 && greenNeighbors != 6)
                        {
                            newGen[row, col]= new Cell(false, row, col) ;
                        }
                        else
                        {
                            newGen[row, col] = new Cell(true, row, col);
                        }
                       
                    }
                    else
                    {
                        int redNeighbors = CountGreenNeigbours(this.Values[row,col],row, col);

                        if(redNeighbors == 3 )
                        {
                            newGen[row, col]= new Cell( true, row, col);
                        }
                        else if(redNeighbors == 6)
                        {
                            newGen[row, col] = new Cell(true, row, col);
                        }
                        else
                        {
                            newGen[row, col] = new Cell(false, row, col);
                        }
                        
                    }


                }
            }

            this.Values = newGen.Clone() as Cell[,];
            

        }

        private int CountGreenNeigbours(Cell cell, int rowIndex, int colIndex)
        {
            int greenNeigbours = 0;
                        
            if(rowIndex-1>=0 )
            {
                // check if top left neighbor excist and if it is green 
                if (colIndex - 1 >= 0)
                {
                    if (this.Values[rowIndex - 1, colIndex - 1].Value)
                    {
                        greenNeigbours++;
                    }
                }

                // check if top right neighbor excist and if it is green 
                if (colIndex + 1 < this.Cols)
                {
                    if(this.Values[rowIndex-1, colIndex + 1].Value)
                    {
                        greenNeigbours++;
                    }
                }

                // check if top  neigbor excist and if it is green 
                if (this.Values[rowIndex-1, colIndex].Value)
                {
                    greenNeigbours++;
                }
            }

            
            if (rowIndex + 1 < this.Rows)
            {
                // check if bottom left neigbor excist and if it is green 
                if (colIndex - 1 >= 0)
                {
                    if(this.Values[rowIndex+1, colIndex - 1].Value)
                    {
                        greenNeigbours++;
                    }
                }

                // check if top right neigbor excist and if it is green 
                if (colIndex + 1 < this.Cols)
                {
                    if(this.Values[rowIndex+1, colIndex + 1].Value)
                    {
                        greenNeigbours++;
                    }
                }

                // check if bottom  neigbor excist and if it is green 
                if (this.Values[rowIndex+1, colIndex].Value)
                {
                    greenNeigbours++;
                }
            }

            // check if right neigbor excist and if it is green 
            if (colIndex + 1 < this.Cols)
            {
                if(this.Values[rowIndex, colIndex + 1].Value)
                {
                    greenNeigbours++;
                }
            }

            // check if  left neigbor excist and if it is green 
            if (colIndex - 1 >= 0)
            {
                if(this.Values[rowIndex, colIndex - 1].Value)
                {
                    greenNeigbours++;
                }
            }

            

            return greenNeigbours;
            

        }
    }
}
