using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature_generator : MonoBehaviour
{
    public int length;
    public float frequency;
    [Range(0, 180)][Tooltip("In Degrees")]
    public float start_angle;
    public float base_size, multiplier;
    public GameObject Segment;
    public GameObject Head;

    private void OnDrawGizmos()
    {
        Vector3 activePosition = transform.position;

        //Take a half step back
        float stepScale = Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad * start_angle + ((0 * frequency) / length) * Mathf.PI));
        float stepLength = Mathf.Lerp(1, multiplier, stepScale);
        activePosition += new Vector3(0, 0, stepLength/2);


        for (int i = 0; i < length; i++)
        {
            float scaleT = Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad * start_angle + ((i * frequency) / length)*Mathf.PI));
            float actucalScale = Mathf.Lerp(1, multiplier, scaleT);
            activePosition += new Vector3(0, 0, -actucalScale / 2);//Take a half step forward
            Gizmos.DrawWireCube(activePosition, Vector3.one * actucalScale);//draw the cube centered
            activePosition += new Vector3(0,0,-actucalScale/2);//take another half step forward
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Vector3 activePosition = transform.position;

        //Take a half step back
        float stepScale = Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad * start_angle + ((0 * frequency) / length) * Mathf.PI));
        float stepLength = Mathf.Lerp(1, multiplier, stepScale);
        activePosition += new Vector3(0, 0, stepLength / 2);

        GameObject first = null;

        for (int i = 0; i < length; i++)
        {
            float scaleT = Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad * start_angle + ((i * frequency) / length) * Mathf.PI));
            float actucalScale = Mathf.Lerp(1, multiplier, scaleT);
            activePosition += new Vector3(0, 0, -actucalScale / 2);//Take a half step forward

            GameObject newPart = Instantiate(Segment, activePosition, Quaternion.identity, null);
            newPart.transform.localScale = Vector3.one * actucalScale;
            if(first == null)
            {
                SpineAnimator spine = newPart.AddComponent<SpineAnimator>();
                spine.useChildrenAsBones = true;
                first = newPart;
            }
            else
            {
                newPart.transform.parent = first.transform;
            }
            activePosition += new Vector3(0, 0, -actucalScale / 2);//take another half step forward
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
