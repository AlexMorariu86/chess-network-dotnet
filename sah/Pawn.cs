using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sah
{
    public class Pawn : Piece
    {
        public Pawn(ChessColor color) : base(color) { }

        public override string Name
        {
            get { return "Pawn"; }
        }

        public override bool CanMove(int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            int rowDiff = toRow - fromRow;
            int colDiff = Math.Abs(toCol - fromCol);
            if (Color == ChessColor.White)
            {
                if (rowDiff == -1 && colDiff == 0 && board[toRow, toCol] == null)
                {
                    // merge cu unu in fata
                    return true;
                }
                else if (rowDiff == -2 && colDiff == 0 && fromRow == 6 && board[5, fromCol] == null && board[4, fromCol] == null)
                {
                    // merge cu 2 in fata daca e la inceput
                    return true;
                }
                else if (rowDiff == -1 && colDiff == 1 && board[toRow, toCol] != null && board[toRow, toCol].Color == ChessColor.Black)
                {
                    // captureaza in diagonala
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (rowDiff == 1 && colDiff == 0 && board[toRow, toCol] == null)
                {
                    // merge cu unu in fata
                    return true;
                }
                else if (rowDiff == 2 && colDiff == 0 && fromRow == 1 && board[2, fromCol] == null && board[3, fromCol] == null)
                {
                    // merge cu 2 in fata daca e la inceput
                    return true;
                }
                else if (rowDiff == 1 && colDiff == 1 && board[toRow, toCol] != null && board[toRow, toCol].Color == ChessColor.White)
                {
                    // captureaza pe diagonala
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
