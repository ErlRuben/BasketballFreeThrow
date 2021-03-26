using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartQuit : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transition;
    public GameObject panel;
    public void StartGame(){
        StartCoroutine(LoadLevel());
        SceneManager.LoadScene(1);
        panel.SetActive(true);
    }
    public void QuitGame(){
        StartCoroutine(LoadLevel());
        panel.SetActive(false);
        Application.Quit();
    }
    public void Restart(){
        StartCoroutine(LoadLevel());
        SceneManager.LoadScene(0);
    }
    IEnumerator LoadLevel(){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
    }

}
