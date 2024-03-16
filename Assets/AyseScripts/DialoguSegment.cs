using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [System.Serializable]
    public class DialoguSegment
    {
        public string Dialogue;
        public Subjects Speaker;
    }
}
