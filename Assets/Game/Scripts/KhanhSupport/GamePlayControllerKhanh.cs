using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayControllerKhanh : MonoBehaviour
{
    public static GamePlayControllerKhanh Instance;
    public SampleLevel level;
    public bool lockOnEnter = false;
    public Transform doneCanvas;
    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        // level = isnsdsdasd load level theo currentLevel
        level.Init();
    }
    public void SortingLayer( int param, GameObject og)
    {
        if(doneCanvas.childCount == 0)
        {
            og.transform.SetParent(doneCanvas);
        }
        else
        {
            if (doneCanvas.GetChild(doneCanvas.childCount - 1).GetComponent<GoalsPost>().id < param)
            {
                og.transform.SetParent(doneCanvas);
                og.transform.SetSiblingIndex(doneCanvas.childCount - 1);


            }
            else if (doneCanvas.GetChild(doneCanvas.childCount - 1).GetComponent<GoalsPost>().id > param)
            {
                og.transform.SetParent(doneCanvas);
            }
        }
    }

}
