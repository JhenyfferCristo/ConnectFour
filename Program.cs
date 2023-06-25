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
            Console.Write(Name + "'s Turn. Please enter a column number between 1 and 7: ");
            int column= int.Parse(Console.ReadLine());
            return column;
        }

    }

    public class ComputerPlayer : Player
    {
        public override int MakeMove(char[,] board)
        {
            Radom radom = new Random();
            int column;
            do
            {
                column = radom.Next(1,8);
            } while (board [1, column] == 'X' || board[1, column] == 'O');
            
            return column;
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
                Console.WriteLine("Play Connect Four\n");
            }
        }

    
    }
}
  