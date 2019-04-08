using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShaker : MonoBehaviour
{

    public Transform cameraTransform;
    public float shakeTime = 0f; 
    public float shakePower = .5f;
    private Vector3 originalPosition = new Vector3(342f, 191f, -10f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTime <= 0)
        {
            originalPosition = cameraTransform.localPosition;
            shakeTime = 0f;
        }
        else 
        {
            Vector3 temp = new Vector3(cameraTransform.localPosition.x + Random.insideUnitSphere.x * shakePower, originalPosition.y + Random.insideUnitSphere.y * shakePower, originalPosition.z ); 
            cameraTransform.localPosition = temp;
            shakeTime -= Time.deltaTime;
        }
    }

    public void startShake(float newTime, float newPower)
    {
        shakeTime = newTime;
        shakePower = newPower;
    }
}
