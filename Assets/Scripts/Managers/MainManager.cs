using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private MenuManager menuManager;
    
    // TODO: Load all building prefabs. when clicked, find them loaded in lists. Or not? Performance test later on
    //TODO: Mozda da se rastereti GameplayManager. Da klik na dugme, koje svakako se pojavljuje samo na toj sceni
    //TODO: pod odredjenim uslovima, npr kliknuto menu dugme, direktno zove logiku za gameplay koja
    //TODO: se takodje nalazi samo na toj sceni
    private void Awake()
    {
        Intitialize();
    }

    private void Intitialize()
    {
        levelManager.Initialize();
        inputManager.Initialize(levelManager.CancelActions, levelManager.HandleWorldClicked);
        menuManager.Initialize(levelManager.BuildStructure);
        //Maybe use custom event system. used only for subscription to ui.
    }
}

