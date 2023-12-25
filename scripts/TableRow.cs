using Godot;
using System;
using System.Collections.Generic;

public class TableRow : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public Paddle paddle;
    public List<Node2D> borders;
    public int banned;
    public CharacterController.Row row;

    public const float KICK_AMOUNT = 200; // how far the user is kicked out of the region
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        borders = new List<Node2D>();


        var  nodes = GetChildren();
        foreach (var node in nodes){
            borders.Add((Node2D)node);
        }

        Connect("area_entered", this, "_OnAreaEntered");
		//Connect("area_exited", this, "_OnAreaExited");
        
    }
    private void _OnAreaExited(Area2D area){
		if(area.Name == "Handle"){
            if(area.GetParent() is Paddle paddle){
        	    paddle.blocked=false;
		        GD.Print(this.GetType().Name + ".cs Paddle exited.");
            }
        }

	}
	private void _OnAreaEntered(Area2D area){

        if(area.Name == "Handle"){
          
		if(area.GetParent() is Paddle paddle){
        paddle.SetPlayersRow(row);
		GD.Print(this.GetType().Name + ".cs Paddle entered.");
		if(paddle == null){
			GD.Print(this.GetType().Name + ".cs failed to find paddle");

		}
		if(paddle.GetActiveIndex() == banned){
                paddle.blocked = true;
                GD.Print(this.GetType().Name + ".cs Kicking banned pig no. " + banned + " out of region.");
            }else{

                paddle.blocked = false;
            }

        }

        }
		
		
	}


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
