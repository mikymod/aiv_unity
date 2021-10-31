using UnityEngine;

public class Elf : EnemyType, IDuplicable
{
    public override void Fire()
    {
        Debug.Log("Elf is shooting");
    }

    public float GetExperience() => (age * 2) * power;
}
