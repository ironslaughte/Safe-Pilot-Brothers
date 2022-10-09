using System.Windows.Forms;
using System;

namespace The_safe_of_the_Pilot_brothers
{
    public partial class Bootstrapper : Form
    {
        public Bootstrapper()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                int dimension = InitDemension();

                GameModel game = new GameModel(dimension);
                PicturesModel picturesModel = new PicturesModel(game, dimension);

                using (GameView gameView = new GameView(game, picturesModel, dimension))
                {
                    this.Hide();
                    gameView.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private int InitDemension()
        {
            int dimension = Int32.Parse(textBox1.Text);
            if (dimension <= 1 || dimension % 2 != 0)
                throw new ArgumentException("Невозможно решить задачу с такой размерностью");
            return dimension;
        }
    }
}
