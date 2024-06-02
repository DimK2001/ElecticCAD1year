using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsElectronicCAD
{
    internal class ElementPlacement
    {
        public List<List<Rectangle>> Placer(List<Element> elements, int standartOffset, int Width, int Hight)
        {
            List<List<Rectangle>> rects = new List<List<Rectangle>>();
            rects.Add(new List<Rectangle>());
            rects.Add(new List<Rectangle>());
            int col = 0;
            int row = 0;
            foreach (var element in elements.Where(el => el.Legs.Count > 2))
            {
                if (10 + col * 10 > Width)
                {
                    col = 0;
                    ++row;
                }
                element.Position = new Point(5 + col * 10 * 10 + standartOffset / 2, 5 + row * 14 * 10 + standartOffset / 2);
                Rectangle rect = new Rectangle(new Point(element.Position.X + 1 * 10, element.Position.Y), element.Rect.Size);
                rects[0].Add(rect);
                foreach (var legPos in element.Legs)
                {
                    rects[1].Add(new Rectangle(new Point(legPos.X + element.Position.X, legPos.Y + element.Position.Y), new Size(1 * 8, 1 * 8)));
                }
                ++col;
            }
            foreach (var element in elements.Where(el => el.Legs.Count <= 2))
            {
                //TODO: Placement Rs between schemas
            }
            return rects;
        }
    }
}
