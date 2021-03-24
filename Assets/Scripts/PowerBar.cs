using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerBar : MonoBehaviour
{
    [SerializeField]
    private Image imagePower;
    [SerializeField]
    private TMP_Text textPower;

    private bool isPowerUp = false;
    private bool isDirectionUp = true;
    private float ammntPower = 0.0f;
    private float speedPower = 500.0f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (isPowerUp){
            PowerActive();
        }
    }
    public void PowerActive(){
        if(isDirectionUp){
            ammntPower += Time.deltaTime * speedPower;
            if(ammntPower > 100){
                isDirectionUp = false;
                ammntPower = 100.0f;
            }
        }
        else{
            ammntPower -= Time.deltaTime * speedPower;
            if (ammntPower < 0){
                isDirectionUp = true;
                ammntPower = 0.0f;
            }
        }
        imagePower.fillAmount = (0f - 1f) * ammntPower / 100.0f + 1f;
    }
    public void PowerUp()
    {
        isPowerUp = true;
        ammntPower = 0.0f;
        isDirectionUp = true;
        textPower.text = ammntPower.ToString("F0");
    }
    public void EndPower()
    {
        isPowerUp = false;
        textPower.text = ammntPower.ToString("F0");
    }
}
