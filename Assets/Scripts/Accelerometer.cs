using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof (Rigidbody))]
public class Accelerometer : MonoBehaviour
{
    public bool isFlat = false;
    public float speed;
    public Rigidbody rb;
    public string sceneName;
    private Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateForceBasedOnAccelerometer();
    }

    void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// Calculate player movements after getting the device rotation.
    /// </summary>
    private void CalculateForceBasedOnAccelerometer() {
        Vector3 _v = Input.acceleration;
        if(isFlat) {
            _v = Quaternion.Euler(90, 0, 0) * _v;
        }
        force = _v * speed * Time.deltaTime;
    }

    private void Movement() {
        rb.velocity = new Vector3(force.x, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "obstacle") {
            SceneManager.LoadScene(sceneName);
        }
    }
}
