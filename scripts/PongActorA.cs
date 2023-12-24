using Godot;
using System;

// Can block any row, only hits straight
public class PongActorA : CharacterController
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	PongActorA() : base(0){
        // shes gentle so she always hit straight and with not much force :-)
		strength = 400;
		direction = Vector2.Up;
    }

	
	
    public override void PlayMyStyle(){
		if(this.GetRow() == Row.MIDDLE){
			
		}
		else if(this.GetRow()== Row.LEFT){

		}
		else if (this.GetRow()== Row.RIGHT){

		}
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
