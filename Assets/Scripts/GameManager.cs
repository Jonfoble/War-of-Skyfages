using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AgeEnum currentAge;
    [SerializeField] private SoTemplates prehistoricTemplate;
    [SerializeField] private SoTemplates medievalTemplate;
    [SerializeField] private SoTemplates modernTemplate;
    [SerializeField] private SoTemplates currentTemplate;
    [SerializeField] private PlayerData allyData;

    private bool _selectPhase = false;
    private bool _isGameStarted = true;
    public List<GameObject> activeUnits = new List<GameObject>();

    public bool SelectPhase
    {
        get => _selectPhase;
        set => _selectPhase = value;
    }

   

    public bool IsGameStarted
    {
        get => _isGameStarted;
        set => _isGameStarted = value;
    }

    public PlayerData AllyData
    {
        get => allyData;
        set => allyData = value;
    }


    private void Awake()
    {
        allyData.gold = 0;
        currentAge = AgeEnum.PrehistoricAge;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            currentAge = AgeEnum.PrehistoricAge;
            currentTemplate = prehistoricTemplate;
            var go =ObjectPooler.SharedInstance.GetPooledObject(0);
            go.GetComponent<Unit>().UpdateStats(prehistoricTemplate);
            go.transform.position = Vector3.zero;
            go.SetActive(true);
        }

        if (Input.GetKey(KeyCode.W))
        {
            currentAge = AgeEnum.MedievalAge;
            currentTemplate = medievalTemplate;
            var go =ObjectPooler.SharedInstance.GetPooledObject(0);
            go.GetComponent<Unit>().UpdateStats(medievalTemplate);
            go.transform.position = Vector3.zero;
            go.SetActive(true);
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            currentAge = AgeEnum.ModernAge;
            currentTemplate = modernTemplate;
            var go =ObjectPooler.SharedInstance.GetPooledObject(0);
            go.GetComponent<Unit>().UpdateStats(modernTemplate);
            go.transform.position = Vector3.zero;
            go.SetActive(true);
        }

        foreach (GameObject unit in activeUnits)
        {
            unit.GetComponent<Unit>().UpdateStats(currentTemplate);
        }
    }

    public void SpawnEnemy(Vector3 position, UnitTypeEnum unitType)
    {
        var go =ObjectPooler.SharedInstance.GetPooledObject(0);
        go.GetComponent<Unit>()._unitType = unitType;
        go.GetComponent<Unit>().UpdateStats(modernTemplate);
        go.transform.position = position;
        go.SetActive(true);
    }
}