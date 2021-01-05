using System;
using System.Collections.Generic;
using System.Text;

namespace Tatres
{
    class Field
    {
        bool[,] field;

        public int SizeX { get => field.GetLength(0); }

        public int SizeY { get => field.GetLength(1); }

        public bool this [int i, int j]
        {
            get => field[i, j];
            set => field[i, j] = value;
        }

        public Field(int width, int height)
        {
            field = new bool[width, height];
        }

        public int GetTopPointByX(int x)
        {
            int result = 0;
            while (result < this.SizeY && !field[x, result])
            {
                result++;
            }
            return result;
        }

        public void Update()
        {
            var current = Game.TetraminoSet.GetCurrent();
            for (int i = 0; i < current.SizeX; i++)
            {
                for (int j = 0; j < current.SizeY; j++)
                {
                    if (current[i, j])
                    {
                        int x = current.Point.X + i;
                        int y = current.Point.Y + j;
                        if (x < SizeX && y < SizeY)
                        {
                            field[x, y] = true;
                            if (y == 0)
                            {
                                Game.isGameOver = true;
                            }
                        }
                    }
                }
            }
        }

        public bool Check()
        {
            bool result = false;
            var current = Game.TetraminoSet.GetCurrent();

            for (int i = 0; i < current.SizeX; i++)
            {
                for (int j = 0; j < current.SizeY; j++)
                {
                    if (current[i, j])
                    {
                        int x = current.Point.X + i;
                        int y = current.Point.Y + j + 1;
                        if (x < SizeX && y < SizeY)
                        {
                            if (field[x,y] || y+1 == SizeY)
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }

            return result;
        }

        /**
         * Проверяет, есть ли на поле заполненные линии
         * Возвращает число полных линий
         */
        public int CheckLines()
        {
            int linesCount = 0;
            for (int i = 0; i < SizeY; i++)
            {
                bool lineCheckValue = true;
                for (int j = 0; j < SizeX; j++)
                {
                    lineCheckValue &= field[j, i];
                }
                if (lineCheckValue)
                {
                    linesCount++;
                }
            }
            return linesCount;
        }

        public void Reset()
        {
            Array.Clear(field, 0, field.Length);
        }
    }
}
