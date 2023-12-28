using Godot;
using System;
using System.Collections.Generic;

// Can block any row, only hits straight
public class PongActorA : CharacterController
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	PongActorA() : base(0){
		// shes gentle so she always hit straight and with not much force :-)
		//strength = 200;
		direction = Vector2.Up;
		
	}

	
	
	public override void PlayMyStyle(){
		direction = hitPoints[2]; //temp
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
	//TODO - block PongActorA to region, she can block
	//any row but needs to be restricted to the bottom

	 List<Vector2> v = new List<Vector2>();
		var v1 = GetNode<Node2D>("../Table/Right/Border2").Position;
		var v2 =GetNode<Node2D>("../Table/Left/Border1").Position;
		regionRect = new Rect2(v2,v1);

	
	}


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
