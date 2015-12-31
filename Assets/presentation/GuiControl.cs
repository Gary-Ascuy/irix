using UnityEngine;
using System.Collections;

public class GuiControl : MonoBehaviour {
  private bool options;

  void Start() {
    options = false;
  }

  void Update() {
  }

  void OnGUI() {
    var w = Screen.width;
    var h = Screen.height;
    var fontSize = h / 10 - 44;
    if (fontSize < 20) {
      fontSize = 20;
    }

    var style = new GUIStyle(GUI.skin.GetStyle("button"));
    style.fontSize = fontSize;

    var styleLabel = new GUIStyle(GUI.skin.GetStyle("button"));
    styleLabel.fontSize = fontSize;
    styleLabel.fontStyle = FontStyle.Bold;
    styleLabel.normal.textColor = Color.green;

    if (options) {
      GUI.Box(new Rect(0, 0, w, h), "");
      GUILayout.BeginVertical();
      GUILayout.BeginArea(new Rect(w / 4, h / 4, w / 2, h - h / 4));

      GUILayout.Label("OPTIONS", styleLabel);
      if (GUILayout.Button("Return", style)) {
        options = false;
      }

      GUILayout.Button("Audio", style);
      GUILayout.Button("Video", style);
      GUILayout.Button("Game", style);
      GUILayout.EndArea();
      GUILayout.EndVertical();
    } else {
      if (GUI.Button(new Rect(w - 20 - w / 6, 20, w / 6, h / 10), "Options", style)) {
        options = true;
      }

      if (GUI.Button(new Rect(w - 20 - w / 6, h - 20 - h / 10, w / 6, h / 10), "Play", style)) {
        Application.LoadLevel("level 1");
      }

      if (GUI.Button(new Rect(20, h - 20 - h / 10, w / 6, h / 10), "Exit", style)) {
        PlayerPrefs.Save();
        Application.Quit();
      }
    }
  }
}
