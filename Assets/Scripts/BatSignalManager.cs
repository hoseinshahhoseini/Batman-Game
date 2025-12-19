using UnityEngine;

public class BatSignalManager : MonoBehaviour
{
    [SerializeField] private Light signalLight;
    private bool active = false;
    private float rotateValue;
    private Vector3 originPos;

    void Start()
    {
        signalLight.enabled = false;
        originPos = signalLight.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            active = !active;
            signalLight.enabled = active;
            rotateValue = 0f;
        }

        // Move in circle when active
        if (active)
        {
            rotateValue += Time.deltaTime;

            float offsetY = Mathf.Sin(rotateValue);
            float offsetZ = Mathf.Cos(rotateValue);

            signalLight.transform.position = originPos + new Vector3(0, offsetY, offsetZ);
        }
    }
}
