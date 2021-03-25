using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision) {
        if(collision.transform.name == "Sphere") { //palitan mo lang yung "Sphere" into name nung ball
            Score += 10;
        }
    }
}
