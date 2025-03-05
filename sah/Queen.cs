using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sah
{
    public class Queen : Piece
    {
        public Queen(ChessColor color) : base(color) { }

        public override string Name
        {
            get { return "Queen"; }
        }

        public override bool CanMove(int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            // merge in diagonala
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
            // merge drept
            else if (fromRow == toRow || fromCol == toCol)
            {
                if (fromRow == toRow)
                {
                    //merge pe orizontala
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
                else
                {
                    // merge pe verticala
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
            }
            // nu merge nicicum
            else
            {
                return false;
            }
        }
    }
}
