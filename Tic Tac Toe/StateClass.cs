using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class StateClass
    {
        private string[][] data;
        public string[][] Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        private List<StateClass> childs;
        public List<StateClass> Childs
        {
            get { return this.childs; }
            set { this.childs = value; }
        }

        private int score;
        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        public StateClass()
        {
            Data = new string[3][];
            Data[0] = new string[3];
            Data[1] = new string[3];
            Data[2] = new string[3];
            Childs = new List<StateClass>();            
        }

        public StateClass(string[][] _data)
        {
            Data = new string[3][];
            for (int i = 0; i < 3; i++)
            {
                Data[i] = new string[3];
                for (int j = 0; j < 3; j++)
                    Data[i][j] = _data[i][j];
            }
            Childs = new List<StateClass>();
        }

        public List<PositionClass> CreateMoves()
        {
            List<PositionClass> Moves = new List<PositionClass>();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (this.Data[i][j] == null)
                    {                        
                        PositionClass ch = new PositionClass(i,j);
                        Moves.Add(ch);
                    }

            return Moves;
        }

        private bool Win(string Player)
        {
            bool flag = true;

            if (Data[0][0] == Player && Data[1][1] == Player && Data[2][2] == Player)
                return true;

            if (Data[0][2] == Player && Data[1][1] == Player && Data[2][0] == Player)
                return true;

            //rows
            for (int i = 0; i < 3; i++)
            {
                flag = true;
                for (int j = 0; j < 3; j++)
                    if (Data[i][j] != Player)
                    {
                        flag = false;
                        break;
                    }

                if (flag == true)
                    return true;
            }

            //columns
            for (int i = 0; i < 3; i++)
            {
                flag = true;
                for (int j = 0; j < 3; j++)
                    if (Data[j][i] != Player)
                    {
                        flag = false;
                        break;
                    }

                if (flag == true)
                    return true;
            }

            return false;
        }

        public int CalculateScore(StateClass game, string HumanPlayer, string AIPlayer)
        {
            if (game.Win(HumanPlayer))
                return 10;
            if (game.Win(AIPlayer))
                return -10;
            return 0;
        }

        public StateClass GetNewState(PositionClass move, string player)
        {
            StateClass temp = new StateClass();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    temp.Data[i][j] = this.Data[i][j];

            temp.Data[move.Row][move.Column] = player;

            return temp;
        }

        public bool IsFinish()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (this.Data[i][j] == null)
                        return false;
            return true;
        }
    }
}
