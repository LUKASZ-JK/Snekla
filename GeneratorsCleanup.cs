using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace Snekla
{
    public partial class Snekla : Form
    {
        private void GenerateBorder()
        {
            if (existingBorder.Item1 != verticalSize || existingBorder.Item2 != horizontalSize)
            {
                CleanUpBorder();
                border = new List<Coordinate>();
                //Vertical line of the border
                for (int i = 0; i <= (verticalSize + 1); i++)
                {
                    //First line
                    border.Add(new Coordinate(0, i));
                    //Last line
                    border.Add(new Coordinate(horizontalSize + 1, i));
                }

                //Horizontal line
                for (int i = 1; i <= (horizontalSize); i++)
                {
                    //First line
                    border.Add(new Coordinate(i, 0));
                    //Last line
                    border.Add(new Coordinate(i, verticalSize + 1));
                }

                counter = 0;
                foreach (Coordinate coordinate in border)
                {
                    border[counter].ID = GenerateBlock(coordinate.X, coordinate.Y, "Border");
                    counter++;

                }
                model.CommitChanges();
                existingBorder = (verticalSize, horizontalSize);
            }

        }

        private void GenerateSnake()
        {
            Random random = new Random();
            int x = random.Next(4, horizontalSize - 3);
            int y = random.Next(4, verticalSize - 3);
            int orientation = random.Next(0, 2);
            int direction = random.Next(0, 2);
            snake.Add(new Coordinate(x, y));
            //Random direction and orientation at the start of new game
            for (int i = 1; i <= 2; i++)
            {
                if (orientation == 0)
                {
                    if (direction == 0)
                    {
                        snake.Add(new Coordinate(x - i, y));
                    }
                    else
                    {
                        snake.Add(new Coordinate(x + i, y));
                    }
                }
                else
                {
                    if (direction == 0)
                    {
                        snake.Add(new Coordinate(x, y - i));
                    }
                    else
                    {
                        snake.Add(new Coordinate(x, y + i));
                    }
                }
            }
            counter = 0;
            foreach (Coordinate coordinate in snake)
            {
                snake[counter].ID = GenerateBlock(coordinate.X, coordinate.Y, "Snake");
                counter++;
            }
            model.CommitChanges();
        }

        private void GeneratePrize()
        {
            Random random = new Random();
            int x = random.Next(1, horizontalSize - 1);
            int y = random.Next(1, verticalSize - 1);
            prizeCoordinate = new Coordinate(x, y);
            if (!snake.Contains(prizeCoordinate))
            {
                prizeCoordinate.ID = GenerateBlock(prizeCoordinate.X, prizeCoordinate.Y, "Prize");
            }
            else
            {
                GeneratePrize();
            }
            model.CommitChanges();
        }

        private void CleanUpBorder()
        {
            if (border != null)
            {
                foreach (Coordinate borderCoordinate in border)
                {
                    RemoveBlock(borderCoordinate.ID);
                }
            }

        }

        private void CleanUpSnakeAndPrize()
        {
            foreach (Coordinate snakeCoordinate in snake)
            {
                RemoveBlock(snakeCoordinate.ID);
            }
            RemoveBlock(prizeCoordinate.ID);
        }

        private void CreateView()
        {

            RemoveView();
            Tekla.Structures.Model.UI.View view = new Tekla.Structures.Model.UI.View
            {
                Name = "SNEKLA"
            };
            view.ViewCoordinateSystem.AxisX = new Vector(1, 0, 0);
            view.ViewCoordinateSystem.AxisY = new Vector(0, 1, 0);
            // Work area has to be set for new views
            view.WorkArea.MinPoint = new Tekla.Structures.Geometry3d.Point(-10, -10, 0);
            view.WorkArea.MaxPoint = new Tekla.Structures.Geometry3d.Point(110, 110, 0);
            view.ViewDepthUp = 10;
            view.ViewDepthDown = 20;
            view.Insert();
            ViewHandler.ShowView(view);
        }

        private void RemoveView()
        {
            ModelViewEnumerator viewEnum = ViewHandler.GetAllViews();
            while (viewEnum.MoveNext())
            {
                Tekla.Structures.Model.UI.View view = viewEnum.Current;
                if (view.Name == "SNEKLA")
                {
                    view.Delete();
                }
            }
        }


        private void CreateWorkplane()
        {
            planeHandler = model.GetWorkPlaneHandler();
            originalPlane = planeHandler.GetCurrentTransformationPlane();
            planeHandler.SetCurrentTransformationPlane(new TransformationPlane());
            ViewHandler.RedrawWorkplane();
        }
        private void RestoreWorkplane()
        {
            planeHandler = model.GetWorkPlaneHandler();
            planeHandler.SetCurrentTransformationPlane(originalPlane);
            ViewHandler.RedrawWorkplane();
        }
    }

}