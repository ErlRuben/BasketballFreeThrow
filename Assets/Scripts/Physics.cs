using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{
    // Start is called before the first frame update
    public float mass;
    public Vector3 velocityVector;
    public Vector3 netForceVector;

    private List<Vector3> forceVectorList = new List<Vector3>();
    private PhysicsEngine[] physicsEngineArray;

    private const float bigG = 6.673e-11f;
    void Start()
    {
        SetupThrustTrails();
        physicsEngineArray = GameObject.FindObjectOfType<physicsEnginearray>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RenderTrails();
        CalculateGravity();
        UpdatePosition();
    }
    public void AddForce (Vector3 forceVector){
        forceVectorList.Add(forceVector);
        Debug.Log("Adding force" + forceVector + " to " + gameObject.name);
    }
    public void CalculateGravity(){
        foreach (PhysicsEngine physicsEngineA in physicsEngineArray){
            foreach(PhysicsEngine physicsEngineB in physicsEngineArray){
                if(physicsEngineA != physicsEngineB){
                    Debug.Log("Calculating force exerted on " + physicsEngineA.name + "due to the gravity of " + physicsEngineB.name);
                    Vector3 offset = physicsEngineA.transform.position - physicsEngineB.transform.position;
                    float rSquared = MathF.Pow (offset.magnitude, 2f);
                    float gravityMagnitude = bigG * physicsEngineA.mass * physicsEngineB.mass / rSquared;
                    Vector3 gravityFeltVector = gravityMagnitude * offset.normalized;

                    physicsEngineA.AddForce(-gravityFeltVector);
                }
            }
        }
    }
    void UpdatePosition (){
        netForceVector =Vector3.zero;
        foreach(Vector3 forceVector in forceVectorList){
            netForceVector = netForceVector + forceVector;
        }
        forceVectorList = new List<Vector3>();
        Vector3 accelerationVector = netForceVector / mass;
        velocityVector += accelerationVector * Time.deltaTime;
        transform.position += velocityVector * Time.deltaTime;
    }
}
