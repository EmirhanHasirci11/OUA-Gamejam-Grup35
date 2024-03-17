using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialoguBox : MonoBehaviour
{
    public DialoguSegment[] DialoguSegments;
    public bool isWinCondition = false;
    public bool isRestartCondition=false;
    [Space]
    public Image SpeakerFaceDisplay;
    public Image DialogueBoxBorder;
    public Image DialogueBoxInner;
    public Image SkipIndicator;    
    [Space]
    public TextMeshProUGUI SpeakerNameDisplay;
    public TextMeshProUGUI DialogueDisplay;
    [Space]
    public float TextSpeed;
    private bool CanContinue;
    private int DialogueIndex;

    public void StartDialogue()
    {
        
        DialogueIndex = 0;
        gameObject.SetActive(true);
        SetStyle(DialoguSegments[0].Speaker);
        PlayDialogue(DialoguSegments[0].Dialogue);
        
    }
    private void Start()
    {
        isWinCondition = false;
        isRestartCondition = false;
        StartDialogue();
    }

    private void Update()
    {

        SkipIndicator.enabled = CanContinue;
        if(Input.GetKeyDown(KeyCode.Space) && CanContinue)
        {
            DialogueIndex++;
            if(DialogueIndex == DialoguSegments.Length)
            {

                gameObject.SetActive(false);
                if (isWinCondition)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                if (isRestartCondition)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }

            SetStyle(DialoguSegments[DialogueIndex].Speaker);
            PlayDialogue(DialoguSegments[DialogueIndex].Dialogue);

        }
    }

    void SetStyle(Subjects Speaker)
    {
        if(Speaker.SubjectFace == null)
        {
            SpeakerFaceDisplay.color = new Color(0,0,0,0);
        } else
        {
            SpeakerFaceDisplay.sprite = Speaker.SubjectFace;
            SpeakerFaceDisplay.color = Color.white;
        }

        DialogueBoxBorder.color = Speaker.BorderColor;
        DialogueBoxInner.color = Speaker.InnerColor;
        SpeakerNameDisplay.SetText(Speaker.SubjectName);

    }

    public void PlayDialogue(string Dialogue)
    {
        CanContinue = false;
        DialogueDisplay.SetText(Dialogue);
                
        CanContinue = true;
    }
}

[System.Serializable]
public class DialoguSegment
{
    public string Dialogue;
    public Subjects Speaker;
}