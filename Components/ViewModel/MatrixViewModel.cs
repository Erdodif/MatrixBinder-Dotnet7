using System.Collections.ObjectModel;

using MatrixBinder_Dotnet7.Components.Model;
using MatrixBinder_Dotnet7.Components.Utility;
namespace MatrixBinder_Dotnet7.Components.ViewModel;

public class MatrixViewModel : PropertyNotifier
{
    #region Properties
    protected int rowCount;
    protected int columnCount;
    public int RowCount { get => rowCount; }
    public int ColumnCount { get => columnCount; }

    private MatrixModel matrix;

    #region XAML Properties
    public RowDefinitionCollection RowDefinitions { get; set; }
    public ColumnDefinitionCollection ColumnDefinitions { get; set; }

    public ObservableCollection<TileViewModel> Tiles { get; set; }
    #endregion
    #endregion

    #region Constructor
    /// <summary>
    /// This should have all the necesarry properties that the modell needs
    /// </summary>
    public MatrixViewModel(int width,int height)
    {
        Tiles = new ObservableCollection<TileViewModel>();
        ColumnDefinitions = new ColumnDefinitionCollection();
        RowDefinitions = new RowDefinitionCollection();
        matrix = new MatrixModel(width,height);
        matrix.TileUpdate += (y, x, tile) => Tiles[rowCount * y + x].Tile = tile; 
    }
    #endregion

    #region Methods
    public void Resize(int width, int height)
    {
        columnCount = width;
        rowCount = height;
    }
    #endregion
}
