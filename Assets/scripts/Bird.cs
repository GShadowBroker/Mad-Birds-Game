using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float SpeedScale = 400f;
    private Vector2 InitialPos;
    private Vector2 MousePos = new Vector2();
    private Vector2 Direction = new Vector2();
    private Vector2 Viewport;
    private bool Launched = false;
    private float ResetTimer = 0f;
    public float MaxResetTimer = 1f;

    private void Awake()
    {
        Viewport = new Vector2Int(20, 20);
        InitialPos = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, InitialPos);

        if (transform.position.x > Viewport.x ||
            transform.position.x < -Viewport.x
        )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Launched)
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1f && ResetTimer > MaxResetTimer)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                ResetTimer = 0f;
                return;
            }

            ResetTimer += Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        if (GetComponent<SpriteRenderer>().color != Color.yellow)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
            GetComponent<LineRenderer>().enabled = true;
        }
    }

    private void OnMouseUp()
    {
        if (GetComponent<SpriteRenderer>().color != Color.white)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        Direction = SpeedScale * (InitialPos - MousePos);
        GetComponent<Rigidbody2D>().AddForce(Direction);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        Launched = true;
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Vector2.Distance(MousePos, InitialPos) <= 3f)
        {
            transform.position = MousePos;
        }
    }
}