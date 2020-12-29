using UnityEngine;

public class birdController : MonoBehaviour
{
    private Transform targetFocus;
    void Start () {
    targetFocus = GameObject.FindGameObjectWithTag("target").transform;
    }
    
    void Update () {
        Vector3 target = targetFocus.position - this.transform.position;
        Debug.Log(target.magnitude);

        if (target.magnitude < 1){
            targetcollider.instance.moveTarget();
        }

        transform.LookAt(targetFocus.transform);
        float speed = Random.Range(2.9f, 2.2f);
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

}
