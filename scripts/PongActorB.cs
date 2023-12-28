using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

// Shoots diagonally, can only block left and right rows
// if he blocks a ball on the right row, the ball will bounce back to the left row

public class PongActorB : CharacterController
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";


	PongActorB() : base(1){
		//strength  =150;
		this.SetRow(Row.LEFT);
	}

	public override void PlayMyStyle()
	{
		if(this.GetRow() == Row.MIDDLE){
			// he cannot hit in the middle.
			direction = new Vector2(0,0);
		}
		else if(this.GetRow()== Row.LEFT){
		   // var v = Vector2.Up  + Vector2.Right;
		   // var interpolated = v.LinearInterpolate(Vector2.Up, INTERPOLATE_FACTOR).Normalized();
			direction = hitPoints[1]; //TOPR

		}
		else if (this.GetRow()== Row.RIGHT){
			//var v = Vector2.Up  + Vector2.Left;
			//var interpolated = v.LinearInterpolate(hitPoints[0], INTERPOLATE_FACTOR).Normalized();
			direction = hitPoints[0]; // TOPL Node

		}
		
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
	   base._Ready();
       List<Vector2> v = new List<Vector2>();
		foreach (Node2D node in GetNode<Node2D>("../Table/Left").GetChildren()){
			v.Add(node.Position);
		}
		regionRect = new Rect2(v[0], v[1]);

        //TODO - change PongActorBs region depending upon which side hes on
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
