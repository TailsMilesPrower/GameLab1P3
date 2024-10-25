using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    private bool _isCausingDamage = false;
    public float DamageRepeatRate = 1f;
    public int DamageAmount = 1;
    public bool Repeating = true;



    private void OnTriggerEnter()
    {
        _isCausingDamage = true;
        PlayerController player = gameObject.GetComponent<PlayerController>();

        if (player != null )
        {
            if(Repeating)
            {
                StartCoroutine(TakeDamage(player, DamageRepeatRate));
            }
        }
    }

    IEnumerator TakeDamage(PlayerController player, float repeatRate)
    {
        while(_isCausingDamage)
        {
            player.TakeDamage(DamageAmount);
            TakeDamage(player, repeatRate);
            yield return new WaitForSeconds(repeatRate);
        }
    }

    private void OnTriggerExit()
    {
        PlayerController player = gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            _isCausingDamage = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
