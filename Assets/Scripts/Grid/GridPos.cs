


public struct GridPos
{
    public int x;
    public int z;

    public GridPos(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override string ToString()
    {
        return "x:" + x + ": z:" + z;
    }
}