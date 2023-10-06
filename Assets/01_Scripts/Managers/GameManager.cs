using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
  

    public DateManager datamanager;

    public int now_game;
    public Sprite game_tab_img;
    public GameObject game_pop;

    void Start()
    {
        datamanager = GameObject.Find("GameManager").GetComponent<DateManager>();
      
    }

    public void click_sound()
    {
        GameObject.Find("GameManager").GetComponent<AudioSource>().Play();
    }
   

    public void go_main()
    {
        SceneManager.LoadScene(0);
    }

    public void go_game()
    {
        SceneManager.LoadScene(1);
    }

}
