using UnityEngine;

public class ObjectPathMove : MonoBehaviour
{
    public enum MoveMode
    {
        Once,
        Loop,
        PingPong
    }

    public BezierSplinePath spline;

    public float duration;

    public bool lookForward;

    public MoveMode mode;

    private float progress;
    private bool goingForward = true;

    private void Update()
    {
        if (goingForward)
        {
            progress += Time.deltaTime / duration;
            if (progress > 1f)
            {
                if (mode == MoveMode.Once)
                {
                    progress = 1f;
                }
                else if (mode == MoveMode.Loop)
                {
                    progress -= 1f;
                }
                else
                {
                    progress = 2f - progress;
                    goingForward = false;
                }
            }
        }
        else
        {
            progress -= Time.deltaTime / duration;
            if (progress < 0f)
            {
                progress = -progress;
                goingForward = true;
            }
        }

        Vector3 position = spline.GetPoint(progress);
        transform.localPosition = position;
        if (lookForward)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
    }
}