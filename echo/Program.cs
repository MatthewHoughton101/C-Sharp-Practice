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
    public static int size = 50; // Determines the size of the pond
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
        for (int i = 0; i < size; i++)
        {
            //Console.Write("| ");
            for (int j = 0; j < size; j++)
            {
                Console.Write(grid[i, j].character);
            }
            Console.Write("\n");
        }
        //Console.Write($"  {bottom}");
    }

    public void UpdateGrid()
    {
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(grid[x, y].character);
            }
        }
    }
    public void UpdateTileOutput(int[] xy)
    {
        int x = xy[0];
        int y = xy[1];
        Console.SetCursorPosition(x, y);
        Console.Write(grid[x, y].character);
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

    public void changeTile(int[] coord, string type)
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
            character = 'o';
        }
        grid[coord[0], coord[1]].type = type;
        grid[coord[0], coord[1]].character = character;
        UpdateTileOutput(coord);
    }


}
class Program
{
    public static void Main(string[] args)
    {
        Grid board = new Grid();
        board.OutputGrid();

        for (int i = 0; i < 15; i++)
        {
            int[] xy = board.GenerateRandXY();
            board.changeTile(xy, "pebble");
            Thread.Sleep(50);
        }
    }
}