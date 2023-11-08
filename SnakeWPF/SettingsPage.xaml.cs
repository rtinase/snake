using System;
using System.Windows;

namespace SnakeWPF;

public partial class Settings
{
    private readonly MainWindow window;

    public Settings(MainWindow window)
    {
        InitializeComponent();

        Visibility = Visibility.Visible;
        this.window = window;

        SizeInputBox.Text = window.GetBoardSize();
        SpeedInputBox.Text = window.GetSpeed();
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        window.ChangeSettings(Convert.ToInt32(SizeInputBox.Text), Convert.ToInt32(SpeedInputBox.Text));
    }
}