using Godot;
using System;

public class BounceZoneR : BounceZoneL
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Connect("body_entered", this, "_OnBodyEntered");
    }
    private void _OnBodyEntered(Node body){
        float appliedStrength = FORCE ;
        Vector2 direction = Vector2.Left + Vector2.Down; //this may be adjusted to be random between Up and Down;
        GD.Print(this.GetType().Name + ".cs Ball detected.");
        if (body is KinematicBody2D ball){
                GD.Print(this.GetType().Name + ".cs Ball bounced");
                  Ball data = (Ball) ball;
                var motion = (appliedStrength*direction);
                ball.MoveAndCollide(motion);

        }
    }
            
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
