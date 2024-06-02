using System;
using System.Collections.Generic;

namespace FormsElectronicCAD
{
    internal class PositionOptimiser
    {
        private List<ConnectionData> connections = new List<ConnectionData>();
        private List<Element> stelements = new List<Element>();
        public PositionOptimiser(List<ConnectionData> _connections, List<Element> _elements)
        {
            this.connections = _connections;
            this.stelements = _elements;
        }
        public List<Element> Optimize()
        {
            double best = double.MaxValue;
            for (int i = 0; i < stelements.Count * 2; i++)
            {
                Random random = new Random();
                List<Element> elements = new List<Element>();
                foreach (var el in stelements)
                {
                    elements.Add(el);
                }
                int e1 = random.Next(0, elements.Count);
                int e2 = random.Next(0, elements.Count);
                var tmpel = elements[e1].Position;
                elements[e1].Position = elements[e2].Position;
                elements[e2].Position = tmpel;
                var counted = connectionsDistance(elements);
                if (counted < best)
                {
                    best = counted;
                    stelements = elements;
                }
            }
            return stelements;
        }
        private double connectionsDistance(List<Element> elements)
        {
            for (int i = 0; i < connections.Count; ++i)
            {
                var el1 = elements.Find(el => el.Data.Name == connections[i].NameElement1);
                var el2 = elements.Find(el => el.Data.Name == connections[i].NameElement2);
                connections[i].X1 = (el1.Legs[connections[i].Connector1 - 1].X + el1.Position.X) / 10;
                connections[i].Y1 = (el1.Legs[connections[i].Connector1 - 1].Y + el1.Position.Y) / 10;
                connections[i].X2 = (el2.Legs[connections[i].Connector2 - 1].X + el2.Position.X) / 10;
                connections[i].Y2 = (el2.Legs[connections[i].Connector2 - 1].Y + el2.Position.Y) / 10;
            }
            double distance = 0;
            foreach (ConnectionData _connection in connections)
            {
                distance += Math.Sqrt(Math.Pow(_connection.X1 - _connection.X2, 2)
                    + Math.Pow(_connection.Y1 - _connection.Y2, 2));
            }
            return distance;
        }
    }
}
