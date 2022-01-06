using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteCloner_Start : MonoBehaviour
{
    public Texture2D Source;
    public bool UseSetPixels = false;
    SpriteRenderer SRenderer;

    void Start()
    {
        SRenderer = GetComponent<SpriteRenderer>();
        Texture2D destination = new Texture2D(Source.width, Source.height);

        if (UseSetPixels)
        {
            //Use Get/SetPixel to copy
        }
        else
        {
            //Use Get/SetPixels to copy
        }
        //Apply()
        //FilterMode
        //Set Sprite
    }
}
