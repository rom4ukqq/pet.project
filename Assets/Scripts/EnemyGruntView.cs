
public class EnemyGruntView : EnemyView
{
    public void OnDieAnimationFinished()
    {
        _enemy.Recycle();
    }
}
