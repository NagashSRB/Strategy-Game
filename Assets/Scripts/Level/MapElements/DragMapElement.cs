using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMapElement : MonoBehaviour
{
    //what to do with z? 0? 1?
    private bool isDragging;
    private void Update()
    {
        if (!isDragging)
        {
            return;
        }

        Vector2 mousePosition = LevelManager.Instance.MouseWorldPosition;
        
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        
        //Vector3 pos = BuildingSystem.GetMouseWorldPosition() + offset;
        //transform.position = BuildingSystem.current.SnapCoordinateToGrid(pos);
    }

    public void StartDragging()
    {
        isDragging = true;
    }
    
    public void StopDragging()
    {
        isDragging = false;
    }

}
