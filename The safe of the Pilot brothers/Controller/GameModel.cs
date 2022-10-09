namespace The_safe_of_the_Pilot_brothers
{
    public class GameModel
    {
        private readonly HandleType[][] _originalHandleStates;
        private readonly SafeModel _safe;

        public readonly string VictoryCongratsMessage = "Вы открыли сейф, поздравляю!";

        public GameModel(int dimension)
        {
            _safe = new SafeModel(dimension);
            _originalHandleStates = SafeModel.CopyArray(_safe.GetHandles());
        }

        public void ResetToOriginalHandlesState() => _safe.SetHandles(_originalHandleStates);

        public void TurnHandle(int row, int column) => _safe.TurnHandle(row, column);

        public bool IsHandleOpened(int i, int j) => _safe.IsHandleOpened(i, j);

        public bool CheckWinCondition() => _safe.CheckWin();
    }
}