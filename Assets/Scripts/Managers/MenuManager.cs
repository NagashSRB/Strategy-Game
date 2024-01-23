using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    // Mozda bolji sistem, da nema ovde direktne reference na pojedinacni meni nego lista?
    [SerializeField] private BuildingMenu buildingMenu;

    public void Initialize(UnityAction<int> handleBuildStructureButtonClicked)
    {
        buildingMenu.Initialize(handleBuildStructureButtonClicked);
    }
}
