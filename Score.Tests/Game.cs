using System.Collections.Generic;

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
        var sum = _scores[0] + _scores[1];
        for (var frameIndex = 2; frameIndex < _scores.Length; frameIndex++)
        {
            if (IsSpare(frameIndex))
                sum += _scores[frameIndex] * 2;    
            sum += _scores[frameIndex];
        }
        return sum;
    }

    private bool IsSpare(int index)
    {
        return _scores[index - 1] + _scores[index - 2] == 10;
    }
}