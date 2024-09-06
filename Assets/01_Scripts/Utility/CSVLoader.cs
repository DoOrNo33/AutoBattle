using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Storage;
using UnityEngine.Networking;
using System.IO;
using Firebase;
using Firebase.Extensions;

public class CSVLoader : MonoBehaviour
{
    private FirebaseStorage storage;
    private StorageReference storageRef;

    [SerializeField] DataManager dataManager;

    private void Start()
    {
        // Firebase 초기화가 완료된 후에 CSV 파일을 로드한다.
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                storage = FirebaseStorage.DefaultInstance;
                storageRef = storage.GetReferenceFromUrl("gs://autobattle-d2d33.appspot.com/SampleMonster.csv");
                StartCoroutine(LoadCSV());
            }
            else
            {
                Debug.LogError($"Could not resolve all Firebase dependencies: {task.Result}");
            }
        });
    }

    private IEnumerator LoadCSV()
    {
        var task = storageRef.GetDownloadUrlAsync();
        yield return new WaitUntil(() => task.IsCompleted);

        // 에러 처리
        if (task.Exception != null)
        {
            Debug.LogError($"URL 오류: {task.Exception}");
            yield break;
        }

        // URL 이용해서 유니티 웹 리퀘스트
        string url = task.Result.ToString();
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        // 에러 처리
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("CSV 파일 다운 실패");
            yield break;
        }

        string csvData = www.downloadHandler.text;

        List<EnemyData> enemyDataList = ProcessCSV(csvData);

        // EnemyManager의 enemyDataList 설정
        EnemyManager.Instance.enemyDataList = enemyDataList;
    }

    private List<EnemyData> ProcessCSV(string csvData)
    {
        StringReader reader = new StringReader(csvData);

        List<EnemyData> enemyDataList = new List<EnemyData>();

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
