using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sah
{
    public class Bishop : Piece
    {
        public Bishop(ChessColor color) : base(color) { }

        public override string Name
        {
            get { return "Bishop"; }
        }
        public override bool CanMove(int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            if (fromRow == toRow && toCol == fromCol)
                return false;
            if (Math.Abs(toRow - fromRow) == Math.Abs(toCol - fromCol))
            {
                int rowDir = Math.Sign(toRow - fromRow);
                int colDir = Math.Sign(toCol - fromCol);
                int row = fromRow + rowDir;
                int col = fromCol + colDir;
                while (row != toRow && col != toCol)
                {
                    if (board[row, col] != null)
                    {
                        return false;
                    }
                    row += rowDir;
                    col += colDir;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
