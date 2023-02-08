using System.Drawing;
using System.Runtime.InteropServices;

namespace echo;

class Tile
{
    // Tile object for pond grid
    public string type = string.Empty;
    public char character = '.';

}
class Grid
{
    // Pond grid containing tiles of water/ pebble/ splash
    public static int size = 30; // Determines the size of the pond
    public Tile[,] grid = generateGrid();

    public static Tile[,] generateGrid()
    {
        Tile[,] generatedGrid = new Tile[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                generatedGrid[i, j] = new Tile
                {
                    type = "water",
                    character = '.'
                };

            }
        }
        return generatedGrid;
    }

    public void OutputGrid()
    {
        // Prints out the current contents of the pond to the console
        //string top = new string('_', size);
        //string bottom = new string('-', size);
        //Console.Write($"\n  {top}\n");
        for (int x = 0; x < size; x++)
        {
            //Console.Write("| ");
            for (int y = 0; y < size; y++)
            {
                int[] xy = { x, y };
                UpdateTileOutput(xy);
            }
            //Console.Write("\n");
        }
        //Console.Write($"  {bottom}");
    }

    public void UpdateGrid()
    {
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                int[] xy = { x, y };
                UpdateTileOutput(xy);
            }
        }
    }
    public void UpdateTileOutput(int[] xy)
    {
        int x = xy[0];
        int y = xy[1];
        Console.SetCursorPosition(x, y);
        Console.Write(grid[x, y].character);
        //Console.SetCursorPosition(0, size + 1);
    }
    public int[] GenerateRandXY()
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

    public int changeTileType(int[] coord, string type)
    {
        // Changes tile type using xy coordinates
        char character = 'X';
        if (type.Contains("water"))
        {
            character = '.';
        }
        if (type.Contains("pebble"))
        {
            character = '0';
        }
        if (type.Contains("splash"))
        {
            character = '°';
        }
        try {
            grid[coord[0], coord[1]].type = type;
            grid[coord[0], coord[1]].character = character;
            UpdateTileOutput(coord);
            return 0;
        }
        catch(IndexOutOfRangeException)
        {
            return 1;
        }
        
    }

    public void ChangeTyleColor(int[] coord, ConsoleColor color) {
        Console.SetCursorPosition(coord[0], coord[1]);
        Console.ForegroundColor = color;
    }


    public void DrawCircle(int[] center, int radius, string type)
    {
        int centerX = center[0];
        int centerY = center[1];
        int check = size ^ 2;
        if (radius <= check) {
            for (int y = centerY - radius; y <= centerY + radius; y++)
            {
                for (int x = centerX - radius; x <= centerX + radius; x++)
                {
                    if (x <= size && y <= size)
                    {
                        int distance = (int)Math.Round(Math.Sqrt((x - centerX) * (x - centerX) + (y - centerY) * (y - centerY)));
                        int[] coord = { x, y };
                        if (distance == radius && x<size && y<size && x>=0 && y>=0)
                        {
                            if (grid[x,y].type != "pebble")
                            {
                                changeTileType(coord, type);
                            }                            
                        }
                        if (x == centerX && y == centerY)
                        {
                            changeTileType(coord, "pebble");
                        }
                    }

                }
            }
        }
        
    }

    public void SimulateRipple(int[] coord)
    {
        int a = 0;
        if (coord[0] >= coord[1])
        {
            a = coord[0] +size;
        }
        else
        {
            a = coord[1] +size;
        }
        DrawCircle(coord, 1, "splash");
        for (int i = 2; i < a; i++)
        {
            DrawCircle(coord, i-1, "water");
            DrawCircle(coord, i, "splash");
            Thread.Sleep(15);
        }
    }

    public void startInterface()
    {
        int[] OldCoord = {0,0 };
        int x = 0;
        int y = 0;
        int[] coord = {x, y};
        Console.SetCursorPosition(x, y);
        while (true)
        {
            ConsoleKeyInfo ki = Console.ReadKey();
            if(ki.Key == ConsoleKey.Escape) {
                break;
                    }
            if (ki.Key == ConsoleKey.Enter) {
                coord[0] = x;
                coord[1] = y;
                changeTileType(coord, "pebble");
                SimulateRipple(coord);

            }
            if (ki.Key == ConsoleKey.UpArrow)
            {
                y--;
                coord[1] = y;
                Console.SetCursorPosition(x, y);
            }
            if (ki.Key == ConsoleKey.DownArrow)
            {
                y++;
                coord[1] = y;
                Console.SetCursorPosition(x, y);
            }
            if (ki.Key == ConsoleKey.LeftArrow)
            {
                x--;
                coord[0] = x;
                Console.SetCursorPosition(x, y);
            }
            if (ki.Key == ConsoleKey.RightArrow)
            {
                x++;
                coord[0] = x;
                Console.SetCursorPosition(x, y);
            }
            
            
        }
    }


}
class Program
{
    public static void Main(string[] args)
    {
        Grid board = new Grid();
        board.OutputGrid();
        board.startInterface();
            
        }
}