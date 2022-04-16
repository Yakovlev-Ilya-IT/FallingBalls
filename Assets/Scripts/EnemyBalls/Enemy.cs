using UnityEngine;

public class Enemy : MonoBehaviour, IShootable
{
    private float _speed;
    private int _rewardPoints;
    private int _damage;

    private float _bottomBorder;

    [SerializeField] private EnemyView _view;


    public void Initizalize(EnemyConfiguration enemyConfiguration)
    {
        _speed = enemyConfiguration.Speed;
        _rewardPoints = enemyConfiguration.RewardPoints;
        _damage = enemyConfiguration.Damage;
        _view.Initialize(enemyConfiguration.Color);
    }

    private void Update()
    {
        transform.position -= Vector3.up * _speed * Time.deltaTime;

        if (transform.position.y < _bottomBorder)
            ReachedBottom();
    }

    public void SpawnTo(FieldBoundaries fieldBoundaries)
    {
        transform.position = fieldBoundaries.GetRandomTopPoint();
        _bottomBorder = fieldBoundaries.BottomBorder;
    }

    public void CatchShot()
    {
        GameplayEventsHolder.SendBallCathedShot(_rewardPoints);

        _view.PlayEffects();

        Destroy(gameObject);
    }

    private void ReachedBottom()
    {
        GameplayEventsHolder.SendBallReachedBottom(_damage);

        Destroy(gameObject);
    }
}
