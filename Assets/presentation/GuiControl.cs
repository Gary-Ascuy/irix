using UnityEngine;
using System.Collections;

public class GuiControl : MonoBehaviour {
  void Start() {
  }

  void Update() {
  }

  void OnGUI() {
    var w = Screen.width;
    var h = Screen.height;

    if (GUI.Button(new Rect(w - 20 - w / 6, h - 20 - h / 10, w / 6, h / 10), "Play")) {
      Application.LoadLevel("level 1");
    }

    if (GUI.Button(new Rect(20, h - 20 - h / 10, w / 6, h / 10), "Exit")) {
      Application.Quit();

      // workaround and does not works too xD
      PlayerPrefs.Save();
      var threads = System.Diagnostics.Process.GetCurrentProcess().Threads;
      foreach (var thread in threads) {
        thread.Dispose();
      }
      System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
  }
}
