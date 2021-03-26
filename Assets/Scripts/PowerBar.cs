using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class PowerBar : MonoBehaviour
{
    [SerializeField]
    private Image imagePower;
    [SerializeField]
    public Text textPower;
    
    private bool isDirectionUp = true;
    public float ammntPower = 0.0f;
    private float speedPower = 50.0f;
    
    public Rigidbody rb;
    public GameObject ball;
    public GameObject button;


    void Start() {
        Rigidbody rb = GetComponent<Rigidbody>();
        button.SetActive(true);
    }
    void Update()
    {   
        PowerActive();
        if(Input.GetButtonDown("Fire1")){   
            EndPower();          
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
        textPower.text = ammntPower.ToString("F0");
    }

    public void EndPower()
    {
        rb.AddForce(Vector3.up * ammntPower * 200.0f);
        rb.AddForce(Vector3.left * ammntPower * 190.0f);
        textPower.text = ammntPower.ToString("F0");
    }
    
}
 

