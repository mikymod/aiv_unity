using UnityEngine;

public class BakeMesh : MonoBehaviour
{
    public bool IsConvex;

    public bool ChangeMesh;
    public bool DoBakeMesh;
    public bool UpdateCreateMeshCollider;
    Mesh m;
    MeshFilter mf;

    private void Start()
    {
        mf = GetComponent<MeshFilter>();
        m = mf.mesh;
    }

    public void FixedUpdate()
    {
        if (ChangeMesh)
        {
            //When we change this mesh, 
            ChangeMesh = false;
            Vector3[] vertices = m.vertices;
            for (int i = 0; i < vertices.Length/2; i++)
                vertices[i] += new Vector3(0, 1, 0);
            m.vertices = vertices;
            mf.mesh = m;
            Debug.Log("Mesh GetInstanceID():" + m.GetInstanceID());
        }
        if (DoBakeMesh)
        {
            DoBakeMesh = false;
            // Bake this Mesh to use later.
            Physics.BakeMesh(m.GetInstanceID(), IsConvex);
        }
        // If the collider wasn't yet created - create it now.
        if (UpdateCreateMeshCollider)
        {
            // No mesh baking will happen here because the mesh was pre-baked, making instantiation faster.
            UpdateCreateMeshCollider = false;
            MeshCollider mc = gameObject.GetComponent<MeshCollider>();
            if(mc == null)
                mc = gameObject.AddComponent<MeshCollider>();
            mc.sharedMesh = m;
            mc.convex = IsConvex;
        }
    }
}