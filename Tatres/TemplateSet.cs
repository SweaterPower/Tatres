using System;
using System.Collections.Generic;
using System.Text;

namespace Tatres
{
    enum Direction
    {
        Up,
        Left,
        Down,
        Right
    }

    class DirectionIterator
    {
        Direction direction = Direction.Up;
        int index = 0;
        int[] values = (int[])Enum.GetValues(typeof(Direction));

        public Direction Current { get => direction; }

        public Direction Iterate()
        {
            index++;
            if (index >= values.Length)
                index = 0;
            direction = (Direction)values[index];
            return direction;
        }

        public void Reset()
        {
            index = 0;
            direction = (Direction)values[index];
        }
    }

    class TetraminoTemplateSet
    {
        string name;
        DirectionIterator iterator;
        Dictionary<Direction, Tetramino> set;

        public TetraminoTemplateSet(string name)
        {
            this.name = name;
            iterator = new DirectionIterator();
            set = new Dictionary<Direction, Tetramino>();
        }

        public string Name { get => name; set => name = value; }

        public void AddTemplate(Direction direction, Tetramino tetramino)
        {
            set.Add(direction, tetramino);
        }

        public Tetramino GetCurrent()
        {
            return set[iterator.Current];
        }

        public Tetramino GetRotated()
        {
            Rotate();
            return set[iterator.Current];
        }

        public void Rotate()
        {
            iterator.Iterate();
        }

        public void Reset()
        {
            iterator.Reset();
            foreach (var template in set)
            {
                template.Value.SetPointXY(0, 0);
            }
        }
    }
}
