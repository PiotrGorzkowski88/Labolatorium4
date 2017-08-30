using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_chess.Chess
{
    class SigletonToolbox
    {
        private static ChessBoard chessBoard = new ChessBoard();
        private static Position Cursor = new Position(0, 0);

        public static void PutFigure(Figure figure)
        {
            chessBoard.Add(figure.Position, figure);
        }

        public static int Count()
        {
            return chessBoard.Count();
        }

        public static bool IsFigureOn(Position position)
        {
            return chessBoard.IsFigureOn(position);
        }

        public static void DrawOnConsole()
        {
            //Select Figure
            Figure selectedFigure = null;
            if(IsFigureOn(Cursor))
            {
                selectedFigure = chessBoard[Cursor];
            }

            //Write indent
            Console.Write("   ");

            //Write header (x)
            for(int i = 0; i < 8; i++)
            {
                Console.Write(" " + i + " ");
            }

            //Write newline
            Console.WriteLine();

            for(int j = 0; j < 8; j++)
            {
                //Write row header
                Console.Write(j + ": ");

                //Write figures
                for(int i = 0; i < 8; i++)
                {
                    Position position = new Position(i, j);
                    if(IsFigureOn(position) )
                    {
                        Figure figureToWrite = chessBoard[position];
                        if (Cursor.Equals(position))
                        {
                            Console.Write("[" + figureToWrite + "]");
                        } else
                        {
                            if (selectedFigure != null && selectedFigure.CanMove(position))
                            {
                                Console.Write("<" + figureToWrite + ">");
                            } else
                            {
                                Console.Write(" " + figureToWrite + " ");
                            }
                        }
                    } else
                    {
                        if (Cursor.Equals(position))
                        {
                            Console.Write("[ ]");
                        }
                        else
                        {
                            if (selectedFigure != null && selectedFigure.CanMove(position))
                            {
                                Console.Write("< >");
                            } else
                            {
                                Console.Write("   ");
                            }
                        }
                    }
                }
                Console.WriteLine();
            }

            //Write informations
            Console.WriteLine("Cursor position is " + Cursor + ". On chessboard is " + chessBoard.Count() + " figures.");
        }

        public static void CursorMoveUp()
        {
            if (Cursor.Y > 0)
                Cursor.Y--;
        }

        public static void CursorMoveDown()
        {
            if (Cursor.Y < 7)
                Cursor.Y++;
        }

        public static void CursorMoveLeft()
        {
            if (Cursor.X > 0)
                Cursor.X--;
        }

        public static void CursorMoveRight()
        {
            if (Cursor.X < 7)
                Cursor.X++;
        }
    }
}
