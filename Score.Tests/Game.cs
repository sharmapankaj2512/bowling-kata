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
        var score = 0;
        for (var frameIndex = 0; frameIndex < _scores.Length - 1 && NotPerfectGame(frameIndex, score); frameIndex++)
        {
            if (IsSpare(frameIndex))
                score += _scores[frameIndex] + _scores[frameIndex + 2];
            else if (IsStrike(frameIndex))
                score += _scores[frameIndex] + _scores[frameIndex + 1] + _scores[frameIndex + 2];
            else
                score += _scores[frameIndex];
        }
        return score;
    }

    private bool NotPerfectGame(int frameIndex, int score)
    {
        return !PerfectGame(frameIndex, score);
    }

    private bool PerfectGame(int frameIndex, int score)
    {
        return frameIndex == 10 && score == 300;
    }

    private bool IsStrike(int frameIndex)
    {
        return _scores[frameIndex] == 10;
    }

    private bool IsSpare(int index)
    {
        return _scores[index] + _scores[index + 1] == 10;
    }
}