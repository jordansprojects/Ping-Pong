using Godot;
using System;
using System.Collections.Generic;

public class BallMaker : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    List<Node2D> spawnPoints;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        spawnPoints = new List<Node2D>();
        Godot.Collections.Array children = GetChildren();
        foreach(var point in children){
            spawnPoints.Add((Node2D)point);  
        }
        GD.Print(this.GetType().Name + ".cs:" + spawnPoints.Count +  " spawn points added.");
    }

    public void CreateBall(){

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
