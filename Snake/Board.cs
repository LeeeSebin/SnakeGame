using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Board
    {
        public const int N = 3;
        public float Width { get; set; }
        public float Height { get; set; }
        public float HSlotSize { get; set; }
        public float WSlotSize { get; set; }
        public int HN = 30;
        public int WN = 30;
        public Board(float width, float height)
        {
            Width = width;
            Height = height;
            HSlotSize = height / HN;
            WSlotSize = width / WN;
        }

        public void Darw(Graphics g)
        {
            Pen pen = Pens.Black;
            for (int i = 1; i < HN; i++)//가로선
                g.DrawLine(pen, 0, i * HSlotSize, Width, i * HSlotSize);
            for (int i = 1; i < WN; i++)//세로선
                g.DrawLine(pen, i * WSlotSize, 0, i * WSlotSize, Height);

        }


    }
}
