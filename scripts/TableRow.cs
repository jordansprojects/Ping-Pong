using Godot;
using System;

public class TableRow : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        Connect("area_entered", this, "_OnAreaEntered");
        
    }

private void _OnAreaEntered(Area2D obj)
	{
		
		if (obj is Cursor){
			
		}
		
		
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
