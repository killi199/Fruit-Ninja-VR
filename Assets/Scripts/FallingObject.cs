using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 3f; // Geschwindigkeit, mit der das Objekt fällt
    public float deleteUnderY = -5f;
    private ChangeText changeTextScript;

    private void Start()
    {
        GameObject textGameObject = GameObject.Find("Schildtext");
        changeTextScript = textGameObject.GetComponent<ChangeText>();
    }

    private void Update()
    {
        // Bewege das Objekt nach unten entlang der globalen Y-Achse mit der festgelegten Geschwindigkeit
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        // Überprüfe die Y-Koordinate des Objekts
        if (transform.position.y < deleteUnderY)
        {
            // Lösche das Objekt
            Destroy(gameObject);
            changeTextScript.updateLives(-1);
        }
    }
}
