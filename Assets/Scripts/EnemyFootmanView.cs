
public class EnemyFootmanView : EnemyView
{
    public void OnDieAnimationFinished()
    {
        _enemy.Recycle();
    }
}