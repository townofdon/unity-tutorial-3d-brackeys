using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 4000f;
    public float sidewaysForce = 100;
    
    private float _currentTorque = 0;

    private Vector3 _lastPosition = new Vector3(0, 0, 0);
    private Vector3 _currentGoalDirection = new Vector3(0, 0, 1);

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = true;
        rb.maxAngularVelocity = 2 * 2 * Mathf.PI;
    }

    // Update is called once per frame
    void Update()
    {
        if (_lastPosition.magnitude > 0) {
            Vector3 deltaPosition = rb.position - _lastPosition;
            // get the amount of distance that the user has accumulated relative to the current goal direction
            float amountTraversedTowardsGoal = Vector3.Dot(deltaPosition, _currentGoalDirection);
            GameData.AddScore((int) Mathf.Round(amountTraversedTowardsGoal * 10));
        }

        _lastPosition = rb.position;
    }

    private void FixedUpdate() {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d")) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a")) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        float magnitude = rb.angularVelocity.magnitude;
        bool isAtMaxTorque = rb.angularVelocity.magnitude < rb.maxAngularVelocity - 10;

        if (Input.GetKey("w") && (isAtMaxTorque || _currentTorque < 0)) {
            _currentTorque += 100 * Time.deltaTime;
        }

        if (Input.GetKey("s") && (isAtMaxTorque || _currentTorque > 0)) {
            _currentTorque -= 100 * Time.deltaTime;
        }

        rb.AddRelativeTorque(0, _currentTorque * Time.deltaTime, 0, ForceMode.VelocityChange);

        if (rb.position.y < -10) {
            GameManager.getInstance().EndGame();
        }
    }
}
