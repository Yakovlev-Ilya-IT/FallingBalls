using UnityEngine;

[CreateAssetMenu]
public class EnemyFactory : ScriptableObject
{
    [SerializeField] Enemy _prefab;

    [SerializeField] EnemyConfigurationGenerator _enemyConfigurationGenerator;

    public Enemy Get(int diffcult)
    {
        Enemy instance = Instantiate(_prefab);
        instance.Factory = this;
        EnemyConfiguration enemyConfiguration = _enemyConfigurationGenerator.Get(diffcult);
        instance.Initizalize(enemyConfiguration);
        return instance;
    }

    public void Remove(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
