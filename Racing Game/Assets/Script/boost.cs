using UnityEngine;
 using System.Collections;
 
 public class boost : MonoBehaviour
 {
     public float boostCooldown = 10f;
     public float boostDuration = 2f;
     private float speedBoost = 30;
 
     private bool hasCooldown;
     private Vector3 normalMovementVector = Vector3.forward;
     private Vector3 currentMovementVector;
 
     void Start()
     {
         currentMovementVector = normalMovementVector;
 
         StartCoroutine(ActivateCooldown());
     }
     
     void Update()
     {
         if(Input.GetKeyDown(KeyCode.Q) && !hasCooldown)
         {
             
             currentMovementVector += Vector3.forward * speedBoost; 
            
             StartCoroutine(ActivateCooldown());
             StartCoroutine(ResetMovementVector());
         }
         
         transform.Translate(currentMovementVector * Time.deltaTime);
     }
 
     IEnumerator ResetMovementVector()
     {
         
         yield return new WaitForSeconds(boostDuration);
         
         currentMovementVector = normalMovementVector;
         Debug.Log("NITRO EXPIRED!");
     }
 
     IEnumerator ActivateCooldown()
     {
         
         hasCooldown = true;
         
         yield return new WaitForSeconds(boostCooldown);
         
         hasCooldown = false;
         Debug.Log("NITRO READY!"); 
         
     }
 }