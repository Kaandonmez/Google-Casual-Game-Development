using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCurveDemo : MonoBehaviour
{
    [SerializeField]
    AnimationCurve _curve;

    [SerializeField]
    float animTime;

    [SerializeField]
    AnimationCurve _animationCurve;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimationCurveT());
    }

    // Update is called once per frame
    void Update() { }

    IEnumerator AnimationCurveT()
    {
        // float currentTime = 0f;
        // _animationCurve = new AnimationCurve();

        // while(currentTime < animTime)
        // {
        //     transform.position = new Vector3;
        // }
        // orbit object around itself
        float currentTime = 0f;
        _animationCurve = new AnimationCurve(
            new Keyframe(0f, transform.position.x),
            new Keyframe(0.5f, transform.position.x + 10),
            new Keyframe(1f, transform.position.x + 20)
        );
        _animationCurve.SmoothTangents(0, 0.25f);
        _animationCurve.SmoothTangents(1, 1f);
        _animationCurve.SmoothTangents(2, 0.25f);
        while (currentTime < animTime)
        {
            transform.position = new Vector3(_animationCurve.Evaluate(currentTime), 0, 0);
            currentTime += Time.deltaTime;
            yield return null;
        }

        yield break;
    }
}
