using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Source.Enginge
{
    public class Field
    {
        Cell[,] Matrix;

        /// <summary>
        /// Инициализация игрового поля
        /// </summary>
        /// <param name="n">Размерность игровой матрицы</param>
        public Field(int n)
        {
            Matrix = new Cell[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matrix[i, j] = new Cell(i, j); 
                }
            }
        }

        public void DrawField(DrawHelper helper)
        {
            foreach (var cell in Matrix)
            {
                helper.DrawCell(cell);
            }
        }
    }
}
