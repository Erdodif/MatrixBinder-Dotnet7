using System.Windows.Input;

using MatrixBinder_Dotnet7.Components.Model;
using MatrixBinder_Dotnet7.Components.Utility;

namespace MatrixBinder_Dotnet7.Components.ViewModel;

public class TileViewModel : PropertyNotifier
{
    #region Properties
    private TileModel tile;
    public TileModel Tile
    {
        get => tile;
        set
        {
            this.tile = value;
            NotifyPropertyChanged();
        }
    }

    /// <summary>
    /// Virtual Column Position
    /// </summary>
    public int X { get; protected set; }

    /// <summary>
    /// Virtual Row Position
    /// </summary>
    public int Y { get; protected set; }

    /// <summary>
    /// Visible Text
    /// </summary>
    public string Text { get => $"({Y},{X}); {tile}"; }
    #endregion

    #region Constructor
    public TileViewModel(int y, int x, TileModel tile)
    {
        this.Y = y;
        this.X = x;
        this.tile = tile;
    }
    #endregion

    #region ClickCommand
    /// <summary>
    /// Function that can determine whether the Command should be clickable or not
    /// </summary>
    /// <returns>Boolean value to represent the command's availability</returns>
    public bool ClickCommandCanExecute(object _) => true;

    /// <summary>
    /// Method that has Current Object's scope, and runs the needed operation 
    /// when the corresponding View element is activated (Button click most likely)
    /// </summary>
    private void ClickCommandFunction(object _)
    {
        Application.Current.MainPage.DisplayAlert($"({Y},{X})", "Click On position", "NoNo");
    }

    /// <summary>
    /// Click command, using it's helper functions, so no init needed in the constructor
    /// </summary>
    private SmartCommand clickCommand;

    /// <summary>
    /// Publicly Available ICommand, 'cause the MAUI reflection based Binding can only see ICommand interface definition
    /// </summary>
    public ICommand ClickCommand
    {
        get => clickCommand ??= new SmartCommand(ClickCommandCanExecute,ClickCommandFunction);
    }
    #endregion

}