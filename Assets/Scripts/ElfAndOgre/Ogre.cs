using UnityEngine;

public class Ogre : EnemyType, IDuplicable
{
    public override void Fire()
    {
        Debug.Log("Ogre is shooting");
    }

    public float GetExperience() => age * power;
}
