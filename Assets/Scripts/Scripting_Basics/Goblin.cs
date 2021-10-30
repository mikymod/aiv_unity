using System.Collections;
using System.Collections.Generic;

public class Goblin
{
    public static int Level = 1;
    public static int GoblinCount = 0;
    //3
    const string name = "Goblin";

    float power;
    public float Power
    {
        get
        {
            return power * Level;
        }

        set
        {
            power = value;
        }
    }

    //Constructor
    public Goblin()
    {
        power = 100;
        GoblinCount++;
    }

    public static void LevelUp()
    {
        Level++;

        //2
        //Error - An Object reference is required for the non-static field!
        //power = 100;
    }
}
