using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _score = 0;
    private int _maxScore = 0;

    [SerializeField] private ScoreView _view;
    private ScoreSaver _saver;

    public event Action<int> ScoreChanged;

    private void Awake()
    {
        _saver = new ScoreSaver();
        _maxScore = _saver.GetSavedScore();

        GameplayEventsHolder.BallCathedShot += OnBallCathedShot;

        _view.Initialize(_maxScore);
    }

    private void OnBallCathedShot(int scoreGaind)
    {
        _score += scoreGaind;
        _view.SetScore(_score);
        ScoreChanged?.Invoke(_score);
    }

    public bool TrySaveMaxScore()
    {
        return _saver.TrySaveMaxScore(_score);
    }

    public void OnDisable()
    {
        GameplayEventsHolder.BallCathedShot -= OnBallCathedShot;
    }
}
