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
        if (Input.GetMouseButtonUp(0))
        {
            real_ball.GetComponent<Rigidbody>().AddForce(currForce, ForceMode.Impulse);
        }
    }

    private void SimulatePath()
    {
        ClearTrajectory();     //removes all previously simulated balls
        
        //set the simulation white ball back to the original position
        sim_ball = Instantiate(BallPrefab, real_ball.transform.position, real_ball.transform.rotation);
        SceneManager.MoveGameObjectToScene(sim_ball, physicsScene);
        Rigidbody sim_rb = sim_ball.GetComponent<Rigidbody>();

        //simulate a specific number of frames into the future
        sim_rb.AddForce(currForce, ForceMode.Impulse);
        for (int i = 0; i < SimSteps; i++)
        {
            physicsScene.GetPhysicsScene().Simulate(Time.fixedDeltaTime);

            //Instantiate a trajectory_prefab for each step the sim_whiteball takes into the simulation
            GameObject new_point = Instantiate(whiteball_trajectory_prefab);
            new_point.transform.position = sim_ball.transform.position;
            sim_steps.Add(new_point);
        }

        Destroy(sim_ball);
    }
}

