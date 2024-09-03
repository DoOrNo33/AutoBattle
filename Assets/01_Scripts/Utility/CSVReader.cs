using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class CSVReader : MonoBehaviour
{
    [SerializeField] DataManager dataManager;

    public TextAsset csvFile;

    public List<EnemyData> ReadCSV()
    {
        List<EnemyData> enemyDataList = new List<EnemyData>();
        StringReader reader = new StringReader(csvFile.text);

        bool isFirstLine = true;
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            if (isFirstLine)
            {
                isFirstLine = false;
                continue; // 첫 라인 건너뜀
            }

            string[] values = line.Split(',');
            EnemyData data = new EnemyData
            {
                Sprite = dataManager.EnemySprite[int.Parse(values[0])],
                Name = values[1],
                Grade = values[2],
                Speed = float.Parse(values[3]),
                Health = float.Parse(values[4])
            };

            enemyDataList.Add(data);
        }

        return enemyDataList;
    }
}

[Serializable]
public class EnemyData
{
    public string Name;
    public string Grade;
    public float Speed;
    public float Health;
    public Sprite Sprite; 
}
