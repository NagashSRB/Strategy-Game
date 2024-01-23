using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Better name, construction or something like that. System.
public class BuildStructureManager
{
    private GameObject selectedStructure;
    private DragMapElement selectedBuildingDragComponent;
    public void BuildStructure(GameObject structure)
    {
        Vector3 structurePosition = LevelManager.Instance.MouseWorldPosition;
        structurePosition.z = -1; // hard coded but change that
        // Todo: add parent
        selectedStructure = Object.Instantiate(structure, structurePosition, Quaternion.identity);
        selectedBuildingDragComponent = selectedStructure.AddComponent<DragMapElement>();
        selectedBuildingDragComponent.StartDragging();
        // Highlight
    }

    // Name: Cancel Building. Or cancel for everything? If building, then cancal that. if moving, also.
    // how to define those kind of processes?
    public void CancelActions()
    {
        if (selectedStructure == null)
        {
            return;
        }
        
        selectedBuildingDragComponent.StopDragging();
        Object.Destroy(selectedBuildingDragComponent);
        selectedStructure = null;
    }
}
