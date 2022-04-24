using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScene : BaseScene
{
    [SerializeField] private Button playBtn;
    public void Init()
    {
        playBtn.onClick.AddListener(OnClickPlay);
    }

    public void OnClickPlay()
    {
        GameController.Instance.LoadScene(SceneName.GAME_PLAY);
    }

    public override void OnEscapeWhenStackBoxEmpty()
    {

    }
}
