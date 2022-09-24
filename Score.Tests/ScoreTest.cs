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
        RollMany(20, 1);
        Assert.AreEqual(20, _game.Score());
    }

    [Test]
    public void OneSpare()
    {
        _game.Roll(5);
        _game.Roll(5);
        _game.Roll(2);
        RollMany(17, 0);
        Assert.AreEqual(16, _game.Score());
    }

    private static void RollMany(int frames, int pins)
    {
        for (var i = 0; i < frames; i++)
        {
            _game.Roll(pins);
        }
    }
}