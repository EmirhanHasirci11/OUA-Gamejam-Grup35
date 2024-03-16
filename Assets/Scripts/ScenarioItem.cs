using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenarioıtem : MonoBehaviour
{
    [SerializeField] public DialoguSegment[] DialoguSegments;
    private CanvasRenderer _canvasRenderer;
    DialoguBox _dialoguBox;
    public GameObject DialogCanvas;
    public void clickEvent()
    {
       _dialoguBox= DialogCanvas.gameObject.GetComponent<DialoguBox>();
        _dialoguBox.DialoguSegments=DialoguSegments;       
        _dialoguBox.StartDialogue();
    }

}
