using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DateManager : MonoBehaviour
{
    public TextMeshProUGUI time_text_1;
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

    public bool choise_game_1=false;
    public bool choise_game_2=false;
    public bool choise_game_3=false;
    public int delete_game_num;
    public GameObject alert;
    public TextMeshProUGUI alert_text;

    public string comfirm_mode;

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
     list_load();
    }
    IEnumerator time_coru()
    {
        if (game_mng.now_game == 1)
        {
            if (game_mng.time_1 >= 0)
            {
                   game_mng.time_1++;
            }

            if (time_text_1 != null)
            {
                
            

            time_text_1.text = ((game_mng.time_1 / 14400) + 1) + "일차\n" + (game_mng.time_1 / 600%24) + ":" + (game_mng.time_1 / 60%60);
        }else if (game_mng.now_game == 2)
        {
            if (game_mng.time_2 >= 0)
            {
                game_mng.time_2++;
            }


            time_text_1.text = ((game_mng.time_2 / 14400) + 1) + "일차\n" + (game_mng.time_2 / 600%24) + ":" + (game_mng.time_2 / 60%60);

        }else if (game_mng.now_game == 3)
            {
                if (game_mng.time_3 >= 0)
                {
                    game_mng.time_3++;
                }


                time_text_1.text = ((game_mng.time_3 / 14400) + 1) + "일차\n" + (game_mng.time_3 / 600 % 24) + ":" +
                                   (game_mng.time_3 / 60 % 60);
            }
        }
      
        yield return new WaitForSeconds(1f/6f);
        StartCoroutine("time_coru", 1f/6f);
    }
    // Start is called before the first frame update
    void Start()
    {
        tab_pop_bool = false;

        comfirm_mode = "";
        game_mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        game_mng.Load();
        list_load();
        SceneManager.sceneLoaded += LoadedsceneEvent;
        StartCoroutine("time_coru", 1f/6f);
    }

    public void game_exit()
    {
        is_play = false;
    }

    public void game_1_choise()
    {
        choise_game_1 = !choise_game_1;
        if (choise_game_1)
        {
            game_1_btn.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
        else
        {
              game_1_btn.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
      
    }
    
    public void game_2_choise()
    {
        choise_game_2 = !choise_game_2;
        if (choise_game_2)
        {
            game_2_btn.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
        else
        {
            game_2_btn.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
      
    }
    
    public void game_3_choise()
    {
        choise_game_3 = !choise_game_3;
        if (choise_game_3)
        {
            game_3_btn.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
        else
        {
            game_3_btn.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
      
    }


    public void delete_btn_click()
    {
        if (choise_game_1||choise_game_2||choise_game_3)
        {
       
            alert_text.text = "정말 삭제하시겠습니까?";
            alert.SetActive(true);
        }
    }

    public void comfirm_con()
    {
        if (comfirm_mode == "삭제")
        {
            delete_func();
        }else if (comfirm_mode == "입장")
        {

            if (choise_game_1)
            {
                game_mng.now_game = 1;
                is_play = true;
                SceneManager.LoadScene(0);
            }
            else if(choise_game_2)
            {
                game_mng.now_game =2;
                is_play = true;
                SceneManager.LoadScene(0);
            }else if(choise_game_3)
            {
                game_mng.now_game =3;
                is_play = true;
                SceneManager.LoadScene(0);
            }
            else
            {
                
            }
        }
    }
    
    
    public void game_start()
    {
        
        if (game_mng.time_1 != -1 && game_mng.time_2 != -1  && game_mng.time_3 != -1 )
        {
               game_mng.time_1 = 0;
                                            game_mng.now_game = 1;
        }
        else
        {





            if (game_mng.time_1 == -1 && game_mng.time_2 == -1 && game_mng.time_3 == -1 ||
                game_mng.time_1 == -1 && game_mng.time_2 != -1 && game_mng.time_3 != -1 ||
                game_mng.time_1 == -1 && game_mng.time_2 != -1 && game_mng.time_3 == -1 )
            {
               
            }else if(game_mng.time_1 != -1 && game_mng.time_2 == -1 && game_mng.time_3 != -1 ||
                     game_mng.time_1 != -1 && game_mng.time_2 != -1 && game_mng.time_3 == -1 ||
                     game_mng.time_1 != -1 && game_mng.time_2 == -1 && game_mng.time_3 == -1 )
            
            {
                game_mng.time_2 = 0;
                game_mng.now_game = 2;
              
            }else if(game_mng.time_1 != -1 && game_mng.time_2 != -1 && game_mng.time_3 == -1 )
            
            {
                game_mng.time_3 = 0;
                game_mng.now_game = 3;
              
            }
            
            
       
            
             
        }



              is_play = true;
            SceneManager.LoadScene(0);
    }
    
    
    public void delete_mode()
    {

        comfirm_mode = "삭제";



    }
    
     
    public void visit_mode()
    {

        comfirm_mode = "입장";



    }
    
   

   


    public void delete_func()
    {
        if (choise_game_1)
        {
            game_mng.time_1 = -1;
        }
        
      if(choise_game_2)
        {
            game_mng.time_2 = -1;
        }
      
      if(choise_game_3)
        {
            game_mng.time_3 = -1;
        }
        
        list_load();
    }
   
    public void list_load()
    {
        if (game_mng.time_1 == -1)
        {
            game_1_btn.GetComponent<Button>().interactable = false;
        }
        else
        {
            game_1_btn.GetComponent<Button>().interactable = true;
        }
        
        if (game_mng.time_2 == -1)
        {
            game_2_btn.GetComponent<Button>().interactable = false;
        }
        else
        {
            game_2_btn.GetComponent<Button>().interactable = true;
        }
        
        if (game_mng.time_3 == -1)
        {
            game_3_btn.GetComponent<Button>().interactable = false;
        }
        else
        {
            game_3_btn.GetComponent<Button>().interactable = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (is_play)
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                tab_pop_bool = !tab_pop_bool;
                if (tab_pop_bool)
                {
                      game_tab_pop.SetActive(true);
                      list_load();
                }
                else
                {
                    game_tab_pop.SetActive(false);
                }
              
            }
        }
    }
}
