using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public int ogreNum = 0;
    public int elfNum = 0;
    private List<EnemyType> enemies;

    void Start()
    {
        enemies = new List<EnemyType>();

        foreach (var enemy in enemies)
        {
            enemy.Fire();
        }   

        var ogre = new Ogre();
        var elf = new Elf();

        elf.CopyExperienceFrom<Ogre>(ogre);

        Debug.Log($"ogre exp: {ogre.GetExperience()}, elf exp: {elf.GetExperience()}");
    }
}
