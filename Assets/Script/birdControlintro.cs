using UnityEngine;

public class birdControlintro : MonoBehaviour
{
    private Transform targetFocus;
    void Start () {
    targetFocus = GameObject.FindGameObjectWithTag("target").transform;
    }
    
    void Update () {
        Vector3 target = targetFocus.position - this.transform.position;

        if (target.magnitude < 1){
            targetcolliderIntro.instance.moveTarget();
        }

        transform.LookAt(targetFocus.transform);
        float speed = Random.Range(2.2f, 2.8f);
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

}
