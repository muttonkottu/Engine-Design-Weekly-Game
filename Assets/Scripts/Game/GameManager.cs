using UnityEngine;
using Chapter.Singleton;

public class GameManager : Singleton<GameManager>
{
    private int _remainingEnemies = 0;
    private bool _gameOver = false;

    public void AddTotalEnemy()
    {
        _remainingEnemies++;
    }

    public void EnemyDefeated()
    {
        if (_gameOver) return;

        _remainingEnemies--;
        if (_remainingEnemies <= 0)
        {
            Win();
        }
    }

    public void TouchPlayer()
    {
        if (_gameOver) return;
        Lose();
    }

    private void Win()
    {
        _gameOver = true;
        print("YOU WIN!!!!!!! :)");
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void Lose()
    {
        _gameOver = true;
        print("you lose :(");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
