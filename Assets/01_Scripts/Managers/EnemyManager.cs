using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private CSVReader csvReader;

    [SerializeField] private Transform spawnStandardPos;

    [SerializeField] private GameObject enemyPrefab;
    public List<EnemyData> enemyDataList;

    [SerializeField] private int enemyIndex = 0;

    private float rightPos = 13f;
    private float leftPos = -12f;

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
        // x값 범위 내에서 무작위 선택
        float ranX = UnityEngine.Random.Range(leftPos, rightPos);

        Vector3 spawnPos = new Vector3(ranX, spawnStandardPos.position.y, spawnStandardPos.position.z);

        GameObject EnemyObj = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        Enemy enemy = EnemyObj.GetComponent<Enemy>();
        enemy.InitializeData(enemyDataList[enemyIndex]);

        // 인덱스 초기화
        if (enemyIndex >= (enemyDataList.Count - 1))
        {
            enemyIndex = 0;
        }
        else
        {
            enemyIndex++;
        }
    }
}
