using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    internal class Gra
    {
        private int[,] gameTable;
        public Gra()
        {
            gameTable = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        }
        public void Shuffle()
        {
            Random rand = new Random();
            int n = gameTable.GetLength(0);
            for (int i = n - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    int m = rand.Next(i + 1);
                    int k = rand.Next(j + 1);

                    Switch(i, j, m, k);
                }
            }
        }
        public void Switch(int x1,int y1, int x2, int y2)
        {
            int temp = gameTable[x1, y1];
            gameTable[x1, y1] = gameTable[x2, y2];
            gameTable[x2, y2] = temp;
        }
        public bool Win()
        {
            if (gameTable[0,0]==1 & gameTable[0,1]==2 & gameTable[0,2]==3 & gameTable[1,0]==4 & gameTable[1,1]==5 & gameTable[1,2]==6 & gameTable[2,0]==7 & gameTable[2,1]==8 & gameTable[2,2]==9)
            { return true; }
            else
            { return false; }
        }
        public bool GameMovement(Button button1, Button button2)
        {
            int row1 = Grid.GetRow(button1);
            int column1 = Grid.GetColumn(button1);
            int row2 = Grid.GetRow(button2);
            int column2 = Grid.GetColumn(button2);

            return (Math.Abs(row1 - row2) + Math.Abs(column1 - column2)) == 1;
        }
        public int[,] GetGameStatus
        {
            get { return gameTable; }
        }
    }
}
