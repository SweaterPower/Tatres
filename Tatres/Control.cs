using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tatres
{
    class Control
    {
        Thread thread;
        bool isGameRunning = false;
        bool gameTickCheck = false;

        void Action()
        {
            while (isGameRunning)
            {
                //if (gameTickCheck)
                //{
                    var key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.A: MoveLeft(); break;
                        case ConsoleKey.D: MoveRight(); break;
                        case ConsoleKey.S: SkipDown(); break;
                        case ConsoleKey.Spacebar: Rotate(); break;
                    }
                    gameTickCheck = false;
                //}
                //else
                    Thread.Sleep(10);
            }
        }

        void MoveLeft()
        {
            var current = Game.TetraminoSet.GetCurrent();
            current.SetPointX(current.Point.X - 1);
        }

        void MoveRight()
        {
            var current = Game.TetraminoSet.GetCurrent();
            current.SetPointX(current.Point.X + 1);
        }

        public void MoveDown()
        {
            var current = Game.TetraminoSet.GetCurrent();
            current.SetPointY(current.Point.Y+1);
        }

        void SkipDown()
        {
            var current = Game.TetraminoSet.GetCurrent();
            var newy = Game.Field.GetTopPointByX(current.Point.X);
            current.SetPointY(newy);
        }

        void Rotate()
        {
            //какое же говно я написал...
            Point point = Game.TetraminoSet.GetCurrent().Point;
            Game.TetraminoSet.Rotate();
            Game.TetraminoSet.GetCurrent().SetPointXY(point.X, point.Y);
        }

        public Control()
        {
            ThreadStart ts = new ThreadStart(Action);
            thread = new Thread(ts);
        }

        public void Start()
        {
            isGameRunning = true;
            thread.Start();
        }

        public void Stop()
        {
            isGameRunning = false;
        }

        public void GameTickChecked()
        {
            gameTickCheck = true;
        }
    }
}
