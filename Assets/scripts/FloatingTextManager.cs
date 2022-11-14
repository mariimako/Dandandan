using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()//every frame
    {
        foreach(FloatingText txt in floatingTexts){
            txt.UpdateFloatingText();
        }
    }
    public void Show(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.txt.text = message;//change text message in floating text object parameter txt
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;

        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position); // "go" game object, text is in screen space, not world space, so must change world cordiantes to screen cordinates
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
       

    }

    private FloatingText GetFloatingText()
    {
        
        FloatingText txt = floatingTexts.Find(t => !t.active);//find in list one that is not active
        if (txt == null)//if no active texts found in list, instantiate new text
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }

        return txt;
    }
}
