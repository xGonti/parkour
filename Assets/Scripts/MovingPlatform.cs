using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Av Michal
// Checkpoint = Ett eller flera stället som platformen ska röra sig till/imellan
public class MovingPlatform : MonoBehaviour
{
    public float speed; // Hur snabbt platform rör sig
    public int startingPoint; // Start position där platformen startar
    public Transform[] points; // Positions där platformen ska röra sig till

    private int i;
    void Start()
    {
        transform.position = points[startingPoint].position; // Ställer den till ena positionen med anvädning av "startingPoint"
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f) // Kollar distansen mellan platformen och "checkpoint" där den ska åka till
        {
            i++; // Höjer index
            if (i == points.Length) // Kollar ifall platformen var på sista "checkpoint" innan den höjer index
            {
                i = 0; // Reset av index
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime); // Flyttar platform till checkpoint till positionen med index "i"
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform); // När man hoppar upp på platformen så åker spelaren med platformen (Det blir en child object till platformen)
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null); // När spelaren hoppar av platformen så åker den inte med platformen (Den blir inte längre en child object till platformen)
    }
}
