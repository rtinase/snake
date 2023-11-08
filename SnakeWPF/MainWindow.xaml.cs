using System.Windows;
using System.Windows.Input;
using SnakeCore;

namespace SnakeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Game game;
        private Ui ui;
        private GameSettings gameSettings;

        public MainWindow()
        {
            InitializeComponent();
            gameSettings = new GameSettings(30, 20);
            ui = new Ui(this, gameSettings);
            game = new Game(ui, gameSettings);
            game.StartGame();
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    game.Move(MovementSide.Up);
                    break;
                case Key.Down:
                    game.Move(MovementSide.Down);
                    break;
                case Key.Left:
                    game.Move(MovementSide.Left);
                    break;
                case Key.Right:
                    game.Move(MovementSide.Right);
                    break;
                case Key.R:
                    game.Restart();
                    break;
                case Key.P:
                    game.Pause();
                    break;
            }
        }

        private void Settings_OnClick(object sender, RoutedEventArgs e)
        {
            _ = new Settings(this);
        }

        private void StartNewGame()
        {
            game.GameOver();
            ui = new Ui(this, gameSettings);
            game = new Game(ui, gameSettings);
            game.StartGame();
        }

        public void ChangeSettings(int boardSize, int speed)
        {
            gameSettings = new GameSettings(boardSize, speed);
            StartNewGame();
        }

        public string GetBoardSize()
        {
            return gameSettings.BoardSize.ToString();
        }

        public string GetSpeed()
        {
            return gameSettings.Speed.ToString();
        }
    }
    
}