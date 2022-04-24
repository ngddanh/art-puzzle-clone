using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateGame
{
    Playing = 0,
    Win = 1,
    Lose = 2,
}

public class GamePlayController : Singleton<GamePlayController>
{
    public PlayerContain playerContain;
    public GameScene gameScene;

    [HideInInspector] public Level level;
    public StateGame state;

    protected override void OnAwake()
    {
        //GameController.Instance.currentScene = SceneType.GamePlay;

        Init();
    }

    public void Init()
    {
        //InitLevel();
        gameScene.Init();
    }

    public void InitLevel()
    {
        if (level != null)
        {
            level.Init();
            state = StateGame.Playing;
        }
    }
}
