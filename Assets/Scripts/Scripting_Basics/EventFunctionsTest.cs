using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFunctionsTest : MonoBehaviour
{
    private int updateCounter = 0;
    private int fixedUpdateCounter = 0;
    // Start is called before the first frame update
    private void Awake()
    {

        Debug.Log("Awake");
    }
    void Start()
    {
        Debug.Log("Start");
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    /*
    // Update is called once per frame
    void Update()
    {
        Debug.Log(updateCounter++);
    }
    void FixedUpdate()
    {
        Debug.Log(fixedUpdateCounter++);
    }
    //This is called in Editormode even if this script has not [ExecuteInEditorMode] attribute
    void Reset()
    {
        Debug.Log("Reset");
    }
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit");
    }
    */
}
