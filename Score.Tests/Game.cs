using System.Collections.Generic;

namespace Score.Tests;

public class Game
{
    private readonly List<int> _scores = new();

    public void Roll(int pins)
    {
        _scores.Add(pins);
    }

    public int Score()
    {
        var sum = _scores[0] + _scores[1];
        for (var frameIndex = 2; frameIndex < _scores.Count; frameIndex++)
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