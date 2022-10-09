using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace The_safe_of_the_Pilot_brothers
{
    public class PicturesModel
    {
        public int Dimension { get; private set; }

        private readonly PictureBox[,] _pics;
        private readonly GameModel _game;

        private readonly Image _openHandlePic;
        private readonly Image _closeHandlePic;

        private const int PicsBoxSize = 50;
        private const int PicsInitialOffsetX = 12;
        private const int PicsInitialOffsetY = 70;
        private const int PicsBoxOffset = 60;

        private const string OrangePicPath = @".\Pictures\\OrangeHandle.png";
        private const string BluePicPath = @".\Pictures\\BlueHandle.png";
        
        public PicturesModel(GameModel game, int dimension)
        {
            Dimension = dimension;

            _openHandlePic = Image.FromFile(OrangePicPath);
            _closeHandlePic = Image.FromFile(BluePicPath);

            _pics = new PictureBox[Dimension, Dimension];
            _game = game;
        }

        public void InitPics(Control.ControlCollection Controls, MouseEventHandler clickAction, bool allocatePics)
        {
            for (var i = 0; i < Dimension; i++)
            {
                for (var j = 0; j < Dimension; j++)
                {
                    if (allocatePics)
                    {
                        _pics[i, j] = new PictureBox();
                        _pics[i, j].MouseClick += clickAction;
                    }

                    _pics[i, j].Location = new Point(PicsInitialOffsetX + (PicsBoxOffset * i), PicsInitialOffsetY + (PicsBoxOffset * j));
                    _pics[i, j].Size = new Size(PicsBoxSize, PicsBoxSize);
                    _pics[i, j].Image = _game.IsHandleOpened(i, j) ? _openHandlePic : _closeHandlePic;                   
                    _pics[i, j].Name = $"{i},{j}";

                    if (allocatePics)
                        Controls.Add(_pics[i, j]);

                    _pics[i, j].Hide();
                }
            }
        }

        public void ChangeHandlesPics(int row, int column)
        {
            for (int i = 0; i < Dimension; i++)
            {
                _pics[row, i].Image = GetImageByHandleState(row, i);
                _pics[i, column].Image = GetImageByHandleState(i, column);
            }

            _pics[row, column].Image = GetImageByHandleState(row, column);
        }

        public void ShowPics()
        {
            for (var i = 0; i < Dimension; i++)
                for (var j = 0; j < Dimension; j++)
                    _pics[i, j].Show();
        }

        public int GetPicLocation(int lastPicIndex) => _pics[lastPicIndex, lastPicIndex].Location.Y;
        
        private Image GetImageByHandleState(int i, int j) 
            => _game.IsHandleOpened(i, j) ? _openHandlePic : _closeHandlePic;
    }
}