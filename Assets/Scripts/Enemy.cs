using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed;
    private int _rewardPoints;
    private int _damage;
    [SerializeField]private MeshRenderer _mesh;

    [SerializeField] private ParticleSystem _particlePrefab;

    private float _bottomBorder;

    public EnemyFactory Factory { get; set; }

    public void Initizalize(EnemyConfiguration enemyConfiguration)
    {
        _speed = enemyConfiguration.Speed;
        _rewardPoints = enemyConfiguration.RewardPoints;
        _damage = enemyConfiguration.Damage;
        _mesh.material.color = enemyConfiguration.Color;
    }

    private void Update()
    {
        transform.position -= Vector3.up * _speed * Time.deltaTime;
        if(transform.position.y < _bottomBorder)
        {
            ReachedBottom();
        }
    }

    public void SpawnTo(FieldBoundaries fieldBoundaries)
    {
        transform.position = fieldBoundaries.GetRandomTopPoint();
        _bottomBorder = fieldBoundaries.BottomBorder;
    }

    //Вопрос: оправдано ли использование статических методов для нанесения урона игроку и подсчета очков 
    //или лучше передавать игрока с счетчиком в фабрике или еще каким-то образом
    public void CatchShot()
    {
        ScoreCounter.ScoreIncrease(_rewardPoints);

        _particlePrefab = Instantiate(_particlePrefab, transform.position, Quaternion.identity);
        _particlePrefab.startColor = _mesh.material.color;

        Factory.Remove(this);
    }

    private void ReachedBottom()
    {
        Player.ApplyDamage(_damage);

        Factory.Remove(this);
    }
}
