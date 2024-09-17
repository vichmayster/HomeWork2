using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleLogic : MonoBehaviour
{
   
    public delegate void ApplCollacted();
    public static event ApplCollacted Collacted;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
          
            Collacted?.Invoke();

            
            Destroy(gameObject);
        }
    }
}