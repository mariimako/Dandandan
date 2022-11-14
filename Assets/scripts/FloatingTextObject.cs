using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool active; //shows whether is being using ornot
    public GameObject go; 
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;
    public void Show(){
    
        active= true;
        lastShown = Time.time;
        go.SetActive(active);
    }
    public void Hide(){
        active =false;
        go.SetActive(active);

    }
    public void UpdateFloatingText(){
        if(!active){
            return;
        }
        //Time.time=10. last shown 7, duration is 2, than hide (it has been shown longer than duration)
        if(Time.time - lastShown > duration){
            Hide();
        }

        go.transform.position += motion * Time.deltaTime;
        
    }
    
    
}
