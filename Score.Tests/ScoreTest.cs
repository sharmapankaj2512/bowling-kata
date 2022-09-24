using NUnit.Framework;

namespace Score.Tests;

public class GameTest
{
    [Test]
    public void GutterGame()
    {
        var pins = 0;
        var frames = 20;
        var game = RollMany(frames, pins);
        Assert.AreEqual(0, game.Score());
    }

    [Test]
    public void AllOnes()
    {
        var pins = 1;
        var frames = 20;
        var game = RollMany(frames, pins);
        Assert.AreEqual(20, game.Score());
    }

    private static Game RollMany(int frames, int pins)
    {
        var game = new Game();
        for (var i = 0; i < frames; i++)
        {
            game.Roll(pins);
        }

        return game;
    }
}

public class Game
{
    private int _score;
    
    public void Roll(int pins)
    {
        _score += pins;
    }

    public int Score()
    {
        return _score;
    }
}