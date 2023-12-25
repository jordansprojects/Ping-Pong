using Godot;
using System;

public class Ball : KinematicBody2D
{
    private float gravity = 26f;
    public Vector2 velocity = new Vector2(0,0);
    private float minScale = 0.05f; // Minimum scale when Y is at its maximum
    private float maxScale = .5f; // Maximum scale when Y is at its minimum
    private float speedFactor = 0.001f; // Adjust this to control the scaling speed

    float targetX;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
      SimulateServe();
    }


public void SimulateServe(){
  velocity += new Vector2(0,200f);
  MoveAndSlide(velocity);
}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _PhysicsProcess(float delta){

        var motion = velocity * delta;
        MoveAndCollide(motion);

       // Get the current Y coordinate of the ball
        float currentY = Position.y;

        // Calculate the new scale based on the Y coordinate
        float scaleFactor = Mathf.InverseLerp(minScale, maxScale, currentY);
        float newScale = Mathf.Lerp(minScale, maxScale, scaleFactor) * speedFactor;

        // Limit the scale to never exceed 1
        newScale = Mathf.Clamp(newScale, minScale, maxScale);

        // Update the scale of the ball
        Scale = new Vector2(newScale, newScale);

        // Update the scale of the ball
        Scale = new Vector2(newScale, newScale);

         // Move towards the target X-coordinate
      //  Vector2 targetPosition = new Vector2(targetX, Position.y);
       // Position = Position.LinearInterpolate(targetPosition, delta);

       
  }



}
