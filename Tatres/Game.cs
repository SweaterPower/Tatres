using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tatres
{
    static class Game
    {
        static int score = 0;
        static public bool isGameOver = false;
        static int gameDelay = 300;
        static Screen screen;
        static Field field;
        static Control control;
        static TetraminoTemplateSet tetraminoSet;
        static TetraminoTemplateSet nextTetraminoSet;
        static Random rnd;

        internal static TetraminoTemplateSet TetraminoSet { get => tetraminoSet; set => tetraminoSet = value; }
        internal static TetraminoTemplateSet NextTetraminoSet { get => nextTetraminoSet; set => nextTetraminoSet = value; }
        internal static Field Field { get => field; set => field = value; }
        internal static Screen Screen { get => screen; set => screen = value; }
        internal static Control Control { get => control; set => control = value; }

        public static void Init()
        {
            Screen = new Screen();
            Field = new Field(16,28);
            Control = new Control();
            rnd = new Random();
            TetraminoStorage.InitStorage();
            Reset();
        }

        public static void Reset()
        {
            score = 0;
            isGameOver = false;
            Screen.Reset();
            Field.Reset();
            StopControlThread();
            TetraminoSet = GetRandomTetraminoSet();
            NextTetraminoSet = GetRandomTetraminoSet();
        }

        public static void Start()
        {
            StartControlThread();
            while (!isGameOver)
            {
                GameTick();
            }
        }

        public static void GameTick()
        {
            Control.MoveDown();
            if (Field.Check())
            {
                Field.Update();
                UpdateScore(Field.CheckLines());
                TetraminoSet = NextTetraminoSet;
                NextTetraminoSet = GetRandomTetraminoSet();
            }
            Screen.Redraw();
            Control.GameTickChecked();
            Thread.Sleep(gameDelay);
        }

        static TetraminoTemplateSet GetRandomTetraminoSet()
        {
            var values = Enum.GetValues(typeof(TetraminoType));
            int max = values.Length;
            int index = rnd.Next(0, max);
            var set = TetraminoStorage.GetTemplateSet((TetraminoType)values.GetValue(index));
            set.Reset();
            return set;
        }

        public static void StartControlThread()
        {
            Control.Start();
        }

        public static void StopControlThread()
        {
            Control.Stop();
        }

        public static void UpdateScore(int linesCount)
        {
            //TODO score system
            Game.score += linesCount;
        }
    }
}
