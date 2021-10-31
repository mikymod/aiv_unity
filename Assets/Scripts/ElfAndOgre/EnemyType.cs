using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType
{
    protected float experience;
    protected int age;
    protected float power;

    public static int enemyCount = 0;

    public EnemyType()
    {
        enemyCount++;
        
        experience = Random.Range(0f, 100f);
        age = (int)Random.Range(0f, 100f);
        power = Random.Range(0f, 100f);
    }

    public EnemyType(float experience, int age, float power)
    {
        enemyCount++;

        this.experience = experience;
        this.age = age;
        this.power = power;
    }

    public virtual void Fire()
    {
        Debug.Log("Enemy is shooting");
    }

    public void CopyExperienceFrom<T>(T enemy) where T: IDuplicable
    {
        this.experience = enemy.GetExperience();
    }
}
