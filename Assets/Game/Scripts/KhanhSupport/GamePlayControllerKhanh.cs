using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayControllerKhanh : MonoBehaviour
{
    public static GamePlayControllerKhanh Instance;
    public SampleLevel level;
    public bool lockOnEnter = false;
    public Transform doneCanvas;
    public List<GoalsPost> goalsPosts;
    public GameSence gameSence;
    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        // level = isnsdsdasd load level theo currentLevel
        level.Init();
        goalsPosts.Clear();
    }
    public void SortingLayer(GoalsPost og)
    {
        goalsPosts.Add(og);
        og.transform.SetParent(doneCanvas);
        goalsPosts.Sort(delegate (GoalsPost gp1, GoalsPost gp2)
        {
            int a = gp1.id;
            int b = gp2.id;
            return a.CompareTo(b);
        });
       for(int i = 0; i < goalsPosts.Count; i ++)
        {
            goalsPosts[i].transform.SetSiblingIndex(i);
        }
    }
    
}
