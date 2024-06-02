using System.Collections.Generic;
using System.Drawing;

namespace FormsElectronicCAD
{
    public class Element
    {
        public ElementData Data;
        public List<Point> Legs = new List<Point>();
        public Point Position = new Point();
        public Rectangle Rect;
        public Element(ElementData data)
        {
            this.Data = data;
            switch (data.Type)
            {
                case ElementTypes.R:
                    Legs.AddRange(new List<Point>() { new Point(0 * 10, 0 * 10), new Point(3 * 10, 0 * 10) });
                    Rect = new Rectangle(new Point(1, 0), new Size(2 * 10, 1 * 10));
                    break;
                case ElementTypes.M14:
                    for (int i = 0; i < 2; ++i)
                    {
                        for (int j = 0; j < 14 / 2; ++j)
                        {
                            Legs.Add(new Point(i * 3 * 10, j * 10));
                        }
                    }
                    Rect = new Rectangle(new Point(1, 0), new Size(2 * 10, 14 / 2 * 10));
                    break;
                case ElementTypes.M16:
                    for (int i = 0; i < 16 / 2; ++i)
                    {
                        Legs.AddRange(new List<Point>() { new Point(0 * 10, i * 10), new Point(3 * 10, i * 10) });
                    }
                    Rect = new Rectangle(new Point(1, 0), new Size(2 * 10, 16 / 2 * 10));
                    break;
            }
        }
        public Element(int legsAmount)
        {
            switch (legsAmount)
            {
                case 2: Data.Type = ElementTypes.R;
                    Legs.AddRange(new List<Point>() { new Point(0 * 10, 0 * 10), new Point(3 * 10, 0 * 10) });
                    Rect = new Rectangle(new Point(1, 0), new Size(2 * 10, 1 * 10));
                    break;
                case 14: Data.Type = ElementTypes.M14;

                    break;
                case 16 : Data.Type = ElementTypes.M16;

                    break;
                default:

                    break;
            }
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < legsAmount / 2; ++j)
                {
                    Legs.Add(new Point(3 * i * 10, j * 10));
                }
            }
            Rect = new Rectangle(new Point(1, 0), new Size(2 * 10, legsAmount / 2 * 10));
        }
    }
}
