using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Goblin g1 = new Goblin();
        Debug.Log("g1 total power is: " + g1.Power);
        Debug.Log("There are " + Goblin.GoblinCount + " goblins");

        //Simulate a PowerUp that affects Goblin Level
        Goblin.Level++;

        Goblin g2 = new Goblin();
        Debug.Log("g1 total power is: " + g1.Power);
        Debug.Log("g2 total power is: " + g2.Power);
        Debug.Log("There are " + Goblin.GoblinCount + " goblins");

        //2
        //You cannot access a static method with an instance reference!
        //g2.LevelUp();
        //While this is correct:
        //Goblin.LevelUp();
    }
}
