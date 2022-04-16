public class DifficultHandler
{
    private int _difficultLevel = 1;
    private int _difficultStep = 1;

    private int _pointsToIncreaseDiffcuilty;
    private int _multiplierPointsToIncreaseDiffcuilty;

    private Score _score;

    public int DifficultLevel => _difficultLevel;

    public DifficultHandler(DifficultConfig difficultConfig, Score score)
    {
        _difficultLevel = difficultConfig.StartDifficultLevel;
        _difficultStep = difficultConfig.DifficultStep;
        _pointsToIncreaseDiffcuilty = difficultConfig.PointsToIncreaseDiffcuilty;
        _multiplierPointsToIncreaseDiffcuilty = difficultConfig.MultiplierPointsToIncreaseDiffcuilty;
        _score = score;
        _score.ScoreChanged += OnScoreChanged;
    }

    public void OnScoreChanged(int score)
    {
        if(score > _pointsToIncreaseDiffcuilty)
        {
            _pointsToIncreaseDiffcuilty *= _multiplierPointsToIncreaseDiffcuilty;
            _difficultLevel += _difficultStep;
        }
    }

    ~DifficultHandler()
    {
        _score.ScoreChanged -= OnScoreChanged;
    }
}
