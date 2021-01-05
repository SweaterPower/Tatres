using System;
using System.Collections.Generic;
using System.Text;

namespace Tatres
{
    enum TetraminoType
    {
        Stick,
        Box,
        SSnake,
        ZSnake,
        LShape,
        JShape,
        TShape
    }

    static class TetraminoStorage
    {
        static Dictionary<TetraminoType, TetraminoTemplateSet> storage = new Dictionary<TetraminoType, TetraminoTemplateSet>();

        public static TetraminoTemplateSet GetTemplateSet(TetraminoType type)
        {
            return storage[type];
        }

        public static void InitStorage()
        {
            //box (O-shape) tetramino template
            TetraminoTemplateSet boxSet = new TetraminoTemplateSet("Box");
            boxSet.AddTemplate(Direction.Up, new Tetramino(
                new bool[2,2]
                {
                    {true, true },
                    {true, true }
                }
                ));
            boxSet.AddTemplate(Direction.Left, new Tetramino(
                new bool[2, 2]
                {
                    {true, true },
                    {true, true }
                }
                ));
            boxSet.AddTemplate(Direction.Down, new Tetramino(
                new bool[2, 2]
                {
                    {true, true },
                    {true, true }
                }
                ));
            boxSet.AddTemplate(Direction.Right, new Tetramino(
                new bool[2, 2]
                {
                    {true, true },
                    {true, true }
                }
                ));
            storage.Add(TetraminoType.Box, boxSet);

            //stick (l-shape) tetramino template
            TetraminoTemplateSet stickSet = new TetraminoTemplateSet("Stick");
            stickSet.AddTemplate(Direction.Up, new Tetramino(
                new bool[1, 4]
                {
                    {true, true, true, true }
                }
                ));
            stickSet.AddTemplate(Direction.Left, new Tetramino(
                new bool[4, 1]
                {
                    {true },
                    {true },
                    {true },
                    {true },
                }
                ));
            stickSet.AddTemplate(Direction.Down, new Tetramino(
                new bool[1, 4]
                {
                    {true, true, true, true }
                }
                ));
            stickSet.AddTemplate(Direction.Right, new Tetramino(
                new bool[4, 1]
                {
                    {true },
                    {true },
                    {true },
                    {true },
                }
                ));
            storage.Add(TetraminoType.Stick, stickSet);

            //S-shape tetramino template
            TetraminoTemplateSet sSet = new TetraminoTemplateSet("S-Snake");
            sSet.AddTemplate(Direction.Up, new Tetramino(
                new bool[2,3]
                {
                    {false, true, true },
                    {true, true, false }
                }
                ));
            sSet.AddTemplate(Direction.Left, new Tetramino(
                new bool[3,2]
                {
                    {true, false },
                    {true, true },
                    {false, true }
                }
                ));
            sSet.AddTemplate(Direction.Down, new Tetramino(
                new bool[2, 3]
                {
                    {true, true, false },
                    {false, true, true }
                }
                ));
            sSet.AddTemplate(Direction.Right, new Tetramino(
                new bool[3, 2]
                {
                    {false, true },
                    {true, true },
                    {true, false }
                }
                ));
            storage.Add(TetraminoType.SSnake, sSet);

            //z-shape tetramino template
            TetraminoTemplateSet zSet = new TetraminoTemplateSet("Z-Snake");
            zSet.AddTemplate(Direction.Up, new Tetramino(
                new bool[3, 2]
                {
                    {false, true },
                    {true, true },
                    {true, false }
                }
                ));
            zSet.AddTemplate(Direction.Left, new Tetramino(
                new bool[2, 3]
                {
                    {true, true, false },
                    {false, true, true }
                }
                ));
            zSet.AddTemplate(Direction.Down, new Tetramino(
               new bool[2, 3]
                {
                    {false, true, true },
                    {true, true, false }
                }
                ));
            zSet.AddTemplate(Direction.Right, new Tetramino(
                new bool[3, 2]
                {
                    {true, false },
                    {true, true },
                    {false, true }
                }
                ));
            storage.Add(TetraminoType.ZSnake, zSet);

            //t-shape tetramino template
            TetraminoTemplateSet tSet = new TetraminoTemplateSet("T-Shape");
            tSet.AddTemplate(Direction.Up, new Tetramino(
                new bool[2,3]
                {
                    {false, true, false },
                    {true, true, true }
                }
                ));
            tSet.AddTemplate(Direction.Left, new Tetramino(
                new bool[3,2]
                {
                    {false, true },
                    {true, true },
                    {false, true }
                }
                ));
            tSet.AddTemplate(Direction.Down, new Tetramino(
                new bool[2, 3]
                {
                    {true, true, true },
                    {false, true, false }
                }
                ));
            tSet.AddTemplate(Direction.Right, new Tetramino(
                new bool[3, 2]
                {
                    {true, false },
                    {true, true },
                    {true, false }
                }
                ));
            storage.Add(TetraminoType.TShape, tSet);

            //L-shape tetramino template
            TetraminoTemplateSet lSet = new TetraminoTemplateSet("L-Hook");
            lSet.AddTemplate(Direction.Up, new Tetramino(
                new bool[3,2]
                {
                    {true, false },
                    {true, false },
                    {true, true }
                }
                ));
            lSet.AddTemplate(Direction.Left, new Tetramino(
                new bool[2,3]
                {
                    {false, false, true },
                    {true, true, true }
                }
                ));
            lSet.AddTemplate(Direction.Down, new Tetramino(
                new bool[3,2]
                {
                    {true, true },
                    {false, true },
                    {false, true }
                }
                ));
            lSet.AddTemplate(Direction.Right, new Tetramino(
                new bool[2,3]
                {
                    {true, true, true },
                    {true, false, false }
                }
                ));
            storage.Add(TetraminoType.LShape, lSet);

            //J-shape tetramino template
            TetraminoTemplateSet jSet = new TetraminoTemplateSet("J-Hook");
            jSet.AddTemplate(Direction.Up, new Tetramino(
                new bool[3, 2]
                {
                    {false, true },
                    {false, true },
                    {true, true }
                }
                ));
            jSet.AddTemplate(Direction.Left, new Tetramino(
                new bool[2, 3]
                {
                    {true, true, true },
                    {false, false, true }
                }
                ));
            jSet.AddTemplate(Direction.Down, new Tetramino(
                new bool[3, 2]
                {
                    {true, true },
                    {true, false },
                    {true, false }
                }
                ));
            jSet.AddTemplate(Direction.Right, new Tetramino(
                new bool[2, 3]
                {
                    {true, false, false },
                    {true, true, true }
                }
                ));
            storage.Add(TetraminoType.JShape, jSet);
        }
    }
}
