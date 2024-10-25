using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // [Range (0f, 180f)]
    public float rotation = 0f;

    public float dayCycle = 20f;

    public Vector3 rotationAxis = new Vector3(0f, 1f, 2f);

    // Update is called once per frame
    void Update()
    {
        rotation = dayCycle * Time.deltaTime;
        
        transform.Rotate(rotationAxis, rotation, Space.World);
    }
}
