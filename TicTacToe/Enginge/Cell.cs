using Microsoft.Xna.Framework;

namespace TicTacToe.Enginge
{
    // перечисление возможных состояний для ячейки
    public enum CellState { Default, X, O, VerticalX, VerticalO, HorizontalX, HorizontalO, LeftX, RightX, LeftO, RightO }
    public class Cell
    {
        public int I, J; // индекс (местонахождение в матрице)
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
            I = i; J = j; 
            Coordinates = new Point(i * 20 + i, j * 20 + j);
            State = state;
        }

        /// <summary>
        /// Изменяет статус клетки если она нажата
        /// </summary>
        /// <param name="order">true = X, false = O</param>
        /// <param name="x">Координата клика по Х</param>
        /// <param name="y">Координата клика по У</param>
        /// <returns>True в случае изменения статуса ячейки</returns>
        public bool Click(bool order, int x, int y)
        {
            if(State != CellState.Default)
            {
                return false;
            }
            if(Coordinates.X <= x && Coordinates.X + 20 >= x && Coordinates.Y <= y && Coordinates.Y + 20 >= y)
            {
                State = (order) ? CellState.X : CellState.O;
                return true;
            }
            return false;
        }
    }
}
