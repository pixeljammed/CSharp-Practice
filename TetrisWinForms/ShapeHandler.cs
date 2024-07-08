using System;
using TetrisWinForms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TetrisWinForms;

static class ShapeHandler
{
    private static Shape[] shapesArray;

    static ShapeHandler()
    {
        shapesArray = new Shape[]
            {
                // SHAPES - CREATED IN A GRID OF: 1 = block, 0 = blank

                // Cube
                new Shape {
                    Width = 2,
                    Height = 2,
                    Colour = Color.Yellow,
                    Dots = new int[,]
                    {
                        { 1, 1 },
                        { 1, 1 }
                    }
                },

                // Line
                new Shape {
                    Width = 1,
                    Height = 4,
                    Colour = Color.LightBlue,
                    Dots = new int[,]
                    {
                        { 1 },
                        { 1 },
                        { 1 },
                        { 1 }
                    }
                },

                // T shape
                new Shape {
                    Width = 3,
                    Height = 2,
                    Colour = Color.Purple,
                    Dots = new int[,]
                    {
                        { 0, 1, 0 },
                        { 1, 1, 1 }
                    }
                },

                // L shape
                new Shape {
                    Width = 3,
                    Height = 2,
                    Colour = Color.Orange,
                    Dots = new int[,]
                    {
                        { 0, 0, 1 },
                        { 1, 1, 1 }
                    }
                },
                
                // J shape
                new Shape {
                    Width = 3,
                    Height = 2,
                    Colour = Color.Indigo,
                    Dots = new int[,]
                    {
                        { 1, 0, 0 },
                        { 1, 1, 1 }
                    }
                },

                // Z shape
                new Shape {
                    Width = 3,
                    Height = 2,
                    Colour = Color.Red,
                    Dots = new int[,]
                    {
                        { 1, 1, 0 },
                        { 0, 1, 1 }
                    }
                },

                // S shape
                new Shape {
                    Width = 3,
                    Height = 2,
                    Colour = Color.LightGreen,
                    Dots = new int[,]
                    {
                        { 0, 1, 1 },
                        { 1, 1, 0 }
                    }
                }
            };
    }

    // GET A RANDOMLY SELECTED SHAPE
    // ADDED BAG SYSTEM

    static int bagNum = 7;

    public static Shape GetRandomShape()
    {
        Console.WriteLine(bagNum);

        if (bagNum == 7)
        {
            (new Random()).Shuffle(shapesArray);
            bagNum = 0;
        }

        var shape = shapesArray[bagNum];

        bagNum += 1;

        return shape;
    }
}