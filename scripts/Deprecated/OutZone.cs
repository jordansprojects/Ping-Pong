using Godot;
using System;

public class OutZone : Area2D
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
        if(body is KinematicBody2D kine){
            if(kine is Ball ball){
                GD.Print(this.GetType().Name + ".cs : Ball entered outzone.");
                ball.Destroy();

            }

        }else if(body is RigidBody2D ){
            
        }


    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
