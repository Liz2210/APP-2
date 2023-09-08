using Newtonsoft.Json;
using SampleHierarchies.Data;
using System.Runtime.CompilerServices;

namespace SampleHierarchies.Services;

/// <summary>
/// Screen Definion Service.
/// </summary>
/// 
public static class ScreenDefinionService
{
    #region ScreenDefinionService Implementation 

    // Used to show text and load settings from json
    public static void Show(string jsonPath, int lineNumber, params string[] args)
    {
        try
        {
            if (!File.Exists("Language.json")) File.WriteAllText("Language.json", "Language: ENG");
            string? language = File.ReadAllText("Language.json");
            ScreenDefinition? screenDefinition = Read(jsonPath);

            if (screenDefinition == null) { throw new ArgumentNullException(nameof(screenDefinition)); }
            if (lineNumber > screenDefinition.LineEntries.Count) { throw new OverflowException(nameof(lineNumber)); }

            List<ScreenLineEntry> lines = new List<ScreenLineEntry>();

            if (language != "Language: PL") lines = screenDefinition.LineEntries;
            else lines = screenDefinition.LineEntriesPL;


            Console.BackgroundColor = lines[lineNumber].BackgroundColor;
            Console.ForegroundColor = lines[lineNumber].ForegroundColor;

            if (args.Length == 0)
            {
                Console.WriteLine(lines[lineNumber].Text);
            }
            else if (args.Length == 1)
            {
                string? line = lines[lineNumber].Text;
                string? result = line?.Replace("arg", args[0].ToString());
                Console.WriteLine(result);
            }
            else if (args.Length == 3)
            {
                string? line = lines[lineNumber].Text;
                string? result = line?.Replace("arg", args[0].ToString());
                result = line?.Replace("arg1", args[1].ToString());
                result = line?.Replace("arg2", args[2].ToString());
                Console.WriteLine(result);
            }
            Console.ResetColor();
        }
        catch
        {
            Console.ResetColor();
            Console.WriteLine("Error while reading json");
        }
    }

    /// Used to read json
    public static ScreenDefinition? Read(string jsonPath)
    {
        try
        {
            if (jsonPath is null) throw new ArgumentNullException(nameof(jsonPath));
            string jsonSource = File.ReadAllText(jsonPath);
            var jsonContent = JsonConvert.DeserializeObject<ScreenDefinition>(jsonSource);
            if (jsonContent == null) throw new ArgumentNullException(nameof(jsonContent));
            return jsonContent;
        }
        catch
        {
            Console.WriteLine("Error while reading json");
            return null;
        }
    }
    
    /// Used to write json
    public static void Write(ScreenDefinition settings, string jsonPath)
    {
        try
        {
            if (jsonPath is null) throw new ArgumentNullException(nameof(jsonPath));
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(settings));
            Console.WriteLine("Data saving to: '{0}' was successful.", jsonPath);
        }
        catch
        {
            Console.WriteLine("Error while writting json.");
        }
    }
    #endregion // ScreenDefinionService Implementation
}