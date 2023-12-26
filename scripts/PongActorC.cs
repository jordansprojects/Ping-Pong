using Godot;
using System;

// Smashes on middle row
// Can only block on middle row, but it "smashes" to any row randomly and makes the ball faster
public class PongActorC : CharacterController
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";


    PongActorC() : base(2){
        strength = 400;
        direction = Vector2.Up; //this will be adjusted to be random
    }

    public override void PlayMyStyle()
    {
        //throw new NotImplementedException();
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        base._Ready();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
