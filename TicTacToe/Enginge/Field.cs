namespace TicTacToe.Enginge
{
    public class Field
    {
        Cell[,] Matrix;
        public int PointsX; // очки первого игрока
        public int PointsO; // очки второго игрока
        public bool Order; // очередь хода: true = X игрок; false = O игрок
        int steps; // количество ходов отводимые игроку

        /// <summary>
        /// Инициализация игрового поля
        /// </summary>
        /// <param name="n">Размерность игровой матрицы</param>
        public Field(int n)
        {
            Matrix = new Cell[n, n];
            for (int i = 0; i < n; i++) // горизонталь
            {
                for (int j = 0; j < n; j++) // вертикаль
                {
                    Matrix[i, j] = new Cell(i, j); 
                }
            }
            // инициализируем очки нулями
            PointsX = 0;
            PointsO = 0;
            // первым пойдет игрок X
            Order = true;
            // ходить он будет 1 раз
            steps = 1;
        }

        /// <summary>
        /// Проверяет есть ли не занятые ячейки
        /// </summary>
        /// <returns>True, если все ячейки заняты</returns>
        public bool IsFull()
        {
            foreach (var cell in Matrix)
            {
                if (cell.State == CellState.Default) // CellState.Default = Незанятая ячейка
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Рисует ячейки
        /// </summary>
        /// <param name="helper"></param>
        public void DrawField(DrawHelper helper)
        {
            foreach (var cell in Matrix) // нарисуем каждую ячейку
            {
                helper.DrawCell(cell);
            }
        }

        /// <summary>
        /// Обрабатывает клик
        /// </summary>
        /// <param name="x">X координата клика</param>
        /// <param name="y">Y координата клика</param>
        /// <returns>True, если игрок поставил свой знак</returns>
        public bool Click(int x, int y)
        {
            foreach (var cell in Matrix)
            {
                if (cell.Click(Order, x, y)) // если игрок нажал на свободную ячейку
                {
                    steps--; // отнимаем у него 1 шаг
                    if (TryLine(cell)) // линия образована
                    {
                        Order = !Order; // передаем право хода другому игроку
                        steps = 2; // даём ему 2 шага
                    }
                    else // линия не образована
                    {
                        if(steps == 0) // если количество шагов текущего игрока истекло
                        {
                            Order = !Order; // передаем право хода другому игроку
                            steps = 1; // даём ему 1 шаг
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверяет образовалась ли линия
        /// Если да, состояние задействованных ячеек
        /// </summary>
        /// <param name="cell">Нажатая ячейка</param>
        /// <returns>True, если образовалась линия</returns>
        public bool TryLine(Cell cell)
        {
            bool result = false;
            CellState tmp = cell.State; // запоминаем состояние текущей ячейки
            // проверки от нажатой ячейки
            // если линия есть, то присваиваем всем трём ячейкам одно состояние
            // присваиваемое состояние зависит от предыдущего состояния ячейки
            // если там был Х, то ставим сотояние определенный в зависимости от направления Х (с O по аналогии)
            if (cell.I < Matrix.GetLength(0) - 1 && Matrix[cell.I + 1, cell.J].State == cell.State && Matrix[cell.I + 2, cell.J].State == cell.State) // вправо по горизонтали
            {
                Matrix[cell.I, cell.J].State = Matrix[cell.I + 1, cell.J].State = Matrix[cell.I + 2, cell.J].State = (cell.State == CellState.X) ? CellState.HorizontalX : CellState.HorizontalO;
                result = true;
            }
            else if (cell.I > 1 && Matrix[cell.I - 1, cell.J].State == cell.State && Matrix[cell.I - 2, cell.J].State == cell.State) // влево по горизонтали
            {
                Matrix[cell.I, cell.J].State = Matrix[cell.I - 1, cell.J].State = Matrix[cell.I - 2, cell.J].State = (cell.State == CellState.X) ? CellState.HorizontalX : CellState.HorizontalO;
                result = true;
            }
            else if (cell.J < Matrix.GetLength(1) - 1 && Matrix[cell.I, cell.J + 1].State == cell.State && Matrix[cell.I, cell.J + 2].State == cell.State) // вниз по вертикали
            {
                Matrix[cell.I, cell.J].State = Matrix[cell.I, cell.J + 1].State = Matrix[cell.I, cell.J + 2].State = (cell.State == CellState.X) ? CellState.VerticalX : CellState.VerticalO;
                result = true;
            }
            else if (cell.J > 1 && Matrix[cell.I, cell.J - 1].State == cell.State && Matrix[cell.I, cell.J - 2].State == cell.State) // вверх по вертикали
            {
                Matrix[cell.I, cell.J].State = Matrix[cell.I, cell.J - 1].State = Matrix[cell.I, cell.J - 2].State = (cell.State == CellState.X) ? CellState.VerticalX : CellState.VerticalO;
                result = true;
            }
            else if (cell.I > 1 && cell.J > 1 && Matrix[cell.I - 1, cell.J - 1].State == cell.State && Matrix[cell.I - 2, cell.J - 2].State == cell.State) // вверх и влево
            {
                Matrix[cell.I, cell.J].State = Matrix[cell.I - 1, cell.J - 1].State = Matrix[cell.I - 2, cell.J - 2].State = (cell.State == CellState.X) ? CellState.LeftX : CellState.LeftO;
                result = true;
            }
            else if (cell.I < Matrix.GetLength(0) - 2 && cell.J < Matrix.GetLength(1) - 2 && Matrix[cell.I + 1, cell.J + 1].State == cell.State && Matrix[cell.I + 2, cell.J + 2].State == cell.State) // вниз и вправо
            {
                Matrix[cell.I, cell.J].State = Matrix[cell.I + 1, cell.J + 1].State = Matrix[cell.I + 2, cell.J + 2].State = (cell.State == CellState.X) ? CellState.LeftX : CellState.LeftO;
                result = true;
            }
            else if (cell.I < Matrix.GetLength(0) - 2 && cell.J > 1 && Matrix[cell.I + 1, cell.J - 1].State == cell.State && Matrix[cell.I + 2, cell.J - 2].State == cell.State) // вверх и вправо
            {
                Matrix[cell.I, cell.J].State = Matrix[cell.I + 1, cell.J - 1].State = Matrix[cell.I + 2, cell.J - 2].State = (cell.State == CellState.X) ? CellState.RightX : CellState.RightO;
                result = true;
            }
            else if (cell.I > 1 && cell.J < Matrix.GetLength(1) && Matrix[cell.I - 1, cell.J + 1].State == cell.State && Matrix[cell.I - 2, cell.J + 2].State == cell.State) // вверх и вправо
            {
                Matrix[cell.I, cell.J].State = Matrix[cell.I - 1, cell.J + 1].State = Matrix[cell.I - 2, cell.J + 2].State = (cell.State == CellState.X) ? CellState.RightX : CellState.RightO;
                result = true;
            }
            // если игрок соединил 3 клетки,
            if (result == true)
            {
                // определяем игрока, сделавшего ход и добавим ему очко
                if (tmp == CellState.X)
                    PointsX++;
                else
                    PointsO++;
            }
                return result;
        }
    }
}
