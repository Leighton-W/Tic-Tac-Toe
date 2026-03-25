
Player game = new Player();

game.Manager.Board.DisplayBoard();
game.Manager.Board.FreshBoard();

while (game.Manager.CheckForEmpty())
{
    game.GetPlayerChoice();
    if (game.Manager.CheckWin() == true)
        { break; }
}

if(game.Manager.CheckWin() == true)
{
    Console.Clear();
    game.Manager.Board.DisplayBoard();
    Console.WriteLine($"Congratulations {game._player} you have won!");
}

if (game.Manager.CheckForDraw())
{
    Console.Clear();
    game.Manager.Board.DisplayBoard();
    Console.WriteLine("It's a Draw!");
}




public class GameManager
{
    public Board Board = new Board();
    public bool CheckForEmpty()
    {
        for (int row = 0; row < Board.square.grid.GetLength(0); row++)
            for (int column = 0; column < Board.square.grid.GetLength(1); column++)
                if (Board.square.grid[row, column] == " ")
                    return true;
        return false;
    }

    public bool CheckWin()
    {
        for (int row = 0; row < Board.square.grid.GetLength(0); row++)
            if (Board.square.grid[row, 0] == Board.square.grid[row, 1] && Board.square.grid[row, 0] == Board.square.grid[row, 2] 
                && Board.square.grid[row, 0] != " ")
                return true;
        for (int column = 0; column < Board.square.grid.GetLength(0); column++)
            if (Board.square.grid[0, column] == Board.square.grid[1, column] && Board.square.grid[0, column] == Board.square.grid[2, column]
                && Board.square.grid[0, column] != " ")
                return true;

        if (Board.square.grid[0, 0] == Board.square.grid[1, 1] && Board.square.grid[0, 0] == Board.square.grid[2, 2]
                && Board.square.grid[0, 0] != " ")
            return true;
        else if (Board.square.grid[0, 2] == Board.square.grid[1, 1] && Board.square.grid[0, 2] == Board.square.grid[2, 0]
                && Board.square.grid[0, 2] != " ")
            return true;

        return false;
    }

    public bool CheckForDraw()
    {
        if (CheckForEmpty() == false && CheckWin() == false)
            return true;
        return false;
    }

}

public class Player
{
    public PlayerTurn Turn { get; set; } = PlayerTurn.Noughts;
    public GameManager Manager = new GameManager(); 
    public string _player { get; set; }

    public void GetPlayerChoice()
    {
        Console.Clear();
        Manager.Board.NumberBoard();

        ChangePlayerTurn();
        Manager.Board.DisplayBoard();
        Console.Write("Player please choose a space. "); 
        string choice = Console.ReadLine();

        while (CheckSquare(choice))
        {
            Console.Write("Please choose an empty space. ");
            choice = Console.ReadLine();
        }

        Manager.Board.UpdateBoard(choice, _player);
        Manager.CheckForEmpty();

    }

    public void ChangePlayerTurn()
    {
        if (Turn == PlayerTurn.Noughts)
        {
            Turn = PlayerTurn.Crosses;
            _player = "X";
        }
        else if (Turn == PlayerTurn.Crosses)
        {
            Turn = PlayerTurn.Noughts;
            _player = "O";
        }
        Console.WriteLine($"It is {_player}'s turn.");
        Console.WriteLine();
    }

    public bool CheckSquare(string choice)
    {
        switch(choice)
        {
            case "1":
                if (Manager.Board.square.grid[0, 0] == " ")
                    return false;
                else if (Manager.Board.square.grid[0, 0] != " ")
                    return true;
                break;
            case "2":
                if (Manager.Board.square.grid[0, 1] == " ")
                    return false;
                else if (Manager.Board.square.grid[0, 1] != " ")
                    return true;
                break;
            case "3":
                if (Manager.Board.square.grid[0, 2] == " ")
                    return false;
                else if (Manager.Board.square.grid[0, 2] != " ")
                    return true;
                break;
            case "4":
                if (Manager.Board.square.grid[1, 0] == " ")
                    return false;
                else if (Manager.Board.square.grid[1, 0] != " ")
                    return true;
                break;
            case "5":
                if (Manager.Board.square.grid[1, 1] == " ")
                    return false;
                else if (Manager.Board.square.grid[1, 1] != " ")
                    return true;
                break;
            case "6":
                if (Manager.Board.square.grid[1, 2] == " ")
                    return false;
                else if (Manager.Board.square.grid[1, 2] != " ")
                    return true;
                break;
            case "7":
                if (Manager.Board.square.grid[2, 0] == " ")
                    return false;
                else if (Manager.Board.square.grid[2, 0] != " ")
                    return true;
                break;
            case "8":
                if (Manager.Board.square.grid[2, 1] == " ")
                    return false;
                else if (Manager.Board.square.grid[2, 1] != " ")
                    return true;
                break;
            case "9":
                if (Manager.Board.square.grid[2, 2] == " ")
                    return false;
                else if (Manager.Board.square.grid[2, 2] != " ")
                    return true;
                break;
        }
        return true;
       
    }

}


public class Grid
{
    public string[,] grid = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
      
}


public class Board
{
    public Grid square = new Grid();
    public string GetValue(int row, int column)
    {
        string value = square.grid[row, column];
        return value;
    }

    public void DisplayBoard()
    {
        string board = $"" +
        $" {GetValue(0,0)} | {GetValue(0,1)} | {GetValue(0,2)} \n" +
        $"---+---+---\n" +
        $" {GetValue(1,0)} | {GetValue(1,1)} | {GetValue(1,2)} \n" +
        $"---+---+---\n" +
        $" {GetValue(2,0)} | {GetValue(2,1)} | {GetValue(2,2)} ";
        Console.WriteLine(board);
        Console.WriteLine();
    }   
    
    public void FreshBoard()
    {
        for (int row = 0; row < square.grid.GetLength(0); row++)
            for (int column = 0; column < square.grid.GetLength(1); column++)
                square.grid[row, column] = " ";
    }

    public void NumberBoard()
    {
        string board = $"" +
        $" 1 | 2 | 3 \n" +
        $"---+---+---\n" +
        $" 4 | 5 | 6 \n" +
        $"---+---+---\n" +
        $" 7 | 8 | 9 ";
        Console.WriteLine(board);
        Console.WriteLine();
    }

    public void UpdateBoard(string choice, string playerTurn)
    {
        string response = choice switch
        {
            "1" => square.grid[0, 0] = playerTurn,
            "2" => square.grid[0, 1] = playerTurn,
            "3" => square.grid[0, 2] = playerTurn,
            "4" => square.grid[1, 0] = playerTurn,
            "5" => square.grid[1, 1] = playerTurn,
            "6" => square.grid[1, 2] = playerTurn,
            "7" => square.grid[2, 0] = playerTurn,
            "8" => square.grid[2, 1] = playerTurn,
            "9" => square.grid[2, 2] = playerTurn
        };
    }
}

public enum PlayerTurn { Noughts, Crosses }

