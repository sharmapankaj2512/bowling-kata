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
        var frameIndex = 0;

        while (NotPerfectGame(frameIndex, score) && GameNotOver(frameIndex))
        {
            score += _scores[frameIndex];
            score += Bonus(frameIndex);
            frameIndex += 1;
        }
        
        return score;
    }

    private static bool GameNotOver(int frameIndex)
    {
        return frameIndex < 20;
    }

    private int Bonus(int frameIndex)
    {
        if (IsSpare(frameIndex))
            return SpareBonus(frameIndex);
        if (IsStrike(frameIndex))
            return StrikeBonus(frameIndex);
        return 0;
    }

    private int StrikeBonus(int frameIndex)
    {
        return _scores[frameIndex + 1] + _scores[frameIndex + 2];
    }

    private int SpareBonus(int frameIndex)
    {
        return _scores[frameIndex + 2];
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