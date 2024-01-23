using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Ovo je konkretan meni. Znaci imena promenljivih i to sve treba da budu specificno za taj meni.
// Mislim da nema potrebe da se generalizuje za sve building menije, ali razmislicu
public class BuildingMenu : Menu
{
    // Kako ovde?
    [SerializeField] private List<Button> buildingButtons;

    private UnityAction<int> onBuildStructureButtonClicked;
    public void Initialize(UnityAction<int> handleBuildStructureButtonClicked)
    {
        onBuildStructureButtonClicked += handleBuildStructureButtonClicked;
    }
    
    // Mozda ime da bude BuildButtonClick, nesto sa button click. Takodje build nije dobar naziv.
    public void BuildStructure(GameObject structure)
    {
        //error check? mozda u dev fazu makar. structure dal ima komponentu
        onBuildStructureButtonClicked?.Invoke(structure.GetComponent<MapElement>().id);
    }
}
