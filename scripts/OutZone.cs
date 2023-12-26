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

        if (body is KinematicBody2D ball){

            
            // bounce back into the zone
            

        }



    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
