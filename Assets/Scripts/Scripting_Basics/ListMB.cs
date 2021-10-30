using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListMB : MonoBehaviour
{
    List<EnemyA> enemies = new List<EnemyA>();
    Dictionary<string, EnemyA> enemiesDictionary = new Dictionary<string, EnemyA>();

    void Start()
    {
        //Adds EnemyA instances with different power values
        enemies.Add(new EnemyA(10));
        enemies.Add(new EnemyA(5));
        enemies.Add(new EnemyA(30));
        enemies.Add(new EnemyA(1));

        print("There are " + enemies.Count + " EnemyA instances in classes");
        PrintEnemies();

        //TODO: SORT enemies based on their power
        //  * We need IComparable<> interface and using System;
        //PrintEnemies();

        //Dictionaries
        enemiesDictionary.Add("Tom", new EnemyA(10));
        enemiesDictionary.Add("Jack", new EnemyA(13));
        enemiesDictionary.Add("Harry", new EnemyA(15));

        //If we are sure that the key exists
        string enemyToSearch = "Tom";
        EnemyA currEnemy = enemiesDictionary[enemyToSearch];
        print("currEnemyPower " + currEnemy.power);

        //If we are not sure that the key exists, use TryGetValue(). Note the use of 'out' to pass the parameter as reference
        enemyToSearch = "Jack";
        if (enemiesDictionary.TryGetValue(enemyToSearch, out currEnemy))
            print(enemyToSearch + " Power: " + currEnemy.power);
        else
            print("can't find enemy " + enemyToSearch);

    }

    void PrintEnemies()
    {
        string description = "";
        description = "enemies: ";

        foreach (EnemyA c in enemies)
            description += c.power + ", ";

        print(description);
    }
}
