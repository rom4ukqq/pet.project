
public class EnemyDragonView : EnemyView
{
    public void OnDieAnimationFinished()
    {
        _enemy.Recycle();
    }
}