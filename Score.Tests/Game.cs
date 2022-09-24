namespace Score.Tests;

public class Game
{
    private int _currentRoll;
    private readonly int[] _scores = new int[21];

    public void Roll(int pins)
    {
        _scores[_currentRoll++] = pins;
    }

    public int Score()
    {
        var sum = 0;
        for (var frameIndex = 0; frameIndex < _scores.Length - 1; frameIndex++)
        {
            if (IsSpare(frameIndex))
                sum += _scores[frameIndex] + _scores[frameIndex + 2];
            else
                sum += _scores[frameIndex];
        }
        return sum;
    }

    private bool IsSpare(int index)
    {
        return _scores[index] + _scores[index + 1] == 10;
    }
}