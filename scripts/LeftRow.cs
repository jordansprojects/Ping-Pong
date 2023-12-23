using Godot;
using System;

public class LeftRow : TableRow
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        base._Ready();
        
    }

    private void _OnAreaEntered(Area2D obj)
	{
		
		if (obj is Cursor){
			GD.Print(this.GetType().Name + ".cs: cursor entered.");
		}
		
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
