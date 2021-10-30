using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTranslationOnStart : MonoBehaviour
{
    void Start()
    {
        transform.ResetTranslation();
    }
}
