using UnityEngine;

public class TreeAndGiftInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private GameObject giftPrefab;
    [SerializeField] private Transform pivot;
    [SerializeField] private Transform player;

    public Transform parent;

    [SerializeField][Range(1, 5)] private int numTrees = 1;
    [SerializeField][Range(1, 5)] private int numGifts = 1;
    [SerializeField][Range(0.1f, 50f)] private float radius = 5f;

    [SerializeField][Range(0.1f, 5f)] public float treeInstantiateTime = 2f;
    [SerializeField][Range(0.1f, 5f)] public float giftInstantiateTime = 2f;
    private float treeInstantiateTimer = 0f;
    private float giftInstantiateTimer = 0f;


    void Update()
    {
        treeInstantiateTimer += Time.deltaTime;
        if (treeInstantiateTimer >= treeInstantiateTime)
        {
            InstantiateTrees();
            treeInstantiateTimer = 0f;
        }

        giftInstantiateTimer += Time.deltaTime;
        if (giftInstantiateTimer >= giftInstantiateTime)
        {
            InstantiateGifts();
            giftInstantiateTimer = 0f;
        }
        
    }

    private void InstantiateTrees()
    {
        for (int i = 0; i < numTrees; i++)
        {
            var tree = Instantiate(treePrefab, parent);
            tree.transform.rotation = Quaternion.Euler(0f, Random.Range(-30f, 30f), 0f);
            tree.transform.position = pivot.position + (tree.transform.forward * (radius - 0.15f));
            tree.GetComponent<Collectable>().Target = player;
        }

    }

    private void InstantiateGifts()
    {
        for (int i = 0; i < numGifts; i++)
        {
            var gift = Instantiate(giftPrefab, parent);
            gift.transform.rotation = Quaternion.Euler(0f, Random.Range(-30f, 30f), 0f);
            gift.transform.position = pivot.position + (gift.transform.forward * (radius - 0.15f));
            gift.GetComponent<Collectable>().Target = player;
        }
    }

    private void DestroyAll()
    {
        Transform[] children = parent.GetAllChildren();
        for (int i = children.Length - 1; i >= 0; i--)
        {
            if (Application.isPlaying)
            {
                Destroy(children[i].gameObject);             
            }
        }
    }
}
