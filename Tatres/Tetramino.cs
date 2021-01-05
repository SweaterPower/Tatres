using System;
using System.Collections.Generic;
using System.Text;

namespace Tatres
{
    class Tetramino
    {
        bool[,] blockmap;

        public bool this[int i, int j]
        {
            get
            {
                if (i < blockmap.GetLength(0) && j < blockmap.GetLength(1))
                    return blockmap[i, j];
                else
                    return false;
            }
        }

        public int SizeX { get => blockmap.GetLength(0); }

        public int SizeY { get => blockmap.GetLength(1); }

        Point point;
        Point oldPoint;
        public Point Point { get => point;}
        public Point OldPoint { get => oldPoint; }

        public Tetramino(bool[,] blockmap)
        {
            this.blockmap = blockmap;
            point = new Point(0, 0);
            oldPoint = new Point(0, 0);
        }

        public void CopyBlockmap(ref bool[,] blockmap)
        {
            Array.Copy(this.blockmap, blockmap, this.blockmap.Length);
        }

        public void Rotate()
        {
            bool[,] oldArr = new bool[blockmap.GetLength(0), blockmap.GetLength(1)];
            Array.Copy(blockmap, oldArr, blockmap.Length);
            for (int i = 0; i < blockmap.GetLength(0); i++)
            {
                for (int j = 0; j < blockmap.GetLength(0); j++)
                    blockmap[i, j] = oldArr[j, i];
            }
        }

        public override string ToString()
        {
            if (this.blockmap.Length != 0)
            {
                string result = "";
                for (int i = 0; i < blockmap.GetLength(0); i++)
                {
                    for (int j = 0; j < blockmap.GetLength(0); j++)
                        result += this.blockmap[i, j] ? "1" : "0";
                    result += "\n\r";
                }
                return result;
            }
            return base.ToString();
        }

        public void SetPointXY(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Game.Field.SizeX && y < Game.Field.SizeY)
            {
                oldPoint.X = Point.X;
                oldPoint.Y = Point.Y;
                Point.X = x;
                Point.Y = y;
            }
        }

        public void SetPointX(int x)
        {
            if (x >= 0 && x < Game.Field.SizeX)
            {
                oldPoint.X = Point.X;
                Point.X = x;
            }
        }

        public void SetPointY(int y)
        {
            if (y >= 0 && y < Game.Field.SizeY)
            {
                oldPoint.Y = Point.Y;
                Point.Y = y;
            }
        }
    }
}
