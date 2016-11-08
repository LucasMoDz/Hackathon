using UnityEngine;
using System.Collections;

public class LerpCamera : MonoBehaviour
{
    private Quaternion targetRot;
    private Vector3 targetPos;

    public GameObject target;

    private Quaternion currentRotation;
    private Vector3 currentPosition;
    
    private const int LERP_SPEED = 5;
    
    private void Start()
    {
        targetRot = target.transform.rotation;
        targetPos = target.transform.position;

        StartCoroutine(Place(0));
    }
    
    private IEnumerator Place(float _seconds)
    {
        yield return new WaitForSeconds(_seconds);

        while (true)
        {
            // Save current position and rotation of rotatable object
            currentPosition = this.transform.position;
            currentRotation = this.transform.rotation;

            // Lerp rotation and position
            this.transform.rotation = Quaternion.Lerp(currentRotation, targetRot, LERP_SPEED * Time.deltaTime);
            this.transform.position = Vector3.Lerp(currentPosition, targetPos, LERP_SPEED * Time.deltaTime);

            if ((targetPos - currentPosition).magnitude > 0.05f)
                yield return null;
            else
                yield break;
        }
    }
    
    private Camera camera;
    public float ProjectionChangeTime = 0.5f;
    public bool ChangeProjection = false;

    private bool _changing = false;
    private float _currentT = 0.0f;

    private void Awake()
    {
        camera = Camera.main;
    }
     
    private void Update()
    {
        if (_changing)
        {
            ChangeProjection = false;
        }
        else if (ChangeProjection)
        {
            _changing = true;
            _currentT = 0.0f;
        }
    }

    private void LateUpdate()
    {
        if (!_changing)
        {
            return;
        }

        var currentlyOrthographic = camera.orthographic;
        Matrix4x4 orthoMat, persMat;
        if (currentlyOrthographic)
        {
            orthoMat = camera.projectionMatrix;

            camera.orthographic = false;
            camera.ResetProjectionMatrix();
            persMat = camera.projectionMatrix;
        }
        else
        {
            persMat = camera.projectionMatrix;

            camera.orthographic = true;
            camera.ResetProjectionMatrix();
            orthoMat = camera.projectionMatrix;
        }
        camera.orthographic = currentlyOrthographic;

        _currentT += (Time.deltaTime / ProjectionChangeTime);
        if (_currentT < 1.0f)
        {
            if (currentlyOrthographic)
            {
                camera.projectionMatrix = MatrixLerp(orthoMat, persMat, _currentT * _currentT);
            }
            else
            {
                camera.projectionMatrix = MatrixLerp(persMat, orthoMat, Mathf.Sqrt(_currentT));
            }
        }
        else
        {
            _changing = false;
            camera.orthographic = !currentlyOrthographic;
            camera.ResetProjectionMatrix();
        }
    }

    private Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float t)
    {
        t = Mathf.Clamp(t, 0.0f, 1.0f);
        var newMatrix = new Matrix4x4();
        newMatrix.SetRow(0, Vector4.Lerp(from.GetRow(0), to.GetRow(0), t));
        newMatrix.SetRow(1, Vector4.Lerp(from.GetRow(1), to.GetRow(1), t));
        newMatrix.SetRow(2, Vector4.Lerp(from.GetRow(2), to.GetRow(2), t));
        newMatrix.SetRow(3, Vector4.Lerp(from.GetRow(3), to.GetRow(3), t));
        return newMatrix;
    }
}