using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Enginge;

namespace TicTacToe
{
    public class DrawHelper
    {
        private static SpriteBatch _spriteBatch;

        Texture2D _default, _x, _o, _verticalX, _verticalO, _horizontalX, _horizontalO;


        public Point FC { get; set; } // Field Corner

        public List<Point> MissShots = new List<Point>();

        public DrawHelper(SpriteBatch spriteBatch, Texture2D def, Texture2D x, Texture2D o, Texture2D verticalX, Texture2D verticalO, Texture2D horizontalX, Texture2D horizontalO)
        {
            _spriteBatch = spriteBatch;
            _default = def;
            _x = x;
            _o = o;
            _verticalX = verticalX;
            _verticalO = verticalO;
            _horizontalX = horizontalX;
            _horizontalO = horizontalO;
        }
        public void DrawCell(Cell cell)
        {

            switch (cell.State)
            {
                case CellState.Default:
                    _spriteBatch.Draw(_default, new Vector2(cell.Coordinates.X, cell.Coordinates.Y), Color.White);
                    break;
                case CellState.X:
                    _spriteBatch.Draw(_x, new Vector2(cell.Coordinates.X, cell.Coordinates.Y), Color.White);
                    break;
                case CellState.O:
                    _spriteBatch.Draw(_o, new Vector2(cell.Coordinates.X, cell.Coordinates.Y), Color.White);
                    break;
                case CellState.VerticalX:
                    _spriteBatch.Draw(_verticalX, new Vector2(cell.Coordinates.X, cell.Coordinates.Y), Color.White);
                    break;
                case CellState.VerticalO:
                    _spriteBatch.Draw(_verticalO, new Vector2(cell.Coordinates.X, cell.Coordinates.Y), Color.White);
                    break;
                case CellState.HorizontalX:
                    _spriteBatch.Draw(_horizontalX, new Vector2(cell.Coordinates.X, cell.Coordinates.Y), Color.White);
                    break;
                case CellState.HorizontalO:
                    _spriteBatch.Draw(_horizontalO, new Vector2(cell.Coordinates.X, cell.Coordinates.Y), Color.White);
                    break;
                default:
                    break;
            }
        }
    }
}
