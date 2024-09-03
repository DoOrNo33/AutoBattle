using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
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
                Name = values[0],
                Grade = values[1],
                Speed = float.Parse(values[2]),
                Health = float.Parse(values[3])
            };

            enemyDataList.Add(data);
        }

        return enemyDataList;
    }
}

public class EnemyData
{
    public string Name;
    public string Grade;
    public float Speed;
    public float Health;
}
