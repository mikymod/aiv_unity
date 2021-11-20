using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInfo : MonoBehaviour {
    string info;
    public bool displayInfo = true;
    public Vector2 offset;

    //This is called as soon as the collision starts
    void OnCollisionEnter(Collision c) {
        
	}
	//This is called if the Collision c remains the same of the previous frame
	void OnCollisionStay(Collision c) {
        PrintInfo("OnCollisionStay\n", c);
    }
	//This is called as soon as the collision ends
	void OnCollisionExit(Collision c) {
	}

    void PrintInfo(string prefix, Collision c)
    {
        string colliderName = c.collider.name;
        ContactPoint[] contactPts = c.contacts;
        foreach (ContactPoint cp in contactPts)
            Debug.DrawLine(cp.point, cp.point + cp.normal * 3, Color.green);
        Vector3 impulse = c.impulse;
        Vector3 relV = c.relativeVelocity;

        info = string.Format("ColliderName: {0}\nThere are {1} contact points\nImpulse: {2}\nRelVel: {3}\n",
            colliderName, contactPts.Length, impulse, relV);
    }

    void OnGUI()
    {
        if (!displayInfo) return;
        GUILayout.BeginHorizontal();
        GUILayout.Space(offset.x);
        GUILayout.BeginVertical();
        GUILayout.Space(offset.y);
        GUILayout.BeginVertical("box");
        GUILayout.Label(info);
        GUILayout.EndVertical();
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
}
