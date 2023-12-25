namespace MatrixBinder_Dotnet7.Components.Model;

public class TileModel
{
    //bs
    protected int count = 0;
    public int Count => count;

    public MatrixModel parent { get; protected set; }

    public TileModel(MatrixModel parent, int count = 0)
    {
        this.count = count;
        this.parent = parent;
    }
}
