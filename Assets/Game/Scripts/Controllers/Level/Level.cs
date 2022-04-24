using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelConfig
{
    public List<Layer> layers;
}

[System.Serializable]
public class Layer
{
    public List<CorrectPos> correctPos;
    public bool isDoneCorrectPos;
    public int count = 0;
}

[System.Serializable]
public class CorrectPos
{
    public Transform trans;
    public bool isDoneMove;
    public Piece piece;
}

public class Level : MonoBehaviour
{
    public LevelConfig config;
    int indexOfCorPos = 0;
    int indexOfLayer = 0;
    bool isWin = false;
    public void Init()
    {

    }
    public void NextLayer()
    {
        config.layers[indexOfLayer].isDoneCorrectPos = true;
        if (indexOfLayer >= config.layers.Count - 1)
        {
            isWin = true;
            Debug.LogError("Win");
        }
        else
        {
            indexOfLayer++;
            indexOfCorPos = 0;
            Debug.LogError("Move to next Layer");
        }
    }
    public void Update()
    {
        CheckCorrectPos();
    }

    public void CheckCorrectPos()
    {
        var nearestPos = Vector2.Distance(config.layers[indexOfLayer].correctPos[indexOfCorPos].piece.transform.position, config.layers[indexOfLayer].correctPos[indexOfCorPos].trans.position);
        if (nearestPos < 1f)
        {
            config.layers[indexOfLayer].correctPos[indexOfCorPos].piece.isDone = true;
            config.layers[indexOfLayer].correctPos[indexOfCorPos].piece.transform.SetParent(config.layers[indexOfLayer].correctPos[indexOfCorPos].trans);
            config.layers[indexOfLayer].correctPos[indexOfCorPos].piece.transform.position = config.layers[indexOfLayer].correctPos[indexOfCorPos].trans.position;
            if (config.layers[indexOfLayer].correctPos[indexOfCorPos].isDoneMove == false)
            {
                config.layers[indexOfLayer].correctPos[indexOfCorPos].isDoneMove = true;
                config.layers[indexOfLayer].count++;
                if (indexOfCorPos >= config.layers[indexOfLayer].correctPos.Count - 1)
                {
                    SuccessPoint();
                }
                else
                {
                    indexOfCorPos++;
                    CheckCorrectPos();
                }
            }
        }
    }
    public void SuccessPoint()
    {
        if (!config.layers[indexOfLayer].isDoneCorrectPos)
        {
            if (config.layers[indexOfLayer].count >= config.layers[indexOfLayer].correctPos.Count)
            {
                NextLayer();
            }
        }
    }
    public void WinLevel()
    {

    }
}
