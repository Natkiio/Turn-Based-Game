using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //proper raycast 
        Debug.Log(Physics.Raycast(ray, out RaycastHit raycastHit)); //returns true if hit something 
        transform.position = raycastHit.point; //moving object to raycast point
    }
}
