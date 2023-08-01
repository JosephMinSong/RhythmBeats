using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(NotePoolManagerPriority)]
public class NotePoolManager : MonoBehaviour
{
    public GameObject notePrefab;
    public int poolSize = 10;

    private List<GameObject> notePool = new List<GameObject>();
    
    private const int NotePoolManagerPriority = -100;

    // Initialize the note pool
    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject note = Instantiate(notePrefab);
            note.SetActive(false);
            notePool.Add(note);
        }
    }

    // Method to get a note from the pool and initialize it with position, speed, and color
    public void GetNoteFromPool(Vector2 position, float noteSpeed, Color color, KeyCode keyToPress)
    {
        // Find an inactive note in the pool
        GameObject note = notePool.Find(n => !n.activeInHierarchy);

        if (note == null)
        {
            // If no inactive note is found, create a new one
            note = Instantiate(notePrefab);
            notePool.Add(note);
        }

        // Activate the note and set its position
        note.SetActive(true);
        note.transform.position = position;

        // Get the NoteObject component from the note and initialize it with the provided color
        NoteObject noteObject = note.GetComponent<NoteObject>();
        noteObject.Initialize(position, noteSpeed, color, keyToPress);
    }
}