using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialoguBox : MonoBehaviour
{
    public DialoguSegment[] DialoguSegments;
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

    private void Start()
    {
        SetStyle(DialoguSegments[0].Speaker);
        StartCoroutine(PlayDialogue(DialoguSegments[0].Dialogue));
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
                return;
            }

            SetStyle(DialoguSegments[DialogueIndex].Speaker);
            StartCoroutine(PlayDialogue(DialoguSegments[DialogueIndex].Dialogue));

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

    IEnumerator PlayDialogue(string Dialogue)
    {
        CanContinue = false;
        DialogueDisplay.SetText(string.Empty);
        

        for (int i = 0; i < Dialogue.Length; i++)  
        {
            DialogueDisplay.text += Dialogue[i];
            yield return new WaitForSeconds(1f / TextSpeed);
        }

        CanContinue = true;
    }
}



[System.Serializable]
public class DialoguSegment
{
    public string Dialogue;
    public Subjects Speaker;
}