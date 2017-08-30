using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_chess.Chess;

namespace pg_chess
{
    class Program
    {
        static void Header()
        {
            Console.WriteLine("#######################################################");
            Console.WriteLine("##                     C H E S S                     ##");
            Console.WriteLine("#######################################################");
            Console.WriteLine("            Please use WSAD to move cursor.");
            Console.WriteLine("                     Type Q to exit.");
            Console.WriteLine();
        }

        static void CheckNewAndOverride()
        {
            Console.WriteLine("Checking new and override differences...\n");
            Pawn p = new Pawn();
            Console.Write(p); //Child class
            Figure f = p;
            Console.WriteLine(f); //Parent class
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            CheckNewAndOverride();
            
            SigletonToolbox.PutFigure(FigureFactory.GetFigure(FigureType.Pawn, ChessColor.Black, new Position(1, 1)));
            SigletonToolbox.PutFigure(FigureFactory.GetFigure(FigureType.King, ChessColor.White, new Position(1, 3)));
            SigletonToolbox.PutFigure(FigureFactory.GetFigure(FigureType.Pawn, ChessColor.White, new Position(4, 4)));
            SigletonToolbox.PutFigure(FigureFactory.GetFigure(FigureType.Bishop, ChessColor.White, new Position(5, 5)));
            SigletonToolbox.PutFigure(FigureFactory.GetFigure(FigureType.King, ChessColor.Black, new Position(3, 3)));
            SigletonToolbox.PutFigure(FigureFactory.GetFigure(FigureType.Castle, ChessColor.White, new Position(2, 6)));


            //Main loop
            while (true)
            {
                Console.Clear();
                Header();
                SigletonToolbox.DrawOnConsole();
            
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.KeyChar)
                {
                    case 'w':
                        SigletonToolbox.CursorMoveUp();
                        break;
                    case 's':
                        SigletonToolbox.CursorMoveDown();
                        break;
                    case 'a':
                        SigletonToolbox.CursorMoveLeft();
                        break;
                    case 'd':
                        SigletonToolbox.CursorMoveRight();
                        break;
                    case 'q':
                        return;
                    default:
                        break;
                }
                
            }
        }
    }
}
