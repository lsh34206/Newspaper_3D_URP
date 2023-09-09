using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class data
{
    public int time_1;
    
    public int time_2;
    
    public int time_3;



}

public class GameManager : MonoBehaviour
{
    public int time_1;

    public int time_2;

    public int time_3;
    private data datavar = new data();


    public int now_game;

    public Sprite game_tab_img;

    public GameObject game_pop;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    public void exit()
    {
        Application.Quit();
    }

    public void click_sound()
    {
        GameObject.Find("GameManager").GetComponent<AudioSource>().Play();
    }

// Update is called once per frame
    void Update()
    {

    }

    public void Load()
    {

        string path = Application.persistentDataPath + "/data.Json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data datavar = JsonUtility.FromJson<data>(json);




            if (now_game == 1)
            {
                time_1 = datavar.time_1;
            }

            if (now_game == 2)
            {
                time_2 = datavar.time_2;
            }

            if (now_game == 3)
            {
                time_3 = datavar.time_3;
            }

        }
        else
        {


            time_1 = -1;


            time_2 = -1;

            time_3 = -1;




        }
    }


public void Save()
        {
            if (now_game == 1)
            {
                datavar.time_1 = time_1;
            }

            if (now_game == 2)
            {
                datavar.time_1 = time_2;
            }

            if (now_game == 3)
            {
                datavar.time_1 = time_3;
            }



            string json = JsonUtility.ToJson(datavar);
            Debug.Log(json);
            string path = Application.persistentDataPath + "/data.Json";
            File.WriteAllText(path, json);
        }

        void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                Save();
            }
        }

        void OnApplicationQuit()
        {

            Save();
        }
    }

