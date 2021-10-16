using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ObjectCreatorSystem : IExecuteSystem
{
    private Contexts _context;
    
    public ObjectCreatorSystem(Contexts context)
    {
        _context = context;
    }
    
    public void Execute()
    {
        Debug.Log("executing");
        
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Press");
           var entity = _context.game.CreateEntity();
           var newFlyObject = GameObject.Instantiate(Sky_ECS.Instance._flyObjectPrefab).GetComponent<FlyObject>();
           entity.AddTransform(newFlyObject.transform);
           entity.AddFlyObject(newFlyObject.rotationSpeed,newFlyObject.speed,newFlyObject.acceleration,newFlyObject.maxSpeed,newFlyObject.finishDistance);
           entity.AddTargetPoint(new Vector3(-5f,1.6f,0f));
        }
    }
}
