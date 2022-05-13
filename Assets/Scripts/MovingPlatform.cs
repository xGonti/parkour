using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Av Michal
// Checkpoint = Ett eller flera st�llet som platformen ska r�ra sig till/imellan
public class MovingPlatform : MonoBehaviour
{
    public float speed; // Hur snabbt platform r�r sig
    public int startingPoint; // Start position d�r platformen startar
    public Transform[] points; // Positions d�r platformen ska r�ra sig till

    private int i;
    void Start()
    {
        transform.position = points[startingPoint].position; // St�ller den till ena positionen med anv�dning av "startingPoint"
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f) // Kollar distansen mellan platformen och "checkpoint" d�r den ska �ka till
        {
            i++; // H�jer index
            if (i == points.Length) // Kollar ifall platformen var p� sista "checkpoint" innan den h�jer index
            {
                i = 0; // Reset av index
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime); // Flyttar platform till checkpoint till positionen med index "i"
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform); // N�r man hoppar upp p� platformen s� �ker spelaren med platformen (Det blir en child object till platformen)
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null); // N�r spelaren hoppar av platformen s� �ker den inte med platformen (Den blir inte l�ngre en child object till platformen)
    }
}
