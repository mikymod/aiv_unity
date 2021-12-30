using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopulateMeshInstantiator : MonoBehaviour
{
    public GameObject prefab;
    public float left = -16f;
    public float right = 16f;
    public float bottom = 0f;
    public float up = 14f;
    public int numHealtyObject = 100;

    public static UnityEvent<int> StartSimulation = new UnityEvent<int>();
    private GameObject patientZero;

    private void Start()
    {
        StartSimulation.Invoke(numHealtyObject);
        
        patientZero = Instantiate(prefab, new Vector3(Random.Range(left, right), 0, Random.Range(bottom, up)), Quaternion.identity, transform);
        patientZero.GetComponent<PopulateMeshPerson>().state = PopulateMeshPerson.State.Sick;
        StartCoroutine(DestroyPatientZero());

        for (int i = 0; i < numHealtyObject; i++)
        {
            var healty = Instantiate(prefab, new Vector3(Random.Range(left, right), 0, Random.Range(bottom, up)), Quaternion.identity, transform);
            healty.GetComponent<PopulateMeshPerson>().state = PopulateMeshPerson.State.Healty;
        }
    }

    private IEnumerator DestroyPatientZero()
    {
        yield return new WaitForSeconds(10f);
        Destroy(patientZero);
    }
}
