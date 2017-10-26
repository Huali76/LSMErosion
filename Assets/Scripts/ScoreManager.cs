﻿using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public string m_fileName;

    private void Awake()
    {

    }

    void Update ()
    {

	}

    private void AppendToScoreFile()
    {
        string filePath = Application.dataPath + "/" + m_fileName;

        string score = Date() + ", ";
        score += System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute.ToString("00") + ", ";
        string testAnswers = "";
        float landScore = 0;

        foreach (string s in FindObjectOfType<TestManager>().GetAnswers())
        {
            testAnswers += s + ", ";
        }
        
        foreach(_PLACEHOLDER_LAND_DEFORM p in FindObjectsOfType<_PLACEHOLDER_LAND_DEFORM>())
        {
            landScore += p.CalculateLandRemaining();
        }
        landScore /= FindObjectsOfType<_PLACEHOLDER_LAND_DEFORM>().Length;

        score += testAnswers;
        score += ((landScore) * 100f).ToString("00") + "%";

        System.IO.StreamWriter file = System.IO.File.AppendText(filePath);
        file.WriteLine(score);
        file.Close();
    }

    private string Date()
    {
        return System.DateTime.Now.Year.ToString() + " " +
            System.DateTime.Now.Month.ToString() + " " +
            System.DateTime.Now.Day.ToString();
    }

    private void OnDisable()
    {
        print("dead");
        AppendToScoreFile();   
    }
}