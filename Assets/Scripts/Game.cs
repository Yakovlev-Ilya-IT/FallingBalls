using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ScoreCounter _scoreCounter;

    [SerializeField] private EnemyFactory _enemyFactory;

    [SerializeField] private float _spawnInterval = 1;
    [SerializeField] private float _spawnIntervalChangeMultiplier = 0.9f;

    private int _difficultLevel = 1;

    [SerializeField] private FieldBoundaries _fieldBoundaries;

    [SerializeField] private GameObject _looseScreen;

    private bool _isPaused = false;

    void Start()
    {
        _scoreCounter.DifficultyChanged += OnDifficultyChanged;

        _player.OutOfHealth += _scoreCounter.OnOutOfHealth;
        _player.OutOfHealth += OnOutOfHealth;

        StartCoroutine(EnemySpawner());
    }

    //можно ли оставить функционал спавна в классе game или лучше вынести в отдельный класс спавна врагов
    public IEnumerator EnemySpawner()
    {
        while (true)
        {
            Enemy enemy;
            enemy = _enemyFactory.Get(_difficultLevel);
            enemy.SpawnTo(_fieldBoundaries);
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    public void OnDifficultyChanged()
    {
        _difficultLevel++;
        _spawnInterval *= _spawnIntervalChangeMultiplier;
    }

    public void OnOutOfHealth()
    {
        _looseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetPause()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
