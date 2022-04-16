using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCore : MonoBehaviour
{
    [SerializeField] private Score _score;

    [SerializeField] private PlayerHealth _playerHealth;

    [SerializeField] private GameObject _looseScreen;

    [SerializeField] private EnemySpawner _enemySpawner;

    private DifficultHandler _difficultHandler;

    [SerializeField] private DifficultConfig difficultConfig;

    private bool _isPaused = false;

    void Awake()
    {
        _playerHealth.OutOfHealth += OnOutOfHealth;

        _difficultHandler = new DifficultHandler(difficultConfig, _score);
        _enemySpawner.Initialize(_difficultHandler);
        _enemySpawner.Launch();
    }

    public void OnOutOfHealth()
    {
        _looseScreen.SetActive(true);
        _score.TrySaveMaxScore(); // в случае удачного сохранения можно обработать (вывести поздравление с новым рекордом)
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

    private void OnDisable()
    {
        _playerHealth.OutOfHealth -= OnOutOfHealth;
    }
}
