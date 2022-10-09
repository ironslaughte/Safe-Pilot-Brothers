using System;

namespace The_safe_of_the_Pilot_brothers
{
    public enum HandleType { CLOSE = 0, OPEN = 1 }

    public class SafeModel
    {
        private HandleType[][] _handles;

        public int Dimension { get; private set; }   

        public SafeModel(int dimension)
        {
            Dimension = dimension;
            
            AllocateHandles();
            RandomInitHandles();
        }

        public SafeModel(HandleType[][] handles, int dimension)
        {
            _handles = CopyArray(handles);
            Dimension = dimension;
        }

        public void SetHandles(HandleType[][] handlesToCopy) => _handles = CopyArray(handlesToCopy);

        public static HandleType[][] CopyArray(HandleType[][] arrToCopy)
        {
            HandleType[][] newArr = new HandleType[arrToCopy.Length][];

            for (int i = 0; i < arrToCopy.Length; i++)
            {
                newArr[i] = new HandleType[arrToCopy.Length];
                arrToCopy[i].CopyTo(newArr[i], 0);
            }

            return newArr;
        }
        
        public HandleType[][] GetHandles() => _handles;

        public HandleType GetHandle(int i, int j) => _handles[i][j];

        public void TurnHandle(int row, int column)
        {
            for (int i = 0; i < Dimension; i++)
            {
                _handles[row][i] = Utils.ChangeHandleState(_handles[row][i]);
                _handles[i][column] = Utils.ChangeHandleState(_handles[i][column]);
            }

            _handles[row][column] = Utils.ChangeHandleState(_handles[row][column]);
        }

        public bool CheckWin()
        {
            HandleType boardState = _handles[0][0];

            for(int i = 0; i < Dimension; i++)
                for(int j = 0; j < Dimension; j++)
                    if (_handles[i][j] != boardState) 
                        return false;
                    
            return true;
        }

        private void RandomInitHandles()
        {
            Random rand = new Random();

            do
            {
                for (int i = 0; i < Dimension; i++)
                    for (int j = 0; j < Dimension; j++)
                        _handles[i][j] = (HandleType)rand.Next(2);

            } while (CheckWin());
        }
        private void AllocateHandles()
        {
            _handles = new HandleType[Dimension][];
            for (int i = 0; i < Dimension; i++)
                _handles[i] = new HandleType[Dimension];
        }
    }
}
