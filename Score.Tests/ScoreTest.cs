using NUnit.Framework;

namespace Score.Tests;

public class GameTest
{
    [Test]
    public void GutterGame()
    {
        var game = new Game();
        for (var i = 0; i < 20; i++)
        {
            game.Roll(0);
        }
        Assert.AreEqual(0, game.Score());
    }
    
    [Test]
    public void AllOnes()
    {
        var game = new Game();
        for (var i = 0; i < 20; i++)
        {
            game.Roll(1);
        }
        Assert.AreEqual(20, game.Score());
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