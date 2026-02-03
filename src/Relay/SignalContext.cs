using UnityEngine;

namespace weluvsubtitle.Relay;

public struct SignalContext(string id, Vector3 pos, float Intensity = 1f)
{
    public string id;
    
    public Vector3 pos;
    
    public float Intensity;
}