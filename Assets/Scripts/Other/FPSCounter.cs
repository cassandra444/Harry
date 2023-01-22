using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public float _fps;
    public Text _fpsText;

    public void Start() { InvokeRepeating(nameof(GetFPS), 1, 1); }
    public void GetFPS() { _fps = (int)(1f / Time.unscaledDeltaTime); _fpsText.text = _fps + "fps"; }

}
