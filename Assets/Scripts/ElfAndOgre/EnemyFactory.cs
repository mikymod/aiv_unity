using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public int ogreNum = 0;
    public int elfNum = 0;
    private List<EnemyType> enemies;

    private void Awake()
    {
        enemies = new List<EnemyType>();    
    }

    void Start()
    {
        for (int i = 0; i < ogreNum; i++)
        {
            enemies.Add(new Ogre());
        }

        for (int i = 0; i < elfNum; i++)
        {
            enemies.Add(new Elf());
        }

        foreach (var enemy in enemies)
        {
            enemy.Fire();
        }   

        var ogre = new Ogre();
        var elf = new Elf();

        elf.CopyExperienceFrom<Ogre>(ogre);

        Debug.Log($"ogre exp: {ogre.experience}, elf exp: {elf.experience}");
    }
}
