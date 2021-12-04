using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicsSceneTest : MonoBehaviour
{
    public GameObject BallPrefab, whiteball_trajectory_prefab;
    public float ForceFactor = 10f;
    public int SimSteps = 50;
    public GameObject real_ball;
    public Camera cam;
    public GameObject SceneRoot;
    
    Scene mainScene;
    Scene physicsScene;
    List<GameObject> sim_steps = new List<GameObject>();
    Vector3 currForce, prevMousePos;//, lastSimForce;
    Vector3 lastHitPoint;
    GameObject sim_ball;
    private Rigidbody realBallRB;
    private Material realBallMat;
    private LineRenderer realBallLineRenderer;

    // [SerializeField] private Rigidbody[] spheres;
    [SerializeField] private LineRenderer[] renderers;
    private Rigidbody[] sim_spheres;

    void Start()
    {
        //We won't use mainScene reference
        mainScene = SceneManager.GetActiveScene();
        
        physicsScene = SceneManager.CreateScene("physics-scene", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        
        //If we create physicsScene in this way, both scenes will have the same DefaultPhysicsScene:
        //  if we'll disable SceneRoot in the mainScene, real_white ball will continue to collide with sim_sceneRoot!
        //physicsScene = SceneManager.CreateScene("physics-scene");

        GameObject sim_sceneRoot = Instantiate(SceneRoot);
        MeshRenderer[] MRenderers = sim_sceneRoot.GetComponentsInChildren<MeshRenderer>();
        foreach (var MRenderer in MRenderers)
            MRenderer.enabled = false;
        SceneManager.MoveGameObjectToScene(sim_sceneRoot, physicsScene);

        realBallRB = real_ball.GetComponent<Rigidbody>();
        realBallMat = real_ball.GetComponent<Renderer>().material;

        realBallLineRenderer = real_ball.GetComponent<LineRenderer>();
    }

    void ClearTrajectory()
    {
        foreach (var go in sim_steps)
            Destroy(go);
        sim_steps.Clear();
    }

    private void Update()
    {
        realBallMat.color = realBallRB.IsSleeping() ? Color.white : Color.red;
        
        if (!realBallRB.IsSleeping())
        {
            return;
        }
        // else if (realBallRB.IsSleeping() && !Input.GetMouseButton(0))
        // {
        //     realBallLineRenderer.positionCount = 0;
        //     for (int i = 0; i < renderers.Length; i++)
        //     {
        //         renderers[i].positionCount = 0;
        //     }
        // }

        if (Input.GetMouseButton(0))
        {
            Debug.DrawLine(lastHitPoint, real_ball.transform.position, Color.red);
            if (Input.mousePosition == prevMousePos)
                return;
            prevMousePos = Input.mousePosition;
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                lastHitPoint = hit.point;
                currForce = hit.point - real_ball.transform.position;
                currForce = Vector3.Scale(currForce, new Vector3(ForceFactor, 0, ForceFactor));
                SimulatePath(); 
            }
        }
        
        // if (realBallRB.IsSleeping() && !Input.GetMouseButton(0)) 
        // {
        //     realBallLineRenderer.positionCount = 0;
        //     for (int i = 0; i < renderers.Length; i++)
        //     {
        //         renderers[i].positionCount = 0;
        //     }
        // }

        if (Input.GetMouseButtonUp(0))
        {
            real_ball.GetComponent<Rigidbody>().AddForce(currForce, ForceMode.Impulse);
        }
    }

    private void SimulatePath()
    {
        realBallLineRenderer.positionCount = 0;
        
        //set the simulation white ball back to the original position
        sim_ball = Instantiate(BallPrefab, real_ball.transform.position, real_ball.transform.rotation);
        SceneManager.MoveGameObjectToScene(sim_ball, physicsScene);
        Rigidbody sim_rb = sim_ball.GetComponent<Rigidbody>();

        // Instantiate balls
        List<GameObject> simOthers = new List<GameObject>();
        for (int i = 0; i < renderers.Length; i++)
        {
            var sim_sphere = Instantiate(BallPrefab, renderers[i].transform.position, renderers[i].transform.rotation);
            SceneManager.MoveGameObjectToScene(sim_sphere, physicsScene); 
            simOthers.Add(sim_sphere);
        }

        //simulate a specific number of frames into the future
        sim_rb.AddForce(currForce, ForceMode.Impulse);

        // Set line renderers position counts
        realBallLineRenderer.positionCount = SimSteps;
        for (int j = 0; j < renderers.Length; j++)
        {
            renderers[j].positionCount = SimSteps;
        }

        // Start simulation
        for (int i = 0; i < SimSteps; i++)
        {
            physicsScene.GetPhysicsScene().Simulate(Time.fixedDeltaTime);

            // Add positions to line renderer
            realBallLineRenderer.SetPosition(i, sim_ball.transform.position);
            for (int j = 0; j < renderers.Length; j++)
            {
                renderers[j].SetPosition(i, simOthers[j].transform.position);
            }
        }

        // Destroy balls
        Destroy(sim_ball);
        for (int i = 0; i < simOthers.Count; i++)
        {
            Destroy(simOthers[i]);
        }
    }
}

