using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tic_tac_toe.Models;

namespace tic_tac_toe.Services
{
    public class GameService
    {
        public static int PlayerDecider = 0;
        public static int[,] values = new int[3, 3] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };
        public int[,] GameState()
        {
            return values;
        }

        public String AddPosition(Position position)
        {
            if (PlayerDecider == 0)
                PlayerDecider = position.PlayerId;
            if (PlayerDecider == position.PlayerId)
            {
                if (values[position.X_Coordinate, position.Y_Coordinate] == -1)
                {
                    values[position.X_Coordinate, position.Y_Coordinate] = position.PlayerId;
                    UnSetPlayerDecider(position.PlayerId);
                    return "ok";
                }
                else
                    return "can't";

            }
            return "bad_request";

        }

        private void UnSetPlayerDecider(int playerId)
        {
            if (playerId == 1)
                PlayerDecider = 2;
            else
                PlayerDecider = 1;
        }

        internal bool IsLastMove()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (values[i, j] == -1)
                        return false;
                }
            return true;
        }

        public void ResetGame()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    values[i, j] = -1;
        }

        public Boolean IsWin(int X_Coordinate, int Y_Coordinate)
        {
            var sum = X_Coordinate + Y_Coordinate;
            if (values[X_Coordinate, Y_Coordinate] != -1)
            {
                if (Colomn(X_Coordinate, Y_Coordinate))
                    return true;
                else if (Row(X_Coordinate, Y_Coordinate))
                    return true;
                else if (!(sum == 1 || sum == 3))
                    return Diagonal(X_Coordinate, Y_Coordinate);
                else
                    return false;
            }
            else
                return false;


        }
        public Boolean Colomn(int X_Coordinate, int Y_Coordinate)
        {
            for (int i = 0; i < 3; i++)
            {
                if (values[i, Y_Coordinate] != values[X_Coordinate, Y_Coordinate])
                    return false;
            }
            return true;
        }
        public Boolean Row(int X_Coordinate, int Y_Coordinate)
        {
            for (int i = 0; i < 3; i++)
            {
                if (values[X_Coordinate, i] != values[X_Coordinate, Y_Coordinate])
                    return false;
            }
            return true;
        }
        public Boolean Diagonal(int X_Coordinate, int Y_Coordinate)
        {
            if (X_Coordinate == 1 && Y_Coordinate == 1)
            {
                if (LeadingDiagnol(X_Coordinate, Y_Coordinate) || CounterDiagnol(X_Coordinate, Y_Coordinate))
                    return true;
                else
                    return false;
            }
            else if (X_Coordinate == Y_Coordinate)
                return LeadingDiagnol(X_Coordinate, Y_Coordinate);
            else
                return CounterDiagnol(X_Coordinate, Y_Coordinate);
        }

        public Boolean LeadingDiagnol(int X_Coordinate, int Y_Coordinate)
        {
            for (int i = 0; i < 3; i++)
            {
                if (values[i, i] != values[X_Coordinate, Y_Coordinate])
                    return false;
            }
            return true;
        }

        public Boolean CounterDiagnol(int X_Coordinate, int Y_Coordinate)
        {
            for (int i = 0; i < 3; i++)
            {
                if (values[i, 2 - i] != values[X_Coordinate, Y_Coordinate])
                    return false;
            }
            return true;
        }
    }
}
