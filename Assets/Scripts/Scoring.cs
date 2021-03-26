using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Scoring : MonoBehaviour
{
    public int score;
    public Text text;
    private float moveLevel = 4;
    public GameObject Ball1;
    public GameObject Ball2;
    public GameObject Ball3;
    public GameObject Ball4;
    public Transform Waypoint1;
    public Transform Waypoint2;
    public Transform Waypoint3;
    public GameObject Character;
    public GameObject UI;
    public GameObject CharacterUI;
    public GameObject LoseUI;   
    public AudioSource ring;

    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider collision) {
        ring.Play();
        if(collision.transform.name == "Ball") {
        
            score = score + 25;
            moveLevel -= 1;
            if (moveLevel == 4){
                Ball1.SetActive(false);
                Ball2.SetActive(false);
                Ball3.SetActive(false);
                Ball4.SetActive(false);
            }
            else if (moveLevel == 3){
                Ball1.SetActive(false);
                Ball2.SetActive(false);
                Ball3.SetActive(false);
                Ball4.SetActive(true);
                Character.transform.position = Waypoint1.position;
            }
            else if (moveLevel == 2){
                Ball1.SetActive(false);
                Ball2.SetActive(false);
                Ball3.SetActive(true);
                Ball4.SetActive(true);
                Character.transform.position = Waypoint2.position;

            }
            else if (moveLevel == 1){
                Ball1.SetActive(false);
                Ball2.SetActive(true);
                Ball3.SetActive(true);
                Ball4.SetActive(true);
                Character.transform.position = Waypoint3.position;

            }
            else if (moveLevel == 0){
                Ball1.SetActive(true);
                Ball2.SetActive(true);
                Ball3.SetActive(true);
                Ball4.SetActive(true);
                StartCoroutine(MoveLevel());

            }
            text.text = score.ToString();
        }
    }
    public void LoseGame(){
        UI.SetActive(false);
        CharacterUI.SetActive(false);
        LoseUI.SetActive(true);
    }
    IEnumerator MoveLevel (){
        SceneManager.LoadScene(3);
        yield return new WaitForSeconds(1);
        
    }
}
