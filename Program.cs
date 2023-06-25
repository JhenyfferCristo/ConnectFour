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
            board = new char[lenght +3, width +2];
            trueWidth = width;
            trueLength = lenght;
        }

        public char[,] Board { get { return board; } }

        public bool IsColumnFull(int column)
        {
         
            return board[1, column] == 'X' || board[1, column] == 'O';

        }

        public void PlacePiece(int column, char piece)
        {
            for (int row = trueLength; row >= 1; row--) 
            {
                if (board[row,column] != 'X' && board[row,column] != 'O')
                {
                    board[row,column] = piece;
                    break;
                }
            }
        }

        public bool CheckWin(char piece)
        {
            for (int row = trueLength; row >= 1; row--)
            {
                for (int col = trueWidth; col >= 1; col--)
                {
                    if (board[row, col] == piece &&
                        (board[row - 1, col - 1] == piece && board[row - 2, col - 2] == piece && board[row - 3, col - 3] == piece ||
                         board[row, col - 1] == piece && board[row, col - 2] == piece && board[row, col - 3] == piece ||
                         board[row - 1, col] == piece && board[row - 2, col] == piece && board[row - 3, col] == piece ||
                         board[row - 1, col + 1] == piece && board[row - 2, col + 2] == piece && board[row - 3, col + 3] == piece ||
                         board[row, col + 1] == piece && board[row, col + 2] == piece && board[row, col + 3] == piece))
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public bool IsBoardFull()
        {
            for (int col = 1; col <= trueWidth; col++)
            {
                if (board[1,col] != 'X' && board[1,col] != 'O')
                {
                    retun false;
                }
            }

            return true;
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
  