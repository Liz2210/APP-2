using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System;
using System.Data;

namespace SampleHierarchies.Gui;

/// <summary>
/// Settings screen class.
/// </summary>
public sealed class SettingsScreen : Screen
{

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            Console.Clear();
            ScreenDefinionService.Show("SettingsScreen.json", 0);
            ScreenDefinionService.Show("SettingsScreen.json", 1);
            ScreenDefinionService.Show("SettingsScreen.json", 2);
            ScreenDefinionService.Show("SettingsScreen.json", 3);
            ScreenDefinionService.Show("SettingsScreen.json", 4);

            string? choiceAsString = Console.ReadLine();

            // Validate user choice
            try
            {
                if (choiceAsString == null) throw new ArgumentNullException(nameof(choiceAsString));

                int choice = int.Parse(choiceAsString);

                if (choice == 1 || choice == 2) SetLanguage(choice);
                else if(choice == 0) { return; }
            }
            catch
            {
                ScreenDefinionService.Show("SettingsScreen.json", 6);
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    // Method used to set language
    private void SetLanguage(int userChoice)
    {
        try
        {
            if (userChoice == 1) File.WriteAllText("Language.json", "Language: ENG");
            else if (userChoice == 2) File.WriteAllText("Language.json", "Language: PL");
            ScreenDefinionService.Show("SettingsScreen.json", 5);
            Console.ReadLine();
        }
        catch
        {
            ScreenDefinionService.Show("SettingsScreen.json", 6);
        }
    }

    #endregion // Private Methods
}