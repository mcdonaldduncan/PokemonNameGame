using PokemonNameGame.Data;
using PokemonNameGame.GameServices;
using PokemonNameGame.Logging;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace PokemonNameGame.Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbLogger _dbLogger = new DbLogger();
        DataService _dataService = new DataService();
        DisplayService _displayService = new DisplayService();

        GameFactory _factory = new GameFactory();
        GameService _gameService;

        List<Type> _types = new List<Type>();
        List<Generation> _generations = new List<Generation>();

        private GameState _gameState;

        public GameState GameState 
        {
            get => _gameState; 
            set
            {
                _gameState = value;
                HandleState();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            BindDropDowns();

            GameState = GameState.CREATE;
        }

        void BindDropDowns()
        {
            try
            {
                _types = _dataService.GetTypes();
                cb_Type.ItemsSource = _types;
                cb_Type.DisplayMemberPath = "Name";

                _generations = _dataService.GetGenerations();
                cb_Region.ItemsSource = _generations;
                cb_Region.DisplayMemberPath = "RegionName";
            }
            catch (System.Exception e)
            {
                _dbLogger.LogError("Error Collecting Types and Generations", e);
            }
        }

        void HandleState()
        {
            switch (GameState)
            {
                case GameState.CREATE:
                    grd_CreateGame.Visibility = Visibility.Visible;
                    grd_EndGame.Visibility = Visibility.Collapsed;
                    grd_PlayGame.Visibility = Visibility.Collapsed;
                    break;
                case GameState.PLAY:
                    grd_CreateGame.Visibility = Visibility.Collapsed;
                    grd_EndGame.Visibility = Visibility.Collapsed;
                    grd_PlayGame.Visibility = Visibility.Visible;
                    break;
                case GameState.RESULT:
                    grd_CreateGame.Visibility = Visibility.Collapsed;
                    grd_EndGame.Visibility = Visibility.Visible;
                    grd_PlayGame.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }

            cb_Type.BorderBrush = Brushes.Gray;
            cb_Region.BorderBrush = Brushes.Gray;
        }

        void RefreshLists()
        {
            var game = _gameService.GetGame();
            tb_Actual.Text = _displayService.FormatPokemonCollection(game.actual);
            tb_PlayGuessed.Text = _displayService.FormatPokemonCollection(game.guessed);
            tb_Guessed.Text = _displayService.FormatPokemonCollection(game.guessed);
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            if (cb_Region.SelectedIndex == -1 || cb_Type.SelectedIndex == -1) return;

            var type = _types[cb_Type.SelectedIndex];
            var generation = _generations[cb_Region.SelectedIndex];

            wd_Main.Background = (SolidColorBrush)new BrushConverter().ConvertFrom($"#{type.HexColor}");

            var game = _factory.CreateGame(type.ID, generation.ID);
            _gameService = new GameService(game);

            lbl_Type.Content = type.Name;
            lbl_Region.Content = generation.RegionName;

            GameState = GameState.PLAY;
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (_gameService.GuessPokemon(tb_PlayerGuess.Text))
            {
                if (_gameService.CheckGameOver()) GameState = GameState.RESULT;
                tb_PlayerGuess.BorderBrush = Brushes.Green;
                tb_PlayerGuess.Text = string.Empty;
            }
            else
            {
                tb_PlayerGuess.BorderBrush = Brushes.Red;
            }

            RefreshLists();
        }

        private void btn_Done_Click(object sender, RoutedEventArgs e)
        {
            tb_Score.Text = _displayService.FormatScore(_gameService.GetGame());
            GameState = GameState.RESULT;
        }

        private void btn_Restart_Click(object sender, RoutedEventArgs e)
        {
            GameState = GameState.CREATE;
        }
    }
}

public enum GameState
{
    CREATE,
    PLAY,
    RESULT
}
