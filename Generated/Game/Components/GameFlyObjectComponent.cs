//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public FlyObjectComponent flyObject { get { return (FlyObjectComponent)GetComponent(GameComponentsLookup.FlyObject); } }
    public bool hasFlyObject { get { return HasComponent(GameComponentsLookup.FlyObject); } }

    public void AddFlyObject(float newRotationSpeed, float newSpeed, float newAcceleration, float newMaxSpeed, float newFinishDistance) {
        var index = GameComponentsLookup.FlyObject;
        var component = (FlyObjectComponent)CreateComponent(index, typeof(FlyObjectComponent));
        component.rotationSpeed = newRotationSpeed;
        component.speed = newSpeed;
        component.acceleration = newAcceleration;
        component.maxSpeed = newMaxSpeed;
        component.finishDistance = newFinishDistance;
        AddComponent(index, component);
    }

    public void ReplaceFlyObject(float newRotationSpeed, float newSpeed, float newAcceleration, float newMaxSpeed, float newFinishDistance) {
        var index = GameComponentsLookup.FlyObject;
        var component = (FlyObjectComponent)CreateComponent(index, typeof(FlyObjectComponent));
        component.rotationSpeed = newRotationSpeed;
        component.speed = newSpeed;
        component.acceleration = newAcceleration;
        component.maxSpeed = newMaxSpeed;
        component.finishDistance = newFinishDistance;
        ReplaceComponent(index, component);
    }

    public void RemoveFlyObject() {
        RemoveComponent(GameComponentsLookup.FlyObject);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherFlyObject;

    public static Entitas.IMatcher<GameEntity> FlyObject {
        get {
            if (_matcherFlyObject == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FlyObject);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFlyObject = matcher;
            }

            return _matcherFlyObject;
        }
    }
}
