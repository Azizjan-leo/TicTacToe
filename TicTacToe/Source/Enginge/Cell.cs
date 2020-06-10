using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Source.Enginge
{
    public enum CellState { Default, X, O, Vertical, Horizontal }
    public class Cell
    {
        public Point Coordinates { get; set; }
        public CellState State { get; set; }

        /// <summary>
        /// Инициализация клетки игрового поля
        /// Если ничего не пришло в качестве параметра,
        /// инициализируем клетку состоянием по умолчанию
        /// </summary>
        /// <param name="state">Состояние</param>
        public Cell(int i, int j, CellState state = CellState.Default)
        {
            Coordinates = new Point(i * 20 + i, j * 20 + j);
            State = state;
        }
    }
}
