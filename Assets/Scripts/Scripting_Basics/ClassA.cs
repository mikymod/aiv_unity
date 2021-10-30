using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassA
{
    public float life;
    public Vector3 startPos;

    //0
    public string MethodA()
    {
        return "ClassA.MethodA()";
    }

    //1
    //public virtual string MethodA()
    //{
    //    return "ClassA.MethodA()";
    //}

    //4
    public void Fire()
    {
        Debug.Log("ClassA.Fire()");
        return;
    }

    //5
    public virtual void Fire2()
    {
        Debug.Log("ClassA.Fire2()");
        return;
    }

    //6
    public ClassA()
    {
        life = 100.0f;
        startPos = Vector3.zero;
        Debug.Log("constructor ClassA()");
    }
    public ClassA(int Life)
    {
        //this.life = Life;
        life = Life;
        startPos = Vector3.zero;
        Debug.Log("constructor ClassA(int Life)");
    }
    public ClassA(int Life, Vector3 startPos)
    {
        life = Life;
        //We need to specify "this"
        this.startPos = startPos;
    }

    //10 Clone with Hiding
    //public ClassA Clone()
    //{
    //    return new ClassA((int)life, startPos);
    //}
    //Clone with Overriding -> Error in ClassB.cs
    //public virtual ClassA Clone()
    //{
    //    return new ClassA((int)life, startPos);
    //}

}
