using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;


namespace sah
{
	public partial class Game : Form
	{
		private Piece[,] board;
		int destCol = 0, destRow = 0, fromCol = 0, fromRow = 0;
		bool turn = true;
		Thread thread;
		TcpListener server;
		TcpClient client;
		NetworkStream stream;
		public Game(int gameType)
		{
			InitializeComponent();
			InitializeBoard();
			IPAddress localHost = IPAddress.Parse("127.0.0.1");
			Int32 port = 3000;
			if(gameType == 1)
			{
				createServer();
				thread = new Thread(Listen);
				thread.Start();
				this.Text = "Server";
			}
			else
			{
				createClient("127.0.0.1", "Created a client");
				thread = new Thread(Listen);
				thread.Start();
				this.Text = "Client";
			}
		

			DrawBoard();
		}

		private void createClient(string server, string message)
		{
			try
			{
				Int32 port = 8000;

				client = new TcpClient(server,port);
				stream = client.GetStream();
			}
			catch(ArgumentNullException e)
			{
				Console.WriteLine("ArgumentNullException: {0}", e);
			}
			catch (SocketException se)
			{
				Console.WriteLine("SocketException: {0}", se);
			}
		}

		private void createServer()
		{
			server = null;
			try
			{
				Int32 port = 8000;
				IPAddress localHost = IPAddress.Parse("127.0.0.1");
				server = new TcpListener(localHost, port);

				server.Start();

				while (true)
				{
					Console.WriteLine("Waiting for a connection... ");

					client = server.AcceptTcpClient();
					stream = client.GetStream();
					break;
					//MessageBox.Show("Connected!");


				}

			}
			catch(SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
			}
		}

		public void SendData(int oldRow, int oldCol, int newRow, int newCol)
		{
			string message = String.Format("{0},{1};{2},{3}", oldRow, oldCol, newRow, newCol);


			Byte[] bytes = new Byte[256];

			stream = client.GetStream();

			string serverMessage = message;
			byte[] initialMessageBytes = Encoding.ASCII.GetBytes(serverMessage);
			stream.Write(initialMessageBytes, 0, initialMessageBytes.Length);


		}

		private void Listen()
		{

			Byte[] bytes = new Byte[256];
			String responseData = String.Empty;

			while (true)
			{
				while (true)
				{
					Int32 data = stream.Read(bytes, 0, bytes.Length);
					if (data != 0)
					{
						responseData = System.Text.Encoding.ASCII.GetString(bytes, 0, data);
						break;
					}

				}
				string[] parsedMessage = responseData.Split(';');
				string[] newPos = parsedMessage[1].Split(',');
				string[] oldPos = parsedMessage[0].Split(',');

				int oldRow = int.Parse(oldPos[0]);
				int oldCol = int.Parse(oldPos[1]);
				int newRow = int.Parse(newPos[0]);
				int newCol = int.Parse(newPos[1]);
				Piece piece = board[oldRow, oldCol];
				this.Invoke((MethodInvoker)delegate
				{ piece.Move(oldRow, oldCol, newRow, newCol, board);
					board[newRow, newCol] = piece;
					board[oldRow, oldCol] = null;

					// Update position of piece on screen
					Panel oldSquare = GetSquare(oldRow, oldCol);
					Panel newSquare = GetSquare(newRow, newCol);
					Image pieceImage = (Image)oldSquare.BackgroundImage;
					oldSquare.BackgroundImage = (null);
					newSquare.BackgroundImage = (pieceImage);

					this.selectingPiece = false;

					turn = !turn;
					Controls.Clear();
					DrawBoard();
				});
				
			}
		}

		void Game_Load(object sender, EventArgs e)
		{

		}
		void InitializeBoard()
		{
			board = new Piece[8, 8];

			board[0, 0] = new Rook(Piece.ChessColor.Black);
			board[0, 1] = new Knight(Piece.ChessColor.Black);
			board[0, 2] = new Bishop(Piece.ChessColor.Black);
			board[0, 3] = new Queen(Piece.ChessColor.Black);
			board[0, 4] = new King(Piece.ChessColor.Black);
			board[0, 5] = new Bishop(Piece.ChessColor.Black);
			board[0, 6] = new Knight(Piece.ChessColor.Black);
			board[0, 7] = new Rook(Piece.ChessColor.Black);
			for (int i = 0; i < 8; i++)
			{
				board[1, i] = new Pawn(Piece.ChessColor.Black);
			}

			board[7, 0] = new Rook(Piece.ChessColor.White);
			board[7, 1] = new Knight(Piece.ChessColor.White);
			board[7, 2] = new Bishop(Piece.ChessColor.White);
			board[7, 3] = new Queen(Piece.ChessColor.White);
			board[7, 4] = new King(Piece.ChessColor.White);
			board[7, 5] = new Bishop(Piece.ChessColor.White);
			board[7, 6] = new Knight(Piece.ChessColor.White);
			board[7, 7] = new Rook(Piece.ChessColor.White);
			for (int i = 0; i < 8; i++)
			{
				board[6, i] = new Pawn(Piece.ChessColor.White);
			}
		}

		private Image GetChessPieceImage(Piece piece)
		{
			string color = piece.Color == Piece.ChessColor.White ? "white" : "black";
			string name = piece.Name.ToLower();
			string filename = $"C:\\Users\\senon\\Desktop\\sah\\sah\\piese\\{color}{name}.png";
			return Image.FromFile(filename);
		}

		private void DrawBoard()
		{
			for (int row = 0; row < 8; row++)
			{
				for (int col = 0; col < 8; col++)
				{
					Panel square = new Panel();
					square.Size = new Size(64, 64);
					square.Location = new Point(col * 64, row * 64);
					if ((row + col) % 2 == 0)
					{
						square.BackColor = Color.White;
					}
					else
					{
						square.BackColor = Color.Gray;
					}
					Controls.Add(square);

					Piece piece = board[row, col];
					if (piece != null)
					{
						PictureBox image = new PictureBox();
						image.Size = new Size(64, 64);
						image.Location = new Point(0, 0);
						image.Image = GetChessPieceImage(piece);
						square.BackgroundImage = image.Image;

						square.Click += new EventHandler(Square_Click);
					}
					else
					{
						square.Click += new EventHandler(Square_Click);
					}
				}
			}
		}

		bool selectingPiece = false;
		private void Square_Click(object sender, EventArgs e)
		{

			Panel square = (Panel)sender;


			int clickedRow = square.Location.Y / 64;
			int clickedCol = square.Location.X / 64;
			Piece selectedPiece = board[clickedRow, clickedCol];

			if (this.selectingPiece == false && 
				((turn == true && selectedPiece.Color == Piece.ChessColor.White) || (turn == false && selectedPiece.Color == Piece.ChessColor.Black)))
			{
				fromRow = clickedRow;
				fromCol = clickedCol;
				this.selectingPiece = true;
			}

			else
			{
				selectedPiece = board[fromRow, fromCol];
				if (selectedPiece!=null && ((turn == true && selectedPiece.Color == Piece.ChessColor.White) || (turn == false && selectedPiece.Color == Piece.ChessColor.Black)))
				{
					
					if (selectedPiece != null &&
					selectedPiece.CanMove(fromRow, fromCol, clickedRow, clickedCol, board))

					{
						Application.DoEvents();

						destRow = clickedRow;
						destCol = clickedCol;

						// se muta piesa
						selectedPiece.Move(fromRow, fromCol, destRow, destCol, board);

						// se da update la piesa pe tabla
						board[destRow, destCol] = selectedPiece;
						board[fromRow, fromCol] = null;

						// se da update vizual la piesa pe tabla
						Panel oldSquare = GetSquare(fromRow, fromCol);
						Panel newSquare = GetSquare(destRow, destCol);
						Image pieceImage = (Image)oldSquare.BackgroundImage;
						oldSquare.BackgroundImage = (null);
						newSquare.BackgroundImage = (pieceImage);

						SendData(fromRow, fromCol, destRow, destCol);
						// se redeseneaza tabla
						Controls.Clear();
						DrawBoard();

						// se "elibereaza" selectingpiece pentru urmatorul jucator
						this.selectingPiece = false;

						// se schimba randul
						turn = !turn;
					}
					else
					{
						this.selectingPiece = false;
						
						MessageBox.Show("Invalid move!");
					}
				}
			}
		}


		private Panel GetSquare(int row, int col)
		{
			foreach (Control control in Controls)
			{
				if (control is Panel)
				{
					Panel square = (Panel)control;
					if (square.Location.Y / 64 == row && square.Location.X / 64 == col)
					{
						return square;
					}
				}
			}
			return null;
		}
	}
}





