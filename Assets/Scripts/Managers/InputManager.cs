using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//TODO: Menu manager. And it has access to all canvases for example. Or UIManager
public class InputManager : MonoBehaviour
{
    //TODO: maybe pass camera as parameter? Consider could camera be changed.
    public Camera gameCamera;
    public UnityAction onCancelAllActions;
    public UnityAction<List<RaycastHit2D>> onWorldClicked; // maybe convert to transform

    [SerializeField] private GraphicRaycaster canvasRaycaster;
    [SerializeField] private EventSystem eventSystem;

    public void Initialize(UnityAction handleCancelAllActions, UnityAction<List<RaycastHit2D>> handleWorldClicked)
    {
        onCancelAllActions += handleCancelAllActions;
        onWorldClicked += handleWorldClicked;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMousePressed();
        }
        else if (Input.GetMouseButtonUp(0)) //ili neki interrupt mozda? razmisli o tome
        {
            OnMouseReleased();
        }
    }

    #region OnMousePressed
    private void OnMousePressed()
    {
        List<RaycastResult> canvasRaycastResults = GetClickedObjectsOnCanvas();

        if (canvasRaycastResults.Count == 0) // Canvas was not hit
        {
            // Cast regular rays and handle that.
            HandleWorldClicked(GetClickedObjectsOnWorld());
            return;
        }
        
        HandleCanvasClicked(canvasRaycastResults);
    }

    #region Raycasts

    private List<RaycastResult> GetClickedObjectsOnCanvas()
    {
        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = Input.mousePosition;
        
        List<RaycastResult> results = new List<RaycastResult>();
        canvasRaycaster.Raycast(pointerEventData, results);
        return results;
        
        // Maybe using EventSystem. EventSystem.current.IsPointerOverGameObject()
    }

    private List<RaycastHit2D> GetClickedObjectsOnWorld()
    {
        if (gameCamera == null)
        {
            return null;
        }
        
        return RaycastFunction2D(Input.mousePosition, gameCamera);
    }

    private List<RaycastHit2D> RaycastFunction2D(Vector3 screenPosition, Camera targetCamera)
    {
        List<RaycastHit2D> hits = Physics2D.RaycastAll(targetCamera.ScreenToWorldPoint(screenPosition), Vector2.zero)
            .ToList();
        return hits.Count == 0 ? null : hits;
    }
    
    #endregion
    
    private void HandleCanvasClicked(List<RaycastResult> raycastResults)
    {
        if (raycastResults != null)
        {
            foreach (RaycastResult result in raycastResults)
            {
                Debug.Log("Raycast result: " + result.gameObject.name);
            }
        }
    }

    private void HandleWorldClicked(List<RaycastHit2D> raycastResults)
    {
        if (raycastResults != null)
        {
            foreach (RaycastHit2D result in raycastResults)
            {
                Debug.Log("Raycast result: " + result.transform.name);
            }
            
            onWorldClicked?.Invoke(raycastResults);
        }
    }
    
    #endregion

    private void OnMouseReleased()
    {
        //Nije na release, i nije calncel. nego u ovom slucaju je place building. al treba da se vidi sta
        //onCancelAllActions?.Invoke();
    }
}
