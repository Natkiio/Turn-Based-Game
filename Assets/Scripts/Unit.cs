using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPos;

    private void Update() 
    {
        float stoppingDist = .1f; //Distance to stop before new pos

        if (Vector3.Distance(transform.position, targetPos) > stoppingDist)
        {
            Vector3 moveDirection = (targetPos - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
        } 
        

        if (Input.GetKeyDown(KeyCode.T))
        {
            Move(new Vector3(4,0,4)); //When T is pressed, move to this location.
        }
    }
   private void Move (Vector3 targetPos)
   {
        this.targetPos = targetPos;
   }
}
