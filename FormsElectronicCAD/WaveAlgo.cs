using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace FormsElectronicCAD
{
    internal class WaveAlgo
    {
        int[,] waves;
        List<Point> path = new List<Point>();
        private int Xsize = 0;
        private int Ysize = 0;
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
            Xsize = xsize;
            Ysize = ysize;
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
            path.Clear();
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
            waves = new int[Xsize, Ysize];
            for (int i = 0; i < waves.GetLength(0); i++)
            {
                for (int j = 0; j < waves.GetLength(1); j++)
                {
                    waves[i, j] = int.MaxValue;
                }
            }
        }
    }
}
