using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class date_con : MonoBehaviour
{
    public Text time_text_1;
    private bool tab_pop_bool;
    public int time;
    private int sub_time;
    private bool is_play;
    private GameManager game_mng;
    public GameObject game_tab_pop;
    
    public GameObject game_1_btn;
    public GameObject game_2_btn;
    public GameObject game_3_btn;
    
    
    public GameObject load_list_pop;
    IEnumerator time_coru()
    {
        if (game_mng.now_game == 1)
        {
            game_mng.time_1++;


            time_text_1.text = ((game_mng.time_1 / 14400) + 1) + "일차\n" + (game_mng.time_1 / 600%24) + ":" + (game_mng.time_1 / 60%60);
        }else if (game_mng.now_game == 2)
        {
            game_mng.time_2++;


            time_text_1.text = ((game_mng.time_2 / 14400) + 1) + "일차\n" + (game_mng.time_2 / 600%24) + ":" + (game_mng.time_2 / 60%60);

        }else if (game_mng.now_game == 3)
        {
            game_mng.time_3++;


            time_text_1.text = ((game_mng.time_3 / 14400) + 1) + "일차\n" + (game_mng.time_3 / 600%24) + ":" + (game_mng.time_3 / 60%60);

        }
      
        yield return new WaitForSeconds(1f/6f);
        StartCoroutine("time_coru", 1f/6f);
    }
    // Start is called before the first frame update
    void Start()
    {
        tab_pop_bool = false;
        time = 0;
        game_mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine("time_coru", 1f/6f);
    }

    public void game_exit()
    {
        is_play = false;
    }
    public void game_1_start()
    {
        game_mng.now_game = 1;
        is_play = true;
        game_mng.game_pop.SetActive(true);
        time_text_1.text = game_mng.time_1.ToString();
    }
    
    public void game_2_start()
    {
        game_mng.now_game = 2;
        is_play = true;
        game_mng.game_pop.SetActive(true);
        time_text_1.text = game_mng.time_2.ToString();
    }
    
    public void game_3_start()
    {
        game_mng.now_game = 3;
        is_play = true;
        game_mng.game_pop.SetActive(true);
        time_text_1.text = game_mng.time_3.ToString();
    }
    public void new_game()
    {
        if (game_mng.time_1 == -1 && game_mng.time_2 == -1 && game_mng.time_3 == -1)
        {
            game_mng.time_1 = 0;
        }else if (game_mng.time_1 != -1 && game_mng.time_2 == -1 && game_mng.time_3 == -1)
        {
            game_mng.time_2 = 0;
        }else if (game_mng.time_1 != -1 && game_mng.time_2 != -1 && game_mng.time_3 == -1)
        {
            game_mng.time_3 = 0;
        }else if (game_mng.time_1 != -1 && game_mng.time_2 != -1 && game_mng.time_3 != -1)
        {
            
        }
        game_mng.Save();
    }
    public void list_load()
    {
        if (game_mng.time_1 == -1)
        {
          game_1_btn.SetActive(false);
        }
        else
        {
            game_1_btn.SetActive(true);
        }
        
        if (game_mng.time_2 == -1)
        {
            game_2_btn.SetActive(false);
        }
        else
        {
            game_2_btn.SetActive(true);
        }
        
        if (game_mng.time_3 == -1)
        {
            game_3_btn.SetActive(false);
        }
        else
        {
            game_3_btn.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (is_play)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                tab_pop_bool = !tab_pop_bool;
                if (tab_pop_bool)
                {
                      game_tab_pop.SetActive(true);
                }
                else
                {
                    game_tab_pop.SetActive(false);
                }
              
            }
        }
    }
}
