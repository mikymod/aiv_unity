using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventMng_
{
    public static UnityEvent<Item_, GameObject> ItemPicked = new UnityEvent<Item_, GameObject>(); 
    public static UnityEvent<Item_> ItemRemoved = new UnityEvent<Item_>();
    //Create 2 public static instances of the 2 Unity Events
}
