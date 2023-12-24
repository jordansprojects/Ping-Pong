using Godot;
using System;

// Shoots diagonally, can only block left and right rows
// if he blocks a ball on the right row, the ball will bounce back to the left row

public class PongActorB : CharacterController
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";


    PongActorB() : base(1){
        strength  =40;
        this.SetRow(Row.LEFT);
    }

    public override void PlayMyStyle()
    {
        if(this.GetRow() == Row.MIDDLE){
			// he cannot hit in the middle.
		}
		else if(this.GetRow()== Row.LEFT){
            direction = (Vector2.Up + Vector2.Right);

		}
		else if (this.GetRow()== Row.RIGHT){
            direction = (Vector2.Up + Vector2.Left);

		}
        
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
