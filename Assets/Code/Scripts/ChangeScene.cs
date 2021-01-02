using UnityEngine;

public class ChangeScene : Interaction
{
    public string toScene;
    public Vector2 toPosition;
    public Vector3 toCameraPosition;
    public Vector2 toDirection;

    public override void Interact()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.LoadScene(toScene, toPosition, toCameraPosition, toDirection);
        }
    }
}