public class Door 
{
    public int tile1;
    public int tile2;
    public bool exists;

    public Door()
    {

    }

    public Door(bool exists)
    {
        this.exists = exists;
    }

    public Door(int tile1, int tile2, bool exists)
    {
        this.tile1 = tile1;
        this.tile2 = tile2;
        this.exists = exists;
    }


}
