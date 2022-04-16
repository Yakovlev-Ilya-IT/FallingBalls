using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/Factories")]
public class EnemyFactory : ScriptableObject
{
    [SerializeField] Enemy _prefab;

    [SerializeField] EnemyConfigurationGenerator _enemyConfigurationGenerator;

    public Enemy Get(int diffcult)
    {
        Enemy instance = Instantiate(_prefab);
        EnemyConfiguration enemyConfiguration = _enemyConfigurationGenerator.Get(diffcult);
        instance.Initizalize(enemyConfiguration);
        return instance;
    }
}
