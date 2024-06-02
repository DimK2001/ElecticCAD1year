using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FormsElectronicCAD
{
    public static class Parser
    {
        public static List<ElementData> ParseElementList(string fileContent)
        {
            List<ElementData> elements = new List<ElementData>();
            //fileContent = fileContent.Replace(" ", string.Empty);
            for (int i = 0; i < fileContent.Split('\n').Length; i++)
            {
                string content = fileContent.Split('\n')[i];
                string filenames = content.Split(' ')[0];
                string type = content.Split(' ')[1];
                List<string> names = new List<string>();
                if (filenames.Contains("-"))
                {
                    string nameStart = filenames.Split('-')[0];
                    string nameEnd = filenames.Split('-')[1];

                    Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
                    Match result = re.Match(nameStart);
                    string nameAlpha = result.Groups[1].Value;
                    int startNumber = Convert.ToInt32(result.Groups[2].Value);
                    result = re.Match(nameEnd);
                    int endNumber = Convert.ToInt32(result.Groups[2].Value);
                    for (int j = startNumber; j <= endNumber; j++)
                    {
                        names.Add(nameAlpha + j);
                    }
                }
                else if (filenames.Contains(","))
                {
                    for (int j = 0; j < filenames.Split(',').Length; j++)
                    {
                        names.Add(filenames.Split(',')[j]);
                    }
                }
                else
                {
                    names.Add(filenames);
                }
                foreach (string name in names)
                {
                    ElementData element = new ElementData();
                    element.Name = name;
                    Enum.TryParse(type, out element.Type);
                    elements.Add(element);
                }
            }
            return elements;
        }
        public static List<ConnectionData> ParseConnectionList(string fileContent)
        {
            List<ConnectionData> connections = new List<ConnectionData>();
            //fileContent = fileContent.Replace(" ", string.Empty);
            for (int i = 0; i < fileContent.Split('\n').Length; i++)
            {
                string content = fileContent.Split('\n')[i];
                string connectionnames = content.Split(':')[0];
                string data = content.Split(':')[1];
                string first = data.Split(',')[0];
                string second = data.Split(',')[1];
                var connection = new ConnectionData();
                connection.NameElement1 = first.Split('/')[0];
                connection.NameElement2 = second.Split('/')[0];
                connection.Connector1 = Convert.ToInt32(first.Split('/')[1]);
                connection.Connector2 = Convert.ToInt32(second.Split('/')[1]);
                connection.Name = connectionnames;
                connections.Add(connection);
            }
            return connections;
        }
    }
    public enum ElementTypes
    {
        R, M14, M16
    }
    public struct ElementData
    {
        public ElementTypes Type;
        public string Name;
    }
    public class ConnectionData
    {
        public string Name;
        public string NameElement1;
        public string NameElement2;
        public int Connector1;
        public int Connector2;
        public int X1;
        public int X2;
        public int Y1;
        public int Y2;
    }
}
