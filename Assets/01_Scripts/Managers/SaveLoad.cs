using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


[System.Serializable]
public class data
{
    public int time_1;
    public int time_2;
    public int time_3;
}
public class SaveLoad : MonoBehaviour
{
    public int time_1;
    public int time_2;
    public int time_3;
    public int now_game;
    private data datavar = new data();
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save()
    {
        datavar.time_1 = time_1;
        datavar.time_2 = time_2;
        datavar.time_3 = time_3;
    
        string json = JsonUtility.ToJson(datavar);
        Debug.Log(json);
        string path = Application.persistentDataPath + "/data.Json";
        File.WriteAllText(path,json);
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus)
        {
            Save();
        }
    }

    void OnApplicationQuit()
    {
        Save();
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/data.Json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data datavar = JsonUtility.FromJson<data>(json);

            if (now_game == 1)
            {
                time_1 = datavar.time_1;
            }
            
            if (now_game ==2)
            {
                time_2 = datavar.time_2;
            }
     
            if (now_game == 3)
            {
                time_3 = datavar.time_3;
            }
            time_1 = datavar.time_1;
            time_2 = datavar.time_2; 
            time_3 = datavar.time_3;
        }
        else
        {
            time_1 = -1;
            time_2 = -1;
            time_3 = -1;
            return;
        }
    }

}
