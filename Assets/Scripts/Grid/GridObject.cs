using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
   private GridPos gridPos;
   private GridSystem gridSystem;

   public GridObject(GridSystem gridSystem, GridPos gridPos)
   {
    this.gridPos = gridPos;
    this.gridSystem = gridSystem;

   }

    public override string ToString()
    {
        return gridPos.ToString();
    }
}
