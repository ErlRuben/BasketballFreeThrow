using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSFX : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource shoot;

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        shoot.Play();
    }
}
