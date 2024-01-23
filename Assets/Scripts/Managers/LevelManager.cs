using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private CameraController mainCameraController;
    [SerializeField] private Camera mainCamera;
    
    // TODO: This should handle Level component? or LevelData or something.
    [SerializeField] private List<GameObject> structurePrefabs;
    
    public static LevelManager Instance;
    
    public Camera MainCamera => mainCamera;

    public Vector2 MouseWorldPosition => mainCamera.ScreenToWorldPoint(Input.mousePosition);

    //Again, should you avoid references?
    private BuildStructureManager buildStructureManager = new BuildStructureManager();

    public void Initialize()
    {
        //TODO: Set up pan limits based on terrain. Map vs terrain?
        //mainCameraController       
        //buildStructureManager initialize? 
        
    }
    
    private void Awake()
    {
        Instance = this;
        // Add to game initialization functions. Maybe separate class that starts at the beginning of
        // everything
        //Cursor.lockState = CursorLockMode.Confined;
        //Not working as intended yet. 

    }

    void Update()
    {
        
    }

    public void CancelActions()
    {
        buildStructureManager.CancelActions();
    }

    public void BuildStructure(int id)
    {
        //play sound here or in buildingmaanager
        //mouse to world position
        // Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        //check za id da ne crashuje po index out of range
        buildStructureManager.BuildStructure(structurePrefabs[id]);
        Debug.Log("Build structure with id:" + id);
        // TODO: Call Building system manager. But load prefab here. or find if already loaded
        // TODO: Getting into logic here and gameplay. This is for 0.2version
    }

    public void HandleWorldClicked(List<RaycastHit2D> hits)
    {
        CancelActions();
        //TODO: TESTONLY 
    }
}