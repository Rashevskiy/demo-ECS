using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystem : Feature
{
    public MainSystem(Contexts context)
    {
        Add(new ObjectCreatorSystem(context));
        Add(new FlyingSystem(context));
        Add(new GenerationTargetSystem(context));
    }
    
}
