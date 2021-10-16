using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyObject : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 150f;
    [SerializeField] public float speed = 0.01f;
    [SerializeField] public float acceleration = 0.005f;
    [SerializeField] public float maxSpeed = 0.04f;

    [SerializeField] public float finishDistance = 2f;
    private Vector3 target;
    private Sky_ClassicUnity sky;
    private Coroutine flyRoutine;
    public void Init(Sky_ClassicUnity birdSky){
        this.sky = birdSky;
    }

    public void Fly(){
        if(flyRoutine == null){
            flyRoutine = StartCoroutine(Flying());
        }
    }
    public void StopFly(){
        StopCoroutine(flyRoutine);
        flyRoutine = null;
    }
    private IEnumerator Flying()
    {
        target = sky.RandomPointInBounds();
        while (true)
        {
            float currentRotationSpeed = rotationSpeed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.LookRotation((target - transform.position).normalized);
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, currentRotationSpeed);
            transform.rotation = newRotation;
            
            // Accelerate
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, 0, maxSpeed);
            
            // Move.
            transform.Translate(Vector3.forward * speed);
            
            
            if (Vector3.Distance(transform.position, target) < finishDistance)
            {
                target = sky.RandomPointInBounds();
            }
            yield return null;
        }
    }
}
