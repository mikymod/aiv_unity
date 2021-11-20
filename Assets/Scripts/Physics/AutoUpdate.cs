using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoUpdate : MonoBehaviour
{
    private float timer;
    public Transform CubeRotatedInUpdate;
    public bool SimulatePhysicsInUpdate;

    void Update()
    {
        CubeRotatedInUpdate.Rotate(0, Time.deltaTime * 100, 0);

        if (Physics.autoSimulation)
        {
            Debug.LogWarning("Physics.autoSimulation is ON: Turn it OFF!");
            return; // do nothing if the automatic simulation is enabled
        }

        Debug.Log("timer: " + timer);
        Debug.Log("FixedTime: " + Time.fixedTime);
        timer += Time.deltaTime;

        if (SimulatePhysicsInUpdate) {
            // Catch up with the game time.
            // Advance the physics simulation in portions of Time.fixedDeltaTime
            // Note that generally, we don't want to pass variable delta to Simulate as that leads to unstable results.
            Debug.Log("Time.fixedDeltaTime is.. " + Time.fixedDeltaTime);
            while (timer >= Time.fixedDeltaTime)
            {
                timer -= Time.fixedDeltaTime;
                Physics.Simulate(Time.fixedDeltaTime);
                Debug.Log("..timer is greater: I'm advancing in Physics.Simulate(), and now timer is: " + timer);
            }
        }
    }
}
