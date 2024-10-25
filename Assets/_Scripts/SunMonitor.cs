using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMonitor : MonoBehaviour
{
    public LayerMask mask;
    public Light dirLight;
    private Vector3 oppositeDirection;
    private Renderer playerRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        oppositeDirection = -1f * dirLight.transform.forward;
        // Debug.Log(oppositeDirection.ToString());
        RaycastHit hit;

        if (Physics.BoxCast(transform.position, transform.localScale * 0.25f, oppositeDirection, out hit, transform.rotation, 100f, mask)) {
            Debug.DrawRay(transform.position, oppositeDirection * hit.distance, Color.green);
            playerRenderer.material.color = Color.green;
        } else 
        {
            Debug.DrawRay(transform.position, oppositeDirection * 50f, Color.red);
            playerRenderer.material.color= Color.red;
        }
    }
}
