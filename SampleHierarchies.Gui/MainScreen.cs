using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private readonly SettingsScreen _settingsScreen;
    /// <summary>
    /// Animals screen.
    /// </summary>
    private readonly AnimalsScreen _animalsScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public MainScreen(
        AnimalsScreen animalsScreen,
        SettingsScreen settingsScreen)
    {
        _settingsScreen = settingsScreen;
        _animalsScreen = animalsScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            Console.Clear();
            ScreenDefinionService.Show("MainScreen.json", 0);
            ScreenDefinionService.Show("MainScreen.json", 1);
            ScreenDefinionService.Show("MainScreen.json", 2);
            ScreenDefinionService.Show("MainScreen.json", 3);
            ScreenDefinionService.Show("MainScreen.json", 4);
            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.Animals:
                        _animalsScreen.Show();
                        break;

                    case MainScreenChoices.Settings:
                        _settingsScreen.Show();
                        break;

                    case MainScreenChoices.Exit:
                        ScreenDefinionService.Show("MainScreen.json", 5);
                        return;
                }
            }
            catch
            {
                ScreenDefinionService.Show("MainScreen.json", 6);
            }
        }
    }

    #endregion // Public Methods
}