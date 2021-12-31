using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventMng_
{
    public static UnityEvent<Item_, GameObject, int> ItemPicked = new UnityEvent<Item_, GameObject, int>(); 
    public static UnityEvent<Item_, int> ItemRemoved = new UnityEvent<Item_, int>();
}
