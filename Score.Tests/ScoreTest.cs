using NUnit.Framework;

namespace Score.Tests;

public class GameTest
{
    private static Game _game;

    [SetUp]
    public void Setup()
    {
        _game = new Game();
    }
    
    [Test]
    public void GutterGame()
    {
        RollMany(20, 0);
        Assert.AreEqual(0, _game.Score());
    }

    [Test]
    public void AllOnes()
    {
        var pins = 1;
        var frames = 20;
        RollMany(frames, pins);
        Assert.AreEqual(20, _game.Score());
    }

    private static void RollMany(int frames, int pins)
    {
        for (var i = 0; i < frames; i++)
        {
            _game.Roll(pins);
        }
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