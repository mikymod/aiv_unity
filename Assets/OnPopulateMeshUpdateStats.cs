using UnityEngine;
using TMPro;
using System;

public class OnPopulateMeshUpdateStats : MonoBehaviour
{
    public TMP_Text HealthyText;
    public TMP_Text SickText;
    public TMP_Text RecoveredText;

    private int healthy = 0;
    private int infected = 0;
    private int recovered = 0;

    private void OnEnable()
    {
        PopulateMeshInstantiator.StartSimulation.AddListener(OnStartSimulationCallback);
        PopulateMeshPerson.InfectedEvent.AddListener(OnInfectedEventCallback);
        PopulateMeshPerson.RecoveredEvent.AddListener(OnRecoveredEventCallback);
    }

    private void OnDisable()
    {
        PopulateMeshInstantiator.StartSimulation.RemoveListener(OnStartSimulationCallback);
        PopulateMeshPerson.InfectedEvent.RemoveListener(OnInfectedEventCallback);
        PopulateMeshPerson.RecoveredEvent.RemoveListener(OnRecoveredEventCallback);
    }

    private void OnStartSimulationCallback(int healthy)
    {
        this.healthy = healthy;
    }

    private void OnInfectedEventCallback()
    {
        healthy--;
        infected++;
    }

    private void OnRecoveredEventCallback()
    {
        infected--;
        recovered++;
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthyText.text = "0";
        SickText.text = "0";
        RecoveredText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        HealthyText.text = healthy.ToString();
        SickText.text = infected.ToString();
        RecoveredText.text = recovered.ToString();        
    }
}
