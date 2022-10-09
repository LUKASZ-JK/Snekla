using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tekla.Structures.Model;

namespace Snekla
{
    public partial class Snekla : Form
    {
        Model model = new Model();
        public Snekla()
        {
            InitializeComponent();
            if (!model.GetConnectionStatus())
            {
                MessageBox.Show("Tekla not running");
                return;
            }
            //Creating proper workplane and view on form creation
            CreateWorkplane();
            CreateView();
        }

        int verticalSize;
        int horizontalSize;
        int speed;
        bool gameOver;

        List<Coordinate> border;
        List<Coordinate> snake;
        Coordinate prizeCoordinate;
        Tekla.Structures.Identifier CreatedID;

        int counter;
        (int, int) existingBorder;


        SnakesDirection snakesDirection;
        Coordinate snakesHead;

        WorkPlaneHandler planeHandler;
        TransformationPlane originalPlane;

        private void ValidateInput()
        {
            if (!Int32.TryParse(verticalSizeInput.Text, out verticalSize) || !Int32.TryParse(horizontalSizeInput.Text, out horizontalSize) || !Int32.TryParse(speedInput.Text, out speed))
            {
                MessageBox.Show("Wrong input values");
                return;
            }
            if (verticalSize < 10 || horizontalSize < 10)
            {
                MessageBox.Show("Board would be too small");
                return;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            snake = new List<Coordinate>();
            gameOver = false;
            ValidateInput();
            GenerateBorder();
            GenerateSnake();
            GeneratePrize();
            GetSnakesInitialDirection();


            while (gameOver is false)
            {
                GetSnakesDirection();
                MoveSnake();
                EvaluateState();
            }
            CleanUpSnakeAndPrize();

        }

        private void Snekla_FormClosed(object sender, FormClosedEventArgs e)
        {
            CleanUpBorder();
            RemoveView();
            RestoreWorkplane();
        }
    }
}