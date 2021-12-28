
using System;

[Serializable]
public class Item_
{
    public string spritePath;
    public string objPath;

    public override bool Equals(object other)
    {
        if ((other == null) || !this.GetType().Equals(other.GetType()))
        {
            return false;
        }
        else
        {
            Item_ item = (Item_)other;
            return spritePath == item.spritePath && objPath == item.objPath;
        }
    }

    public override int GetHashCode()
    {
        return spritePath.GetHashCode() ^ objPath.GetHashCode();
    }
}
