using System.Windows.Forms;
using System.Drawing;
using System;

namespace The_safe_of_the_Pilot_brothers
{
    public partial class GameView : Form
    {
        private PicturesModel _picturesModel;
        private GameModel _game;

        private int _dimension;

        private const int BorderFormOffsetY = 5;

        public GameView(GameModel game, PicturesModel imageModel, int dimension)
        {                    
            InitializeComponent();
            SwitchButtonState(false);
            InitializeData(game, imageModel, dimension);

            _picturesModel.InitPics(Controls, PictureBoxes_Click, allocatePics: true);
        }
     
        private void RestartButton_Click(object sender, EventArgs e)
        {
            _game.ResetToOriginalHandlesState();

            _picturesModel.InitPics(Controls, PictureBoxes_Click, allocatePics: false);
            GameStart();
        }

        private void PictureBoxes_Click(object sender, EventArgs e)
        {
            ProcessTurnedHandle((PictureBox)sender);
            CheckWinCondition();
        }

        private void StartButton_Click(object sender, EventArgs e) => GameStart();

        private void RebootButton_Click(object sender, EventArgs e) => Close();

        private void InitializeData(GameModel game, PicturesModel imageModel, int dimension)
        {
            BackColor = Color.White;
            _dimension = dimension;

            _picturesModel = imageModel;
            _game = game;
        }

        private void ProcessTurnedHandle(PictureBox pictureBox)
        {
            var indexes = Utils.ParseIndexesPic(pictureBox.Name);

            _game.TurnHandle(indexes.Item1, indexes.Item2);
            _picturesModel.ChangeHandlesPics(indexes.Item1, indexes.Item2);
        }

        private void GameStart()
        {
            SwitchButtonState(true);

            _picturesModel.ShowPics();
            ChangeFormSize();
        }

        private void ChangeFormSize()
        {
            int differenceY = GetDifferenceFormY();
            
            Height += differenceY + BorderFormOffsetY;
        }

        private int GetDifferenceFormY()
        {
            int idxLastCoordPics = _dimension - 1;
            int yPicCoordLast =  _picturesModel.GetPicLocation(idxLastCoordPics);

            return yPicCoordLast - Height;
        }

        private void CheckWinCondition()
        {
            if (_game.CheckWinCondition())
            {
                MessageBox.Show(_game.VictoryCongratsMessage);
                Close();
            }
        }

        private void SwitchButtonState(bool enabled) => restartButton.Enabled = enabled;
    }
}