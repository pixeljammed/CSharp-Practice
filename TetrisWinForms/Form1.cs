using System.Reflection.Emit;
using System.Windows.Forms;
using TetrisWinForms;
using System.Drawing;

namespace TetrisWinForms
{
    public partial class Form1 : Form
    {
        // VARIABLES
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        Bitmap canvasBitmap;
        Graphics canvasGraphics;

        int canvasWidth = 10;
        int canvasHeight = 20;
        (int presence, Color color)[,] canvasDotArray;
        int dotSize = 28;

        Shape currentShape;
        Shape nextShape;
        Shape heldShape;

        bool isHoldAvailable = true;

        

        // START FUNCTION
        public Form1()
        {
            InitializeComponent();
            loadCanvas();

            currentShape = getRandomShapeWithCenterAligned();
            nextShape = getNextShape();

            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            timer.Start();

            this.KeyDown += Form1_KeyDown;
        }

        // CREATE THE BOARD
        private void loadCanvas()
        {
            // resize the picture box based on the board size
            pictureBox1.Width = canvasWidth * dotSize;
            pictureBox1.Height = canvasHeight * dotSize;

            canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.FillRectangle(Brushes.LightGray, 0, 0, canvasBitmap.Width, canvasBitmap.Height);

            pictureBox1.Image = canvasBitmap;

            canvasDotArray = new (int, Color)[canvasWidth, canvasHeight];
        }

        int currentX;
        int currentY;
        private Shape getRandomShapeWithCenterAligned()
        {
            var shape = ShapeHandler.GetRandomShape();

            // calculate the x and y values as if the shape lies in the center
            currentX = 7;
            currentY = -shape.Height;

            return shape;
        }

        Bitmap workingBitmap;
        Graphics workingGraphics;
        private void Timer_Tick(object sender, EventArgs e)
        {
            var isMoveSuccess = moveShapeIfPossible(moveDown: 1);

            // if shape reached bottom or touched any other shapes
            if (!isMoveSuccess)
            {
                // copy working image into canvas image
                canvasBitmap = new Bitmap(workingBitmap);

                updateCanvasDotArrayWithCurrentShape();

                // get next shape
                currentShape = nextShape;
                nextShape = getNextShape();

                clearFilledRowsAndUpdateScore();

                // reset hold availability after a new shape is spawned
                isHoldAvailable = true;
            }
        }

        private void updateCanvasDotArrayWithCurrentShape()
        {
            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] == 1)
                    {
                        checkIfGameOver();

                        canvasDotArray[currentX + i, currentY + j] = (1, currentShape.Colour);
                    }
                }
            }
        }

        private void checkIfGameOver()
        {
            if (currentY < 0)
            {
                timer.Stop();
                MessageBox.Show("Game Over");
                Application.Restart();
            }
        }

        // returns if it reaches the bottom or touches any other blocks
        private bool moveShapeIfPossible(int moveDown = 0, int moveSide = 0)
        {
            var newX = currentX + moveSide;
            var newY = currentY + moveDown;

            // check if it reaches the bottom or side bar
            if (newX < 0 || newX + currentShape.Width > canvasWidth || newY + currentShape.Height > canvasHeight)
                return false;

            // check if it touches any other blocks 
            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (newY + j > 0 && canvasDotArray[newX + i, newY + j].presence == 1 && currentShape.Dots[j, i] == 1)
                        return false;
                }
            }

            currentX = newX;
            currentY = newY;

            drawShape();

            return true;
        }

        private void drawShape()
        {
            workingBitmap = new Bitmap(canvasBitmap);
            workingGraphics = Graphics.FromImage(workingBitmap);

            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] == 1)
                        workingGraphics.FillRectangle(new SolidBrush(currentShape.Colour), (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox1.Image = workingBitmap;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var verticalMove = 0;
            var horizontalMove = 0;

            // calculate the vertical and horizontal move values
            // based on the key pressed
            switch (e.KeyCode)
            {
                // move shape left
                case Keys.Left:
                    verticalMove--;
                    break;

                // move shape right
                case Keys.Right:
                    verticalMove++;
                    break;

                // move shape down faster
                case Keys.Down:
                    horizontalMove++;
                    break;

                // rotate the shape clockwise
                case Keys.Up:
                    currentShape.turn();
                    break;

                // hold the shape
                case Keys.ShiftKey:
                    HoldShape();
                    return;

                // hard drop
                case Keys.Space:
                    HardDrop();
                    return;
                default:
                    return;
            }

            var isMoveSuccess = moveShapeIfPossible(horizontalMove, verticalMove);

            // if the player was trying to rotate the shape, but if not possible -> rollback the shape
            if (!isMoveSuccess && e.KeyCode == Keys.Up)
                currentShape.rollback();
        }

        private void HardDrop()
        {
            // mve the shape down until it can't move anymore
            while (moveShapeIfPossible(moveDown: 1))
            {
                // keep moving down
            }

            // trigger the timer event to handle the shape reaching the bottom
            Timer_Tick(this, EventArgs.Empty);
        }

        private void HoldShape()
        {
            if (!isHoldAvailable)
                return;

            if (heldShape == null)
            {
                heldShape = currentShape;
                currentShape = nextShape;
                nextShape = getNextShape();
            }
            else
            {
                var tempShape = heldShape;
                heldShape = currentShape;
                currentShape = tempShape;
            }

            isHoldAvailable = false;
            updateHeldShapeDisplay();
            currentX = 7;
            currentY = -currentShape.Height;
        }

        private void updateHeldShapeDisplay()
        {
            if (heldShape == null) return;

            // show the held shape in the side panel
            var heldShapeBitmap = new Bitmap(6 * dotSize, 6 * dotSize);
            var heldShapeGraphics = Graphics.FromImage(heldShapeBitmap);

            heldShapeGraphics.FillRectangle(Brushes.LightGray, 0, 0, heldShapeBitmap.Width, heldShapeBitmap.Height);

            // find ideal position for the shape in the side panel
            var startX = (6 - heldShape.Width) / 2;
            var startY = (6 - heldShape.Height) / 2;

            for (int i = 0; i < heldShape.Height; i++)
            {
                for (int j = 0; j < heldShape.Width; j++)
                {
                    heldShapeGraphics.FillRectangle(
                        heldShape.Dots[i, j] == 1 ? new SolidBrush(heldShape.Colour) : Brushes.LightGray,
                        (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox3.Size = heldShapeBitmap.Size;
            pictureBox3.Image = heldShapeBitmap;
        }

        int score;
        public void clearFilledRowsAndUpdateScore()
        {
            // check through each row
            for (int i = 0; i < canvasHeight; i++)
            {
                int j;
                for (j = canvasWidth - 1; j >= 0; j--)
                {
                    if (canvasDotArray[j, i].presence == 0)
                        break;
                }

                if (j == -1)
                {
                    // update score and level values and labels
                    score++;
                    label2.Text = Convert.ToString(score);
                    // increase the speed 
                    timer.Interval -= 10;

                    // update the dot array based on the check
                    for (j = 0; j < canvasWidth; j++)
                    {
                        for (int k = i; k > 0; k--)
                        {
                            canvasDotArray[j, k] = canvasDotArray[j, k - 1];
                        }

                        canvasDotArray[j, 0] = (0, Color.Empty);
                    }
                }
            }

            // draw panel based on the updated array values
            for (int i = 0; i < canvasWidth; i++)
            {
                for (int j = 0; j < canvasHeight; j++)
                {
                    canvasGraphics = Graphics.FromImage(canvasBitmap);
                    canvasGraphics.FillRectangle(
                        canvasDotArray[i, j].presence == 1 ? new SolidBrush(canvasDotArray[i, j].color) : Brushes.LightGray,
                        i * dotSize, j * dotSize, dotSize, dotSize
                        );
                }
            }

            pictureBox1.Image = canvasBitmap;
        }

        Bitmap nextShapeBitmap;
        Graphics nextShapeGraphics;
        private Shape getNextShape()
        {
            var shape = getRandomShapeWithCenterAligned();

            // codes to show the next shape in the side panel
            nextShapeBitmap = new Bitmap(6 * dotSize, 6 * dotSize);
            nextShapeGraphics = Graphics.FromImage(nextShapeBitmap);

            nextShapeGraphics.FillRectangle(Brushes.LightGray, 0, 0, nextShapeBitmap.Width, nextShapeBitmap.Height);

            // find the ideal position for the shape in the side panel for prettiness
            var startX = (6 - shape.Width) / 2;
            var startY = (6 - shape.Height) / 2;

            for (int i = 0; i < shape.Height; i++)
            {
                for (int j = 0; j < shape.Width; j++)
                {
                    nextShapeGraphics.FillRectangle(
                        shape.Dots[i, j] == 1 ? new SolidBrush(shape.Colour) : Brushes.LightGray,
                        (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox2.Size = nextShapeBitmap.Size;
            pictureBox2.Image = nextShapeBitmap;

            return shape;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            return;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            return;
        }
    }
}
