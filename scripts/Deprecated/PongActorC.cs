using Godot;
using System;
using System.Collections.Generic;

// Smashes on middle row
// Can only block on middle row, but it "smashes" to any row randomly and makes the ball faster
public class PongActorC : CharacterController
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    RandomNumberGenerator rand;
    List<Vector2> vectors;
    PongActorC() : base(2){
        vectors = new List<Vector2>{Vector2.Up, (Vector2.Up + Vector2.Left), (Vector2.Up + Vector2.Right)};
       // strength = 200;
        direction = Vector2.Up; //this will be adjusted to be random
        rand = new RandomNumberGenerator();

    }

    public override void PlayMyStyle()
    {
         if(this.GetRow() == Row.MIDDLE){
            int index = rand.RandiRange(0,vectors.Count-1);
            var interpolated = vectors[index].LinearInterpolate(hitPoints[2], INTERPOLATE_FACTOR).Normalized();
            direction = interpolated;
           // direction = hitPoints[2]; // middle.
		}
		else if(this.GetRow()== Row.LEFT){
            // he cannot hit in the left
            direction = new Vector2(0,0);

		}
		else if (this.GetRow()== Row.RIGHT){
            // he cannot hit in the right
            direction = new Vector2(0,0);

		}
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        base._Ready();
        List<Vector2> v = new List<Vector2>();
		foreach (Node2D node in GetNode<Node2D>("../Table/Middle").GetChildren()){
			v.Add(node.Position);
		}
		regionRect = new Rect2(v[0], v[1]);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
