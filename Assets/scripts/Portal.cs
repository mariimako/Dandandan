using UnityEngine;


public class Portal : Collidable
{
    public string[] sceneNames;
    protected override void OnCollide(Collider2D coll){
        if(coll.name == "player0")
        {

            //teleport player
            GameManager.instance.SaveState();
            string sceneName =sceneNames[Random.Range(0,sceneNames.Length)];//get random scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

        }
    }
}
