using System;
using UnityEngine;

public abstract class Tower : GameTileContent
{
    [SerializeField, Range(1.5f, 10.5f)] protected float _targetingRange = 1.5f;

    private const int ENEMY_LAYER_MASK = 1 << 9;
    
    public abstract TowerType Type { get; }
    
    protected bool IsAcquireTarget(out TargetPoint target)
    {
        Collider[] targets = Physics.OverlapSphere(transform.localPosition, _targetingRange, ENEMY_LAYER_MASK);
        if (targets.Length > 0)
        {
            target = targets[0].GetComponent<TargetPoint>();
            return true;
        }

        target = null;
        return false;
    }

    protected bool IsTargetTracked(ref TargetPoint target)
    {
        if (target == null)
        {
            return false;
        }

        Vector3 myPos = transform.localPosition;
        Vector3 targetPos = target.Position;
        if (Vector3.Distance(myPos, targetPos) > _targetingRange + target.ColliderSize * target.Enemy.Scale)
        {
            target = null;
            return false;
        }
        return true;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 position = transform.localPosition;
        position.y += 0.01f;
        Gizmos.DrawWireSphere(position, _targetingRange);
    }
}
