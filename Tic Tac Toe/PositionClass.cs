using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class PositionClass
    {
        private int row;
        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }

        private int column;
        public int Column
        {
            get { return this.column; }
            set { this.column = value; }
        }

        public PositionClass()
        {
            Row = Column = 0;
        }

        public PositionClass(int _row, int _column)
        {
            Row = _row;
            Column = _column;
        }
    }
}
