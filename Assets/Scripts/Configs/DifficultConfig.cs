using UnityEngine;

[CreateAssetMenu (menuName = "Configs/DifficultConfig")]
public class DifficultConfig : ScriptableObject
{
    [SerializeField, Range(0, 5)] private int _startDifficultLevel = 1;
    [SerializeField, Range(1, 5)] private int _difficultStep = 1;
    [SerializeField, Range(10, 100)] private int _pointsToIncreaseDiffcuilty;
    [SerializeField, Range(2, 4)] private int _multiplierPointsToIncreaseDiffcuilty;

    public int StartDifficultLevel => _startDifficultLevel;
    public int DifficultStep => _difficultStep;
    public int PointsToIncreaseDiffcuilty => _pointsToIncreaseDiffcuilty;
    public int MultiplierPointsToIncreaseDiffcuilty => _multiplierPointsToIncreaseDiffcuilty;
}
