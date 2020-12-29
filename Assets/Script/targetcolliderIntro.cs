using UnityEngine;

public class targetcolliderIntro : DefaultTrackableEventHandler
{
    public static targetcolliderIntro instance;

    void Awake(){
        if(instance == null) {
            instance = this;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        moveTarget();    
    }

    public void moveTarget() {
        Vector3 temp;
        temp.x = Random.Range(-11.5f,4.5f);
        temp.y = Random.Range(2f,2f);
        temp.z = Random.Range(-10.3f,3.3f);
        transform.position = new Vector3(temp.x+(Random.Range(1f,3f)), temp.y, temp.z+(Random.Range(2f,3f)));

        if(DefaultTrackableEventHandler.trueFalse == true) {
            // RaycastController.instance.playSound(0);
        }
    }
}
