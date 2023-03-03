using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private Board board;
        private SnakeChar snake;
        private Food food;
        Bitmap[] snakeBody = new Bitmap[20];
        bool test = true;
        Timer timer = new Timer();
        public static Size blockSize;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board = new Board(boardPanel.Width, boardPanel.Height);
            timer.Interval = 150;
            timer.Tick += new EventHandler(SnakeMoveAfter);
            timer.Enabled = true;

            blockSize = new Size((int)board.WSlotSize, (int)board.HSlotSize);
            snake = new SnakeChar();
            food = new Food();
            food.FoodReset(snake.snakeBody, snake.snakeHeadX, snake.snakeHeadY);
        }
        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {
            board.Darw(e.Graphics);
            snake.Draw(e.Graphics, board.WSlotSize, board.HSlotSize);
            food.Draw(e.Graphics, board.WSlotSize, board.HSlotSize);
        }

        private void SnakeMoveAfter(object sender, EventArgs e)//뱀을 이동시키고, 움직이고 난후 다른 객체들과의 상호작용 판정
        {
            snake.SnakeMove(board.WN, board.HN);

            if (snake.snakeHeadX == food.foodX && snake.snakeHeadY == food.foodY)
            {
                snake.AddTail();
                food.FoodReset(snake.snakeBody, snake.snakeHeadX, snake.snakeHeadY);
            }
            if (snake.snakeBody.Count / 2 >= snake.maxBody)
            {
                timer.Enabled = false;
                MessageBox.Show("Win!!");
            }

            if (!snake.AliveCheck())
            {
                timer.Enabled = false;
                MessageBox.Show("Dead");
            }
            else
                boardPanel.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    snake.SnakeControl("left");
                    break;
                case Keys.Right:
                    snake.SnakeControl("right");
                    break;
                case Keys.Up:
                    snake.SnakeControl("up");
                    break;
                case Keys.Down:
                    snake.SnakeControl("down");
                    break;
                case Keys.R:
                    Application.Restart();
                    break;
                case Keys.Escape:
                    Environment.Exit(0);
                    break;
            }
        }
    }

}
