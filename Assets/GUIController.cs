﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

    public string subjectID = "";
    public GameObject UserPanel;
    public GameObject ControlPanel;
    public GameObject GamePanel;
    public TrailmakingController task;
    public Text statusMsg;

    // Use this for initialization
    public IEnumerator showOverlay(float duration, string text)
    {
        statusMsg.text = text;
        statusMsg.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        statusMsg.gameObject.SetActive(false);
    }
    public void startTask(int taskID)
    {
        if (subjectID != "")
        {
            task.currentTask = taskID;
           
            task.writer.trialID+=1;
            UserPanel.SetActive(false);
            // GamePanel.SetActive(true);
            task.writer.setFileName();
            task.startTask();
        }
        else { StartCoroutine(showOverlay(2, "Enter Subject ID First!")); }
    }
    public void setSubjectID(string newID)
    {
        subjectID = newID;
        task.writer.subID = subjectID;
        
    }
    public void showGUI()
    {
        UserPanel.SetActive(true);
        // GamePanel.SetActive(false);
    }
     public void showSettings()
    {
        if(ControlPanel.activeSelf)
        {
            ControlPanel.SetActive(false);
            UserPanel.SetActive(true);    
        } 
        else
        {
            ControlPanel.SetActive(true);
            UserPanel.SetActive(false);
        }
        
    }

}
   