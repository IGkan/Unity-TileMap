using UnityEngine;
using UnityEngine.Tilemaps;

public class Test : MonoBehaviour
{
    private float xpos = 0f;
    private bool hide = false;
    void OnGUI()
    {
        GUI.BeginGroup(new Rect(xpos, 0, Screen.width / 2, Screen.height));
        GUI.Button(new Rect(0, 0, Screen.width / 2, Screen.height), "");
        GUI.EndGroup();
        if (GUI.Button(new Rect(Screen.width / 2 + xpos, 0, 30, 30), ""))
        {
            hide = !hide;
        }
        if (hide && (xpos > -Screen.width / 2))
        {
            xpos -= 5;
        }
        else if (!hide && (xpos < 0))
        {
            xpos += 5;
        }
    }
}

