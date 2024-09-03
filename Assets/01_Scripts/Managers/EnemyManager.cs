using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private CSVReader csvReader;

    [SerializeField] private Transform spawnPos;

    [SerializeField] private GameObject enemyPrefab;
    public List<EnemyData> enemyDataList;

    [SerializeField] private int enemyIndex = 0;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        enemyDataList = csvReader.ReadCSV();

        CreateEnemy();
    }

    public void CreateEnemy()
    {
        GameObject EnemyObj = Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
        Enemy enemy = EnemyObj.GetComponent<Enemy>();
        enemy.InitializeData(enemyDataList[enemyIndex]);

        // 인덱스 초기화
        if (enemyIndex >= enemyDataList.Count)
        {
            enemyIndex = 0;
        }
        else
        {
            enemyIndex++;
        }
    }
}
