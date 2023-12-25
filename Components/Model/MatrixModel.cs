namespace MatrixBinder_Dotnet7.Components.Model;

public delegate void TileUpdateHandler(int x, int y, TileModel newValue);

public class MatrixModel
{
    /// <summary>
    /// Event to catch model change more easily, 
    /// you only need to attach a NotifyPropertyChanged lambda to it 
    /// and the magic happens on it's own
    /// </summary>
    public event TileUpdateHandler TileUpdate;

    /// <summary>
    /// A [Y][X] based matrix representation of the given tiles
    /// </summary>
    protected TileModel[][] tiles;

    public TileModel GetTile(int y, int x) => tiles[y][x];
    public void SetTileAt(int y, int x, TileModel tile)
    {
        tiles[y][x] = tile;
        TileUpdate?.Invoke(y, x, tile);
    }

    public MatrixModel(int width, int height) {
        tiles = new TileModel[height][];
        for (int y = 0; y < height; y++) {
            tiles[y] = new TileModel[width];
            for (int x = 0; x < width; x++)
            {
                tiles[y][x] = new TileModel(this, 0);
            }
        }
    }
}
