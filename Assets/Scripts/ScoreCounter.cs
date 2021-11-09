using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private int _scoreToChangeDifficulty;
    [SerializeField] private int _scoreToChangeDifficultyMultiplier = 2;


    [SerializeField] private Text _currentScoreText;
    [SerializeField] private Text _maxScoreText;

    [SerializeField] private ScoreSaver _scoreSaver;

    public event Action DifficultyChanged;

    private static ScoreCounter _scoreCounterInstance;

    private void Start()
    {
        _scoreCounterInstance = this;
        _maxScoreText.text = _scoreSaver.GetSavedScore().ToString();
        _currentScoreText.text = _score.ToString();
    }

    public void IncreaseScoreToChangeDifficulty()
    {
        _scoreToChangeDifficulty *= _scoreToChangeDifficultyMultiplier;
    }

    public static void ScoreIncrease(int scoreGaind)
    {
        _scoreCounterInstance._score += scoreGaind;
        _scoreCounterInstance._currentScoreText.text = _scoreCounterInstance._score.ToString();

        if (_scoreCounterInstance._score >= _scoreCounterInstance._scoreToChangeDifficulty) {
            _scoreCounterInstance.DifficultyChanged();
            _scoreCounterInstance.IncreaseScoreToChangeDifficulty();
        }
    }

    public void OnOutOfHealth()
    {
        _scoreSaver.SaveMaxScore(_score);
    }
}
