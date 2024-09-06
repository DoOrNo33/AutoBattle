using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private CSVReader csvReader;
    [SerializeField] private CSVLoader csvLoader;

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
        //enemydatalist = csvreader.readcsv();

        //CreateEnemy();

        StartCoroutine(Init());
    }

    private IEnumerator Init()
    {
        // CSVLoader가 enemyDataList를 설정할 때까지 기다림
        while (enemyDataList == null || enemyDataList.Count == 0)
        {
            yield return null;
        }

        CreateEnemy();
    }

    public void CreateEnemy()
    {
        // x값 범위 내에서 무작위 선택
        float ranX = GetWeightedRandomX(leftPos, rightPos);

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

    // 중앙 지역 가중치
    private float GetWeightedRandomX(float min, float max)
    {
        float mean = (min + max) / 2f; // 중심
        float stdDev = (max - min) / 6f; // 표준 편차 (범위의 1/6)

        float u1 = UnityEngine.Random.value;
        float u2 = UnityEngine.Random.value;

        // Box-Muller 변환
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);
        float randNormal = mean + stdDev * randStdNormal;

        // min과 max 사이로 클램프
        return Mathf.Clamp(randNormal, min, max);
    }
}
