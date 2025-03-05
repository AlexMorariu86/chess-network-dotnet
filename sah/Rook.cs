using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sah
{
    public class Rook : Piece
    {
        public Rook(ChessColor color) : base(color) { }

        public override string Name
        {
            get { return "Rook"; }
        }

        public override bool CanMove(int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            if (fromRow == toRow)
            {
                // merge orizontal
                int start = Math.Min(fromCol, toCol);
                int end = Math.Max(fromCol, toCol);
                for (int col = start + 1; col < end; col++)
                {
                    if (board[fromRow, col] != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (fromCol == toCol)
            {
                // merge vrtical
                int start = Math.Min(fromRow, toRow);
                int end = Math.Max(fromRow, toRow);
                for (int row = start + 1; row < end; row++)
                {
                    if (board[row, fromCol] != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                // nu merge nicicum
                return false;
            }
        }
    }
}
