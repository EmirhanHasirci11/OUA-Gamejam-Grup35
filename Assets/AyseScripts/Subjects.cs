using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu ( fileName = "NewSubject", menuName = "Create New Subject")]
public class Subjects : ScriptableObject
{
   public string SubjectName;
   public Color BorderColor;
   public Color InnerColor;
   public Sprite SubjectFace;
}
