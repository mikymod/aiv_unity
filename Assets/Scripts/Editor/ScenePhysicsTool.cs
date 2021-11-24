using UnityEditor;
using UnityEngine;

public class ScenePhysicsTool : EditorWindow
{
    string TicksToSimulateString = "";
    int ticksToSimulate = 0;
    int remainingTicksToSimulate = 0;
    bool cachedAutoSimValue;
    private void OnGUI()
    {
        if (GUILayout.Button("Run Physics"))
        {
            StepPhysics();
        }
        GUILayout.Label("TicksToSimulate");
        TicksToSimulateString = GUILayout.TextField(TicksToSimulateString);
        int.TryParse(TicksToSimulateString, out ticksToSimulate);
    }

    private void StepPhysics()
    {
        remainingTicksToSimulate = ticksToSimulate;
        cachedAutoSimValue = Physics.autoSimulation;
        Physics.autoSimulation = false;
        while (remainingTicksToSimulate > 0)
        {
            Physics.Simulate(Time.fixedDeltaTime);
            remainingTicksToSimulate--;
        }
        Physics.autoSimulation = cachedAutoSimValue;
    }

    [MenuItem("Tools/Physics/ScenePhysicsEditor")]
    private static void OpenWindow()
    {
        GetWindow<ScenePhysicsTool>(false, "Physics", true);
    }
}