using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FormsElectronicCAD
{
    public partial class Form1 : Form
    {
        private int standartOffset = 3;
        private string fileContent;
        private string filePath;
        private int elementToSpawn = -1;

        private List<Element> elements = new List<Element>();
        private List<List<Point>> tracks = new List<List<Point>>();
        private bool[,] obstacles;
        private List<ConnectionData> connections = new List<ConnectionData>();
        private int prevX = -1;
        private int prevY = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void panel1_Click(object sender, MouseEventArgs e)
        {
            int X = e.X;
            int Y = e.Y;
            if (elementToSpawn != -1)
            {
                Element element = new Element(2);
                switch (elementToSpawn)
                {
                    case 0:
                        element = new Element(8);
                        break;
                    case 1:
                        element = new Element(14);
                        break;
                    case 2:
                        element = new Element(16);
                        break;
                    case 3:
                        element = new Element(2);
                        break;
                    case 4:
                        //TODO: Element with 3 legs (Transistor)
                        break;
                }
                element.Position = new Point(X / 10 * 10, Y / 10 * 10);
                elements.Add(element);
                elementToSpawn = -1;
            }
            else // Add connection or move element
            {
                if (prevX != -1 && prevY != -1)
                {
                    string element1 = null;
                    int connector1 = -1;
                    string element2 = null;
                    int connector2 = -1;
                    foreach (Element element in elements)
                    {
                        for (int i = 0; i < element.Legs.Count; ++i)
                        {
                            if (element.Legs[i].X - 1 + element.Position.X <= prevX && 
                                element.Legs[i].X + 10 + element.Position.X >= prevX &&
                                element.Legs[i].Y - 1 + element.Position.Y <= prevY &&
                                element.Legs[i].Y + 10 + element.Position.Y >= prevY)
                            {
                                element1 = element.Data.Name;
                                connector1 = i;
                            }
                            else if (element.Legs[i].X + element.Position.X - 1 <= X &&
                                element.Legs[i].X + 10 + element.Position.X >= X &&
                                element.Legs[i].Y - 1 + element.Position.Y <= Y &&
                                element.Legs[i].Y + 10 + element.Position.Y >= Y)
                            {
                                element2 = element.Data.Name;
                                connector2 = i;
                            }
                        }
                    }
                    if (connector1 == -1 || connector2 == -1)
                    {
                        prevX = X; prevY = Y;
                        return;
                    }
                    else
                    {
                        connections.Add(new ConnectionData()
                        {
                            Name = element1 + "/" + connector1 + " " + element2 + "/" + connector2,
                            Connector1 = connector1 + 1,
                            Connector2 = connector2 + 1,
                            NameElement1 = element1,
                            NameElement2 = element2,
                            X1 = prevX / 10,
                            X2 = X / 10,
                            Y1 = prevY / 10,
                            Y2 = Y / 10
                        });
                    }
                    prevX = -1; prevY = -1;
                }
                else
                {
                    prevX = X; prevY = Y;
                }
            }
            Invalidation();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            var gr = e.Graphics;
            int X = (int)Xinput.Value;
            int Y = (int)Yinput.Value;
            obstacles = new bool[X, Y];
            Rectangle _rect = new Rectangle(0, 0, X * 10 + standartOffset, Y * 10 + standartOffset);
            gr.FillRectangle(new SolidBrush(Color.Green), _rect);
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    _rect = new Rectangle(i * 10 + standartOffset, j * 10 + standartOffset, 6, 6);
                    gr.FillRectangle(new SolidBrush(Color.DarkGreen), _rect);
                }
            }
            foreach (var track in tracks)
            {
                foreach (Point point in track)
                {
                    _rect = new Rectangle(point.X * 10 + standartOffset, point.Y * 10 + standartOffset, 10, 10);
                    gr.FillRectangle(new SolidBrush(Color.Goldenrod), _rect);
                }
            }
            foreach (Element element in elements)
            {
                Rectangle rect = new Rectangle(element.Rect.Location, element.Rect.Size);
                rect.Offset(element.Position);
                rect.Offset(new Point(10, 2));
                gr.FillRectangle(new SolidBrush(Color.Gray), rect);
                foreach (var legPos in element.Legs)
                {
                    rect = new Rectangle(new Point(legPos.X + 2, legPos.Y + 2), new Size(1 * 8, 1 * 8));
                    rect.Offset(element.Position);
                    gr.FillRectangle(new SolidBrush(Color.Gold), rect);
                }
            }

            /*ElementPlacement placer = new ElementPlacement();
            List<List<Rectangle>> rects = placer.Placer(elements, standartOffset, X, Y);
            foreach (Rectangle processor in rects[0])
            {
                gr.FillRectangle(new SolidBrush(Color.Gray), processor);
            }
            foreach (Rectangle leg in rects[1])
            {
                gr.FillRectangle(new SolidBrush(Color.Gold), leg);
            }*/
            //TODO: Paint Connections
            Pen blackPen = new Pen(Color.Black, 3);
            foreach (ConnectionData connection in connections)
            {
                e.Graphics.DrawLine(blackPen,
                    connection.X1 * 10 + 5, connection.Y1 * 10 + 5,
                    connection.X2 * 10 + 5, connection.Y2 * 10 + 5);
            }
        }

        private void countObstacle()
        {
            foreach (Element element in elements)
            {
                for (int i = 0; i < element.Legs.Count; ++i)
                {
                    obstacles[(element.Legs[i].X + element.Position.X) / 10,
                        (element.Legs[i].Y + element.Position.Y) / 10] = true;
                }
            }
            WaveAlgo wave = new WaveAlgo(Convert.ToInt32(Xinput.Value), Convert.ToInt32(Yinput.Value));
            List<Point> track = new List<Point>();
            foreach (ConnectionData connection in connections)
            {
                track = wave.CountTrack(obstacles, new Point(connection.X1, connection.Y1), new Point(connection.X2, connection.Y2));
                foreach (Point point in track)
                {
                    obstacles[point.X, point.Y] = true;
                }
                tracks.Add(track);
            }
            Invalidation();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openElementBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog1.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
            List<ElementData> data = Parser.ParseElementList(fileContent);
            int i = 5 * 10;
            int j = 5 * 10;
            foreach (var element in data)
            {
                elements.Add(new Element(element));
                elements.Last().Position = new Point(i, j);
                if (i + 10 * 10 < (int)Xinput.Value * 10 - 5 * 10)
                {
                    i += 10 * 10;
                }
                else
                {
                    j += 20 * 10;
                    i = 5 * 10;
                }
            }
            Invalidation();
        }

        private void openConnectDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog1.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
            connections = Parser.ParseConnectionList(fileContent);
            for (int i = 0; i < connections.Count; ++i)
            {
                var el1 = elements.Find(el => el.Data.Name == connections[i].NameElement1);
                var el2 = elements.Find(el => el.Data.Name == connections[i].NameElement2);
                connections[i].X1 = (el1.Legs[connections[i].Connector1 - 1].X + el1.Position.X) / 10;
                connections[i].Y1 = (el1.Legs[connections[i].Connector1 - 1].Y + el1.Position.Y) / 10;
                connections[i].X2 = (el2.Legs[connections[i].Connector2 - 1].X + el2.Position.X) / 10;
                connections[i].Y2 = (el2.Legs[connections[i].Connector2 - 1].Y + el2.Position.Y) / 10;
            }
            Invalidate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Xinput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Yinput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            CreateDialog dialog = new CreateDialog(this);
            dialog.ShowDialog();
        }
        public void Invalidation()
        {
            panel1.Invalidate();
        }
        public void CreateNewScheme(int x, int y)
        {
            Xinput.Value = x;
            Yinput.Value = y;
            elements = new List<Element>();
            tracks = new List<List<Point>>();
            obstacles = new bool[x, y];
            connections = new List<ConnectionData>();
            Invalidation();
        }

        private void DD8Btn_Click(object sender, EventArgs e)
        {
            elementToSpawn = 0;
        }

        private void DD14Btn_Click(object sender, EventArgs e)
        {
            elementToSpawn = 1;
        }

        private void DD16Btn_Click(object sender, EventArgs e)
        {
            elementToSpawn = 2;
        }

        private void RBtn_Click(object sender, EventArgs e)
        {
            elementToSpawn = 3;
        }

        private void TrBtn_Click(object sender, EventArgs e)
        {
            elementToSpawn = 4;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            countObstacle();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PositionOptimiser optimiser = new PositionOptimiser(connections, elements);
            elements = optimiser.Optimize();
            for (int i = 0; i < connections.Count; ++i)
            {
                var el1 = elements.Find(el => el.Data.Name == connections[i].NameElement1);
                var el2 = elements.Find(el => el.Data.Name == connections[i].NameElement2);
                connections[i].X1 = (el1.Legs[connections[i].Connector1 - 1].X + el1.Position.X) / 10;
                connections[i].Y1 = (el1.Legs[connections[i].Connector1 - 1].Y + el1.Position.Y) / 10;
                connections[i].X2 = (el2.Legs[connections[i].Connector2 - 1].X + el2.Position.X) / 10;
                connections[i].Y2 = (el2.Legs[connections[i].Connector2 - 1].Y + el2.Position.Y) / 10;
            }
            Invalidation();
        }
    }
}
