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
            int column = int.Parse(Console.ReadLine());
            return column;
        }

    }

    public class ComputerPlayer : Player
    {
        public override int MakeMove(char[,] board)
        {
            Random random = new Random();
            int column;
            do
            {
                column = random.Next(1,8);
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
                    return false;
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
            playerOne = GetPlayer("Player One");
            playerOne.ID = 'X';

            playerTwo = GetPlayer("Player Two");
            playerTwo.ID = 'O';

            PlayGame();
        }

        private Player GetPlayer(string playerName)
        {
            Console.WriteLine(playerName + ", please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Choose player type:");
            Console.WriteLine("1. Human Player");
            Console.WriteLine("2. Computer Player");
            Console.Write("Enter player type (1-2): ");
            int playerType = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Player player;
            if (playerType == 1)
            {
                player = new HumanPlayer();
            }
            else
            {
                player = new ComputerPlayer();
            }

            player.Name = name;
            return player;
        }

        private void PlayGame()
        {
            int currentPlayer = 1;
            do
            {
                Player currentPlayerObj;
                if (currentPlayer == 1)
                {
                    currentPlayerObj = playerOne;
                }
                else
                {
                    currentPlayerObj = playerTwo;
                }
                Console.Clear();
                DisplayBoard();

                int move;
                do
                {
                    move = currentPlayerObj.MakeMove(board.Board);
                    if (IsInvalidMove(move) || board.IsColumnFull(move))
                    {
                        Console.WriteLine("Invalid move. Please try again.");
                    }
                }while (IsInvalidMove(move) || board.IsColumnFull(move));

                board.PlacePiece(move, currentPlayerObj.ID);

                if(board.CheckWin(currentPlayerObj.ID))
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine(currentPlayerObj.Name + " Connected Four! You Win!");
                    break;
                }

                if (board.IsBoardFull())
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine("The board is full. It's a draw!");
                    break;
                }

                if (currentPlayer == 1)
                {
                    currentPlayer = 2;
                }
                else
                {
                    currentPlayer = 1;
                }
            }while(true);
        }

        private bool IsInvalidMove(int move)
        {
            return move < 1 || move > 7;
        }

        private void DisplayBoard()
        {
            for (int row = 1; row <= board.Board.GetLength(0) - 3; row++)
            {
                Console.Write("|");
                for (int col = 1; col <= board.Board.GetLength(1) - 2; col++)
                {
                    if (board.Board[row, col] != 'X' && board.Board[row, col] != 'O')
                    {
                        board.Board[row, col] = '*';
                    }

                    Console.Write(board.Board[row, col]);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine();
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Play Connect Four!\n");

                GamePlayer gameController = new GamePlayer();
                gameController.StartGame();
            }
        }

    
    }
}
  