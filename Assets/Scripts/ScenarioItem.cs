using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenarioıtem : MonoBehaviour
{
    private CanvasRenderer _canvasRenderer;
    [SerializeField] Image _image;

    public void clickEvent()
    {
        Debug.Log($"{gameObject.name} nesnesine tıklandı");
    }

}
