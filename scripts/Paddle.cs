using Godot;
using System;

public class Paddle : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    
    private CharacterController actor; 
    public override void _Ready(){
        actor = GetParent() as CharacterController;
         Connect("body_entered", this, "_OnBodyEntered");

        
    }

    private void _OnBodyEntered(Node body){
        int appliedStrength = actor.strength;
        var direction = actor.direction;
        if (body is KinematicBody2D ball){

             if (Input.IsActionPressed("ui_select") || Input.IsActionJustReleased("ui_select")){
                GD.Print(this.GetType().Name + ".cs Ball hit!");
             }else{
                direction = Vector2.Down; // ball falls down if you fail to click
                appliedStrength = 50;
             }
            
            GD.Print(this.GetType().Name + ".cs: Hitting ball with " + appliedStrength + "force in the direction of " 
            +direction);

            Ball data = (Ball) ball;
            var motion = (data.velocity + (appliedStrength*direction) );
            ball.MoveAndCollide(motion);

            
            



        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
