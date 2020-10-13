using UnityEngine;
using System.Collections;
 
public class unflip : MonoBehaviour
{
 
    public KeyCode pressE;

 
    
    void Start ()
    {
       
    }
   

    void Update ()
    {
        
        if(Input.GetKeyDown(pressE))
        GetComponent<Transform> ().eulerAngles = new Vector3(0, -90, 0);

      
    }
}
 