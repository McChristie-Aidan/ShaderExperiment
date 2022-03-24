using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private static ScoreKeeper _instance;
    public static ScoreKeeper Instance { get { return _instance; } }

    [SerializeField]
    TextMeshProUGUI tmp, youWin, youLose;

    public float score;
    public bool hasLost = false;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
        youWin.enabled = false;
        youLose.enabled = false;
    }

    private void Update()
    {
        tmp.text = $"Enemies killed: {score} / 50";

        if (!hasLost)
        {
            if (score > 50)
            {
                youWin.enabled = true;
            }
        }      
        else
        {
            youLose.enabled = true;
        }
    }
}
