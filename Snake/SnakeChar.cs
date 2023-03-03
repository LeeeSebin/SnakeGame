using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
/***************************************************************/
using System.Drawing;
/***************************************************************/

namespace Snake
{
    class SnakeChar : Form1
    {
        private bool alive = true;
        private int[] nextBodyPosition = new int[2];//0은 x좌표, 1은 y좌표를 담당
        private int snakeBodyStartLenght = 4 * 2;//시작시 몸통 조각수
        private String control = "right";

        Size snakeSize;
        Bitmap snakeHeadImg;
        public int snakeHeadX, snakeHeadY;//뱀의 머리좌표
        public ArrayList snakeBody = new ArrayList();
        Bitmap[] snakeBodyImg = new Bitmap[20];
        public int maxBody = 15;//최대 몸통갯수



        public SnakeChar()
        {
            snakeHeadX = snakeHeadY = 14;//시작시 뱀의 머리좌표를 정해줌
            NextPostionReset();//다음에 올 첫몸통의 위치를 현머리위치로 지정
            for(int i = 0; i < snakeBodyStartLenght; i++)
            {
                if (i % 2 == 0) //0과 2의 배수번째 snakeBody는 x좌표 담당
                {
                    nextBodyPosition[0] = nextBodyPosition[0] - 1;//왼쪽에 오도록 배치
                    snakeBody.Add(nextBodyPosition[0]);
                }
                else//나머지는 y좌표 담당
                    snakeBody.Add(nextBodyPosition[1]);//높이는 같게 배치
            }


            snakeSize = Form1.blockSize;
            string path = @"..\..\Bitmap\";
            snakeHeadImg = new Bitmap(path + "SnakeHead.png");
            snakeHeadImg = new Bitmap(snakeHeadImg, snakeSize);
            for (int i = 0; i < maxBody; i++)
            {
                snakeBodyImg[i] = new Bitmap(path + "SnakeBody.png");
                snakeBodyImg[i] = new Bitmap(snakeBodyImg[i], snakeSize);
            }
        }

        /***********************************************************/
        public void Draw(Graphics g,float x,float y)
        {
            g.DrawImage(snakeHeadImg, snakeHeadX * x, snakeHeadY * y);
            for (int i = 0; i < snakeBody.Count / 2; i++)
            {
                g.DrawImage(snakeBodyImg[i], int.Parse(snakeBody[i * 2].ToString()) * x, int.Parse(snakeBody[i * 2 + 1].ToString()) * y);
            }
        }
        /***************************************************************/

        public void SnakeMove(int BoardWN, int BoardHN)
        {
            NextPostionReset();
            if (control.Equals("right"))//머리를 이동시켜준다
            {
                if (snakeHeadX >= BoardWN - 1)
                    alive = false;
                else
                    snakeHeadX++;
            }
            else if (control.Equals("left"))
            {
                if (snakeHeadX <= 0)
                    alive = false;
                else
                    snakeHeadX--;
            }
            else if (control.Equals("up"))
            {
                if (snakeHeadY <= 0)
                    alive = false;
                else
                    snakeHeadY--;
            }
            else if (control.Equals("down"))
            {
                if (snakeHeadY >= BoardHN - 1)
                    alive = false;
                else
                    snakeHeadY++;
            }

            for (int i = 0; i < snakeBody.Count; i++)//몸통 움직이기
            {
                if (i % 2 == 0) //== x좌표
                {
                    int x = int.Parse(snakeBody[i].ToString());//현재 위치 저장
                    snakeBody[i] = nextBodyPosition[0];//새로운 위치로 이동
                    nextBodyPosition[0] = x;//다음 몸통을 위해 저장해 두었던 이전현위치를 넘겨줌
                }
                else//== y좌표
                {
                    int y = int.Parse(snakeBody[i].ToString());
                    snakeBody[i] = nextBodyPosition[1];
                    nextBodyPosition[1] = y;
                }
            }
        }

        public void SnakeControl(String input)
        {
            if (input.Equals("right") && !control.Equals("left"))//오른쪽
                control = "right";
            else if (input.Equals("left") && !control.Equals("right"))//왼쪽
                control = "left";
            else if (input.Equals("up") && !control.Equals("down"))//위
                control = "up";
            else if (input.Equals("down") && !control.Equals("up"))//아래
                control = "down";
        }

        public bool AliveCheck()
        {
            for(int i=0;i<snakeBody.Count/2;i++)
            {
                if (snakeHeadX == int.Parse(snakeBody[i * 2].ToString()) && snakeHeadY == int.Parse(snakeBody[i * 2 + 1].ToString()))
                    alive = false;
            }
            return alive;
        }

        public void NextPostionReset()//다음에 올 첫몸통의 위치를 현머리위치로 지정
        {
            nextBodyPosition[0] = snakeHeadX;
            nextBodyPosition[1] = snakeHeadY;
        }

        public void AddTail()
        {
            if (snakeBody.Count / 2 < maxBody)
            {
                snakeBody.Add(nextBodyPosition[0]);
                snakeBody.Add(nextBodyPosition[1]);
            }
        }

    }
}
