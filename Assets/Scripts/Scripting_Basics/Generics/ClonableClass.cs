using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonableClass: IClonable<ClonableClass>
{
    public int life;
    public int power;
    public string name;

    public ClonableClass Clone()
    {
        ClonableClass clone = new ClonableClass();
        clone.life = life;
        clone.power = power;
        clone.name = name;

        return clone;
    }

}
