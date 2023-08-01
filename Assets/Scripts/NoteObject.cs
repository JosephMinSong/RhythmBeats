using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    // Reference to the SpriteRenderer component
    private SpriteRenderer spriteRenderer;

    // Variables to store note properties
    private Vector2 startPosition;
    private float speed;
    private bool isActive;
    private Color noteColor;
    public bool canBePressed;
    public KeyCode key;

    // Method to initialize a note with color and position
    public void Initialize(Vector2 position, float noteSpeed, Color color, KeyCode keyToPress)
    {
        // Get a reference to the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the key
        key = keyToPress;

        // Set the note's color based on the input
        noteColor = color;
        spriteRenderer.color = noteColor;

        // Set the note's initial position and speed
        startPosition = position;
        speed = noteSpeed;
        isActive = true;

        // Set the note's position to the initial position
        transform.position = startPosition;
    }

    private void Update()
    {
        if (isActive)
        {
            // Move the note based on its speed
            transform.Translate(Vector2.down * speed * Time.deltaTime);

            // Check if the note is out of the screen
            if (transform.position.y < -2f) // Adjust the value based on your screen size
            {
                // Deactivate the note when it goes off the screen
                DeactivateNote();
            }
        }

        if(Input.GetKeyDown(key))
        {
            if(canBePressed)
            {
                DeactivateNote();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = false;
        }
    }

    // Method to deactivate the note and return it to the pool
    private void DeactivateNote()
    {
        isActive = false;
        gameObject.SetActive(false); // Deactivate the GameObject instead of moving it to the starting position
    }
}