using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopulateMeshPerson : MonoBehaviour
{
    public static UnityEvent InfectedEvent = new UnityEvent();
    public static UnityEvent RecoveredEvent = new UnityEvent();

    public enum State
    {
        Healty,
        Sick,
        Recovered
    }

    public State state;
    private Rigidbody rigidBody;

    public float constForce = 2f;
    private MeshRenderer rend;

    public float numSecondsForRecovery = 1f;
    private UIGraphValuesProviderStart dataProvider;

    public static int sickValue = 0;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        rend = GetComponent<MeshRenderer>();
        var dataProviderGO = GameObject.Find("GraphValuesProvider");
        dataProvider = dataProviderGO.GetComponent<UIGraphValuesProviderStart>();
    }

    private void Update()
    {
        switch (state)
        {
            case State.Healty:
                rend.material.color = Color.grey;
                break;
            case State.Sick:
                rend.material.color = Color.red;
                break;
            case State.Recovered:
                rend.material.color = Color.green;
                break;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidBody.velocity = rigidBody.velocity.normalized * constForce;
    }

    private void OnCollisionEnter(Collision other)
    {
        var comp = other.gameObject.GetComponent<PopulateMeshPerson>();
        if (comp)
        {
            if (comp.state == State.Sick && state == State.Healty)
            {
                InfectedEvent.Invoke();
                state = State.Sick;
                sickValue++;
                StartCoroutine(Recovery());
            }
        }
    }

    private IEnumerator Recovery()
    {
        yield return new WaitForSeconds(numSecondsForRecovery);

        state = State.Recovered;
        sickValue--;
        RecoveredEvent.Invoke();
    }
}
