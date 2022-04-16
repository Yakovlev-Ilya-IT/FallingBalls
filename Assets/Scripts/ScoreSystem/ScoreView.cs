using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _currentScore;
    [SerializeField] private Text _maxScore;

    private const int StartScore = 0;
    private const string ScoreTemplate = "Score: {0}"; 
    private const string MaxScoreTemplate = "MaxScore: {0}";

    public void Initialize(int maxScore)
    {
        _maxScore.text = string.Format(MaxScoreTemplate, maxScore);
        _currentScore.text = string.Format(ScoreTemplate, StartScore);
    }

    public void SetScore(int currentScore)
    {
        _currentScore.text = string.Format(ScoreTemplate, currentScore);
    }
}
