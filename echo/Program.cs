using System.Drawing;
using System.Globalization;

namespace echo;

class Tile
{
    // Tile object for pond grid
    public string type = string.Empty;
    public string character = string.Empty;

}
class Grid{
    // Pond grid containing tiles of water/ pebble/ splash
    public static int size = 50;
    public static Tile[,] grid = generateGrid();

    public static Tile[,] generateGrid()
    {
        Tile[,] generatedGrid = new Tile[size,size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                generatedGrid[i, j] = new Tile
                {
                    type = "water",
                    character = "."
                };
                
            }
        }
        return generatedGrid;
    }

    public void OutputGrid()
    {
        // Prints out the current contents of the pond to the console
        string top = new string('_', size);
        string bottom = new string('-', size);
        Console.Write($"\n  {top}\n");
        for (int i = 0; i< size; i++)
        {
            Console.Write("| ");
            for(int j = 0; j < size; j++)
            {
                Console.Write(grid[i,j].character);
            }
            Console.Write(" |\n");
        }
        Console.Write($"  {bottom}");
    }
    public static int[] GenerateRandXY()
    {
        // Generate random X Y coordinates
        int[] randXY = new int[2];
        Random rd = new Random();
        int rx = rd.Next(0, size - 1);
        int ry = rd.Next(0, size - 1);
        randXY[0] = rx;
        randXY[1] = ry;
        return randXY;
    }

    
}
class Program
{
    public static void Main(string[] args)
    {
        Grid board= new Grid();
        board.OutputGrid();
    }
}