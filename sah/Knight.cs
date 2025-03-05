using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sah
{
    public class Knight : Piece
    {
        public Knight(ChessColor color) : base(color) { }

        public override string Name
        {
            get { return "Knight"; }
        }

        public override bool CanMove(int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            int rowDiff = Math.Abs(toRow - fromRow);
            int colDiff = Math.Abs(toCol - fromCol);
            if ((rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2))
            {
                // daca e pozitia goala sau e piesa inamica
                if (board[toRow, toCol] == null || board[toRow, toCol].Color != Color)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
