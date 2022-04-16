using System;


public class GameplayEventsHolder
{
    public static event Action<int> BallReachedBottom;

    public static event Action<int> BallCathedShot;

    public static void SendBallReachedBottom(int damage)
    {
        BallReachedBottom?.Invoke(damage);
    }

    public static void SendBallCathedShot(int reward)
    {
        BallCathedShot?.Invoke(reward);
    }
}
