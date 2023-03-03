using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        public int foodX, foodY;
        Random ran;
        Bitmap foodImg;
        Size foodSize;

        public Food()
        {
            string path = @"..\..\Bitmap\";
            foodSize = Form1.blockSize;
            foodImg = new Bitmap(path + "Food.png");
            foodImg = new Bitmap(foodImg, foodSize);
            ran = new Random();
        }

        public void FoodReset(ArrayList snakeBodyPostion, int snakeHeadX, int snakeHeadY)
        {
            RandPostion(snakeHeadX, snakeHeadY);

            for(int i=0;i<snakeBodyPostion.Count/2;i++)
            {
                if((int)snakeBodyPostion[i*2]==foodX && (int)snakeBodyPostion[i*2+1]==foodY)//몸과 겹칠시
                {
                    RandPostion(snakeHeadX, snakeHeadY);
                    i = 0;
                }
            }
        }

        public void RandPostion(int x, int y)
        {
            do//머리와 겹칠시 반복한다
            {
                foodX = ran.Next(0, 29);
                foodY = ran.Next(0, 29);
            }while (x == foodX && y == foodY) ;
        }

        public void Draw(Graphics g, float x, float y)
        {
            g.DrawImage(foodImg, foodX * x, foodY * y);
        }
    }
}
