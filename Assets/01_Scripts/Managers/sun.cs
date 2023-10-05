using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    [SerializeField] private float secondPerRealTimeSecond; // 게임 세계에서의 100초 = 현실 세계의 1초

    private bool isNight = false;

    [SerializeField] private float nightFogDensity; // 밤 상태의 Fog 밀도
    private float dayFogDensity; // 낮 상태의 Fog 밀도
    [SerializeField] private float fogDensityCalc; // 증감량 비율
    private float currentFogDensity; 

    void Start()
    {
        dayFogDensity = RenderSettings.fogDensity;
    }

    void Update()
    {

        if ((GameObject.Find("GameManager").GetComponent<DateManager>().time_1 >= 920 &&
             GameObject.Find("GameManager").GetComponent<DateManager>().time_1 >= 1140))
        {
            isNight = true;
        }
        else if((GameObject.Find("GameManager").GetComponent<DateManager>().time_1 >= 0 &&
                 GameObject.Find("GameManager").GetComponent<DateManager>().time_1 >= 200))
        {
            isNight = false;
        }
        
        if ((GameObject.Find("GameManager").GetComponent<DateManager>().time_2 >= 920 &&
             GameObject.Find("GameManager").GetComponent<DateManager>().time_2 >= 1140))
        {
            isNight = true;
        }
        else if((GameObject.Find("GameManager").GetComponent<DateManager>().time_2 >= 0 &&
                 GameObject.Find("GameManager").GetComponent<DateManager>().time_2 >= 200))
        {
            isNight = false;
        }
        
        if ((GameObject.Find("GameManager").GetComponent<DateManager>().time_3 >= 920 &&
             GameObject.Find("GameManager").GetComponent<DateManager>().time_3 >= 1140))
        {
            isNight = true;
        }
        else if((GameObject.Find("GameManager").GetComponent<DateManager>().time_3 >= 0 &&
                 GameObject.Find("GameManager").GetComponent<DateManager>().time_3 >= 200))
        {
            isNight = false;
        }
        
      

        if (!isNight)
        {
            gameObject.transform.rotation = new Quaternion(5.5f,36f,-291.9f,0);
        }
        else
        {
            gameObject.transform.rotation = new Quaternion(-11.2f, 34.5f, -121.4f,0);
        }
    }
}