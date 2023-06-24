using System;

namespace ConnectFour
{
    public abstract class Player
    {
        public string Name { get; set; }
        public char ID { get; set; }

        public abstract int MakeMove(char[,] board);
    }

    public class HumanPlayer : Player
    {
        public override int MakeMove(char[,] board)
        {

        }
    }

    public class ComputerPlayer : Player
    {
        public override int MakeMove(char[,] board)
        {

        }
    }

    public class GameBoard
    {
        private char[,] board;
        private int trueWidth;
        private int trueLength;

        public GameBoard(int width, int lenght)
        {

        }

        public bool IsColumnFull(int column)
        {

        }

        public void PlacePiece(int column, char piece)
        {

        }

        public bool CheckWin(char piece)
        {

        }

        public bool IsBoardFull()
        {

        }

    }

    public class GamePlayer 
    { 
    private GameBoard board;
    private Player playerOne;
    private Player playerTwo; 

     public GamePlayer()
        {
            board = new GameBoard(7, 6);
        }

        public void StartGame()
        {

        }

        private Player GetPlayer()
        {

        }

        private void PlayGame()
        {

        }

        private void DisplayBoard()
        {

        }

        public class Program
        {
            public static void Main(string[] args)
            {

            }
        }

    
    }
}
  