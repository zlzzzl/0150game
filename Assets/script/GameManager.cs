using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool[] _TasksCompleted;
    public static GameManager _Instance;
    // Start is called before the first frame update
    void Awake()
    {
        _Instance = this;
    }
    public void CompleteTask(int ID)
    {
        _TasksCompleted[ID] = true;
        for (int i = 0; i < _TasksCompleted.Length; i++)
        {
            if (_TasksCompleted[i] == false)
            {
                return;
            }
        }
        GameEnd();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public string enterscene = "CutScene 1";

    void GameEnd()
    {
        SceneChange(enterscene );
    }


    public void SceneChange(string target)
    {
        SceneManager.LoadScene(target);
    }
}
