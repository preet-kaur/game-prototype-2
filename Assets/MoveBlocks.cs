using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float t = 0;
    public float deadZone = -45;
    public float pauseDuration = 10f;
    public float amtToMove;
    public bool moveforward = false;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(MoveDown());
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveDown());
        //transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;
        //new WaitForSeconds(pauseDuration);
        //StartCoroutine(MoveDown());
        // if (transform.position.y < deadZone)
        //{
        //Debug.Log("pipe deleted");
        // Destroy(gameObject);
        //}
    }
   
    IEnumerator MoveDown()
    {
        while (true)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = startPosition - Vector3.up * moveSpeed * Time.deltaTime;

            float t = 0.0f;
            while (t < 1.0f)
            {
                t += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, t);
                yield return null;
            }

            yield return new WaitForSeconds(pauseDuration);
        }
    }
}
