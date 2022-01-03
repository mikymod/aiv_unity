using UnityEngine;

public class ReorderSiblings : MonoBehaviour
{
    public Transform byOrder;
    public Transform byPower;

    void Start()
    {
        Transform[] byOrderChildren = byOrder.GetAllChildren();
        foreach (var child in byOrderChildren)
        {
            child.SetSiblingIndex(0);
        }

        Transform[] byPowerChildren = byPower.GetAllChildren();
        foreach (var child in byPowerChildren)
        {
            if (child.GetComponent<Enemy>()?.power < 50f)
            {
                child.SetSiblingIndex(0);
            }
        }
    }
}

public static class TransformExtension
{
    public static Transform[] GetAllChildren(this Transform transform)
    {
        Transform[] children = new Transform[transform.childCount];
        for (int i = 0 ; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i);
        }

        return children;
    }
}
