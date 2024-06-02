using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FormsElectronicCAD
{
    internal class WaveAlgo
    {
        //TODO: While path .....
        /*public List<Point> CountTrack(bool[,] obst, Point point, Point end)
        {
            if ((Math.Abs(point.X - end.X) != 1 && point.Y == end.Y)
                || (Math.Abs(point.Y - end.Y) != 1 && point.X == end.X))
            {
                return new List<Point>{point};
            }
            List<Point> pointsL = new List<Point>();
            List<Point> pointsR = new List<Point>();
            List<Point> pointsD = new List<Point>();
            List<Point> pointsU = new List<Point>();
            obst[point.X, point.Y] = true;
            if (point.X - 1 >= 0 && !obst[point.X - 1, point.Y])
            {
                pointsL = CountTrack(obst, new Point(point.X - 1, point.Y), end);
                pointsL.Add(point);
            }
            if (point.Y - 1 >= 0 && !obst[point.X, point.Y - 1])
            {
                pointsD = CountTrack(obst, new Point(point.X, point.Y - 1), end);
                pointsD.Add(point);
            }
            if (point.X + 1 < obst.GetLength(0) && !obst[point.X + 1, point.Y])
            {
                pointsR = CountTrack(obst, new Point(point.X + 1, point.Y), end);
                pointsR.Add(point);
            }
            if (point.Y + 1 < obst.GetLength(1) && !obst[point.X, point.Y + 1])
            {
                pointsU = CountTrack(obst, new Point(point.X, point.Y + 1), end);
                pointsU.Add(point);
            }
            int[] lenght = { pointsL.Count, pointsR.Count, pointsD.Count, pointsU.Count };
            int min = lenght.Where(x => x != 0).Min();
            switch (min)
            {
                case 0:
                    return pointsL;
                case 1:
                    return pointsR;
                case 2:
                    return pointsD;
                case 3:
                    return pointsU;
                default: return pointsR;
            }
        }*/
        int[,] waves;
        List<Point> path = new List<Point>();
        public WaveAlgo(int xsize, int ysize)
        {
            waves = new int[xsize, ysize];
            for (int i = 0; i < waves.GetLength(0); i++)
            {
                for (int j = 0; j < waves.GetLength(1); j++)
                {
                    waves[i, j] = int.MaxValue;
                }
            }
        }
        public List<Point> CountTrack(bool[,] obst, Point point, Point end)
        {
            waves[point.X, point.Y] = 0;
            int d = countWave(obst, end, 0);
            countPath(end, d);
            return path;
        }
        private int countWave(bool[,] obst, Point end, int d)
        {
            for (int i = 0; i < waves.GetLength(0); i++)
            {
                for (int j = 0; j < waves.GetLength(1); j++)
                {
                    if (waves[i, j] == d)
                    {
                        if (i + 1 == end.X && j == end.Y)
                        {
                            waves[end.X, end.Y] = d + 1;
                            return d + 1;
                        }
                        else
                        {
                            if (i + 1 < waves.GetLength(0) && !obst[i + 1, j] && waves[i + 1, j] > d + 1)
                            {
                                waves[i + 1, j] = d + 1;
                            }
                        }
                        if (i - 1 == end.X && j == end.Y)
                        {
                            waves[end.X, end.Y] = d + 1;
                            return d + 1;
                        }
                        else
                        {
                            if (i - 1 >= 0 && !obst[i - 1, j] && waves[i - 1, j] > d + 1)
                            {
                                waves[i - 1, j] = d + 1;
                            }
                        }
                        if (i == end.X && j + 1 == end.Y)
                        {
                            waves[end.X, end.Y] = d + 1;
                            return d + 1;
                        }
                        else
                        {
                            if (j + 1 < waves.GetLength(1) && !obst[i, j + 1] && waves[i, j + 1] > d + 1)
                            {
                                waves[i, j + 1] = d + 1;
                            }
                        }
                        if (i == end.X && j - 1 == end.Y)
                        {
                            waves[end.X, end.Y] = d + 1;
                            return d + 1;
                        }
                        else
                        {
                            if (j - 1 >= 0 && !obst[i, j - 1] && waves[i, j - 1] > d + 1)
                            {
                                waves[i, j - 1] = d + 1;
                            }
                        }
                    }
                }
            }
            return countWave(obst, end, d + 1);
        }
        private void countPath(Point p, int d)
        {
            path.Add(p);
            do
            {
                if (waves[p.X + 1, p.Y] == d - 1)
                {
                    p.X += 1;
                }
                else if (waves[p.X - 1, p.Y] == d - 1)
                {
                    p.X -= 1;
                }
                else if (waves[p.X, p.Y + 1] == d - 1)
                {
                    p.Y += 1;
                }
                else if (waves[p.X, p.Y - 1] == d - 1)
                {
                    p.Y -= 1;
                }
                path.Add(p);
                d--;
            } 
            while (d > 0);
        }
    }
}
