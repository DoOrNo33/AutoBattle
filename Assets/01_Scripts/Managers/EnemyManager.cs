using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private CSVReader csvReader;

    [SerializeField] private Transform spawnPos;

    [SerializeField] private GameObject enemyPrefab;
    public List<EnemyData> enemyDataList;


    void Start()
    {
        enemyDataList = csvReader.ReadCSV();
    }
}
