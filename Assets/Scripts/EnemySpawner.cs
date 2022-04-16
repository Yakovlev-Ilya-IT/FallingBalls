using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField, Range(0.5f,5)] private float _spawnInterval = 1;

    [SerializeField] private FieldBoundaries _fieldBoundaries;

    [SerializeField] private EnemyFactory _enemyFactory;

    private DifficultHandler _difficultHandler;

    public void Initialize(DifficultHandler difficultHandler)
    {
        _fieldBoundaries.Initialize();
        _difficultHandler = difficultHandler;
    }

    public void Launch()
    {
        StartCoroutine(EnemySpawn());
    }

    public void Stop()
    {
        StopCoroutine(EnemySpawn());
    }

    public IEnumerator EnemySpawn()
    {
        while (true)
        {
            Enemy enemy;
            enemy = _enemyFactory.Get(_difficultHandler.DifficultLevel);
            enemy.SpawnTo(_fieldBoundaries);
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
