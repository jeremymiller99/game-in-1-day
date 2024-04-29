using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenu;
    public static bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        deathMenu.SetActive(false);
    }

    void Update(){
        if(isDead){
            deathMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void PlayAgain(){
        deathMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        isDead = false;
    }

    public void GoToMenu(){
        deathMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        isDead = false;
    }
}
