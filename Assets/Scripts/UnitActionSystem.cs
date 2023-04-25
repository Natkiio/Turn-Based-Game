using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{

    public static UnitActionSystem Instance {get; private set;}
    public event EventHandler OnSelectedUnitChanged;

   [SerializeField] private Unit selectedUnit; // Selects unit 
   [SerializeField] private LayerMask unitLayerMask;

   private void Awake()
   {
        if (Instance != null)
        {
            Debug.Log("More than one Unit Action System" + transform + " - " + "instance");
            Destroy(gameObject);
            return;
        }        
        
        Instance = this;
   }

   private void Update() 
   {
        if (Input.GetMouseButtonDown(0)) // 0 is the Left (Primary) Mouse Button
            { 
             if (TryHandleUnitSelection()) return;
             selectedUnit.Move(MouseWorld.GetPosition()); //Moves unit to mouse click position 
            }
   }

   private bool TryHandleUnitSelection()
   {
         Ray ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out RaycastHit raycastHit,float.MaxValue,unitLayerMask)) 
            {
                if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
                {
                    SetSelectedUnit(unit);
                    return true;
                }
            }  
        return false;
   }
   private void SetSelectedUnit(Unit unit)
   {
        selectedUnit = unit;

        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
   }

   public Unit GetSelectedUnit()
   {
        return selectedUnit;
   }
}
