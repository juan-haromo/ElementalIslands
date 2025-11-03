using Fusion;
using UnityEngine;

public class BasicEnemy : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Runner.IsSharedModeMasterClient) { return; }
        
    }
}
