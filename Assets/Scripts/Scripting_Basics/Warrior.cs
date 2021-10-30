using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    //0
    private float power;

    //1
    public float Power
    {
        get
        {
            return power;
        }

        set
        {
            //4
            //if(value > 0)
            power = value;
        }
    }

    //2
    //public float Power{ get; set; }

    //3
    //public float Power
    //{
    //    get
    //    {
    //        return power;
    //    }

    //    set
    //    {
    //        power = value > 0 ? value : power;
    //    }
    //}
}
