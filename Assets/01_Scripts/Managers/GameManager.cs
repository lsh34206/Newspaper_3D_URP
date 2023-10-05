using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int time_1;
    public int time_2;
    public int time_3;

    public DateManager dataManager;

    public int now_game;
    public Sprite game_tab_img;
    public GameObject game_pop;

    void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager == null)
        {
            
        }
        dataManager = GameObject.Find("Canvas").GetComponent<DateManager>();
    }

    public void click_sound()
    {
        GameObject.Find("GameManager").GetComponent<AudioSource>().Play();
    }
   

    public void go_main()
    {
        SceneManager.LoadScene(1);
    }

    public void go_lobby()
    {
        SceneManager.LoadScene(2);
    }

    public void go_game()
    {
        SceneManager.LoadScene(0);
    }

}
