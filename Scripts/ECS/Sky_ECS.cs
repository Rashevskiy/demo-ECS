using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sky_ECS : MonoBehaviour
{
    public static Sky_ECS Instance;
    
    [SerializeField] private BoxCollider _moveBox;
    [SerializeField] public GameObject _flyObjectPrefab;

    private MainSystem _systems;
    public void Awake()
    {
        Instance = this;
        var contexts = Contexts.sharedInstance;
        var entity = contexts.game.CreateEntity();
        entity.AddMoveBox(_moveBox.bounds);
        _systems = new MainSystem(Contexts.sharedInstance);
    }

    public void Update()
    {
        _systems.Execute();
    }
    
}
