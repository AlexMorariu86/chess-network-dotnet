using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sah
{
    public class King : Piece
    {
        public King(ChessColor color) : base(color) { }

        public override string Name
        {
            get { return "King"; }
        }
        public override bool CanMove(int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            int rowDiff = Math.Abs(toRow - fromRow);
            int colDiff = Math.Abs(toCol - fromCol);
            if (rowDiff <= 1 && colDiff <= 1)
            {
                // vede daca e ocupata sau goala pozitia
                if (board[toRow, toCol] == null || board[toRow, toCol].Color != Color)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
