using UnityEngine;

public abstract class WarEntity : MonoBehaviour
{
    public WarFactory OriginFactory { get; set; }

    public void Recycle()
    {
        OriginFactory.Reclaim(this);
    }
}

