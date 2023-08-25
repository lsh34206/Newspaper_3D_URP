using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class date_con : MonoBehaviour
{
    public Text time_text_1;

    public int time;
    private int sub_time;
    IEnumerator time_coru()
    {
        time++;


        time_text_1.text = ((time / 14400) + 1) + "일차\n" + (time / 600%24) + ":" + (time / 60%60);
        yield return new WaitForSeconds(1f/6f);
        StartCoroutine("time_coru", 1f/6f);
    }
    // Start is called before the first frame update
    void Start()
    {
       
        time = 0;
        StartCoroutine("time_coru", 1f/6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
