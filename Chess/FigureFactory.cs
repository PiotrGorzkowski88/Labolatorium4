using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_chess.Chess
{
    class FigureFactory
    {
        public static Figure GetFigure(FigureType figureType, ChessColor color, Position position)
        {

            Figure figure = null;

            switch (figureType)
            {
                case FigureType.Bishop:
                    figure = new Bishop();
                    break;
                case FigureType.Castle:
                    figure = new Castle();
                    break;
                case FigureType.King:
                    figure = new King();
                    break;
                case FigureType.Pawn:
                    figure = new Pawn();
                    break;
                default:
                    throw new Exception("This FigureType doesn't exists.");
            }

            figure.Color = color;
            figure.Position = position;

            return figure;
        }
        
    }
}
