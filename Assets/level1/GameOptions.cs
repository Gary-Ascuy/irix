using UnityEngine;
using System.Collections;

public class GameOptions : MonoBehaviour {
  public GUISkin Skin;
  private bool options;

  void Start() {
    options = false;
  }
  
  void Update() {
  }

  void OnGUI() {
    if (!options) {
      GUI.skin = Skin;
    }
    var w = Screen.width;
    var h = Screen.height;
    var fontSize = h / 10 - 44;

    if (fontSize < 20) {
      fontSize = 20;
    }
    
    var style = new GUIStyle(GUI.skin.GetStyle("button"));
    style.fontSize = fontSize;

    if (options) {
      var styleLabel = new GUIStyle(GUI.skin.GetStyle("button"));
      styleLabel.fontSize = fontSize;
      styleLabel.fontStyle = FontStyle.Bold;
      styleLabel.normal.textColor = Color.green;

      GUI.Box(new Rect(0, 0, w, h), "");
      GUILayout.BeginVertical();
      GUILayout.BeginArea(new Rect(w / 4, h / 4, w / 2, h - h / 4));
    
      GUILayout.Label("OPTIONS", styleLabel);
      if (GUILayout.Button("Return", style)) {
        options = false;
      }

      if (GUILayout.Button("Exit", style)) {
        PlayerPrefs.Save();
        Application.Quit();
      }

      GUILayout.EndArea();
      GUILayout.EndVertical();
    } else {

      var l = w / 15;
      if (GUI.Button(new Rect(w - 5 - l, 5, l, l), "", style)) {
        options = true;
      }
    }
  }
}
