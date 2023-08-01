using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NotePattern
{
    public float timeDelay; // Time delay before generating the note
    public Color noteColor; // Color of the note
    public Vector2 spawnPosition; // Position of the note on the screen
    public KeyCode keyToPress;
}

[DefaultExecutionOrder(NoteGeneratorPriority)]
public class NoteGenerator : MonoBehaviour
{
    public GameObject notePrefab; // Reference to the note prefab
    public float noteSpeed = 5f; // Speed at which notes move down the screen

    public NotePattern[] customNotePattern; // Custom note pattern defined in the Inspector

    private NotePoolManager poolManager; // Reference to the NotePoolManager script
    private int currentNoteIndex = 0; // Index to keep track of the current note in the pattern

    private const int NoteGeneratorPriority = -90;

    private void Start()
    {
        // Get a reference to the NotePoolManager script
        poolManager = GetComponent<NotePoolManager>();

        // Start generating notes based on the custom note pattern
        if (customNotePattern.Length > 0)
        {
            GenerateNoteFromPattern();
        }
    }

    private void GenerateNoteFromPattern()
    {
        if (currentNoteIndex < customNotePattern.Length)
        {
            // Get the current note properties from the custom note pattern
            NotePattern currentNote = customNotePattern[currentNoteIndex];

            // Get a note from the pool and initialize it with the custom properties
            poolManager.GetNoteFromPool(currentNote.spawnPosition, noteSpeed, currentNote.noteColor, currentNote.keyToPress);

            // Move to the next note in the pattern
            currentNoteIndex++;

            // Schedule the next note generation based on the time delay defined in the pattern
            Invoke("GenerateNoteFromPattern", currentNote.timeDelay);
        }
    }
}