using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sah
{
    public abstract class Piece
    {
        public enum ChessColor { White, Black }

        private ChessColor color;

        public Piece(ChessColor color)
        {
            this.color = color;
        }

        public ChessColor Color
        {
            get { return color; }
            set { color = value; }
        }

        public ChessColor Opposite()
        {
            return color == ChessColor.White ? ChessColor.Black : ChessColor.White;
        }

        public abstract string Name { get; }

        public virtual void Move(int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            Console.WriteLine($"Moving {Name} from ({fromRow}, {fromCol}) to ({toRow}, {toCol})");
            board[toRow, toCol] = this;
            board[fromRow, fromCol] = null;
            Console.WriteLine($"Moved {Name} to ({toRow}, {toCol})");
        }

        public abstract bool CanMove(int fromRow, int fromCol, int toRow, int toCol, Piece[,] board);

    }
}
