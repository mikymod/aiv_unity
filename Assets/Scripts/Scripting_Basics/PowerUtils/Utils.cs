using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerUtils { 
    public class Utils
    {
        public int Add(int first, int second)
        {
            return first + second * 2;
        }
        public Vector2 Add(Vector2 first, Vector2 second)
        {
            return first + second + first;
        }
    }
}