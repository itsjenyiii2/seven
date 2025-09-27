using UnityEngine;

public class newbounds : MonoBehaviour
{
    private void Awake()
    {
        var bounds = GetComponent<SpriteRenderer>().bounds;
        global.WorldBounds = bounds;
    }
}
