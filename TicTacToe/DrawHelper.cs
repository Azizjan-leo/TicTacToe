using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Source.Enginge;

namespace TicTacToe
{
    public class DrawHelper
    {
        private static SpriteBatch _spriteBatch;

        Texture2D _default, _x, _o, _vertical, _horizontal;


        public Point FC { get; set; } // Field Corner

        public List<Point> MissShots = new List<Point>();

        public DrawHelper(SpriteBatch spriteBatch, Texture2D def, Texture2D x, Texture2D o, Texture2D vertical, Texture2D horizontal)
        {
            _spriteBatch = spriteBatch;
            _default = def;
            _x = x;
            _o = o;
            _vertical = vertical;
            _horizontal = horizontal;
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
                case CellState.Vertical:
                    _spriteBatch.Draw(_vertical, new Vector2(cell.Coordinates.X, cell.Coordinates.Y), Color.White);
                    break;
                case CellState.Horizontal:
                    _spriteBatch.Draw(_horizontal, new Vector2(cell.Coordinates.X, cell.Coordinates.Y), Color.White);
                    break;
                default:
                    break;
            }
        }
    }
}
