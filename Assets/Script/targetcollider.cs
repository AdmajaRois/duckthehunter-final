using UnityEngine;

public class targetcollider : DefaultTrackableEventHandler
{
    public static targetcollider instance;

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
        temp.x = Random.Range(-4.5f,4.5f);
        temp.y = Random.Range(1.4f,1.1f);
        temp.z = Random.Range(-5.5f,5.5f);
        transform.position = new Vector3(temp.x, temp.y-7.5f, temp.z);

        if(DefaultTrackableEventHandler.trueFalse == true) {
            // RaycastController.instance.playSound(0);
        }
    }
}
