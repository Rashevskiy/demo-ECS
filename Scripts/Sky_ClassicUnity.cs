using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky_ClassicUnity : MonoBehaviour
{
    [SerializeField] private GameObject flyObjectPrefab;
    [SerializeField] private Collider moveBox;
    
    private List<FlyObject> _flyObjects;
    private Bounds moveBoxBounds;
    void Start()
    {
        _flyObjects = new List<FlyObject>();
        moveBoxBounds = moveBox.bounds;
        InitFlyObjects();
        StartCoroutine(ButtonListener());
    }

    public Vector3 RandomPointInBounds()
    {
        var target = new Vector3(
            UnityEngine.Random.Range(moveBoxBounds.min.x, moveBoxBounds.max.x),
            UnityEngine.Random.Range(moveBoxBounds.min.y, moveBoxBounds.max.y),
            UnityEngine.Random.Range(moveBoxBounds.min.z, moveBoxBounds.max.z)
        );

        return target;
    }
    public void AddFlyObject()
    {
        var newBird = Instantiate(flyObjectPrefab).GetComponent<FlyObject>();
        _flyObjects.Add(newBird);
        newBird.Init(this);
        newBird.Fly();
        newBird.transform.parent = this.transform;
        this.gameObject.name = "bird " + _flyObjects.Count;
    }

    private void InitFlyObjects(){

        for (int i = 0; i < _flyObjects.Count; i++)
        {
            _flyObjects[i].Init(this);
            _flyObjects[i].Fly();
        }
    }

    private IEnumerator ButtonListener()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForSeconds(0.2f);
                AddFlyObject();
            }
            yield return null;
        }
    }
    
}
