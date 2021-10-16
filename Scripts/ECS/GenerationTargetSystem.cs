using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class GenerationTargetSystem : IExecuteSystem
{
    private Contexts _context;
    private Bounds _bounds;
    
    public GenerationTargetSystem(Contexts context)
    {
        _context = context;
        _bounds = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.MoveBox)).GetSingleEntity().moveBox.value;
    }
    
    public void Execute()
    {
        var birds = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.FlyObject, GameMatcher.Transform,
            GameMatcher.TargetPoint));

        foreach (GameEntity bird in birds)
        {
            if (Vector3.Distance(bird.transform.value.position, bird.targetPoint.value) < bird.flyObject.finishDistance)
            {
                bird.targetPoint.value = RandomPointInBounds();
            }
        }
    }
    
    private Vector3 RandomPointInBounds()
    {
        var target = new Vector3(
            UnityEngine.Random.Range(_bounds.min.x, _bounds.max.x),
            UnityEngine.Random.Range(_bounds.min.y, _bounds.max.y),
            UnityEngine.Random.Range(_bounds.min.z, _bounds.max.z)
        );

        return target;
    }
}
