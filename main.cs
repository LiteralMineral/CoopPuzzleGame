using CoopPuzzleGame.PuzzleGenerationTakeTwo;
using Godot;
using Godot.Collections;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;


public partial class main : Node2D
{
	


	// Called when the node enters the scene tree for the first time.

	private Sprite2D bluestar2;
	public override void _Ready()
	{
		bluestar2 = new Sprite2D();
		AddChild(bluestar2);
		GD.Print("hello");
		Console.WriteLine("hello, Visual Studio");


		bluestar2.Texture = new Texture2D();
		bluestar2.Texture = (Texture2D) GD.Load<Texture>("res://bluestar.svg");
		bluestar2.Position = new Vector2(57.3f, 83.7f);
		bluestar2.Scale = new Vector2(0.5f, 0.5f);

        //float[][] _starPosits = Enumerable
        //.Range(0, 15)
        //.Select(i => new float[5])
        //.ToArray();



        //string dictionaryPath = Path.Combine(System.Environment.CurrentDirectory, "GameData/obstacle_compendium.json");

        /*
                Dictionary<string, Dictionary<string, byte>> obstacles = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, byte>>>(File.ReadAllText(dictionaryPath));
                GD.Print(Convert.ToString(obstacles["obstacle_category_4"]["obstacle_option_2"],8));
        */


        //Dictionary<byte, Dictionary<byte, string>> obstacles = JsonConvert.DeserializeObject<Dictionary<byte, Dictionary<byte, string>>>(File.ReadAllText(dictionaryPath));
        //GD.Print(Convert.ToString(obstacles["obstacle_category_4"]["obstacle_option_2"], 8));

        //bluestar2.Scale = new Vector2(0.5f, 0.5f);

        ObstacleCode2 demo = new ObstacleCode2();

        byte test = ObstacleCode2.StringToCodeMap["Terrain_5"];
        //GD.Print(test);
        bluestar2.Scale = new Vector2(0.5f, 0.5f);

        /*
                Dictionary<String, Dictionary<string, byte>> availableObstacles = new Dictionary<string, Dictionary<string, byte>>();
                for (int i = 0; i < 8; i++)
                {
                    string categoryName = $"obstacle_category_{i}";
                    availableObstacles.Add(categoryName, new Dictionary<string, byte>());
                    for (int j = 0; j < 8; j++)
                    {
                        availableObstacles[categoryName].Add($"obstacle_option_{j}", (byte)((i << 3) | j));
                    }
                }
                string obstacleCompendium = JsonConvert.SerializeObject(availableObstacles, Formatting.Indented);
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(System.Environment.CurrentDirectory, "PuzzleGenerationTakeTwo/obstacle_compendium.json"), false))
                {
                    outputFile.Write(obstacleCompendium);
                }
        */



        #region TestingObstacleCodes

        #endregion



        /*
        string docPath = System.Environment.CurrentDirectory;
		using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "PuzzleGenerationTakeTwo/obstacles.txt"), false))
		{
			foreach (string s in ObstacleCode2.ObstacleLexicon.ToArray().Select(a => a.Key +"\t" + Convert.ToString(a.Value, 8)))
			{
				outputFile.WriteLine(s);

				//Console.WriteLine(s);
			}
		}
*/



    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{

	}
}
