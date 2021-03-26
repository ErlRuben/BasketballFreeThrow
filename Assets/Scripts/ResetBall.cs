using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResetBall: MonoBehaviour
{
    public Transform reset;
    public GameObject ball;
    public GameObject button;
    public Text tryText;
    private float tries = 10;
    private bool isEnable = true;
    public bool collidecheck = true;
    public GameObject ballHolder;
    public AudioSource bounce;
    public AudioSource buzzer;


    void Update()
    {
        
    }
    public void Clicked(){
        if(Input.GetButtonDown("Fire1")){
            button.SetActive(false); 
        }
    }
    public void OnTriggerEnter(Collider other){
        bounce.Play();

        if(collidecheck == true){
            if (tries == 0 && isEnable == true){
                buzzer.Play();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(2);
            }
            StartCoroutine(BallReset()); 
            collidecheck = false;
        }
        else if (collidecheck == false){
            if (tries == 1 && isEnable == true){
                tries -= 1;
                tryText.text = tries.ToString("0");
            }
            else{
                collidecheck = true;
            }
            
        }
        
    }
    IEnumerator BallReset()
    {
        
        if(tries > 1){
            if (collidecheck == true){
                ballHolder.SetActive(false);
                yield return new WaitForSeconds(1);
                button.SetActive(true);
                tries -= 1;
                tryText.text = tries.ToString("0");
                ballHolder.SetActive(true);
                ball.transform.position = reset.position;
                ball.transform.rotation = reset.rotation;
            }      
        } 
    }   
}
