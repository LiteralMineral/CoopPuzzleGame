using CoopPuzzleGame.PuzzleGeneration;
using System;
using System.Collections.Generic;

public class Location : PuzzleElement
{

	uint _id;
	public uint Id { get { return _id; } }

	List<PuzzleElement> elements;

	public Location(uint id)
	{
		ID = id;
	}

	/*	public ()
		{
			protected Vector<>
	}*/
	public override int CompareTo(PuzzleElement other)
	{
		throw new NotImplementedException();
	}

	public override bool Equals(PuzzleElement other)
	{
		throw new NotImplementedException();
	}
}
