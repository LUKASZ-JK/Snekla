using System.Collections.Generic;
using System.Windows.Forms;

namespace Snekla
{
    public partial class Snekla : Form
    {
        enum SnakesDirection
        {
            Left,
            Right,
            Up,
            Down,
        }
        private void GetSnakesInitialDirection()
        {
            //Initial Direction

            snakesHead = snake[snake.Count - 1];
            Coordinate snakesBody = snake[snake.Count - 2];

            if (snakesHead.X == snakesBody.X)
            {
                if (snakesHead.Y > snakesBody.Y)
                {
                    snakesDirection = SnakesDirection.Up;
                }
                else
                {
                    snakesDirection = SnakesDirection.Down;
                }
            }
            else
            {
                if (snakesHead.X > snakesBody.X)
                {
                    snakesDirection = SnakesDirection.Right;
                }
                else
                {
                    snakesDirection = SnakesDirection.Left;
                }
            }
        }

        private void GetSnakesDirection()
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(1000 / speed);
        }
        private bool ValidateDirection(SnakesDirection direction)
        {
            snakesHead = snake[snake.Count - 1];
            Coordinate snakesBody = snake[snake.Count - 2];

            if (direction == SnakesDirection.Left)
            {
                if (snakesHead.X - 1 == snakesBody.X) return false; else return true;
            }
            else if (direction == SnakesDirection.Right)
            {
                if (snakesHead.X + 1 == snakesBody.X) return false; else return true;
            }
            else if (direction == SnakesDirection.Up)
            {
                if (snakesHead.Y + 1 == snakesBody.Y) return false; else return true;
            }
            else if (direction == SnakesDirection.Down)
            {
                if (snakesHead.Y - 1 == snakesBody.Y) return false; else return true;
            }
            else return false;
        }

        private void MoveSnake()
        {

            snakesHead = snake[snake.Count - 1];
            switch (snakesDirection)
            {
                case SnakesDirection.Left:
                    snake.Add(new Coordinate(snakesHead.X - 1, snakesHead.Y));
                    break;
                case SnakesDirection.Right:
                    snake.Add(new Coordinate(snakesHead.X + 1, snakesHead.Y));
                    break;
                case SnakesDirection.Up:
                    snake.Add(new Coordinate(snakesHead.X, snakesHead.Y + 1));
                    break;
                case SnakesDirection.Down:
                    snake.Add(new Coordinate(snakesHead.X, snakesHead.Y - 1));
                    break;

            }
            snakesHead = snake[snake.Count - 1];
            CreatedID = GenerateBlock(snakesHead.X, snakesHead.Y, "Snake");
            snake[snake.Count - 1].ID = CreatedID;

        }
        private void EvaluateState()
        {
            //Snake did not find a prize
            if (!snakesHead.Equals(prizeCoordinate))
            {
                RemoveBlock(snake[0].ID);
                snake.RemoveAt(0);

            }
            else
            {
                RemoveBlock(prizeCoordinate.ID);
                GeneratePrize();
            }
            //Snake moves into border
            if (border.Contains(snakesHead))
            {
                gameOver = true;
                MessageBox.Show("Game over");

            }
            //Snake moves into snake
            List<Coordinate> snakesBody = snake.GetRange(0, snake.Count - 1);
            if (snakesBody.Contains(snakesHead))
            {
                gameOver = true;
                MessageBox.Show("Game over");
                model.CommitChanges();
                this.KeyPreview = false;
            }
        }
        private void Snekla_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D: if (ValidateDirection(SnakesDirection.Right)) { snakesDirection = SnakesDirection.Right; } break;
                case Keys.A: if (ValidateDirection(SnakesDirection.Left)) { snakesDirection = SnakesDirection.Left; } break;
                case Keys.W: if (ValidateDirection(SnakesDirection.Up)) { snakesDirection = SnakesDirection.Up; } break;
                case Keys.S: if (ValidateDirection(SnakesDirection.Down)) { snakesDirection = SnakesDirection.Down; } break;
            }

            e.Handled = true;
        }
        /*        void Snekla_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.D: if (ValidateDirection(SnakesDirection.Right)) { snakesDirection = SnakesDirection.Right; } break;
                case (char)Keys.A: if (ValidateDirection(SnakesDirection.Left)) { snakesDirection = SnakesDirection.Left; } break;
                case (char)Keys.W: if (ValidateDirection(SnakesDirection.Up)) { snakesDirection = SnakesDirection.Up; } break;
                case (char)Keys.S: if (ValidateDirection(SnakesDirection.Down)) { snakesDirection = SnakesDirection.Down; } break;
            }
                    e.Handled = true;
         }*/
    }

}