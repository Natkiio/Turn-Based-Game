using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjectArray;
    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
     
        gridObjectArray = new GridObject[width,height];

        for(int x = 0; x< width ;x++)
        {
            for(int z = 0; z < height; z++ )
            {
                GridPos gridPos = new GridPos(x,z);
                gridObjectArray[x,z] = new GridObject(this,gridPos);
            }
        }
        
    }


    public Vector3 GetWorldPosition(GridPos gridPos)
    {
        return new Vector3(gridPos.x, 0, gridPos.z) * cellSize;
    }

    public GridPos GetGridPos(Vector3 worldPosistion)
    {
        return new GridPos(

            Mathf.RoundToInt(worldPosistion.x/cellSize),
            Mathf.RoundToInt(worldPosistion.z/cellSize)
        );
    }


    public void CreateDebugObjects(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++ )
            {
                GridPos gridPos = new GridPos(x,z);
                Transform debugTransform = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPos),Quaternion.identity); // no rotation 
                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(GetGridObject(gridPos));
            }
        }
    }

    public GridObject GetGridObject(GridPos gridPos)
    {
        return gridObjectArray[gridPos.x, gridPos.z];
    }
}
