using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/ConfigurationGenerator")]
public class EnemyConfigurationGenerator : ScriptableObject
{
    [SerializeField, Range(1, 10)] private float _minSpeed = 1f, _maxSpeed = 5f;
    [SerializeField, Range(10, 50)] private int _minRewardPoints = 15, _maxRewardPoints = 45;
    [SerializeField, Range(10, 30)] private int _minDamage = 10, _maxDamage = 25;
    [SerializeField] private List<Color> _colors;

    [SerializeField] private float _correlationWithDifficult;

    public EnemyConfiguration Get(int difficultLevel)
    {
        float difficulty = Mathf.Pow(_correlationWithDifficult, difficultLevel);

        EnemyConfiguration configuration = new EnemyConfiguration();
        configuration.Speed = Random.Range(_minSpeed, _maxSpeed) * difficulty;
        configuration.RewardPoints = Random.Range(_minRewardPoints, _maxRewardPoints);
        configuration.Damage = Random.Range(_minDamage, _maxDamage);
        configuration.Color = _colors[Random.Range(0, _colors.Count)];

        return configuration;
    }
}
