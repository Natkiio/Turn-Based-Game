using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public static MouseWorld instance; //declares a static variable called instance, which will hold a reference to the MouseWorld instance.
   
    [SerializeField] private LayerMask mousePlaneLayerMask;

     private void Awake() //called by Unity when the script is loaded.
    {
        instance = this; //sets the static instance variable to the current instance of the MouseWorld script ( set to the object that the MouseWorld script is attached to.)
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //casts a ray from the main camera through the current mouse position on the screen.
        Physics.Raycast(ray, out RaycastHit raycastHit,float.MaxValue,instance.mousePlaneLayerMask); //performs a raycast using the ray object, and stores information about the hit in the raycastHit variable.
        return raycastHit.point; //returns the position of the raycast hit point as a Vector3.
    }
}
