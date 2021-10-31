using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassB: ClassA
{
    public bool powerUp;

    //0
    public string MethodB()
    {
        //2
        //If ClassA.MethodA() is private, this would be an error:
        string result = this.MethodA();
        return "ClassB.methodB()";
    }


    //1
    //public override string MethodA()
    //{
    //    return "ClassB.MethodA()";
    //}

    //4
    //Member hiding
    public new void Fire()
    {
        Debug.Log("ClassB.Fire()");
        return;
    }

    //5
    public override void Fire2()
    {
        //6
        //base.Fire2();
        Debug.Log("ClassB.Fire2()");
        return;
    }

    //7
    public ClassB() : base()
    {
    }

    //In a derived class, if a base-class constructor is not called explicitly by using the base keyword, the default constructor, if there is one, is called implicitly.
    //(8 is the same as 7)

    //8
    //public ClassB()
    //{
    //}

    //9
    //The constructor for the base class is called before the block for the constructor is executed
    public ClassB(int life, Vector3 startPos, bool hasPowerUp) : base(life, startPos)
    {
        powerUp = hasPowerUp;
    }

    //11
    public ClassB(int life) : base(life)
    {
        Debug.Log("constructor ClassB(int life)");
    }
    public ClassB(int life, int additionalLife) : this(life + additionalLife)
    {
        Debug.Log("constructor ClassB(int life, int additionalLife)");
    }

    //10 Clone with Hiding
    //public new ClassB Clone()
    //{
    //    return new ClassB((int)life, startPos, powerUp);
    //}
    //Clone with Overriding - Error
    //public override ClassB Clone()
    //{
    //    return new ClassB((int)life, startPos, powerUp);
    //}

    public ClassB(int startLife, bool startPowerUp, int startLevel) : base(startLife * startLevel)
    {
        powerUp = startPowerUp;
    }
}
