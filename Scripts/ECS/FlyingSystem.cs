using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class FlyingSystem : IExecuteSystem
{
    private Contexts _context;
    
    public FlyingSystem(Contexts context)
    {
        _context = context;
    }
    
    public void Execute()
    {
        var birds = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.FlyObject, GameMatcher.Transform,
            GameMatcher.TargetPoint));
        foreach (GameEntity bird in birds)
        {

            // First, steer towards the target.
            float currentRotationSpeed = bird.flyObject.rotationSpeed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.LookRotation((bird.targetPoint.value - bird.transform.value.position).normalized);
            Quaternion newRotation = Quaternion.RotateTowards(bird.transform.value.rotation, targetRotation, currentRotationSpeed);
            bird.transform.value.rotation = newRotation;

            // Accelerate
            bird.flyObject.speed += bird.flyObject.acceleration * Time.deltaTime;
            bird.flyObject.speed = Mathf.Clamp(bird.flyObject.speed, 0, bird.flyObject.maxSpeed);

            // Move.
            bird.transform.value.Translate(Vector3.forward * bird.flyObject.speed);
        }
    }
}
