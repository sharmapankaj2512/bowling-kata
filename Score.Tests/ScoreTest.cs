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
        Assert.AreEqual(game.Score(), 0);
    }
}

public class Game
{
    public void Roll(int pins)
    {
    }

    public int Score()
    {
        return 0;
    }
}