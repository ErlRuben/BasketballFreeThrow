using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10.0f;
    public GameObject UI;
    public GameObject Character;
    public GameObject Lose;
    public Text text;
    public bool isLose = false;
    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponent<Text>();
        currentTime = startingTime;
    }
    void Update() {
        if(isLose == true){
            UI.SetActive(false);
            Character.SetActive(false);
            Lose.SetActive(true);
        }
        else{
            Clock();
        }
    }
    // Update is called once per frame
    void Clock()
    {
        if (isLose == false && currentTime > 0){
            currentTime -= 1 * Time.deltaTime;
            text.text = currentTime.ToString("0");
        }
        else if (currentTime == 0){
            isLose = true;
        }
        else if (isLose == true && currentTime < 0) {
            Destroy(UI);
            Destroy(Character);
            Destroy(Lose);

        }
    }
}
